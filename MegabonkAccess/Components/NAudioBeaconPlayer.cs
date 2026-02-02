using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using NAudio.Wave;
using NAudio.Wave.SampleProviders;
using UnityEngine;

namespace MegabonkAccess.Components
{
    /// <summary>
    /// Tipos de comportamiento de audio
    /// </summary>
    public enum AudioBehavior
    {
        Beacon,  // Sin loop, intervalo dinámico, pitch dinámico, pan 3D
        Ambient  // Loop continuo, solo pan 3D (sin pitch ni intervalo)
    }

    /// <summary>
    /// Sample provider que cambia el pitch mediante resampling.
    /// Pitch > 1 = más agudo y rápido, Pitch < 1 = más grave y lento.
    /// </summary>
    public class PitchShiftingSampleProvider : ISampleProvider
    {
        private readonly ISampleProvider source;
        private readonly float pitch;
        private float position;

        public WaveFormat WaveFormat => source.WaveFormat;

        public PitchShiftingSampleProvider(ISampleProvider source, float pitch)
        {
            this.source = source;
            this.pitch = Math.Max(0.5f, Math.Min(2.0f, pitch));
            this.position = 0;
        }

        public int Read(float[] buffer, int offset, int count)
        {
            int sourceSamplesNeeded = (int)(count * pitch) + 2;
            float[] sourceBuffer = new float[sourceSamplesNeeded];

            int sourceSamplesRead = source.Read(sourceBuffer, 0, sourceSamplesNeeded);
            if (sourceSamplesRead == 0) return 0;

            int outputSamples = 0;
            while (outputSamples < count && position < sourceSamplesRead - 1)
            {
                int index = (int)position;
                float fraction = position - index;

                if (index + 1 < sourceSamplesRead)
                {
                    buffer[offset + outputSamples] = sourceBuffer[index] * (1 - fraction) +
                                                      sourceBuffer[index + 1] * fraction;
                    outputSamples++;
                }

                position += pitch;
            }

            position -= (int)position;
            return outputSamples;
        }
    }


    /// <summary>
    /// Datos de un sonido ambient con loop
    /// </summary>
    public class AmbientSoundData : IDisposable
    {
        public WaveOutEvent OutputDevice;
        public AudioFileReader Reader;
        public VolumeSampleProvider VolumeProvider;
        public PanningSampleProvider PanProvider;
        public string SoundType;
        public int TargetId;
        public bool IsDisposed;

        public void Dispose()
        {
            IsDisposed = true;
            try
            {
                OutputDevice?.Stop();
                OutputDevice?.Dispose();
                Reader?.Dispose();
            }
            catch { }
        }
    }

    /// <summary>
    /// Reproductor de audio 3D usando NAudio.
    /// Soporta múltiples sonidos y comportamientos (beacon vs ambient loop).
    /// </summary>
    public class NAudioBeaconPlayer : IDisposable
    {
        private static NAudioBeaconPlayer _instance;
        public static NAudioBeaconPlayer Instance => _instance ??= new NAudioBeaconPlayer();

        private readonly string soundsPath;
        private Dictionary<string, string> soundFiles = new Dictionary<string, string>();
        private bool isInitialized = false;
        private readonly object playLock = new object();

        // Pool de reproductores para sonidos beacon (one-shot)
        private const int MaxConcurrentSounds = 12;
        private WaveOutEvent[] outputDevices;
        private IDisposable[] activeReaders;
        private int nextDeviceIndex = 0;

        // Ambient sounds (loop) - uno por objeto
        private Dictionary<int, AmbientSoundData> ambientSounds = new Dictionary<int, AmbientSoundData>();
        private readonly object ambientLock = new object();

        private NAudioBeaconPlayer()
        {
            var pluginPath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            soundsPath = Path.Combine(pluginPath, "sounds");

            Plugin.Log.LogInfo($"[NAudioBeacon] Sounds path: {soundsPath}");

            Initialize();
        }

        private void Initialize()
        {
            try
            {
                // Cargar todos los archivos de sonido disponibles
                LoadSoundFiles();

                // Inicializar pool de dispositivos de salida para beacon sounds
                outputDevices = new WaveOutEvent[MaxConcurrentSounds];
                activeReaders = new IDisposable[MaxConcurrentSounds];

                isInitialized = true;
                Plugin.Log.LogInfo($"[NAudioBeacon] Initialized with {soundFiles.Count} sound files");
            }
            catch (Exception e)
            {
                Plugin.Log.LogError($"[NAudioBeacon] Initialize error: {e.Message}");
            }
        }

        private void LoadSoundFiles()
        {
            // Mapeo de tipo -> archivo de sonido
            var soundMappings = new Dictionary<string, string[]>
            {
                // Portales (ambient loop)
                { "portal", new[] { "portal.mp3", "portal.wav" } },

                // Shrines (beacon)
                { "shrine", new[] { "shrines.mp3", "shrines.wav", "shrine.mp3", "shrine.wav" } },

                // Cofres (beacon)
                { "chest", new[] { "chests.mp3", "chests.wav", "chest.mp3", "chest.wav" } },

                // NPCs especiales
                { "boombox", new[] { "boombox.mp3", "boombox.wav" } },
                { "microwave", new[] { "microwave.mp3", "microwave.wav" } },

                // Fallback
                { "default", new[] { "beacon.wav", "beacon.mp3" } }
            };

            foreach (var mapping in soundMappings)
            {
                foreach (var filename in mapping.Value)
                {
                    string fullPath = Path.Combine(soundsPath, filename);
                    if (File.Exists(fullPath))
                    {
                        soundFiles[mapping.Key] = fullPath;
                        Plugin.Log.LogInfo($"[NAudioBeacon] Loaded sound: {mapping.Key} -> {filename}");
                        break;
                    }
                }
            }

            // Asegurar que tenemos al menos el default
            if (!soundFiles.ContainsKey("default"))
            {
                Plugin.Log.LogError("[NAudioBeacon] No default sound file found!");
            }
        }

        /// <summary>
        /// Obtiene el archivo de sonido para un tipo dado
        /// </summary>
        public string GetSoundFile(string type)
        {
            if (soundFiles.TryGetValue(type, out string path))
                return path;
            if (soundFiles.TryGetValue("default", out string defaultPath))
                return defaultPath;
            return null;
        }

        /// <summary>
        /// Determina el comportamiento de audio para un tipo
        /// </summary>
        public static AudioBehavior GetBehavior(string type)
        {
            switch (type)
            {
                case "portal":
                case "boombox":
                case "microwave":
                    return AudioBehavior.Ambient;
                default:
                    return AudioBehavior.Beacon;
            }
        }

        /// <summary>
        /// Reproduce un sonido beacon (one-shot con pitch/volumen dinámico)
        /// </summary>
        public void PlayBeacon(Vector3 listenerPos, Vector3 listenerForward, Vector3 targetPos,
            float maxDistance, string soundType, float baseVolume = 0.7f, float basePitch = 1.0f)
        {
            if (!isInitialized) return;

            try
            {
                Vector3 toTarget = targetPos - listenerPos;
                float distance = toTarget.magnitude;

                if (distance > maxDistance) return;

                float linearProximity = 1.0f - (distance / maxDistance);
                linearProximity = Mathf.Clamp01(linearProximity);
                float proximity = linearProximity * linearProximity;

                // Volumen: 0.1 (lejos) hasta 1.0 (cerca)
                float volumeMultiplier = 0.1f + (proximity * 0.9f);
                float finalVolume = baseVolume * volumeMultiplier;

                // Pitch: 0.6x (lejos) hasta 1.6x (cerca)
                float pitchMultiplier = 0.6f + (proximity * 1.0f);
                float finalPitch = basePitch * pitchMultiplier;

                // Pan
                float pan = CalculatePan(listenerPos, listenerForward, targetPos);

                string soundFile = GetSoundFile(soundType);
                if (soundFile == null) return;

                ThreadPool.QueueUserWorkItem(_ => PlaySoundInternal(soundFile, finalVolume, pan, finalPitch));
            }
            catch (Exception e)
            {
                Plugin.Log.LogDebug($"[NAudioBeacon] PlayBeacon error: {e.Message}");
            }
        }

        /// <summary>
        /// Inicia o actualiza un sonido ambient (loop continuo)
        /// </summary>
        public void UpdateAmbientSound(int targetId, Vector3 listenerPos, Vector3 listenerForward,
            Vector3 targetPos, float maxDistance, string soundType, float baseVolume = 0.7f)
        {
            if (!isInitialized) return;

            try
            {
                Vector3 toTarget = targetPos - listenerPos;
                float distance = toTarget.magnitude;

                // Si está fuera de rango, detener el sonido
                if (distance > maxDistance)
                {
                    StopAmbientSound(targetId);
                    return;
                }

                float linearProximity = 1.0f - (distance / maxDistance);
                linearProximity = Mathf.Clamp01(linearProximity);
                float proximity = linearProximity * linearProximity;

                // Volumen basado en distancia
                float volumeMultiplier = 0.1f + (proximity * 0.9f);
                float finalVolume = baseVolume * volumeMultiplier;

                // Pan
                float pan = CalculatePan(listenerPos, listenerForward, targetPos);

                lock (ambientLock)
                {
                    if (ambientSounds.TryGetValue(targetId, out var ambient))
                    {
                        // Actualizar volumen y pan del sonido existente (loop continuo)
                        if (ambient.VolumeProvider != null)
                            ambient.VolumeProvider.Volume = finalVolume;
                        if (ambient.PanProvider != null)
                            ambient.PanProvider.Pan = pan;
                    }
                    else
                    {
                        // Crear nuevo sonido ambient
                        string soundFile = GetSoundFile(soundType);
                        if (soundFile == null) return;

                        ThreadPool.QueueUserWorkItem(_ => CreateAmbientSound(targetId, soundFile, soundType, finalVolume, pan));
                    }
                }
            }
            catch (Exception e)
            {
                Plugin.Log.LogDebug($"[NAudioBeacon] UpdateAmbientSound error: {e.Message}");
            }
        }

        /// <summary>
        /// Detiene un sonido ambient
        /// </summary>
        public void StopAmbientSound(int targetId)
        {
            lock (ambientLock)
            {
                if (ambientSounds.TryGetValue(targetId, out var ambient))
                {
                    ambient.Dispose();
                    ambientSounds.Remove(targetId);
                    Plugin.Log.LogDebug($"[NAudioBeacon] Stopped ambient sound for {targetId}");
                }
            }
        }

        /// <summary>
        /// Detiene todos los sonidos ambient
        /// </summary>
        public void StopAllAmbientSounds()
        {
            lock (ambientLock)
            {
                foreach (var ambient in ambientSounds.Values)
                {
                    ambient.Dispose();
                }
                ambientSounds.Clear();
                Plugin.Log.LogInfo("[NAudioBeacon] Stopped all ambient sounds");
            }
        }

        private float CalculatePan(Vector3 listenerPos, Vector3 listenerForward, Vector3 targetPos)
        {
            Vector3 toTarget = targetPos - listenerPos;
            // Cross(up, forward) da el vector LEFT, lo invertimos para RIGHT
            Vector3 listenerRight = Vector3.Cross(Vector3.up, listenerForward).normalized;
            Vector3 toTargetHorizontal = new Vector3(toTarget.x, 0, toTarget.z).normalized;
            Vector3 rightHorizontal = new Vector3(listenerRight.x, 0, listenerRight.z).normalized;

            float pan = Vector3.Dot(toTargetHorizontal, rightHorizontal);
            pan = Mathf.Sign(pan) * Mathf.Pow(Mathf.Abs(pan), 0.7f);
            return Mathf.Clamp(pan, -1f, 1f);
        }

        /// <summary>
        /// Calcula el intervalo de repetición basado en la distancia.
        /// </summary>
        public static float CalculateInterval(float distance, float maxDistance, float baseInterval)
        {
            float linearProximity = 1.0f - Mathf.Clamp01(distance / maxDistance);
            float proximity = linearProximity * linearProximity;
            float intervalMultiplier = 2.0f - (proximity * 1.85f);
            return baseInterval * Mathf.Max(0.15f, intervalMultiplier);
        }

        private void PlaySoundInternal(string soundFile, float volume, float pan, float pitch)
        {
            lock (playLock)
            {
                try
                {
                    int deviceIndex = nextDeviceIndex;
                    nextDeviceIndex = (nextDeviceIndex + 1) % MaxConcurrentSounds;

                    CleanupDevice(deviceIndex);

                    var reader = new AudioFileReader(soundFile);

                    ISampleProvider monoProvider = reader;
                    if (reader.WaveFormat.Channels == 2)
                    {
                        monoProvider = new StereoToMonoSampleProvider(reader);
                    }

                    ISampleProvider pitchedProvider = monoProvider;
                    if (Math.Abs(pitch - 1.0f) > 0.01f)
                    {
                        pitchedProvider = new PitchShiftingSampleProvider(monoProvider, pitch);
                    }

                    var pannedProvider = new PanningSampleProvider(pitchedProvider)
                    {
                        Pan = pan
                    };

                    var volumeProvider = new VolumeSampleProvider(pannedProvider)
                    {
                        Volume = volume
                    };

                    var waveOut = new WaveOutEvent();
                    waveOut.Init(volumeProvider);
                    waveOut.Play();

                    outputDevices[deviceIndex] = waveOut;
                    activeReaders[deviceIndex] = reader;
                }
                catch (Exception e)
                {
                    Plugin.Log.LogDebug($"[NAudioBeacon] PlaySoundInternal error: {e.Message}");
                }
            }
        }

        private void CreateAmbientSound(int targetId, string soundFile, string soundType, float volume, float pan)
        {
            lock (ambientLock)
            {
                try
                {
                    // Verificar que no existe ya
                    if (ambientSounds.ContainsKey(targetId)) return;

                    var reader = new AudioFileReader(soundFile);

                    // Convertir a mono si es stereo
                    ISampleProvider monoProvider = reader;
                    if (reader.WaveFormat.Channels == 2)
                    {
                        monoProvider = new StereoToMonoSampleProvider(reader);
                    }

                    var panProvider = new PanningSampleProvider(monoProvider)
                    {
                        Pan = pan
                    };

                    var volumeProvider = new VolumeSampleProvider(panProvider)
                    {
                        Volume = volume
                    };

                    var waveOut = new WaveOutEvent();
                    waveOut.Init(volumeProvider);

                    // Crear el data object primero
                    var ambientData = new AmbientSoundData
                    {
                        OutputDevice = waveOut,
                        Reader = reader,
                        VolumeProvider = volumeProvider,
                        PanProvider = panProvider,
                        SoundType = soundType,
                        TargetId = targetId,
                        IsDisposed = false
                    };

                    // Loop: cuando termina, reiniciar (solo si no fue disposed)
                    waveOut.PlaybackStopped += (sender, args) =>
                    {
                        try
                        {
                            if (ambientData.IsDisposed) return;
                            lock (ambientLock)
                            {
                                if (!ambientData.IsDisposed && ambientSounds.ContainsKey(targetId))
                                {
                                    reader.Position = 0;
                                    waveOut.Play();
                                }
                            }
                        }
                        catch { }
                    };

                    waveOut.Play();
                    ambientSounds[targetId] = ambientData;
                    Plugin.Log.LogInfo($"[NAudioBeacon] Created ambient sound: {soundType} for {targetId}");
                }
                catch (Exception e)
                {
                    Plugin.Log.LogError($"[NAudioBeacon] CreateAmbientSound error: {e.Message}");
                }
            }
        }

        private void CleanupDevice(int index)
        {
            try
            {
                if (outputDevices[index] != null)
                {
                    outputDevices[index].Stop();
                    outputDevices[index].Dispose();
                    outputDevices[index] = null;
                }

                if (activeReaders[index] != null)
                {
                    activeReaders[index].Dispose();
                    activeReaders[index] = null;
                }
            }
            catch { }
        }

        public void Dispose()
        {
            try
            {
                // Limpiar beacon sounds
                if (outputDevices != null)
                {
                    for (int i = 0; i < outputDevices.Length; i++)
                    {
                        CleanupDevice(i);
                    }
                }

                // Limpiar ambient sounds
                StopAllAmbientSounds();
            }
            catch { }

            _instance = null;
        }
    }
}
