using System;
using System.Collections.Generic;
using NAudio.Wave;
using NAudio.Wave.SampleProviders;
using UnityEngine;
using Il2CppInterop.Runtime.Injection;
using Assets.Scripts.Actors.Enemies;
using MegabonkAccess.Patches;

namespace MegabonkAccess.Components
{
    /// <summary>
    /// Genera un sonido de alerta de enemigo - onda cuadrada con decay.
    /// </summary>
    public class EnemyAlertSoundGenerator : ISampleProvider
    {
        private readonly WaveFormat waveFormat;
        private double phase;
        private int samplesRemaining;
        private double frequency;
        private float volume;
        private readonly int totalSamples;
        private readonly int sampleRate;

        public WaveFormat WaveFormat => waveFormat;

        public EnemyAlertSoundGenerator(int sampleRate = 44100)
        {
            this.sampleRate = sampleRate;
            waveFormat = WaveFormat.CreateIeeeFloatWaveFormat(sampleRate, 1); // Mono for panning
            totalSamples = (int)(sampleRate * 0.08); // 80ms beep
            samplesRemaining = 0;
            volume = 0.3f;
        }

        /// <summary>
        /// Dispara el sonido con frecuencia y volumen específicos.
        /// </summary>
        public void Play(double freq, float vol)
        {
            frequency = Math.Max(100, Math.Min(2000, freq));
            volume = Math.Max(0, Math.Min(0.5f, vol));
            samplesRemaining = totalSamples;
            phase = 0;
        }

        public bool IsPlaying => samplesRemaining > 0;

        public int Read(float[] buffer, int offset, int count)
        {
            for (int i = 0; i < count; i++)
            {
                if (samplesRemaining > 0)
                {
                    // Progress through the sound (0 to 1)
                    float progress = 1f - (float)samplesRemaining / totalSamples;

                    // Envelope: quick attack, smooth decay
                    float envelope = (float)Math.Exp(-progress * 4);

                    // Square wave with slight softening
                    double squareWave = phase < 0.5 ? 1.0 : -1.0;
                    // Add some triangle to soften
                    double triangleWave = 2.0 * Math.Abs(2.0 * phase - 1.0) - 1.0;
                    double mixedWave = squareWave * 0.6 + triangleWave * 0.4;

                    buffer[offset + i] = (float)(volume * envelope * mixedWave);

                    // Advance phase
                    phase += frequency / sampleRate;
                    if (phase >= 1.0) phase -= 1.0;

                    samplesRemaining--;
                }
                else
                {
                    buffer[offset + i] = 0;
                }
            }
            return count;
        }
    }

    /// <summary>
    /// Representa un canal de audio direccional para enemigos.
    /// </summary>
    public class EnemyAudioChannel : IDisposable
    {
        public WaveOutEvent OutputDevice;
        public EnemyAlertSoundGenerator SoundGenerator;
        public PanningSampleProvider PanProvider;
        public VolumeSampleProvider VolumeProvider;
        public bool IsDisposed;
        public float Pan;

        public void Dispose()
        {
            IsDisposed = true;
            try
            {
                OutputDevice?.Stop();
                OutputDevice?.Dispose();
            }
            catch { }
        }
    }

    /// <summary>
    /// Información de un grupo de enemigos en una dirección.
    /// </summary>
    public class DirectionalEnemyGroup
    {
        public int Count;
        public float ClosestDistance;
        public Vector3 AveragePosition;
        public float Pan; // -1 left, 0 center, 1 right
        public float NextPlayTime;
    }

    /// <summary>
    /// Sistema de audio 3D para enemigos.
    /// Genera sonidos sintéticos direccionales para indicar presencia de enemigos.
    /// Agrupa enemigos por dirección para evitar spam de sonidos.
    /// </summary>
    public class EnemyAudioSystem : MonoBehaviour
    {
        public static EnemyAudioSystem Instance { get; private set; }

        // Configuración
        private float maxDistance = 40f;           // Distancia máxima para detectar enemigos
        private float baseInterval = 0.7f;         // Intervalo base entre beeps (lejos)
        private float minInterval = 0.12f;         // Intervalo mínimo (muy cerca/muchos enemigos)
        private float baseVolume = 0.15f;          // Volumen base (cómodo)

        // Canales de audio por dirección (4 direcciones)
        private Dictionary<int, EnemyAudioChannel> audioChannels = new Dictionary<int, EnemyAudioChannel>();
        private DirectionalEnemyGroup[] directionGroups = new DirectionalEnemyGroup[4];
        // 0 = Forward, 1 = Right, 2 = Back, 3 = Left

        // Referencias
        private Transform playerTransform = null;
        private Transform cameraTransform = null;
        private float nextPlayerSearchTime = 0f;
        private float nextUpdateTime = 0f;
        private float updateInterval = 0.15f; // Actualizar 6-7 veces por segundo

        // Scene tracking
        private string lastSceneName = "";
        private float sceneLoadTime = 0f;
        private float sceneStartDelay = 4f;

        private bool isInitialized = false;

        static EnemyAudioSystem()
        {
            ClassInjector.RegisterTypeInIl2Cpp<EnemyAudioSystem>();
        }

        void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(gameObject);
                return;
            }
            Instance = this;
            DontDestroyOnLoad(gameObject);

            // Inicializar grupos direccionales
            for (int i = 0; i < 4; i++)
            {
                directionGroups[i] = new DirectionalEnemyGroup();
            }

            Plugin.Log.LogInfo("[EnemyAudio] Initialized - directional enemy audio system");
        }

        void Start()
        {
            InitializeAudioChannels();
        }

        private void InitializeAudioChannels()
        {
            try
            {
                // Crear 4 canales de audio (uno por dirección)
                for (int i = 0; i < 4; i++)
                {
                    CreateAudioChannel(i);
                }
                isInitialized = true;
                Plugin.Log.LogInfo("[EnemyAudio] Audio channels initialized");
            }
            catch (Exception e)
            {
                Plugin.Log.LogError($"[EnemyAudio] Failed to initialize: {e.Message}");
            }
        }

        private void CreateAudioChannel(int directionIndex)
        {
            try
            {
                var generator = new EnemyAlertSoundGenerator();
                var panProvider = new PanningSampleProvider(generator);
                var volumeProvider = new VolumeSampleProvider(panProvider) { Volume = baseVolume };

                var outputDevice = new WaveOutEvent();
                outputDevice.Init(volumeProvider);
                outputDevice.Play(); // Mantener reproduciendo (el generador controla si hay sonido)

                var channel = new EnemyAudioChannel
                {
                    OutputDevice = outputDevice,
                    SoundGenerator = generator,
                    PanProvider = panProvider,
                    VolumeProvider = volumeProvider,
                    IsDisposed = false,
                    Pan = 0
                };

                audioChannels[directionIndex] = channel;
            }
            catch (Exception e)
            {
                Plugin.Log.LogError($"[EnemyAudio] CreateAudioChannel error: {e.Message}");
            }
        }

        void Update()
        {
            try
            {
                CheckSceneChange();

                if (!isInitialized) return;
                if (IsMenuScene()) return;
                if (IsMenuOpen()) return;
                if (Time.time - sceneLoadTime < sceneStartDelay) return;

                // Buscar jugador
                if (Time.time >= nextPlayerSearchTime)
                {
                    FindPlayer();
                    nextPlayerSearchTime = Time.time + 2f;
                }

                if (playerTransform == null || cameraTransform == null) return;

                // Actualizar grupos de enemigos
                if (Time.time >= nextUpdateTime)
                {
                    UpdateEnemyGroups();
                    nextUpdateTime = Time.time + updateInterval;
                }

                // Reproducir sonidos para cada dirección
                PlayDirectionalSounds();
            }
            catch (Exception e)
            {
                Plugin.Log.LogDebug($"[EnemyAudio] Update error: {e.Message}");
            }
        }

        private void UpdateEnemyGroups()
        {
            // Resetear grupos
            for (int i = 0; i < 4; i++)
            {
                directionGroups[i].Count = 0;
                directionGroups[i].ClosestDistance = float.MaxValue;
                directionGroups[i].AveragePosition = Vector3.zero;
            }

            Vector3 playerPos = playerTransform.position;
            Vector3 forward = cameraTransform.forward;
            forward.y = 0;
            forward.Normalize();

            Vector3 right = Vector3.Cross(Vector3.up, forward).normalized;

            // Obtener enemigos del tracker
            foreach (var enemy in EnemyTracker.GetActiveEnemies())
            {
                try
                {
                    if (enemy == null || enemy.IsDead()) continue;

                    Vector3 enemyPos = enemy.GetCenterPosition();
                    float distance = Vector3.Distance(playerPos, enemyPos);

                    if (distance > maxDistance) continue;

                    // Calcular dirección
                    Vector3 toEnemy = (enemyPos - playerPos);
                    toEnemy.y = 0;
                    toEnemy.Normalize();

                    float angle = Vector3.SignedAngle(forward, toEnemy, Vector3.up);
                    int dirIndex = GetDirectionIndex(angle);

                    // Actualizar grupo
                    var group = directionGroups[dirIndex];
                    group.Count++;
                    group.AveragePosition += enemyPos;
                    if (distance < group.ClosestDistance)
                    {
                        group.ClosestDistance = distance;
                    }
                }
                catch { }
            }

            // Calcular posición promedio y pan para cada grupo
            for (int i = 0; i < 4; i++)
            {
                var group = directionGroups[i];
                if (group.Count > 0)
                {
                    group.AveragePosition /= group.Count;

                    // Calcular pan basado en la dirección
                    Vector3 toGroup = (group.AveragePosition - playerPos);
                    toGroup.y = 0;
                    toGroup.Normalize();

                    // Pan: proyección en el eje derecho
                    group.Pan = Vector3.Dot(toGroup, right);
                    group.Pan = Mathf.Clamp(group.Pan, -1f, 1f);
                }
            }
        }

        private int GetDirectionIndex(float angle)
        {
            // 0 = Forward (-45 to 45)
            // 1 = Right (45 to 135)
            // 2 = Back (135 to 180 or -135 to -180)
            // 3 = Left (-45 to -135)

            if (angle >= -45 && angle < 45) return 0;  // Forward
            if (angle >= 45 && angle < 135) return 1;  // Right
            if (angle < -45 && angle >= -135) return 3; // Left
            return 2; // Back
        }

        private void PlayDirectionalSounds()
        {
            float currentTime = Time.time;

            for (int i = 0; i < 4; i++)
            {
                var group = directionGroups[i];
                if (group.Count == 0) continue;

                // Calcular intervalo basado en cantidad de enemigos y distancia
                float proximityFactor = 1f - (group.ClosestDistance / maxDistance);
                proximityFactor = Mathf.Clamp01(proximityFactor);
                proximityFactor = proximityFactor * proximityFactor; // Curva cuadrática

                // Más enemigos = intervalo más corto
                float countFactor = Mathf.Clamp01(group.Count / 10f);

                // Intervalo final
                float interval = Mathf.Lerp(baseInterval, minInterval, Mathf.Max(proximityFactor, countFactor));

                if (currentTime >= group.NextPlayTime)
                {
                    PlaySound(i, group);
                    group.NextPlayTime = currentTime + interval;
                }
            }
        }

        private void PlaySound(int directionIndex, DirectionalEnemyGroup group)
        {
            if (!audioChannels.TryGetValue(directionIndex, out var channel)) return;
            if (channel.IsDisposed) return;

            try
            {
                // Calcular parámetros del sonido
                float proximityFactor = 1f - (group.ClosestDistance / maxDistance);
                proximityFactor = Mathf.Clamp01(proximityFactor);

                // Frecuencia: depende de la dirección
                // Atrás (directionIndex == 2): más grave, sube con proximidad
                // Adelante/Lados: pitch normal (400-900 Hz)
                double frequency;
                if (directionIndex == 2) // Atrás
                {
                    // 200 Hz (lejos) a 500 Hz (cerca) - más grave
                    frequency = 200 + (proximityFactor * 300);
                }
                else
                {
                    // 400 Hz (lejos) a 900 Hz (cerca) - normal
                    frequency = 400 + (proximityFactor * 500);
                }

                // Volumen: más alto cuando está más cerca
                // También aumenta ligeramente con la cantidad de enemigos
                float countBoost = Mathf.Clamp01(group.Count / 5f) * 0.12f;
                float volume = (0.2f + proximityFactor * 0.3f + countBoost);
                volume = Mathf.Clamp(volume, 0.15f, 0.5f);

                // Actualizar pan
                channel.PanProvider.Pan = group.Pan;
                channel.VolumeProvider.Volume = volume;

                // Disparar sonido
                channel.SoundGenerator.Play(frequency, volume);
            }
            catch (Exception e)
            {
                Plugin.Log.LogDebug($"[EnemyAudio] PlaySound error: {e.Message}");
            }
        }

        private void CheckSceneChange()
        {
            try
            {
                var currentScene = UnityEngine.SceneManagement.SceneManager.GetActiveScene().name;
                if (!string.IsNullOrEmpty(lastSceneName) && currentScene != lastSceneName)
                {
                    sceneLoadTime = Time.time;
                    // Resetear grupos
                    for (int i = 0; i < 4; i++)
                    {
                        directionGroups[i].Count = 0;
                        directionGroups[i].NextPlayTime = 0;
                    }
                }
                lastSceneName = currentScene;
            }
            catch { }
        }

        private bool IsMenuScene()
        {
            return lastSceneName == "MainMenu" ||
                   lastSceneName == "BootScene" ||
                   lastSceneName == "LoadingScreen" ||
                   lastSceneName.Contains("Menu") ||
                   string.IsNullOrEmpty(lastSceneName);
        }

        private bool IsMenuOpen()
        {
            if (Time.timeScale < 0.1f) return true;

            try
            {
                string[] menuNames = { "PauseMenu", "Pause", "B_Resume", "ChestWindow", "UpgradeButton" };
                foreach (var name in menuNames)
                {
                    var obj = GameObject.Find(name);
                    if (obj != null && obj.activeInHierarchy) return true;
                }
            }
            catch { }

            if (ChestAnimationTracker.IsChestWindowOpen || ChestAnimationTracker.IsChestAnimationPlaying)
                return true;
            if (MenuStateTracker.IsAnyMenuOpen)
                return true;
            if (EncounterMenuTracker.IsEncounterMenuOpen)
                return true;

            return false;
        }

        private void FindPlayer()
        {
            try
            {
                string[] playerNames = { "Player", "Character", "PlayerCharacter", "Hero" };
                foreach (var name in playerNames)
                {
                    var obj = GameObject.Find(name);
                    if (obj != null && !obj.name.Contains("Camera"))
                    {
                        playerTransform = obj.transform;
                        break;
                    }
                }

                var cam = Camera.main;
                if (cam != null)
                {
                    cameraTransform = cam.transform;
                    if (playerTransform == null)
                        playerTransform = cam.transform;
                }
            }
            catch { }
        }

        /// <summary>
        /// Obtiene información sobre enemigos en cada dirección (para UI/debug).
        /// </summary>
        public string GetEnemyStatusText()
        {
            var parts = new List<string>();
            string[] dirNames = { "Adelante", "Derecha", "Atrás", "Izquierda" };

            for (int i = 0; i < 4; i++)
            {
                if (directionGroups[i].Count > 0)
                {
                    parts.Add($"{directionGroups[i].Count} {dirNames[i]}");
                }
            }

            return parts.Count > 0 ? string.Join(", ", parts) : "Sin enemigos";
        }

        /// <summary>
        /// Obtiene el total de enemigos cercanos.
        /// </summary>
        public int GetTotalNearbyEnemies()
        {
            int total = 0;
            for (int i = 0; i < 4; i++)
            {
                total += directionGroups[i].Count;
            }
            return total;
        }

        void OnDestroy()
        {
            foreach (var channel in audioChannels.Values)
            {
                channel?.Dispose();
            }
            audioChannels.Clear();
            Instance = null;
            Plugin.Log.LogInfo("[EnemyAudio] Destroyed");
        }
    }
}
