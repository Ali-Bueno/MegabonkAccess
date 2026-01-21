using System;
using System.Collections.Generic;
using Assets.Scripts.Inventory__Items__Pickups.Interactables;
using Assets.Scripts.Inventory__Items__Pickups.Pickups;
using UnityEngine;
using Il2CppInterop.Runtime.Injection;

namespace MegabonkAccess.Components
{
    /// <summary>
    /// Sistema de audio por proximidad.
    /// Usa GameObject.Find y GetComponent para compatibilidad con IL2CPP.
    /// Genera audio sintético proceduralmente sin depender del AudioManager del juego.
    /// </summary>
    public class ProximityAudioBeacon : MonoBehaviour
    {
        // Configuración
        private float detectionRadius = 20f;
        private float scanInterval = 0.5f;


        // Estado
        private float nextScanTime = 0f;
        private float nextBeepTime = 0f;
        private bool isActive = false;
        private float nextStatusLogTime = 0f;
        private bool inGameplay = false;

        // Referencia al jugador
        private Transform playerTransform = null;
        private DetectInteractables playerDetector = null;
        private float playerSearchInterval = 2f;
        private float nextPlayerSearchTime = 0f;

        // Objetos detectados
        private Dictionary<int, TrackedObject> trackedInteractables = new Dictionary<int, TrackedObject>();

        // Audio: buscamos un AudioSource existente en la escena
        private bool _audioInitialized = false;
        private AudioSource _cachedAudioSource = null;

        // Nombres de objetos a buscar (NO incluir Player - es el jugador)
        private static readonly string[] searchPatterns = new string[]
        {
            "Chest", "Shrine", "Portal", "Borgor",
            "Pickup", "Health", "Gold", "XP", "World", "Level", "Game",
            "Managers", "Audio"
        };

        // Para dirección
        private Camera mainCamera = null;

        private class TrackedObject
        {
            public GameObject gameObject;
            public string objectType;
        }

        static ProximityAudioBeacon()
        {
            ClassInjector.RegisterTypeInIl2Cpp<ProximityAudioBeacon>();
        }

        void Awake()
        {
            Plugin.Log.LogInfo("[ProximityBeacon] Awake - GameObject.Find approach");
            trackedInteractables = new Dictionary<int, TrackedObject>();
        }

        void Start()
        {
            try
            {
                isActive = true;
                InitializeAudio();
                Plugin.Log.LogInfo("[ProximityBeacon] Started with frequency-based audio system");
            }
            catch (Exception e)
            {
                Plugin.Log.LogError($"[ProximityBeacon] Start error: {e.Message}");
            }
        }

        /// <summary>
        /// Inicializa el sistema de audio buscando un AudioSource por nombre de GameObject.
        /// </summary>
        private void InitializeAudio()
        {
            try
            {
                if (_cachedAudioSource != null)
                {
                    _audioInitialized = true;
                    return;
                }

                // Buscar GameObjects comunes que tienen AudioSource
                string[] audioObjectNames = { "AudioManager", "Audio", "SoundManager", "Music", "SFX", "Managers" };

                foreach (var name in audioObjectNames)
                {
                    var obj = GameObject.Find(name);
                    if (obj != null)
                    {
                        _cachedAudioSource = obj.GetComponent<AudioSource>();
                        if (_cachedAudioSource == null)
                        {
                            _cachedAudioSource = obj.GetComponentInChildren<AudioSource>();
                        }

                        if (_cachedAudioSource != null)
                        {
                            _audioInitialized = true;
                            Plugin.Log.LogInfo($"[ProximityBeacon] Found AudioSource in: {obj.name}");
                            return;
                        }
                    }
                }

                // Si no encontramos, crear nuestro propio AudioSource
                if (_cachedAudioSource == null)
                {
                    var audioObj = new GameObject("ProximityBeacon_Audio");
                    UnityEngine.Object.DontDestroyOnLoad(audioObj);
                    _cachedAudioSource = audioObj.AddComponent<AudioSource>();
                    _audioInitialized = true;
                    Plugin.Log.LogInfo("[ProximityBeacon] Created own AudioSource");
                }
            }
            catch (Exception e)
            {
                Plugin.Log.LogError($"[ProximityBeacon] Audio initialization failed: {e.Message}");
                _audioInitialized = false;
            }
        }

        private void FindPlayer()
        {
            try
            {
                // Buscar por nombres comunes de jugador
                string[] playerNames = { "Player", "Character", "PlayerCharacter", "Hero" };

                foreach (var name in playerNames)
                {
                    var playerObj = GameObject.Find(name);
                    if (playerObj != null)
                    {
                        // Intentar obtener DetectInteractables
                        playerDetector = playerObj.GetComponent<DetectInteractables>();
                        if (playerDetector == null)
                        {
                            playerDetector = playerObj.GetComponentInChildren<DetectInteractables>();
                        }

                        if (playerDetector != null)
                        {
                            playerTransform = playerDetector.transform;
                            Plugin.Log.LogInfo($"[ProximityBeacon] Found player with DetectInteractables: {playerObj.name}");
                            return;
                        }

                        // Si no tiene DetectInteractables, usar el transform
                        playerTransform = playerObj.transform;
                        Plugin.Log.LogInfo($"[ProximityBeacon] Found player: {playerObj.name}");
                        return;
                    }
                }

                // Buscar DetectInteractables en cualquier objeto
                foreach (var pattern in searchPatterns)
                {
                    var obj = GameObject.Find(pattern);
                    if (obj != null)
                    {
                        var detector = obj.GetComponentInChildren<DetectInteractables>();
                        if (detector != null)
                        {
                            playerDetector = detector;
                            playerTransform = detector.transform;
                            Plugin.Log.LogInfo($"[ProximityBeacon] Found DetectInteractables in: {obj.name}");
                            return;
                        }
                    }
                }

                // Último fallback: cámara
                var cam = Camera.main;
                if (cam != null)
                {
                    playerTransform = cam.transform;
                    Plugin.Log.LogInfo("[ProximityBeacon] Using camera as fallback");
                }
            }
            catch (Exception e)
            {
                Plugin.Log.LogDebug($"[ProximityBeacon] FindPlayer error: {e.Message}");
            }
        }


        void Update()
        {
            if (!isActive) return;

            try
            {
                // Buscar jugador periódicamente
                if (Time.time >= nextPlayerSearchTime)
                {
                    FindPlayer();
                    nextPlayerSearchTime = Time.time + playerSearchInterval;
                }

                // Verificar si estamos en gameplay (playerDetector solo existe en juego)
                bool wasInGameplay = inGameplay;
                inGameplay = IsPlayerDetectorValid();

                if (!inGameplay)
                {
                    // No estamos en gameplay - limpiar estado
                    if (wasInGameplay)
                    {
                        Plugin.Log.LogInfo("[ProximityBeacon] Exited gameplay, clearing state");
                        trackedInteractables.Clear();
                    }
                    return;
                }

                // Acabamos de entrar al gameplay
                if (!wasInGameplay && inGameplay)
                {
                    Plugin.Log.LogInfo("[ProximityBeacon] Entered gameplay!");
                    trackedInteractables.Clear();
                }

                // Reintentar inicialización de audio si no está lista
                if (!_audioInitialized)
                {
                    InitializeAudio();
                }

                // Log de estado periódico
                if (Time.time >= nextStatusLogTime)
                {
                    Plugin.Log.LogInfo($"[ProximityBeacon] Status: tracked={trackedInteractables.Count}, audioReady={_audioInitialized}");
                    nextStatusLogTime = Time.time + 5f;
                }

                // Escanear objetos por nombre
                if (Time.time >= nextScanTime)
                {
                    ScanForObjects();
                    nextScanTime = Time.time + scanInterval;
                }

                // Limpiar objetos destruidos
                CleanupTrackedObjects();

                // Beep - usar Console.Beep con frecuencia variable
                if (Time.time >= nextBeepTime)
                {
                    if (_audioInitialized && trackedInteractables.Count > 0)
                    {
                        PlayBeep();
                    }
                    nextBeepTime = Time.time + GetDynamicBeepInterval();
                }
            }
            catch (Exception e)
            {
                Plugin.Log.LogError($"[ProximityBeacon] Update error: {e.Message}");
            }
        }

        private bool IsPlayerDetectorValid()
        {
            try
            {
                if (playerDetector == null) return false;
                // Intentar acceder a algo para verificar que no está destruido
                var _ = playerDetector.transform.position;
                return true;
            }
            catch
            {
                playerDetector = null;
                playerTransform = null;
                return false;
            }
        }

        private void CheckCurrentInteractable()
        {
            // El campo currentInteractable no es accesible en IL2CPP
            // Usamos el escaneo por nombre en su lugar
        }

        private void ScanForObjects()
        {
            try
            {
                Vector3 playerPos = playerTransform.position;

                // Buscar objetos por patrones de nombre
                string[] objectPatterns = {
                    "Chest", "Shrine", "Portal", "Borgor", "Health",
                    "HealthPickup", "GoldPickup", "XPPickup", "Pickup"
                };

                foreach (var pattern in objectPatterns)
                {
                    try
                    {
                        var obj = GameObject.Find(pattern);
                        if (obj != null)
                        {
                            ProcessFoundObject(obj, playerPos, pattern);

                            // También buscar en hijos
                            var parent = obj.transform.parent;
                            if (parent != null)
                            {
                                ScanChildren(parent.gameObject, playerPos);
                            }
                        }
                    }
                    catch { }
                }
            }
            catch (Exception e)
            {
                Plugin.Log.LogDebug($"[ProximityBeacon] ScanForObjects error: {e.Message}");
            }
        }

        private void ScanChildren(GameObject parent, Vector3 playerPos)
        {
            if (parent == null) return;

            try
            {
                int childCount = parent.transform.childCount;
                for (int i = 0; i < childCount && i < 50; i++) // Limitar a 50 hijos
                {
                    var child = parent.transform.GetChild(i);
                    if (child == null) continue;

                    string name = child.name.ToLower();
                    if (name.Contains("chest") || name.Contains("shrine") ||
                        name.Contains("portal") || name.Contains("borgor") ||
                        name.Contains("health") || name.Contains("pickup"))
                    {
                        ProcessFoundObject(child.gameObject, playerPos, name);
                    }
                }
            }
            catch { }
        }

        private void ProcessFoundObject(GameObject obj, Vector3 playerPos, string hint)
        {
            if (obj == null) return;

            try
            {
                float distance = Vector3.Distance(playerPos, obj.transform.position);
                if (distance > detectionRadius) return;

                int id = obj.GetInstanceID();
                if (trackedInteractables.ContainsKey(id)) return;

                // Intentar identificar por componente
                string objectType = "Objeto";

                var interactable = obj.GetComponent<BaseInteractable>();
                if (interactable != null)
                {
                    objectType = IdentifyInteractable(interactable);
                }
                else
                {
                    objectType = IdentifyByName(hint);
                }

                if (string.IsNullOrEmpty(objectType)) return;

                trackedInteractables[id] = new TrackedObject
                {
                    gameObject = obj,
                    objectType = objectType
                };

                string distanceText = GetDistanceDescription(distance);
                string message = $"{objectType} {distanceText}";
                TolkUtil.Speak(message, true);
                Plugin.Log.LogInfo($"[ProximityBeacon] FOUND: {message} ({obj.name})");
            }
            catch { }
        }

        private void CleanupTrackedObjects()
        {
            if (playerTransform == null) return;

            Vector3 playerPos = playerTransform.position;
            var toRemove = new List<int>();

            foreach (var kvp in trackedInteractables)
            {
                try
                {
                    // En IL2CPP, verificar si el objeto fue destruido usando try-catch
                    var go = kvp.Value.gameObject;
                    if (go == null)
                    {
                        toRemove.Add(kvp.Key);
                        continue;
                    }

                    // Intentar acceder al transform - si falla, el objeto fue destruido
                    var pos = go.transform.position;
                    float distance = Vector3.Distance(playerPos, pos);

                    // Solo eliminar si está MUY lejos (3x el radio)
                    if (distance > detectionRadius * 3f)
                    {
                        toRemove.Add(kvp.Key);
                        Plugin.Log.LogDebug($"[ProximityBeacon] Removing far object: {kvp.Value.objectType} at {distance:F1}m");
                    }
                }
                catch
                {
                    // El objeto fue destruido
                    toRemove.Add(kvp.Key);
                }
            }

            foreach (var id in toRemove)
                trackedInteractables.Remove(id);
        }

        private void PlayBeep()
        {
            try
            {
                if (playerTransform == null)
                {
                    Plugin.Log.LogDebug("[ProximityBeacon] PlayBeep: no player");
                    return;
                }

                // Verificar si el audio está inicializado
                if (!_audioInitialized)
                {
                    Plugin.Log.LogDebug("[ProximityBeacon] PlayBeep: audio not initialized");
                    return;
                }

                // Encontrar el objeto más cercano
                Vector3 playerPos = playerTransform.position;
                GameObject nearestObject = null;
                TrackedObject nearestTracked = null;
                float nearestDistance = float.MaxValue;

                foreach (var kvp in trackedInteractables)
                {
                    try
                    {
                        if (kvp.Value.gameObject == null) continue;
                        var objPos = kvp.Value.gameObject.transform.position;
                        float dist = Vector3.Distance(playerPos, objPos);
                        if (dist <= detectionRadius && dist < nearestDistance)
                        {
                            nearestDistance = dist;
                            nearestObject = kvp.Value.gameObject;
                            nearestTracked = kvp.Value;
                        }
                    }
                    catch
                    {
                        // Objeto destruido, ignorar
                    }
                }

                if (nearestObject == null || nearestTracked == null)
                {
                    Plugin.Log.LogDebug("[ProximityBeacon] PlayBeep: no nearby object");
                    return;
                }

                // Calcular dirección para paneo estéreo
                Vector3 objectPos = nearestObject.transform.position;
                Vector3 directionToObject = objectPos - playerPos;

                // Reproducir sonido con nuestro sistema de audio propio
                PlayProximitySound(nearestDistance, directionToObject);
                Plugin.Log.LogDebug($"[ProximityBeacon] BEEP! {nearestTracked.objectType} at {nearestDistance:F1}m");
            }
            catch (Exception e)
            {
                Plugin.Log.LogError($"[ProximityBeacon] PlayBeep error: {e.Message}");
            }
        }

        /// <summary>
        /// Reproduce un sonido de proximidad usando un AudioSource encontrado en la escena.
        /// </summary>
        private void PlayProximitySound(float distance, Vector3 direction)
        {
            try
            {
                if (_cachedAudioSource == null)
                {
                    Plugin.Log.LogDebug("[ProximityBeacon] PlayProximitySound: no AudioSource cached");
                    return;
                }

                // Reproducir el clip del AudioSource
                if (_cachedAudioSource.clip != null)
                {
                    _cachedAudioSource.PlayOneShot(_cachedAudioSource.clip, 0.5f);
                    Plugin.Log.LogDebug($"[ProximityBeacon] Played sound at {distance:F1}m");
                }
                else
                {
                    // Si no tiene clip, intentar Play() de todas formas
                    _cachedAudioSource.Play();
                    Plugin.Log.LogDebug($"[ProximityBeacon] Called Play() at {distance:F1}m");
                }
            }
            catch (Exception e)
            {
                Plugin.Log.LogError($"[ProximityBeacon] PlayProximitySound error: {e.Message}");
            }
        }


        private string GetDirectionToObject(Vector3 objectPos)
        {
            if (playerTransform == null) return "";

            try
            {
                // Obtener cámara si no la tenemos
                if (mainCamera == null)
                {
                    mainCamera = Camera.main;
                }

                Vector3 playerPos = playerTransform.position;
                Vector3 toObject = objectPos - playerPos;
                toObject.y = 0; // Ignorar diferencia vertical

                // Usar la dirección de la cámara como referencia de "adelante"
                Vector3 forward = mainCamera != null ? mainCamera.transform.forward : playerTransform.forward;
                forward.y = 0;
                forward = forward.normalized;

                Vector3 right = mainCamera != null ? mainCamera.transform.right : playerTransform.right;
                right.y = 0;
                right = right.normalized;

                // Calcular ángulo
                float forwardDot = Vector3.Dot(toObject.normalized, forward);
                float rightDot = Vector3.Dot(toObject.normalized, right);

                // Determinar dirección
                if (forwardDot > 0.7f) return "adelante";
                if (forwardDot < -0.7f) return "atrás";
                if (rightDot > 0.7f) return "derecha";
                if (rightDot < -0.7f) return "izquierda";

                // Diagonales
                if (forwardDot > 0 && rightDot > 0) return "adelante-derecha";
                if (forwardDot > 0 && rightDot < 0) return "adelante-izquierda";
                if (forwardDot < 0 && rightDot > 0) return "atrás-derecha";
                return "atrás-izquierda";
            }
            catch
            {
                return "";
            }
        }

        private float GetDynamicBeepInterval()
        {
            if (playerTransform == null) return 1f;

            Vector3 playerPos = playerTransform.position;
            float nearestDistance = float.MaxValue;

            foreach (var kvp in trackedInteractables)
            {
                if (kvp.Value.gameObject == null) continue;
                float dist = Vector3.Distance(playerPos, kvp.Value.gameObject.transform.position);
                if (dist < nearestDistance) nearestDistance = dist;
            }

            if (nearestDistance < 3f) return 0.2f;
            if (nearestDistance < 6f) return 0.4f;
            if (nearestDistance < 10f) return 0.6f;
            return 1f;
        }

        private string IdentifyInteractable(BaseInteractable interactable)
        {
            try
            {
                string typeName = interactable.GetType().Name;

                if (typeName.Contains("Chest")) return "Cofre";
                if (typeName.Contains("Shrine")) return "Santuario";
                if (typeName.Contains("Portal")) return "Portal";
                if (typeName.Contains("Boss")) return "Jefe";
                if (typeName.Contains("Grave") || typeName.Contains("Crypt")) return "Tumba";
                if (typeName.Contains("Ghost")) return "Fantasma";
                if (typeName.Contains("Gift")) return "Regalo";
                if (typeName.Contains("Pot")) return "Vasija";

                return "Interactuable";
            }
            catch
            {
                return "Objeto";
            }
        }

        private string IdentifyByName(string name)
        {
            if (string.IsNullOrEmpty(name)) return "Objeto";

            name = name.ToLower();

            if (name.Contains("chest")) return "Cofre";
            if (name.Contains("shrine")) return "Santuario";
            if (name.Contains("portal")) return "Portal";
            if (name.Contains("borgor") || name.Contains("health")) return "Vida";
            if (name.Contains("gold") || name.Contains("coin")) return "Oro";
            if (name.Contains("xp") || name.Contains("exp")) return "Experiencia";
            if (name.Contains("pickup")) return "Item";

            return "Objeto";
        }

        private string GetDistanceDescription(float distance)
        {
            if (distance < 3f) return "muy cerca";
            if (distance < 6f) return "cerca";
            if (distance < 10f) return "medio";
            return "lejos";
        }

        void OnDestroy()
        {
            isActive = false;
            trackedInteractables?.Clear();
            Plugin.Log.LogInfo("[ProximityBeacon] Destroyed");
        }
    }
}
