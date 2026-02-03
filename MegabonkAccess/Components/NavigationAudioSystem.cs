using System;
using System.Collections.Generic;
using System.IO;
using NAudio.Wave;
using NAudio.Wave.SampleProviders;
using UnityEngine;
using Il2CppInterop.Runtime.Injection;

namespace MegabonkAccess.Components
{
    /// <summary>
    /// Generador de ruido blanco/rosa para sonido de viento.
    /// Mucho más agradable que ondas sinusoidales.
    /// </summary>
    public class WindNoiseGenerator : ISampleProvider
    {
        private readonly WaveFormat waveFormat;
        private readonly System.Random random = new System.Random();
        private float targetVolume;
        private float currentVolume;
        private float targetPan;
        private float currentPan;

        // Filtro pasa-bajos simple para suavizar el ruido
        private float lastSample = 0;
        private const float SMOOTHING = 0.85f; // Más alto = más suave
        private const float VOLUME_SMOOTHING = 0.02f;
        private const float PAN_SMOOTHING = 0.05f;

        public WaveFormat WaveFormat => waveFormat;

        public float Volume
        {
            get => targetVolume;
            set => targetVolume = Math.Max(0, Math.Min(1, value));
        }

        public float Pan
        {
            get => targetPan;
            set => targetPan = Math.Max(-1, Math.Min(1, value));
        }

        public WindNoiseGenerator(float volume = 0.3f, int sampleRate = 44100)
        {
            waveFormat = WaveFormat.CreateIeeeFloatWaveFormat(sampleRate, 2); // Stereo
            targetVolume = volume;
            currentVolume = volume;
            targetPan = 0;
            currentPan = 0;
        }

        public int Read(float[] buffer, int offset, int count)
        {
            for (int i = 0; i < count; i += 2)
            {
                // Suavizado de volumen y pan
                currentVolume += (targetVolume - currentVolume) * VOLUME_SMOOTHING;
                currentPan += (targetPan - currentPan) * PAN_SMOOTHING;

                // Generar ruido blanco
                float noise = (float)(random.NextDouble() * 2 - 1);

                // Filtro pasa-bajos para convertir en "viento" suave
                lastSample = lastSample * SMOOTHING + noise * (1 - SMOOTHING);
                float sample = lastSample * currentVolume;

                // Aplicar pan (estéreo)
                float leftGain = currentPan <= 0 ? 1f : 1f - currentPan;
                float rightGain = currentPan >= 0 ? 1f : 1f + currentPan;

                buffer[offset + i] = sample * leftGain;       // Left
                buffer[offset + i + 1] = sample * rightGain;  // Right
            }

            return count;
        }
    }

    /// <summary>
    /// Generador de sonido de agua (ruido con modulación).
    /// </summary>
    public class WaterSoundGenerator : ISampleProvider
    {
        private readonly WaveFormat waveFormat;
        private readonly System.Random random = new System.Random();
        private float targetVolume;
        private float currentVolume;
        private float targetPan;
        private float currentPan;
        private double phase = 0;

        private float[] filterBuffer = new float[5];
        private int filterIndex = 0;

        private const float VOLUME_SMOOTHING = 0.02f;
        private const float PAN_SMOOTHING = 0.05f;

        public WaveFormat WaveFormat => waveFormat;

        public float Volume
        {
            get => targetVolume;
            set => targetVolume = Math.Max(0, Math.Min(1, value));
        }

        public float Pan
        {
            get => targetPan;
            set => targetPan = Math.Max(-1, Math.Min(1, value));
        }

        public WaterSoundGenerator(float volume = 0.3f, int sampleRate = 44100)
        {
            waveFormat = WaveFormat.CreateIeeeFloatWaveFormat(sampleRate, 2);
            targetVolume = volume;
            currentVolume = 0; // Empieza silenciado
            targetPan = 0;
            currentPan = 0;
        }

        public int Read(float[] buffer, int offset, int count)
        {
            double sampleRate = waveFormat.SampleRate;

            for (int i = 0; i < count; i += 2)
            {
                currentVolume += (targetVolume - currentVolume) * VOLUME_SMOOTHING;
                currentPan += (targetPan - currentPan) * PAN_SMOOTHING;

                // Ruido base
                float noise = (float)(random.NextDouble() * 2 - 1);

                // Modulación lenta para efecto de "olas"
                float modulation = (float)(0.5 + 0.5 * Math.Sin(2 * Math.PI * phase));
                phase += 0.3 / sampleRate; // Modulación muy lenta
                if (phase >= 1.0) phase -= 1.0;

                // Filtro de media móvil para suavizar
                filterBuffer[filterIndex] = noise;
                filterIndex = (filterIndex + 1) % filterBuffer.Length;
                float filtered = 0;
                foreach (var s in filterBuffer) filtered += s;
                filtered /= filterBuffer.Length;

                float sample = filtered * modulation * currentVolume;

                float leftGain = currentPan <= 0 ? 1f : 1f - currentPan;
                float rightGain = currentPan >= 0 ? 1f : 1f + currentPan;

                buffer[offset + i] = sample * leftGain;
                buffer[offset + i + 1] = sample * rightGain;
            }

            return count;
        }
    }

    /// <summary>
    /// Sistema de navegación por audio dinámico.
    ///
    /// Características:
    /// 1. Sonido de viento que viene desde la dirección del objetivo (portal/boss)
    /// 2. Sonido de agua cuando hay peligro cercano (agua/lava)
    /// 3. Reemplaza el sistema de paredes molesto con algo útil
    /// </summary>
    public class NavigationAudioSystem : MonoBehaviour
    {
        public static NavigationAudioSystem Instance { get; private set; }

        // Audio generators
        private WindNoiseGenerator windGenerator;
        private WaterSoundGenerator waterGenerator;
        private WaveOutEvent windOutput;
        private WaveOutEvent waterOutput;

        // Player/Camera references
        private Transform playerTransform;
        private Transform cameraTransform;
        private float nextPlayerSearchTime = 0f;

        // Objective tracking
        private Transform currentObjective;
        private float nextObjectiveSearchTime = 0f;
        private Vector3 lastKnownObjectivePos;

        // Water/hazard tracking
        private float nextHazardScanTime = 0f;
        private Vector3? nearestWaterPos = null;
        private float nearestWaterDistance = float.MaxValue;

        // Configuration - volúmenes más altos para que se escuche
        private float windBaseVolume = 0.4f;
        private float waterBaseVolume = 0.4f;
        private float maxObjectiveDistance = 200f;
        private float maxWaterDetectionDistance = 30f;

        // State
        private bool isInitialized = false;
        private bool isEnabled = true;
        private string lastSceneName = "";
        private float sceneLoadTime = 0f;
        private float sceneStartDelay = 4f;

        // Death camera tracking
        private GameObject cachedDeathCamera = null;
        private float nextDeathCameraSearchTime = 0f;

        static NavigationAudioSystem()
        {
            ClassInjector.RegisterTypeInIl2Cpp<NavigationAudioSystem>();
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

            Plugin.Log.LogInfo("[NavAudio] Navigation Audio System initialized");
        }

        void Start()
        {
            Initialize();
        }

        private void Initialize()
        {
            try
            {
                // Crear generador de viento (para guía hacia objetivo)
                windGenerator = new WindNoiseGenerator(0f); // Empieza silenciado
                windOutput = new WaveOutEvent();
                windOutput.Init(windGenerator);
                windOutput.Play();

                // Crear generador de agua (para peligros)
                waterGenerator = new WaterSoundGenerator(0f);
                waterOutput = new WaveOutEvent();
                waterOutput.Init(waterGenerator);
                waterOutput.Play();

                isInitialized = true;
                Plugin.Log.LogInfo("[NavAudio] Audio generators initialized");
            }
            catch (Exception e)
            {
                Plugin.Log.LogError($"[NavAudio] Initialize error: {e.Message}");
            }
        }

        void Update()
        {
            if (!isInitialized || !isEnabled) return;

            try
            {
                // Buscar jugador periódicamente
                if (Time.time >= nextPlayerSearchTime)
                {
                    FindPlayer();
                    nextPlayerSearchTime = Time.time + 2f;
                }

                if (playerTransform == null) return;

                // Verificar escena de gameplay
                CheckSceneChange();
                if (!IsGameplayScene())
                {
                    SilenceAll();
                    return;
                }

                // Verificar delay de escena y menús
                if (Time.time - sceneLoadTime < sceneStartDelay || IsMenuOpen())
                {
                    SilenceAll();
                    return;
                }

                // Buscar objetivo periódicamente
                if (Time.time >= nextObjectiveSearchTime)
                {
                    FindObjective();
                    nextObjectiveSearchTime = Time.time + 1f;
                }

                // Escanear peligros periódicamente
                if (Time.time >= nextHazardScanTime)
                {
                    ScanForHazards();
                    nextHazardScanTime = Time.time + 0.5f;
                }

                // Actualizar audio
                UpdateWindAudio();
                UpdateWaterAudio();
            }
            catch (Exception e)
            {
                if (Time.frameCount % 300 == 0)
                    Plugin.Log.LogError($"[NavAudio] Update error: {e.Message}");
            }
        }

        private void FindPlayer()
        {
            try
            {
                string[] playerNames = { "Character", "Player", "PlayerCharacter" };

                foreach (var name in playerNames)
                {
                    var obj = GameObject.Find(name);
                    if (obj != null)
                    {
                        string parentName = obj.transform.parent?.name ?? "";
                        if (parentName.Contains("Camera")) continue;

                        var rb = obj.GetComponent<Rigidbody>();
                        if (rb != null)
                        {
                            playerTransform = obj.transform;
                            break;
                        }
                    }
                }

                // Fallback
                if (playerTransform == null)
                {
                    var character = GameObject.Find("Character");
                    if (character != null)
                    {
                        string parentName = character.transform.parent?.name ?? "";
                        if (!parentName.Contains("Camera"))
                        {
                            playerTransform = character.transform;
                        }
                    }
                }

                // Cámara
                var cam = Camera.main;
                if (cam != null)
                {
                    cameraTransform = cam.transform;
                }
            }
            catch { }
        }

        private void FindObjective()
        {
            try
            {
                // Prioridad 1: Buscar ObjectiveArrow del juego
                var arrowObj = GameObject.Find("ObjectiveArrow");
                if (arrowObj != null)
                {
                    var arrow = arrowObj.GetComponent<ObjectiveArrow>();
                    if (arrow != null && arrow.target != null)
                    {
                        currentObjective = arrow.target;
                        lastKnownObjectivePos = currentObjective.position;
                        if (Time.frameCount % 300 == 0)
                            Plugin.Log.LogInfo($"[NavAudio] Found objective via ObjectiveArrow: {currentObjective.name}");
                        return;
                    }
                }

                // Prioridad 2: Buscar portal más cercano - más variantes
                string[] portalNames = {
                    "Portal", "InteractablePortal", "BossSpawner", "BossSpawnerFinal",
                    "portal", "Portals", "ExitPortal", "LevelPortal",
                    "Portal(Clone)", "Portal (Clone)", "InteractablePortal(Clone)",
                    "BossSpawner(Clone)", "BossSpawnerFinal(Clone)"
                };
                Transform nearestPortal = null;
                float nearestDist = float.MaxValue;

                foreach (var name in portalNames)
                {
                    var portal = GameObject.Find(name);
                    if (portal != null && portal.activeInHierarchy)
                    {
                        float dist = Vector3.Distance(playerTransform.position, portal.transform.position);
                        if (dist < nearestDist)
                        {
                            nearestDist = dist;
                            nearestPortal = portal.transform;
                        }
                    }
                }

                if (nearestPortal != null)
                {
                    currentObjective = nearestPortal;
                    lastKnownObjectivePos = currentObjective.position;
                    if (Time.frameCount % 300 == 0)
                        Plugin.Log.LogInfo($"[NavAudio] Found portal objective: {nearestPortal.name} at dist {nearestDist:F0}");
                }
                else
                {
                    if (Time.frameCount % 300 == 0)
                        Plugin.Log.LogDebug("[NavAudio] No objective found");
                    currentObjective = null;
                }
            }
            catch (Exception e)
            {
                Plugin.Log.LogDebug($"[NavAudio] FindObjective error: {e.Message}");
            }
        }

        private void ScanForHazards()
        {
            try
            {
                nearestWaterPos = null;
                nearestWaterDistance = float.MaxValue;

                if (playerTransform == null) return;

                // Buscar agua/lava cercana
                string[] hazardNames = { "Water", "Lava", "WaterPlane", "LavaPlane" };

                foreach (var name in hazardNames)
                {
                    var hazard = GameObject.Find(name);
                    if (hazard != null && hazard.activeInHierarchy)
                    {
                        // El agua es un plano grande, calcular distancia al borde más cercano
                        Vector3 hazardPos = hazard.transform.position;
                        float dist = Vector3.Distance(playerTransform.position, hazardPos);

                        // Para el agua, lo que importa es si estamos cerca del nivel Y del agua
                        // y dentro de los límites XZ
                        float verticalDist = Math.Abs(playerTransform.position.y - hazardPos.y);

                        // Si estamos cerca verticalmente del agua, usar esa distancia
                        if (verticalDist < 10f)
                        {
                            if (dist < nearestWaterDistance)
                            {
                                nearestWaterDistance = dist;
                                nearestWaterPos = hazardPos;
                            }
                        }
                    }
                }

                // También hacer raycast hacia abajo para detectar agua debajo del jugador
                Vector3 origin = playerTransform.position;
                if (Physics.Raycast(origin, Vector3.down, out RaycastHit hit, 20f))
                {
                    string hitName = hit.collider.gameObject.name.ToLower();
                    if (hitName.Contains("water") || hitName.Contains("lava"))
                    {
                        if (hit.distance < nearestWaterDistance)
                        {
                            nearestWaterDistance = hit.distance;
                            nearestWaterPos = hit.point;
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Plugin.Log.LogDebug($"[NavAudio] ScanForHazards error: {e.Message}");
            }
        }

        private void UpdateWindAudio()
        {
            if (windGenerator == null) return;

            try
            {
                // Si no hay objetivo, silenciar
                if (currentObjective == null && lastKnownObjectivePos == Vector3.zero)
                {
                    windGenerator.Volume = 0f;
                    return;
                }

                Vector3 targetPos = currentObjective != null ? currentObjective.position : lastKnownObjectivePos;
                Vector3 playerPos = playerTransform.position;
                Vector3 toTarget = targetPos - playerPos;
                float distance = toTarget.magnitude;

                // Si estamos muy cerca del objetivo, silenciar
                if (distance < 5f)
                {
                    windGenerator.Volume = 0f;
                    return;
                }

                // Calcular dirección relativa a la cámara
                Vector3 forward = cameraTransform != null ? cameraTransform.forward : Vector3.forward;
                forward.y = 0;
                forward.Normalize();

                Vector3 right = new Vector3(forward.z, 0, -forward.x);

                // Dirección al objetivo en el plano horizontal
                Vector3 toTargetFlat = new Vector3(toTarget.x, 0, toTarget.z).normalized;

                // Ángulo entre forward y dirección al objetivo
                float angle = Vector3.SignedAngle(forward, toTargetFlat, Vector3.up);

                // Pan basado en el ángulo (-1 izquierda, +1 derecha)
                // Si el objetivo está a la derecha (ángulo positivo), pan a la derecha
                float pan = Mathf.Clamp(angle / 90f, -1f, 1f);

                // Volumen basado en si estamos mirando hacia el objetivo
                // Más fuerte cuando miramos hacia él, más suave cuando miramos en otra dirección
                float dotProduct = Vector3.Dot(forward, toTargetFlat);

                // Cuando miramos directamente al objetivo (dot=1), volumen alto
                // Cuando miramos perpendicular (dot=0), volumen medio
                // Cuando miramos en dirección opuesta (dot=-1), volumen bajo
                float volumeFromDirection = Mathf.Lerp(0.3f, 1f, (dotProduct + 1f) / 2f);

                // También reducir volumen con la distancia (pero no mucho)
                float volumeFromDistance = Mathf.Lerp(1f, 0.5f, distance / maxObjectiveDistance);

                float finalVolume = windBaseVolume * volumeFromDirection * volumeFromDistance;

                windGenerator.Volume = finalVolume;
                windGenerator.Pan = pan;

                // Debug ocasional
                if (Time.frameCount % 300 == 0)
                {
                    Plugin.Log.LogInfo($"[NavAudio] Wind: dist={distance:F0}, angle={angle:F0}, pan={pan:F2}, vol={finalVolume:F2}");
                }
            }
            catch (Exception e)
            {
                Plugin.Log.LogDebug($"[NavAudio] UpdateWindAudio error: {e.Message}");
            }
        }

        private void UpdateWaterAudio()
        {
            if (waterGenerator == null) return;

            try
            {
                if (!nearestWaterPos.HasValue || nearestWaterDistance > maxWaterDetectionDistance)
                {
                    waterGenerator.Volume = 0f;
                    return;
                }

                // Volumen basado en distancia (más cerca = más fuerte)
                float normalizedDist = nearestWaterDistance / maxWaterDetectionDistance;
                float volume = waterBaseVolume * (1f - normalizedDist * normalizedDist);

                // Pan basado en dirección
                Vector3 toWater = nearestWaterPos.Value - playerTransform.position;
                toWater.y = 0;

                Vector3 forward = cameraTransform != null ? cameraTransform.forward : Vector3.forward;
                forward.y = 0;
                forward.Normalize();

                float angle = Vector3.SignedAngle(forward, toWater.normalized, Vector3.up);
                float pan = Mathf.Clamp(angle / 90f, -1f, 1f);

                waterGenerator.Volume = volume;
                waterGenerator.Pan = pan;

                if (Time.frameCount % 300 == 0 && volume > 0.01f)
                {
                    Plugin.Log.LogInfo($"[NavAudio] Water: dist={nearestWaterDistance:F1}, pan={pan:F2}, vol={volume:F2}");
                }
            }
            catch { }
        }

        private void SilenceAll()
        {
            if (windGenerator != null) windGenerator.Volume = 0f;
            if (waterGenerator != null) waterGenerator.Volume = 0f;
        }

        private void CheckSceneChange()
        {
            try
            {
                var currentScene = UnityEngine.SceneManagement.SceneManager.GetActiveScene().name;
                if (!string.IsNullOrEmpty(lastSceneName) && currentScene != lastSceneName)
                {
                    Plugin.Log.LogInfo($"[NavAudio] Scene changed to {currentScene}");
                    sceneLoadTime = Time.time;
                    currentObjective = null;
                    lastKnownObjectivePos = Vector3.zero;
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
            // TimeScale check
            if (Time.timeScale < 0.1f) return true;

            // Pause menu
            try
            {
                string[] pauseMenuNames = { "PauseMenu", "PausePanel", "Pause", "B_Resume" };
                foreach (var menuName in pauseMenuNames)
                {
                    var menu = GameObject.Find(menuName);
                    if (menu != null && menu.activeInHierarchy) return true;
                }
            }
            catch { }

            // Chest window
            if (ChestAnimationTracker.IsChestWindowOpen || ChestAnimationTracker.IsChestAnimationPlaying)
                return true;

            // Menu state tracker
            if (MenuStateTracker.IsAnyMenuOpen) return true;

            // Encounter menu
            if (EncounterMenuTracker.IsEncounterMenuOpen) return true;

            // Death camera
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
                    if (camComponent != null && camComponent.enabled) return true;
                }
            }
            catch { }

            // Death buttons
            try
            {
                string[] deathButtons = { "B_Continue", "ContinueButton", "RestartButton" };
                foreach (var btn in deathButtons)
                {
                    var obj = GameObject.Find(btn);
                    if (obj != null && obj.activeInHierarchy) return true;
                }
            }
            catch { }

            return false;
        }

        public void SetEnabled(bool enabled)
        {
            isEnabled = enabled;
            if (!enabled) SilenceAll();
            Plugin.Log.LogInfo($"[NavAudio] System {(enabled ? "enabled" : "disabled")}");
        }

        public void SetWindVolume(float volume)
        {
            windBaseVolume = Mathf.Clamp01(volume);
        }

        public void SetWaterVolume(float volume)
        {
            waterBaseVolume = Mathf.Clamp01(volume);
        }

        void OnDestroy()
        {
            try
            {
                windOutput?.Stop();
                windOutput?.Dispose();
                waterOutput?.Stop();
                waterOutput?.Dispose();
            }
            catch { }

            Instance = null;
            Plugin.Log.LogInfo("[NavAudio] Destroyed");
        }
    }
}
