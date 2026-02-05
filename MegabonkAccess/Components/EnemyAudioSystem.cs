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
    /// Tipo de enemigo para el sonido.
    /// </summary>
    public enum EnemyType
    {
        Normal,
        Elite,
        Boss
    }

    /// <summary>
    /// Genera sonidos de alerta según el tipo de enemigo.
    /// - Normal: beep agudo corto
    /// - Elite: beep medio con vibrato
    /// - Boss: tono grave largo y potente
    /// </summary>
    public class EnemyAlertSoundGenerator : ISampleProvider
    {
        private readonly WaveFormat waveFormat;
        private double phase;
        private int samplesRemaining;
        private double baseFrequency;
        private float volume;
        private int totalSamples;
        private readonly int sampleRate;
        private EnemyType enemyType;
        private double vibratoPhase;

        public WaveFormat WaveFormat => waveFormat;

        public EnemyAlertSoundGenerator(int sampleRate = 44100)
        {
            this.sampleRate = sampleRate;
            waveFormat = WaveFormat.CreateIeeeFloatWaveFormat(sampleRate, 1);
            samplesRemaining = 0;
            volume = 0.3f;
        }

        /// <summary>
        /// Dispara el sonido con parámetros según tipo de enemigo.
        /// </summary>
        public void Play(double freq, float vol, EnemyType type)
        {
            baseFrequency = Math.Max(50, Math.Min(2000, freq));
            volume = Math.Max(0, Math.Min(0.9f, vol));
            enemyType = type;
            vibratoPhase = 0;
            phase = 0;

            // Duración según tipo
            switch (type)
            {
                case EnemyType.Boss:
                    totalSamples = (int)(sampleRate * 0.25); // 250ms - largo y amenazante
                    break;
                case EnemyType.Elite:
                    totalSamples = (int)(sampleRate * 0.12); // 120ms - medio
                    break;
                default:
                    totalSamples = (int)(sampleRate * 0.06); // 60ms - corto
                    break;
            }
            samplesRemaining = totalSamples;
        }

        public bool IsPlaying => samplesRemaining > 0;

        public int Read(float[] buffer, int offset, int count)
        {
            for (int i = 0; i < count; i++)
            {
                if (samplesRemaining > 0)
                {
                    float progress = 1f - (float)samplesRemaining / totalSamples;
                    float sample = GenerateSample(progress);
                    buffer[offset + i] = sample;
                    samplesRemaining--;
                }
                else
                {
                    buffer[offset + i] = 0;
                }
            }
            return count;
        }

        private float GenerateSample(float progress)
        {
            double frequency = baseFrequency;
            float envelope;
            double waveform;

            switch (enemyType)
            {
                case EnemyType.Boss:
                    // Boss: onda grave con descenso de pitch, muy potente
                    frequency = baseFrequency * (1.0 - progress * 0.3); // Desciende 30%
                    envelope = (float)(Math.Exp(-progress * 2.5) * (1.0 - progress * 0.3));

                    // Onda cuadrada grave con armónicos
                    double square = phase < 0.5 ? 1.0 : -1.0;
                    double subBass = Math.Sin(2.0 * Math.PI * phase * 0.5); // Sub-octava
                    waveform = square * 0.6 + subBass * 0.4;
                    break;

                case EnemyType.Elite:
                    // Elite: vibrato distintivo
                    vibratoPhase += 12.0 / sampleRate; // 12 Hz vibrato
                    double vibrato = Math.Sin(2.0 * Math.PI * vibratoPhase) * 0.15;
                    frequency = baseFrequency * (1.0 + vibrato);
                    envelope = (float)Math.Exp(-progress * 3.5);

                    // Onda triangular con algo de cuadrada
                    double triangle = 2.0 * Math.Abs(2.0 * phase - 1.0) - 1.0;
                    double squareWave = phase < 0.5 ? 1.0 : -1.0;
                    waveform = triangle * 0.7 + squareWave * 0.3;
                    break;

                default: // Normal
                    envelope = (float)Math.Exp(-progress * 5);

                    // Beep simple y corto
                    double tri = 2.0 * Math.Abs(2.0 * phase - 1.0) - 1.0;
                    double sq = phase < 0.5 ? 1.0 : -1.0;
                    waveform = tri * 0.5 + sq * 0.5;
                    break;
            }

            // Avanzar fase
            phase += frequency / sampleRate;
            if (phase >= 1.0) phase -= 1.0;

            return (float)(volume * envelope * waveform);
        }
    }

    /// <summary>
    /// Canal de audio para enemigos.
    /// </summary>
    public class EnemyAudioChannel : IDisposable
    {
        public WaveOutEvent OutputDevice;
        public EnemyAlertSoundGenerator SoundGenerator;
        public PanningSampleProvider PanProvider;
        public VolumeSampleProvider VolumeProvider;
        public bool IsDisposed;

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
    /// Información de enemigos en una dirección, separados por tipo.
    /// </summary>
    public class DirectionalEnemyGroup
    {
        public int NormalCount;
        public int EliteCount;
        public int BossCount;

        public float ClosestNormalDistance = float.MaxValue;
        public float ClosestEliteDistance = float.MaxValue;
        public float ClosestBossDistance = float.MaxValue;

        // Pan del enemigo más cercano de cada tipo (más preciso)
        public float ClosestNormalPan;
        public float ClosestElitePan;
        public float ClosestBossPan;

        public float NextNormalPlayTime;
        public float NextElitePlayTime;
        public float NextBossPlayTime;

        public void Reset()
        {
            NormalCount = 0;
            EliteCount = 0;
            BossCount = 0;
            ClosestNormalDistance = float.MaxValue;
            ClosestEliteDistance = float.MaxValue;
            ClosestBossDistance = float.MaxValue;
        }

        public int TotalCount => NormalCount + EliteCount + BossCount;
        public bool HasBoss => BossCount > 0;
        public bool HasElite => EliteCount > 0;
        public bool HasNormal => NormalCount > 0;
    }

    /// <summary>
    /// Sistema de audio 3D para enemigos con diferenciación por tipo.
    /// - Jefes: sonido grave, largo y potente
    /// - Élites: sonido medio con vibrato
    /// - Normales: beep agudo corto
    /// </summary>
    public class EnemyAudioSystem : MonoBehaviour
    {
        public static EnemyAudioSystem Instance { get; private set; }

        // Configuración
        private float maxDistance = 50f;
        private float normalBaseInterval = 0.5f;
        private float normalMinInterval = 0.1f;
        private float eliteBaseInterval = 0.8f;
        private float eliteMinInterval = 0.2f;
        private float bossBaseInterval = 1.2f;
        private float bossMinInterval = 0.4f;

        // 8 direcciones para mayor precisión
        private const int NUM_DIRECTIONS = 8;
        private DirectionalEnemyGroup[] directionGroups = new DirectionalEnemyGroup[NUM_DIRECTIONS];

        // Canales de audio: 3 por dirección (normal, elite, boss)
        private Dictionary<string, EnemyAudioChannel> audioChannels = new Dictionary<string, EnemyAudioChannel>();

        // Referencias
        private Transform playerTransform = null;
        private Transform cameraTransform = null;
        private float nextPlayerSearchTime = 0f;
        private float nextUpdateTime = 0f;
        private float updateInterval = 0.1f;

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

            for (int i = 0; i < NUM_DIRECTIONS; i++)
            {
                directionGroups[i] = new DirectionalEnemyGroup();
            }

            Plugin.Log.LogInfo("[EnemyAudio] Initialized with 8 directions and enemy type differentiation");
        }

        void Start()
        {
            InitializeAudioChannels();
        }

        private void InitializeAudioChannels()
        {
            try
            {
                // Crear canales para cada dirección y tipo
                for (int dir = 0; dir < NUM_DIRECTIONS; dir++)
                {
                    CreateAudioChannel($"normal_{dir}");
                    CreateAudioChannel($"elite_{dir}");
                    CreateAudioChannel($"boss_{dir}");
                }
                isInitialized = true;
                Plugin.Log.LogInfo($"[EnemyAudio] Created {audioChannels.Count} audio channels");
            }
            catch (Exception e)
            {
                Plugin.Log.LogError($"[EnemyAudio] Failed to initialize: {e.Message}");
            }
        }

        private void CreateAudioChannel(string key)
        {
            try
            {
                var generator = new EnemyAlertSoundGenerator();
                var panProvider = new PanningSampleProvider(generator);
                var volumeProvider = new VolumeSampleProvider(panProvider) { Volume = 0.3f };

                var outputDevice = new WaveOutEvent();
                outputDevice.Init(volumeProvider);
                outputDevice.Play();

                audioChannels[key] = new EnemyAudioChannel
                {
                    OutputDevice = outputDevice,
                    SoundGenerator = generator,
                    PanProvider = panProvider,
                    VolumeProvider = volumeProvider,
                    IsDisposed = false
                };
            }
            catch (Exception e)
            {
                Plugin.Log.LogError($"[EnemyAudio] CreateAudioChannel error for {key}: {e.Message}");
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

                if (Time.time >= nextPlayerSearchTime)
                {
                    FindPlayer();
                    nextPlayerSearchTime = Time.time + 2f;
                }

                if (playerTransform == null || cameraTransform == null) return;

                if (Time.time >= nextUpdateTime)
                {
                    UpdateEnemyGroups();
                    nextUpdateTime = Time.time + updateInterval;
                }

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
            for (int i = 0; i < NUM_DIRECTIONS; i++)
            {
                directionGroups[i].Reset();
            }

            Vector3 playerPos = playerTransform.position;
            Vector3 forward = cameraTransform.forward;
            forward.y = 0;
            forward.Normalize();

            Vector3 right = Vector3.Cross(Vector3.up, forward).normalized;

            foreach (var enemy in EnemyTracker.GetActiveEnemies())
            {
                try
                {
                    if (enemy == null || enemy.IsDead()) continue;

                    Vector3 enemyPos = enemy.GetCenterPosition();
                    float distance = Vector3.Distance(playerPos, enemyPos);

                    if (distance > maxDistance) continue;

                    // Calcular dirección (8 direcciones)
                    Vector3 toEnemy = (enemyPos - playerPos);
                    toEnemy.y = 0;
                    toEnemy.Normalize();

                    float angle = Vector3.SignedAngle(forward, toEnemy, Vector3.up);
                    int dirIndex = GetDirectionIndex(angle);

                    // Calcular pan preciso
                    float pan = Vector3.Dot(toEnemy, right);
                    pan = Mathf.Clamp(pan, -1f, 1f);

                    // Determinar tipo de enemigo
                    bool isBoss = enemy.IsBoss() || enemy.IsStageBoss() || enemy.IsFinalBoss();
                    bool isElite = !isBoss && enemy.IsElite();

                    var group = directionGroups[dirIndex];

                    if (isBoss)
                    {
                        group.BossCount++;
                        if (distance < group.ClosestBossDistance)
                        {
                            group.ClosestBossDistance = distance;
                            group.ClosestBossPan = pan;
                        }
                    }
                    else if (isElite)
                    {
                        group.EliteCount++;
                        if (distance < group.ClosestEliteDistance)
                        {
                            group.ClosestEliteDistance = distance;
                            group.ClosestElitePan = pan;
                        }
                    }
                    else
                    {
                        group.NormalCount++;
                        if (distance < group.ClosestNormalDistance)
                        {
                            group.ClosestNormalDistance = distance;
                            group.ClosestNormalPan = pan;
                        }
                    }
                }
                catch { }
            }
        }

        private int GetDirectionIndex(float angle)
        {
            // 8 direcciones de 45 grados cada una
            // 0 = Forward (-22.5 to 22.5)
            // 1 = Forward-Right (22.5 to 67.5)
            // 2 = Right (67.5 to 112.5)
            // 3 = Back-Right (112.5 to 157.5)
            // 4 = Back (157.5 to 180 or -157.5 to -180)
            // 5 = Back-Left (-112.5 to -157.5)
            // 6 = Left (-67.5 to -112.5)
            // 7 = Forward-Left (-22.5 to -67.5)

            angle += 22.5f; // Offset para centrar
            if (angle < 0) angle += 360f;
            if (angle >= 360f) angle -= 360f;

            return (int)(angle / 45f) % 8;
        }

        private void PlayDirectionalSounds()
        {
            float currentTime = Time.time;

            for (int dir = 0; dir < NUM_DIRECTIONS; dir++)
            {
                var group = directionGroups[dir];

                // Reproducir sonido de jefe (prioridad máxima)
                if (group.HasBoss)
                {
                    PlayEnemySound(dir, EnemyType.Boss, group, currentTime);
                }

                // Reproducir sonido de élite
                if (group.HasElite)
                {
                    PlayEnemySound(dir, EnemyType.Elite, group, currentTime);
                }

                // Reproducir sonido de normales
                if (group.HasNormal)
                {
                    PlayEnemySound(dir, EnemyType.Normal, group, currentTime);
                }
            }
        }

        private void PlayEnemySound(int dirIndex, EnemyType type, DirectionalEnemyGroup group, float currentTime)
        {
            float distance, pan;
            int count;
            float baseInterval, minInterval;
            ref float nextPlayTime = ref group.NextNormalPlayTime;

            switch (type)
            {
                case EnemyType.Boss:
                    distance = group.ClosestBossDistance;
                    pan = group.ClosestBossPan;
                    count = group.BossCount;
                    baseInterval = bossBaseInterval;
                    minInterval = bossMinInterval;
                    nextPlayTime = ref group.NextBossPlayTime;
                    break;
                case EnemyType.Elite:
                    distance = group.ClosestEliteDistance;
                    pan = group.ClosestElitePan;
                    count = group.EliteCount;
                    baseInterval = eliteBaseInterval;
                    minInterval = eliteMinInterval;
                    nextPlayTime = ref group.NextElitePlayTime;
                    break;
                default:
                    distance = group.ClosestNormalDistance;
                    pan = group.ClosestNormalPan;
                    count = group.NormalCount;
                    baseInterval = normalBaseInterval;
                    minInterval = normalMinInterval;
                    break;
            }

            // Calcular intervalo
            float proximityFactor = 1f - (distance / maxDistance);
            proximityFactor = Mathf.Clamp01(proximityFactor);
            proximityFactor = proximityFactor * proximityFactor;

            float countFactor = Mathf.Clamp01(count / 5f);
            float interval = Mathf.Lerp(baseInterval, minInterval, Mathf.Max(proximityFactor, countFactor));

            if (currentTime < nextPlayTime) return;

            string channelKey = $"{type.ToString().ToLower()}_{dirIndex}";
            if (!audioChannels.TryGetValue(channelKey, out var channel)) return;
            if (channel.IsDisposed) return;

            try
            {
                // Frecuencia según tipo y distancia
                double frequency;
                float volume;

                switch (type)
                {
                    case EnemyType.Boss:
                        // Jefe: muy grave (60-120 Hz), muy fuerte
                        frequency = 60 + (proximityFactor * 60);
                        volume = 0.6f + proximityFactor * 0.3f;
                        break;
                    case EnemyType.Elite:
                        // Élite: grave-medio (150-300 Hz)
                        frequency = 150 + (proximityFactor * 150);
                        volume = 0.5f + proximityFactor * 0.25f;
                        break;
                    default:
                        // Normal: agudo (500-1000 Hz)
                        frequency = 500 + (proximityFactor * 500);
                        volume = 0.4f + proximityFactor * 0.2f;
                        // Boost por cantidad
                        volume += Mathf.Clamp01(count / 8f) * 0.15f;
                        break;
                }

                volume = Mathf.Clamp(volume, 0.35f, 0.85f);

                channel.PanProvider.Pan = pan;
                channel.VolumeProvider.Volume = volume;
                channel.SoundGenerator.Play(frequency, volume, type);

                nextPlayTime = currentTime + interval;
            }
            catch (Exception e)
            {
                Plugin.Log.LogDebug($"[EnemyAudio] PlayEnemySound error: {e.Message}");
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
                    for (int i = 0; i < NUM_DIRECTIONS; i++)
                    {
                        directionGroups[i].Reset();
                        directionGroups[i].NextNormalPlayTime = 0;
                        directionGroups[i].NextElitePlayTime = 0;
                        directionGroups[i].NextBossPlayTime = 0;
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

        // Death camera tracking (cached for performance)
        private GameObject cachedDeathCamera = null;
        private float nextDeathCameraSearchTime = 0f;

        private bool IsMenuOpen()
        {
            // 1. TimeScale check - catches pause menu
            if (Time.timeScale < 0.1f) return true;

            // 2. Pause menu check
            try
            {
                string[] pauseMenuNames = { "PauseMenu", "PausePanel", "Pause", "PauseScreen", "PauseCanvas", "B_Resume", "ResumeButton" };
                foreach (var menuName in pauseMenuNames)
                {
                    var menu = GameObject.Find(menuName);
                    if (menu != null && menu.activeInHierarchy) return true;
                }
            }
            catch { }

            // 3. Chest window open check
            if (ChestAnimationTracker.IsChestWindowOpen || ChestAnimationTracker.IsChestAnimationPlaying)
                return true;

            // 4. MenuStateTracker - upgrade buttons, reward windows
            if (MenuStateTracker.IsAnyMenuOpen)
                return true;

            // 5. EncounterMenuTracker - shrine/encounter menus
            if (EncounterMenuTracker.IsEncounterMenuOpen)
                return true;

            // 6. DeathCamera check - cached reference
            try
            {
                if (Time.time >= nextDeathCameraSearchTime)
                {
                    cachedDeathCamera = GameObject.Find("DeathCamera");
                    nextDeathCameraSearchTime = Time.time + 0.5f;
                }

                if (cachedDeathCamera != null && cachedDeathCamera.activeInHierarchy)
                {
                    var camComponent = cachedDeathCamera.GetComponent<Camera>();
                    if (camComponent != null && camComponent.enabled)
                        return true;
                }
            }
            catch { }

            // 7. Death screen buttons
            try
            {
                string[] deathButtonNames = { "B_Continue", "ContinueButton", "RestartButton", "StatsButton" };
                foreach (var btnName in deathButtonNames)
                {
                    var btn = GameObject.Find(btnName);
                    if (btn != null && btn.activeInHierarchy) return true;
                }
            }
            catch { }

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
