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
    /// WaveStream que hace loop infinito de un audio.
    /// </summary>
    public class LoopStream : WaveStream
    {
        private readonly WaveStream sourceStream;

        public LoopStream(WaveStream sourceStream)
        {
            this.sourceStream = sourceStream;
        }

        public override WaveFormat WaveFormat => sourceStream.WaveFormat;

        public override long Length => sourceStream.Length;

        public override long Position
        {
            get => sourceStream.Position;
            set => sourceStream.Position = value;
        }

        public override int Read(byte[] buffer, int offset, int count)
        {
            int totalBytesRead = 0;

            while (totalBytesRead < count)
            {
                int bytesRead = sourceStream.Read(buffer, offset + totalBytesRead, count - totalBytesRead);
                if (bytesRead == 0)
                {
                    // Llegamos al final, volver al principio
                    sourceStream.Position = 0;
                }
                else
                {
                    totalBytesRead += bytesRead;
                }
            }

            return totalBytesRead;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                sourceStream?.Dispose();
            }
            base.Dispose(disposing);
        }
    }

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
        public LoopStream LoopStream;  // LoopStream dispone el reader internamente
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
                LoopStream?.Dispose();  // Esto también dispone el AudioFileReader interno
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

                // NPCs especiales (beacon)
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
        /// Solo boss_portal (soundType "portal") usa loop ambient
        /// </summary>
        public static AudioBehavior GetBehavior(string type)
        {
            switch (type)
            {
                case "portal":
                case "shrine":
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
                    Plugin.Log.LogDebug($"[NAudioBeacon] Distance {distance:F0} > max {maxDistance:F0}, stopping ambient {targetId}");
                    StopAmbientSound(targetId, "distance_check");
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
                        // Verificar que el sonido no fue disposed
                        if (ambient.IsDisposed)
                        {
                            // Fue disposed, remover y crear uno nuevo
                            ambientSounds.Remove(targetId);
                            Plugin.Log.LogDebug($"[NAudioBeacon] Removing disposed ambient for {targetId}");
                        }
                        else
                        {
                            // Actualizar volumen y pan del sonido existente (loop continuo)
                            if (ambient.VolumeProvider != null)
                                ambient.VolumeProvider.Volume = finalVolume;
                            if (ambient.PanProvider != null)
                                ambient.PanProvider.Pan = pan;
                            return; // Ya existe y está funcionando
                        }
                    }

                    // Crear nuevo sonido ambient (síncrono para evitar duplicados)
                    string soundFile = GetSoundFile(soundType);
                    if (soundFile == null) return;

                    CreateAmbientSound(targetId, soundFile, soundType, finalVolume, pan);
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
        public void StopAmbientSound(int targetId, string source = "unknown")
        {
            lock (ambientLock)
            {
                if (ambientSounds.TryGetValue(targetId, out var ambient))
                {
                    ambient.Dispose();
                    ambientSounds.Remove(targetId);
                    Plugin.Log.LogInfo($"[NAudioBeacon] STOP ambient {targetId} - source: {source}");
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
                int count = ambientSounds.Count;
                if (count == 0) return;

                foreach (var ambient in ambientSounds.Values)
                {
                    ambient.Dispose();
                }
                ambientSounds.Clear();
                Plugin.Log.LogInfo($"[NAudioBeacon] Stopped all ambient sounds (was {count} sounds)");
            }
        }

        /// <summary>
        /// Pausa todos los sonidos ambient sin destruirlos
        /// </summary>
        public void PauseAllAmbientSounds()
        {
            lock (ambientLock)
            {
                foreach (var ambient in ambientSounds.Values)
                {
                    try
                    {
                        if (!ambient.IsDisposed && ambient.OutputDevice != null)
                        {
                            ambient.OutputDevice.Pause();
                        }
                    }
                    catch { }
                }
            }
        }

        /// <summary>
        /// Reanuda todos los sonidos ambient pausados
        /// </summary>
        public void ResumeAllAmbientSounds()
        {
            lock (ambientLock)
            {
                foreach (var ambient in ambientSounds.Values)
                {
                    try
                    {
                        if (!ambient.IsDisposed && ambient.OutputDevice != null)
                        {
                            ambient.OutputDevice.Play();
                        }
                    }
                    catch { }
                }
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
                    if (ambientSounds.ContainsKey(targetId))
                    {
                        Plugin.Log.LogDebug($"[NAudioBeacon] Ambient sound already exists for {targetId}, skipping creation");
                        return;
                    }

                    Plugin.Log.LogInfo($"[NAudioBeacon] Creating NEW ambient sound: {soundType} for targetId={targetId}");

                    // Crear reader y envolverlo en LoopStream para loop infinito
                    var reader = new AudioFileReader(soundFile);
                    var loopStream = new LoopStream(reader);

                    // Convertir a sample provider
                    var sampleProvider = loopStream.ToSampleProvider();

                    // Convertir a mono si es stereo
                    ISampleProvider monoProvider = sampleProvider;
                    if (loopStream.WaveFormat.Channels == 2)
                    {
                        monoProvider = new StereoToMonoSampleProvider(sampleProvider);
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

                    // Crear el data object
                    var ambientData = new AmbientSoundData
                    {
                        OutputDevice = waveOut,
                        LoopStream = loopStream,  // Almacenar el LoopStream para dispose
                        VolumeProvider = volumeProvider,
                        PanProvider = panProvider,
                        SoundType = soundType,
                        TargetId = targetId,
                        IsDisposed = false
                    };

                    // LoopStream hace el loop automáticamente, no necesitamos PlaybackStopped

                    waveOut.Play();
                    ambientSounds[targetId] = ambientData;
                    Plugin.Log.LogInfo($"[NAudioBeacon] SUCCESS: Ambient sound {soundType} now playing with LOOP for targetId={targetId} (total: {ambientSounds.Count})");
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
