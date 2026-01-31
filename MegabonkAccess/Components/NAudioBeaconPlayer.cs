using System;
using System.IO;
using System.Threading;
using NAudio.Wave;
using NAudio.Wave.SampleProviders;
using UnityEngine;

namespace MegabonkAccess.Components
{
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
            this.pitch = Math.Max(0.5f, Math.Min(2.0f, pitch)); // Limitar entre 0.5x y 2x
            this.position = 0;
        }

        public int Read(float[] buffer, int offset, int count)
        {
            // Calcular cuántos samples necesitamos leer de la fuente
            int sourceSamplesNeeded = (int)(count * pitch) + 2;
            float[] sourceBuffer = new float[sourceSamplesNeeded];

            int sourceSamplesRead = source.Read(sourceBuffer, 0, sourceSamplesNeeded);
            if (sourceSamplesRead == 0) return 0;

            // Interpolar para cambiar el pitch
            int outputSamples = 0;
            while (outputSamples < count && position < sourceSamplesRead - 1)
            {
                int index = (int)position;
                float fraction = position - index;

                if (index + 1 < sourceSamplesRead)
                {
                    // Interpolación lineal
                    buffer[offset + outputSamples] = sourceBuffer[index] * (1 - fraction) +
                                                      sourceBuffer[index + 1] * fraction;
                    outputSamples++;
                }

                position += pitch;
            }

            // Ajustar posición para el próximo read
            position -= (int)position;

            return outputSamples;
        }
    }

    /// <summary>
    /// Reproductor de audio 3D usando NAudio.
    /// Calcula pan, volumen y pitch basado en posición relativa.
    /// </summary>
    public class NAudioBeaconPlayer : IDisposable
    {
        private static NAudioBeaconPlayer _instance;
        public static NAudioBeaconPlayer Instance => _instance ??= new NAudioBeaconPlayer();

        private readonly string soundsPath;
        private string beaconFilePath;
        private bool isInitialized = false;
        private readonly object playLock = new object();

        // Pool de reproductores para evitar crear/destruir constantemente
        private const int MaxConcurrentSounds = 12;
        private WaveOutEvent[] outputDevices;
        private IDisposable[] activeReaders;
        private int nextDeviceIndex = 0;

        private NAudioBeaconPlayer()
        {
            // Buscar la carpeta sounds en la ubicación del plugin
            var pluginPath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            soundsPath = Path.Combine(pluginPath, "sounds");

            Plugin.Log.LogInfo($"[NAudioBeacon] Sounds path: {soundsPath}");

            Initialize();
        }

        private void Initialize()
        {
            try
            {
                beaconFilePath = Path.Combine(soundsPath, "beacon.wav");

                if (!File.Exists(beaconFilePath))
                {
                    Plugin.Log.LogError($"[NAudioBeacon] beacon.wav not found at: {beaconFilePath}");
                    return;
                }

                // Inicializar pool de dispositivos de salida
                outputDevices = new WaveOutEvent[MaxConcurrentSounds];
                activeReaders = new IDisposable[MaxConcurrentSounds];

                isInitialized = true;
                Plugin.Log.LogInfo($"[NAudioBeacon] Initialized successfully. Sound file: {beaconFilePath}");
            }
            catch (Exception e)
            {
                Plugin.Log.LogError($"[NAudioBeacon] Initialize error: {e.Message}");
            }
        }

        /// <summary>
        /// Reproduce el sonido de beacon con audio 3D basado en la posición.
        /// Usa curvas no-lineales para mejor percepción espacial.
        /// </summary>
        public void PlayBeacon(Vector3 listenerPos, Vector3 listenerForward, Vector3 targetPos,
            float maxDistance, float baseVolume = 0.7f, float basePitch = 1.0f)
        {
            if (!isInitialized) return;

            try
            {
                // Calcular dirección y distancia
                Vector3 toTarget = targetPos - listenerPos;
                float distance = toTarget.magnitude;

                if (distance > maxDistance) return;

                // Factor de proximidad lineal (0 = lejos, 1 = muy cerca)
                float linearProximity = 1.0f - (distance / maxDistance);
                linearProximity = Mathf.Clamp01(linearProximity);

                // Curva cuadrática para efectos más dramáticos cerca del objetivo
                float proximity = linearProximity * linearProximity;

                // VOLUMEN: curva agresiva - muy bajo lejos, muy alto cerca
                // Rango: 0.1 (lejos) hasta 1.0 (cerca)
                float volumeMultiplier = 0.1f + (proximity * 0.9f);
                float finalVolume = baseVolume * volumeMultiplier;

                // PITCH: rango amplio para mejor diferenciación
                // Rango: 0.6x (grave, lejos) hasta 1.6x (agudo, cerca)
                float pitchMultiplier = 0.6f + (proximity * 1.0f);
                float finalPitch = basePitch * pitchMultiplier;

                // PAN: calcular con precisión y amplificar
                Vector3 listenerRight = Vector3.Cross(Vector3.up, listenerForward).normalized;
                Vector3 toTargetHorizontal = new Vector3(toTarget.x, 0, toTarget.z).normalized;
                Vector3 rightHorizontal = new Vector3(listenerRight.x, 0, listenerRight.z).normalized;

                float pan = Vector3.Dot(toTargetHorizontal, rightHorizontal);

                // Amplificar el pan para hacerlo más pronunciado
                // Usar curva que exagera valores medios
                pan = Mathf.Sign(pan) * Mathf.Pow(Mathf.Abs(pan), 0.7f);
                pan = Mathf.Clamp(pan, -1f, 1f);

                // Reproducir en un thread separado para no bloquear Unity
                ThreadPool.QueueUserWorkItem(_ => PlaySoundInternal(finalVolume, pan, finalPitch));
            }
            catch (Exception e)
            {
                Plugin.Log.LogDebug($"[NAudioBeacon] PlayBeacon error: {e.Message}");
            }
        }

        /// <summary>
        /// Calcula el intervalo de repetición basado en la distancia.
        /// Más cerca = repetición mucho más rápida (curva cuadrática).
        /// </summary>
        public static float CalculateInterval(float distance, float maxDistance, float baseInterval)
        {
            float linearProximity = 1.0f - Mathf.Clamp01(distance / maxDistance);

            // Curva cuadrática para cambios más dramáticos
            float proximity = linearProximity * linearProximity;

            // Rango: baseInterval * 2.0 (lejos) hasta baseInterval * 0.15 (muy cerca)
            float intervalMultiplier = 2.0f - (proximity * 1.85f);
            return baseInterval * Mathf.Max(0.15f, intervalMultiplier);
        }

        private void PlaySoundInternal(float volume, float pan, float pitch)
        {
            lock (playLock)
            {
                try
                {
                    // Obtener el siguiente dispositivo del pool
                    int deviceIndex = nextDeviceIndex;
                    nextDeviceIndex = (nextDeviceIndex + 1) % MaxConcurrentSounds;

                    // Limpiar dispositivo anterior si existe
                    CleanupDevice(deviceIndex);

                    // Crear nuevo reader del archivo
                    var reader = new AudioFileReader(beaconFilePath);

                    // PanningSampleProvider requiere entrada MONO
                    ISampleProvider monoProvider = reader;
                    if (reader.WaveFormat.Channels == 2)
                    {
                        monoProvider = new StereoToMonoSampleProvider(reader);
                    }

                    // Aplicar pitch shifting
                    ISampleProvider pitchedProvider = monoProvider;
                    if (Math.Abs(pitch - 1.0f) > 0.01f)
                    {
                        pitchedProvider = new PitchShiftingSampleProvider(monoProvider, pitch);
                    }

                    // Aplicar pan (convierte mono a estéreo con pan)
                    var pannedProvider = new PanningSampleProvider(pitchedProvider)
                    {
                        Pan = pan
                    };

                    // Aplicar volumen
                    var volumeProvider = new VolumeSampleProvider(pannedProvider)
                    {
                        Volume = volume
                    };

                    // Crear y configurar el dispositivo de salida
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
                if (outputDevices != null)
                {
                    for (int i = 0; i < outputDevices.Length; i++)
                    {
                        CleanupDevice(i);
                    }
                }
            }
            catch { }

            _instance = null;
        }
    }
}
