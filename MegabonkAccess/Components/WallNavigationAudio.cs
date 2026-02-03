using System;
using System.Collections.Generic;
using NAudio.Wave;
using NAudio.Wave.SampleProviders;
using UnityEngine;
using Il2CppInterop.Runtime.Injection;

namespace MegabonkAccess.Components
{
    /// <summary>
    /// Genera una onda sinusoidal continua con frecuencia, volumen y pan ajustables en tiempo real.
    /// </summary>
    public class SineWaveGenerator : ISampleProvider
    {
        private readonly WaveFormat waveFormat;
        private double phase;
        private double targetFrequency;
        private double currentFrequency;
        private float targetVolume;
        private float currentVolume;

        // Suavizado para evitar clicks/pops
        private const float FREQUENCY_SMOOTHING = 0.1f;
        private const float VOLUME_SMOOTHING = 0.05f;

        public WaveFormat WaveFormat => waveFormat;

        public double Frequency
        {
            get => targetFrequency;
            set => targetFrequency = Math.Max(20, Math.Min(20000, value));
        }

        public float Volume
        {
            get => targetVolume;
            set => targetVolume = Math.Max(0, Math.Min(1, value));
        }

        public SineWaveGenerator(double frequency = 440, float volume = 0.5f, int sampleRate = 44100)
        {
            waveFormat = WaveFormat.CreateIeeeFloatWaveFormat(sampleRate, 1); // Mono
            targetFrequency = frequency;
            currentFrequency = frequency;
            targetVolume = volume;
            currentVolume = volume;
            phase = 0;
        }

        public int Read(float[] buffer, int offset, int count)
        {
            double sampleRate = waveFormat.SampleRate;

            for (int i = 0; i < count; i++)
            {
                // Suavizado de frecuencia y volumen
                currentFrequency += (targetFrequency - currentFrequency) * FREQUENCY_SMOOTHING;
                currentVolume += (targetVolume - currentVolume) * VOLUME_SMOOTHING;

                // Generar muestra sinusoidal
                buffer[offset + i] = (float)(currentVolume * Math.Sin(2 * Math.PI * phase));

                // Avanzar fase
                phase += currentFrequency / sampleRate;
                if (phase >= 1.0)
                    phase -= 1.0;
            }

            return count;
        }
    }

    /// <summary>
    /// Representa un canal de audio para una dirección de pared.
    /// </summary>
    public class WallAudioChannel : IDisposable
    {
        public WaveOutEvent OutputDevice;
        public SineWaveGenerator SineGenerator;
        public PanningSampleProvider PanProvider;
        public VolumeSampleProvider VolumeProvider;
        public bool IsPlaying;
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
    /// Direcciones de detección de paredes.
    /// </summary>
    public enum WallDirection
    {
        Forward,
        Back,
        Left,
        Right
    }

    /// <summary>
    /// Sistema de navegación por audio que detecta paredes y emite tonos sinusoidales.
    /// - Frecuencia aguda: pared adelante
    /// - Frecuencia grave: pared detrás
    /// - Frecuencia media: paredes a los lados (con paneo estéreo)
    /// - Volumen proporcional a la cercanía de la pared
    /// </summary>
    public class WallNavigationAudio : MonoBehaviour
    {
        public static WallNavigationAudio Instance { get; private set; }

        // Configuración de frecuencias (Hz)
        private const double FREQ_FORWARD = 900;   // Agudo - pared adelante
        private const double FREQ_BACK = 250;      // Grave - pared detrás
        private const double FREQ_SIDES = 450;     // Medio - paredes a los lados (mismo para ambos)

        // Configuración de detección
        private float maxWallDistance = 15f;       // Distancia máxima de detección
        private float minVolumeDistance = 0.5f;    // Distancia mínima (volumen máximo)
        private float baseVolume = 0.4f;           // Volumen base (ajustar según preferencia)

        // Canales de audio (uno por dirección)
        private Dictionary<WallDirection, WallAudioChannel> channels = new Dictionary<WallDirection, WallAudioChannel>();
        private readonly object channelLock = new object();

        // Referencias del jugador
        private Transform playerTransform;
        private Transform cameraTransform;
        private float nextPlayerSearchTime = 0f;

        // Layer mask para colisiones
        private int wallLayerMask = -1;

        // Estado
        private bool isInitialized = false;
        private bool isEnabled = true;             // Permite activar/desactivar el sistema

        // Scene tracking
        private string lastSceneName = "";
        private float sceneLoadTime = 0f;
        private float sceneStartDelay = 4f;  // Wait 4 seconds after scene load

        // Death camera tracking (cached for performance)
        private GameObject cachedDeathCamera = null;
        private float nextDeathCameraSearchTime = 0f;

        static WallNavigationAudio()
        {
            ClassInjector.RegisterTypeInIl2Cpp<WallNavigationAudio>();
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

            Plugin.Log.LogInfo("[WallNav] Awake - Wall Navigation Audio initialized");
        }

        void Start()
        {
            Initialize();
        }

        private void Initialize()
        {
            try
            {
                // Configurar layer mask para paredes/terreno
                // Intentar usar las capas del juego si están disponibles
                ConfigureLayerMask();

                // Crear canales de audio para cada dirección
                CreateAudioChannels();

                isInitialized = true;
                Plugin.Log.LogInfo($"[WallNav] Initialized with maxDistance={maxWallDistance}, baseVolume={baseVolume}");
            }
            catch (Exception e)
            {
                Plugin.Log.LogError($"[WallNav] Initialize error: {e.Message}");
            }
        }

        private void ConfigureLayerMask()
        {
            // Usar todas las capas (-1 en Unity = todas las capas)
            // Esto es más confiable en IL2CPP que usar ~(1 << 2)
            wallLayerMask = -1;
            Plugin.Log.LogInfo($"[WallNav] Layer mask configured: {wallLayerMask} (all layers)");
        }

        private void CreateAudioChannels()
        {
            lock (channelLock)
            {
                // Crear un canal para cada dirección
                CreateChannel(WallDirection.Forward, FREQ_FORWARD, 0f);   // Centro
                CreateChannel(WallDirection.Back, FREQ_BACK, 0f);         // Centro
                CreateChannel(WallDirection.Left, FREQ_SIDES, -1f);       // Izquierda
                CreateChannel(WallDirection.Right, FREQ_SIDES, 1f);       // Derecha

                Plugin.Log.LogInfo("[WallNav] Audio channels created");
            }
        }

        private void CreateChannel(WallDirection direction, double frequency, float pan)
        {
            try
            {
                // Crear generador de onda sinusoidal (mono)
                var sineGen = new SineWaveGenerator(frequency, 0f); // Comienza silenciado

                // Añadir paneo
                var panProvider = new PanningSampleProvider(sineGen)
                {
                    Pan = pan
                };

                // Añadir control de volumen adicional
                var volumeProvider = new VolumeSampleProvider(panProvider)
                {
                    Volume = 1.0f
                };

                // Crear dispositivo de salida
                var outputDevice = new WaveOutEvent();
                outputDevice.Init(volumeProvider);

                // Crear canal
                var channel = new WallAudioChannel
                {
                    OutputDevice = outputDevice,
                    SineGenerator = sineGen,
                    PanProvider = panProvider,
                    VolumeProvider = volumeProvider,
                    IsPlaying = false,
                    IsDisposed = false
                };

                channels[direction] = channel;

                // Iniciar reproducción (pero silenciado)
                outputDevice.Play();
                channel.IsPlaying = true;

                Plugin.Log.LogInfo($"[WallNav] Channel created: {direction} at {frequency}Hz, pan={pan}");
            }
            catch (Exception e)
            {
                Plugin.Log.LogError($"[WallNav] CreateChannel error for {direction}: {e.Message}");
            }
        }

        // Para debug
        private int debugCounter = 0;

        void Update()
        {
            if (!isInitialized || !isEnabled) return;

            try
            {
                debugCounter++;

                // Buscar jugador periódicamente
                if (Time.time >= nextPlayerSearchTime)
                {
                    FindPlayer();
                    nextPlayerSearchTime = Time.time + 2f;
                }

                if (playerTransform == null)
                {
                    if (debugCounter % 300 == 0)
                        Plugin.Log.LogWarning("[WallNav] No player found!");
                    return;
                }

                // Verificar si estamos en escena de gameplay
                CheckSceneChange();
                bool isGameplay = IsGameplayScene();
                if (!isGameplay)
                {
                    if (debugCounter % 300 == 0)
                        Plugin.Log.LogDebug($"[WallNav] Not gameplay scene: {lastSceneName}");
                    SilenceAllChannels();
                    return;
                }

                // Verificar delay de escena (intro/cinematic) y menú
                bool shouldPause = Time.time - sceneLoadTime < sceneStartDelay || IsMenuOpen();
                if (shouldPause)
                {
                    if (debugCounter % 300 == 0)
                        Plugin.Log.LogDebug("[WallNav] Paused (menu or scene delay)");
                    SilenceAllChannels();
                    return;
                }

                // Llegamos aquí - ejecutar detección
                if (debugCounter % 300 == 0)
                    Plugin.Log.LogInfo("[WallNav] Running wall detection...");

                // Actualizar detección de paredes cada frame
                UpdateWallDetection();
            }
            catch (Exception e)
            {
                Plugin.Log.LogError($"[WallNav] Update error: {e.Message}");
            }
        }

        private void FindPlayer()
        {
            try
            {
                // Buscar el jugador - Character es el nombre correcto en Megabonk
                // Buscar primero por nombres específicos del juego
                string[] playerNames = { "Character", "Player", "PlayerCharacter", "Hero" };

                foreach (var name in playerNames)
                {
                    var obj = GameObject.Find(name);
                    if (obj != null)
                    {
                        // Verificar que NO sea parte de la cámara
                        string parentName = obj.transform.parent?.name ?? "";
                        if (parentName.Contains("Camera") || obj.name == "Camera")
                        {
                            continue;
                        }

                        // Verificar que tenga Rigidbody o CharacterController (es el jugador real)
                        var rb = obj.GetComponent<Rigidbody>();
                        var cc = obj.GetComponent<CharacterController>();
                        if (rb != null || cc != null)
                        {
                            playerTransform = obj.transform;
                            Plugin.Log.LogInfo($"[WallNav] Found player: {name} at {obj.transform.position}");
                            break;
                        }
                    }
                }

                // Si no encontramos con Rigidbody, buscar cualquier Character que no sea cámara
                if (playerTransform == null)
                {
                    var character = GameObject.Find("Character");
                    if (character != null)
                    {
                        string parentName = character.transform.parent?.name ?? "";
                        if (!parentName.Contains("Camera") && character.name != "Camera")
                        {
                            playerTransform = character.transform;
                            Plugin.Log.LogInfo($"[WallNav] Found character (fallback): {character.name}");
                        }
                    }
                }

                // Buscar la cámara para la dirección forward
                var cam = Camera.main;
                if (cam != null)
                {
                    cameraTransform = cam.transform;
                }

                // Log de debug
                if (playerTransform != null && Time.frameCount % 300 == 0)
                {
                    Plugin.Log.LogDebug($"[WallNav] Player pos: {playerTransform.position}, Camera: {cameraTransform?.position}");
                }
            }
            catch (Exception e)
            {
                Plugin.Log.LogDebug($"[WallNav] FindPlayer error: {e.Message}");
            }
        }

        private void CheckSceneChange()
        {
            try
            {
                var currentScene = UnityEngine.SceneManagement.SceneManager.GetActiveScene().name;
                if (!string.IsNullOrEmpty(lastSceneName) && currentScene != lastSceneName)
                {
                    Plugin.Log.LogInfo($"[WallNav] Scene changed to {currentScene}");
                    sceneLoadTime = Time.time;  // Reset timer for new scene
                }
                lastSceneName = currentScene;
            }
            catch { }
        }

        private bool IsGameplayScene()
        {
            return lastSceneName != "MainMenu" &&
                   lastSceneName != "BootScene" &&
                   lastSceneName != "LoadingScreen" &&
                   !lastSceneName.Contains("Menu") &&
                   !string.IsNullOrEmpty(lastSceneName);
        }

        private bool IsMenuOpen()
        {
            // 1. TimeScale check - catches pause menu
            if (Time.timeScale < 0.1f)
            {
                return true;
            }

            // 2. Pause menu check - look for common pause menu objects
            try
            {
                string[] pauseMenuNames = { "PauseMenu", "PausePanel", "Pause", "PauseScreen", "PauseCanvas", "B_Resume", "ResumeButton" };
                foreach (var menuName in pauseMenuNames)
                {
                    var menu = GameObject.Find(menuName);
                    if (menu != null && menu.activeInHierarchy)
                    {
                        return true;
                    }
                }
            }
            catch { }

            // 3. Chest window open check (entire duration, not just animation)
            if (ChestAnimationTracker.IsChestWindowOpen || ChestAnimationTracker.IsChestAnimationPlaying)
            {
                return true;
            }

            // 4. MenuStateTracker - checks for upgrade buttons, chest windows, etc.
            if (MenuStateTracker.IsAnyMenuOpen)
            {
                return true;
            }

            // 5. EncounterMenuTracker - checks for shrine/encounter menus
            if (EncounterMenuTracker.IsEncounterMenuOpen)
            {
                return true;
            }

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
                    {
                        return true;
                    }
                }
            }
            catch { }

            // 7. Death screen detection - check for death-related buttons
            try
            {
                string[] deathButtonNames = { "B_Continue", "ContinueButton", "RestartButton", "StatsButton" };
                foreach (var btnName in deathButtonNames)
                {
                    var btn = GameObject.Find(btnName);
                    if (btn != null && btn.activeInHierarchy)
                    {
                        return true;
                    }
                }
            }
            catch { }

            return false;
        }

        private void UpdateWallDetection()
        {
            if (playerTransform == null) return;

            try
            {
                // Usar la posición del jugador directamente
                Vector3 playerPos = playerTransform.position;

                // Usar Vector3.forward como base y rotar según la cámara
                Vector3 forward = Vector3.forward;
                Vector3 right = Vector3.right;

                if (cameraTransform != null)
                {
                    // Usar dirección de la cámara en el plano horizontal
                    forward = cameraTransform.forward;
                    forward.y = 0;
                    if (forward.sqrMagnitude > 0.001f)
                    {
                        forward = forward.normalized;
                        right = new Vector3(forward.z, 0, -forward.x); // Perpendicular
                    }
                }

                Vector3 back = -forward;
                Vector3 left = -right;

                // Debug ocasional
                if (Time.frameCount % 300 == 0)
                {
                    Plugin.Log.LogInfo($"[WallNav] UpdateWallDetection: pos={playerPos}, fwd={forward}, channels={channels.Count}");
                }

                // Detectar paredes en cada dirección
                DetectWallSimple(WallDirection.Forward, playerPos, forward);
                DetectWallSimple(WallDirection.Back, playerPos, back);
                DetectWallSimple(WallDirection.Left, playerPos, left);
                DetectWallSimple(WallDirection.Right, playerPos, right);
            }
            catch (Exception e)
            {
                Plugin.Log.LogError($"[WallNav] UpdateWallDetection error: {e.Message}");
            }
        }

        /// <summary>
        /// Detecta pared con un solo raycast simple.
        /// </summary>
        private void DetectWallSimple(WallDirection direction, Vector3 playerPos, Vector3 dir)
        {
            if (!channels.TryGetValue(direction, out var channel))
            {
                if (Time.frameCount % 300 == 0)
                    Plugin.Log.LogWarning($"[WallNav] No channel for {direction}");
                return;
            }

            if (channel == null || channel.IsDisposed || channel.SineGenerator == null)
            {
                if (Time.frameCount % 300 == 0)
                    Plugin.Log.LogWarning($"[WallNav] Channel {direction} is null/disposed");
                return;
            }

            try
            {
                // Raycast simple desde la cintura del jugador
                Vector3 origin = playerPos + Vector3.up * 1.0f;

                bool hasWall = Physics.Raycast(origin, dir, out RaycastHit hit, maxWallDistance, wallLayerMask);

                if (hasWall)
                {
                    float distance = hit.distance;
                    float normalizedDist = Mathf.Clamp01((distance - minVolumeDistance) / (maxWallDistance - minVolumeDistance));
                    float volumeMultiplier = 1f - (normalizedDist * normalizedDist);
                    float finalVolume = baseVolume * volumeMultiplier;

                    channel.SineGenerator.Volume = finalVolume;

                    if (Time.frameCount % 120 == 0)
                    {
                        Plugin.Log.LogInfo($"[WallNav] {direction}: WALL at {distance:F1}m, vol={finalVolume:F2}");
                    }
                }
                else
                {
                    channel.SineGenerator.Volume = 0f;
                }
            }
            catch (Exception e)
            {
                if (Time.frameCount % 300 == 0)
                    Plugin.Log.LogError($"[WallNav] DetectWall {direction} error: {e.Message}");
            }
        }

        private void SilenceAllChannels()
        {
            lock (channelLock)
            {
                foreach (var channel in channels.Values)
                {
                    if (channel != null && !channel.IsDisposed && channel.SineGenerator != null)
                    {
                        channel.SineGenerator.Volume = 0f;
                    }
                }
            }
        }

        /// <summary>
        /// Activa o desactiva el sistema de navegación por paredes.
        /// </summary>
        public void SetEnabled(bool enabled)
        {
            isEnabled = enabled;
            if (!enabled)
            {
                SilenceAllChannels();
            }
            Plugin.Log.LogInfo($"[WallNav] System {(enabled ? "enabled" : "disabled")}");
        }

        /// <summary>
        /// Ajusta la distancia máxima de detección de paredes.
        /// </summary>
        public void SetMaxDistance(float distance)
        {
            maxWallDistance = Mathf.Max(1f, distance);
            Plugin.Log.LogInfo($"[WallNav] Max distance set to {maxWallDistance}");
        }

        /// <summary>
        /// Ajusta el volumen base del sistema.
        /// </summary>
        public void SetBaseVolume(float volume)
        {
            baseVolume = Mathf.Clamp01(volume);
            Plugin.Log.LogInfo($"[WallNav] Base volume set to {baseVolume}");
        }

        void OnDestroy()
        {
            lock (channelLock)
            {
                foreach (var channel in channels.Values)
                {
                    channel?.Dispose();
                }
                channels.Clear();
            }

            Instance = null;
            Plugin.Log.LogInfo("[WallNav] Destroyed");
        }
    }
}
