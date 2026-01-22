using System;
using System.Collections.Generic;
using UnityEngine;
using Il2CppInterop.Runtime.Injection;
using Il2CppInterop.Runtime;
using Assets.Scripts.Inventory__Items__Pickups.Pickups;
using Assets.Scripts.Inventory__Items__Pickups.Chests;
using MegabonkAccess;

namespace MegabonkAccess.Components
{
    /// <summary>
    /// Sistema de audio direccional 3D para interactuables.
    /// Accede directamente al AudioManager del juego para obtener clips.
    /// </summary>
    public class DirectionalAudioManager : MonoBehaviour
    {
        public static DirectionalAudioManager Instance { get; private set; }

        // AudioClips del juego - diferentes para cada tipo
        private Dictionary<string, AudioClip> typeClips = new Dictionary<string, AudioClip>();
        private AudioClip defaultClip = null;
        private bool audioReady = false;

        // Pool de beacons activos
        private Dictionary<int, AudioBeaconData> activeBeacons = new Dictionary<int, AudioBeaconData>();
        // Track positions to avoid duplicates
        private HashSet<string> activePositions = new HashSet<string>();
        // Track interacted objects to not recreate beacons
        private HashSet<int> interactedObjects = new HashSet<int>();

        // Configuracion
        private float scanInterval = 0.5f;
        private float detectionRadius = 200f;
        private float nextScanTime = 0f;
        private float nextAudioSearchTime = 0f;

        // Jugador
        private Transform playerTransform = null;
        private float nextPlayerSearchTime = 0f;

        // Scene tracking
        private string lastSceneName = "";
        private float sceneLoadTime = 0f;
        private float sceneStartDelay = 4f;  // Wait 4 seconds after scene load before playing beacons

        // Death camera tracking (cached for performance)
        private GameObject cachedDeathCamera = null;
        private float nextDeathCameraSearchTime = 0f;

        // Configuraciones por tipo (pitch, intervalo en segundos, volumen)
        // Intervalos aumentados para ser menos molestos
        private static readonly Dictionary<string, (float pitch, float interval, float volume)> typeConfigs =
            new Dictionary<string, (float, float, float)>
        {
            // Interactuables
            { "chest", (1.0f, 3.0f, 0.7f) },      // Cofres: cada 3 segundos
            { "shrine", (0.75f, 3.0f, 0.7f) },    // Santuarios: cada 3 segundos
            { "portal", (1.4f, 2.0f, 0.8f) },     // Portales: cada 2 segundos
            { "health", (1.2f, 2.0f, 0.6f) },     // Hamburguesas interactuables
            { "gold", (1.6f, 1.5f, 0.4f) },       // Oro interactuable
            { "urn", (0.9f, 1.5f, 0.6f) },        // Urnas/vasijas rompibles
            { "music", (0.6f, 4.0f, 0.7f) },      // Música: cada 4 segundos
            { "npc", (0.8f, 3.0f, 0.6f) },        // NPCs: cada 3 segundos
            // Pickups (items sueltos en el suelo)
            { "pickup_xp", (1.8f, 1.0f, 0.3f) },       // XP orbs: pitch alto, rápido, bajo volumen
            { "pickup_gold", (1.6f, 1.0f, 0.35f) },    // Gold drops: similar a XP
            { "pickup_health", (1.0f, 1.5f, 0.5f) },   // Health pickups: más audible
            { "pickup_silver", (1.4f, 1.2f, 0.4f) },   // Silver coins
            { "pickup_special", (0.8f, 2.0f, 0.6f) },  // Special powerups (nuke, shield, etc.)
            { "default", (1.0f, 2.5f, 0.5f) }          // Default: cada 2.5 segundos
        };

        private class AudioBeaconData
        {
            public GameObject Target;
            public GameObject AudioObject;
            public AudioSource Source;
            public string Type;
            public float NextPlayTime;
            public float Pitch;
            public float Interval;
            public float Volume;
            public string PosKey;  // For cleanup tracking
        }

        static DirectionalAudioManager()
        {
            ClassInjector.RegisterTypeInIl2Cpp<DirectionalAudioManager>();
        }

        void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(gameObject);
                return;
            }
            Instance = this;
            activeBeacons = new Dictionary<int, AudioBeaconData>();
            activePositions = new HashSet<string>();

            // Hacer que este objeto persista entre escenas
            DontDestroyOnLoad(gameObject);

            Plugin.Log.LogInfo("[DirectionalAudio] Awake - marked as DontDestroyOnLoad");
        }

        void Start()
        {
            Plugin.Log.LogInfo("[DirectionalAudio] Started - searching for game audio...");
        }

        // Para logging periódico
        private float nextStatusLogTime = 0f;

        void Update()
        {
            try
            {
                // Process any pending delayed speech (must run every frame)
                TolkUtil.ProcessDelayedSpeech();

                // Update encounter menu tracker
                EncounterMenuTracker.Update();

                // Check for scene change and clear beacons if needed
                CheckSceneChange();

                // Verificar si los clips siguen siendo válidos
                if (audioReady && defaultClip == null && typeClips.Count == 0)
                {
                    Plugin.Log.LogWarning("[DirectionalAudio] AudioClips were lost, searching again...");
                    audioReady = false;
                }

                // Buscar AudioClip del juego si no tenemos uno
                if (!audioReady && Time.time >= nextAudioSearchTime)
                {
                    SearchForGameAudio();
                    nextAudioSearchTime = Time.time + 2f;
                }

                if (!audioReady) return;

                // Buscar jugador
                if (Time.time >= nextPlayerSearchTime)
                {
                    FindPlayer();
                    nextPlayerSearchTime = Time.time + 2f;
                }

                if (playerTransform == null) return;

                // Escanear interactuables
                if (Time.time >= nextScanTime)
                {
                    ScanForInteractables();
                    nextScanTime = Time.time + scanInterval;
                }

                // Actualizar beacons
                UpdateBeacons();
                CleanupBeacons();

                // Log de estado periódico
                if (Time.time >= nextStatusLogTime)
                {
                    Plugin.Log.LogInfo($"[DirectionalAudio] Status: {activeBeacons.Count} beacons active, clips: {typeClips.Count}");
                    nextStatusLogTime = Time.time + 10f;
                }
            }
            catch (Exception e)
            {
                Plugin.Log.LogDebug($"[DirectionalAudio] Update error: {e.Message}");
            }
        }

        private void CheckSceneChange()
        {
            try
            {
                var currentScene = UnityEngine.SceneManagement.SceneManager.GetActiveScene().name;
                if (!string.IsNullOrEmpty(lastSceneName) && currentScene != lastSceneName)
                {
                    Plugin.Log.LogInfo($"[DirectionalAudio] Scene changed from {lastSceneName} to {currentScene}, clearing beacons");
                    ClearAllBeacons();
                    sceneLoadTime = Time.time;  // Reset timer for new scene
                }
                lastSceneName = currentScene;
            }
            catch { }
        }

        private void ClearAllBeacons()
        {
            foreach (var beacon in activeBeacons.Values)
            {
                try
                {
                    if (beacon?.AudioObject != null)
                    {
                        UnityEngine.Object.Destroy(beacon.AudioObject);
                    }
                }
                catch { }
            }
            activeBeacons.Clear();
            activePositions.Clear();
            interactedObjects.Clear();  // Reset interacted objects on scene change
            Plugin.Log.LogInfo("[DirectionalAudio] All beacons cleared");
        }

        private void SearchForGameAudio()
        {
            try
            {
                Plugin.Log.LogInfo("[DirectionalAudio] Searching for AudioSources by GameObject name...");

                var audioManager = GameObject.Find("AudioManager");
                if (audioManager == null)
                {
                    Plugin.Log.LogWarning("[DirectionalAudio] AudioManager not found yet...");
                    return;
                }

                Plugin.Log.LogInfo("[DirectionalAudio] Found AudioManager, scanning children for clips...");

                // Buscar todos los hijos del AudioManager para obtener clips
                for (int i = 0; i < audioManager.transform.childCount; i++)
                {
                    var child = audioManager.transform.GetChild(i);
                    if (child == null) continue;

                    var source = child.GetComponent<AudioSource>();
                    if (source == null || source.clip == null) continue;

                    string childName = child.name.ToLower();
                    string clipName = source.clip.name;

                    Plugin.Log.LogInfo($"[DirectionalAudio] Found clip: {childName} -> {clipName}");

                    // Asignar clips a tipos según el nombre del hijo
                    if (childName.Contains("gold"))
                    {
                        typeClips["gold"] = source.clip;
                        // Cofres NO usan sonido de oro para distinguirlos
                    }
                    else if (childName.Contains("silver"))
                    {
                        typeClips["shrine"] = source.clip;  // Santuarios usan plata
                        typeClips["npc"] = source.clip;
                    }
                    else if (childName.Contains("bullseye"))
                    {
                        typeClips["chest"] = source.clip;  // Cofres usan bullseye (distintivo)
                    }
                    else if (childName.Contains("xp"))
                    {
                        typeClips["health"] = source.clip;  // Hamburguesas usan XP
                        typeClips["urn"] = source.clip;     // Urnas usan XP
                        if (defaultClip == null)
                            defaultClip = source.clip;
                    }
                    // Skip dungeon/door sound - it's confusing at game start
                    // Portal will use silver sound instead (assigned below)
                }

                // Portal uses silver sound (less intrusive than dungeon door)
                if (!typeClips.ContainsKey("portal") && typeClips.ContainsKey("shrine"))
                {
                    typeClips["portal"] = typeClips["shrine"];  // Silver sound
                }
                else if (!typeClips.ContainsKey("portal") && defaultClip != null)
                {
                    typeClips["portal"] = defaultClip;
                }

                // Asignar clip por defecto para música
                if (!typeClips.ContainsKey("music") && typeClips.ContainsKey("gold"))
                {
                    typeClips["music"] = typeClips["gold"];
                }

                // Asignar clips para pickups usando los clips existentes
                // XP pickups usan el sonido de XP (si existe) o default
                if (typeClips.ContainsKey("health"))
                {
                    typeClips["pickup_xp"] = typeClips["health"];
                    typeClips["pickup_health"] = typeClips["health"];
                }
                else if (defaultClip != null)
                {
                    typeClips["pickup_xp"] = defaultClip;
                    typeClips["pickup_health"] = defaultClip;
                }

                // Gold pickups usan sonido de gold
                if (typeClips.ContainsKey("gold"))
                {
                    typeClips["pickup_gold"] = typeClips["gold"];
                }
                else if (defaultClip != null)
                {
                    typeClips["pickup_gold"] = defaultClip;
                }

                // Silver pickups usan sonido de shrine/silver
                if (typeClips.ContainsKey("shrine"))
                {
                    typeClips["pickup_silver"] = typeClips["shrine"];
                }
                else if (defaultClip != null)
                {
                    typeClips["pickup_silver"] = defaultClip;
                }

                // Special pickups usan sonido de chest (más distintivo)
                if (typeClips.ContainsKey("chest"))
                {
                    typeClips["pickup_special"] = typeClips["chest"];
                }
                else if (defaultClip != null)
                {
                    typeClips["pickup_special"] = defaultClip;
                }

                if (defaultClip != null || typeClips.Count > 0)
                {
                    audioReady = true;
                    Plugin.Log.LogInfo($"[DirectionalAudio] Audio ready! Found {typeClips.Count} type-specific clips (including pickups)");
                }
                else
                {
                    Plugin.Log.LogWarning("[DirectionalAudio] No AudioClips found yet, will retry...");
                }
            }
            catch (Exception e)
            {
                Plugin.Log.LogError($"[DirectionalAudio] SearchForGameAudio error: {e.Message}");
            }
        }

        private string lastPlayerName = "";

        private void FindPlayer()
        {
            try
            {
                // Buscar el jugador por nombre - NO usar la cámara
                string[] playerNames = { "Player", "Character", "PlayerCharacter", "Hero" };
                foreach (var name in playerNames)
                {
                    var obj = GameObject.Find(name);
                    if (obj != null)
                    {
                        // Verificar que no sea parte de la cámara o UI
                        if (obj.name == "Camera" || obj.transform.parent?.name?.Contains("Camera") == true)
                        {
                            continue;
                        }

                        playerTransform = obj.transform;

                        // Si cambió el jugador, re-loguear jerarquía
                        if (lastPlayerName != name)
                        {
                            lastPlayerName = name;
                            hierarchyLogged = false; // Forzar re-log
                            Plugin.Log.LogInfo($"[DirectionalAudio] Found player object: {name}");
                        }
                        return;
                    }
                }

                // NO usar la cámara como fallback - solo la posición para audio
                var cam = Camera.main;
                if (cam != null && playerTransform == null)
                {
                    // Solo usar posición de cámara, no para escanear jerarquía
                    playerTransform = cam.transform;
                }
            }
            catch (Exception e)
            {
                Plugin.Log.LogDebug($"[DirectionalAudio] FindPlayer error: {e.Message}");
            }
        }

        private void LogPlayerHierarchy()
        {
            if (playerTransform == null) return;

            try
            {
                Plugin.Log.LogInfo($"[DirectionalAudio] === Player Hierarchy ===");
                Plugin.Log.LogInfo($"[DirectionalAudio] Player: {playerTransform.name} at {playerTransform.position}");

                // Log hijos del player
                Plugin.Log.LogInfo($"[DirectionalAudio] Player children: {playerTransform.childCount}");
                for (int i = 0; i < Math.Min(5, playerTransform.childCount); i++)
                {
                    var child = playerTransform.GetChild(i);
                    if (child != null)
                        Plugin.Log.LogInfo($"[DirectionalAudio]   - PlayerChild: {child.name}");
                }

                // Log padres
                Transform current = playerTransform.parent;
                int level = 1;
                while (current != null && level <= 5)
                {
                    Plugin.Log.LogInfo($"[DirectionalAudio] Parent {level}: {current.name} (children: {current.childCount})");

                    // Log algunos hijos para ver qué hay
                    int maxChildren = Math.Min(15, current.childCount);
                    for (int i = 0; i < maxChildren; i++)
                    {
                        var child = current.GetChild(i);
                        if (child != null)
                        {
                            // Verificar si tiene BaseInteractable o Pickup
                            bool hasInteractable = child.GetComponent<BaseInteractable>() != null;
                            bool hasPickup = child.GetComponent<Pickup>() != null;
                            string marker = hasInteractable ? " [INTERACTABLE]" : (hasPickup ? " [PICKUP]" : "");
                            Plugin.Log.LogInfo($"[DirectionalAudio]   - Child: {child.name}{marker}");
                        }
                    }
                    if (current.childCount > 15)
                    {
                        Plugin.Log.LogInfo($"[DirectionalAudio]   ... and {current.childCount - 15} more children");
                    }

                    current = current.parent;
                    level++;
                }

                if (playerTransform.parent == null)
                {
                    Plugin.Log.LogInfo($"[DirectionalAudio] Player has NO parent - searching known root objects...");
                    LogKnownRootObjects();
                }
                Plugin.Log.LogInfo($"[DirectionalAudio] === End Hierarchy ===");
            }
            catch (Exception e)
            {
                Plugin.Log.LogError($"[DirectionalAudio] LogPlayerHierarchy error: {e.Message}");
            }
        }

        private void LogKnownRootObjects()
        {
            string[] rootNames = {
                "World", "Level", "Map", "Game", "GameManager", "MapManager",
                "Environment", "Enemies", "Interactables", "Objects",
                "Spawned", "Generated", "Pickups", "Items", "Chests"
            };

            foreach (var name in rootNames)
            {
                try
                {
                    var obj = GameObject.Find(name);
                    if (obj != null)
                    {
                        Plugin.Log.LogInfo($"[DirectionalAudio] Found root: {name} (children: {obj.transform.childCount})");
                        for (int i = 0; i < Math.Min(5, obj.transform.childCount); i++)
                        {
                            var child = obj.transform.GetChild(i);
                            if (child != null)
                                Plugin.Log.LogInfo($"[DirectionalAudio]   - {child.name}");
                        }
                    }
                }
                catch { }
            }
        }

        private void ScanRootObjectsByName(Vector3 playerPos)
        {
            // Base names to search - we'll add Clone variations automatically
            string[] baseNames = {
                // Most important - unique objects
                "Portal", "Chest", "BossSpawner",
                // Shrines
                "Shrine", "ShrineCursed", "ShrineGreed", "ShrineMoai", "ShrineBalance",
                "CursedShrine", "GreedShrine", "MoaiShrine", "BalanceShrine",
                "ChallengeShrine",
                // Charge shrines / Pylons
                "ChargeShrine", "BossPylon", "Pylon",
                // Pots/Urns
                "PotSmall", "PotSmallSilver", "Pot", "Urn", "Vase",
                // NPCs
                "ShadyGuy", "Merchant", "NPC", "Shopkeeper",
                // Music
                "Boombox", "Microwave", "Jukebox",
                // Others
                "Coffin", "Gift", "Gravestone", "Tombstone"
            };

            foreach (var baseName in baseNames)
            {
                // Try all naming variations Unity uses
                TryFindAndCreateBeacon(baseName, playerPos);
                TryFindAndCreateBeacon(baseName + "(Clone)", playerPos);
                TryFindAndCreateBeacon(baseName + " (Clone)", playerPos);  // With space
            }
        }

        // Counter to limit chest debug logging
        private static int chestDebugCounter = 0;

        private void TryFindAndCreateBeacon(string objName, Vector3 playerPos)
        {
            try
            {
                var obj = GameObject.Find(objName);
                string lowerName = objName.ToLower();
                bool isChest = lowerName.Contains("chest");

                // Debug logging for chest specifically (every 100 scans)
                if (isChest)
                {
                    chestDebugCounter++;
                    if (chestDebugCounter % 100 == 1)
                    {
                        Plugin.Log.LogInfo($"[DirectionalAudio] DEBUG: Searching for '{objName}' - Found: {(obj != null ? "YES" : "NO")}");
                    }
                }

                if (obj == null) return;
                if (!obj.activeInHierarchy) return;

                int id = obj.GetInstanceID();

                // Skip if already have beacon
                if (activeBeacons.ContainsKey(id)) return;

                // Skip if already interacted
                if (interactedObjects.Contains(id)) return;

                // Para cofres, usar ProcessChestObject que NO verifica distancia
                if (isChest)
                {
                    ProcessChestObject(obj, playerPos);
                    // También escanear contenedor padre para encontrar más cofres
                    if (obj.transform.parent != null)
                    {
                        ScanContainerForChests(obj.transform.parent, playerPos, 0, 2);
                    }
                }
                else
                {
                    // Para otros objetos, verificar distancia
                    float distance = Vector3.Distance(playerPos, obj.transform.position);
                    if (distance <= detectionRadius)
                    {
                        string type = IdentifyType(lowerName);
                        if (type != "unknown")
                        {
                            CreateBeacon(obj, type, id);
                            Plugin.Log.LogInfo($"[DirectionalAudio] PROACTIVE found: {objName} -> {type} at dist {distance:F0}");
                        }
                    }
                }

                // Escanear hermanos para encontrar duplicados
                ScanSiblingsForDuplicates(obj, playerPos);
            }
            catch { }
        }

        /// <summary>
        /// Escanea los hermanos de un objeto para encontrar TODOS los interactables cercanos.
        /// Esto incluye duplicados del mismo tipo y otros tipos de interactables.
        /// </summary>
        private void ScanSiblingsForDuplicates(GameObject foundObj, Vector3 playerPos)
        {
            if (foundObj == null) return;

            try
            {
                var parent = foundObj.transform.parent;
                if (parent == null) return;

                // Escanear todos los hijos del padre - buscar CUALQUIER interactable
                int childCount = parent.childCount;
                for (int i = 0; i < childCount; i++)
                {
                    try
                    {
                        var sibling = parent.GetChild(i);
                        if (sibling == null || !sibling.gameObject.activeInHierarchy) continue;

                        var siblingObj = sibling.gameObject;
                        int siblingId = siblingObj.GetInstanceID();
                        if (activeBeacons.ContainsKey(siblingId) || interactedObjects.Contains(siblingId)) continue;

                        float distance = Vector3.Distance(playerPos, siblingObj.transform.position);
                        if (distance > detectionRadius) continue;

                        // Verificar si tiene BaseInteractable
                        var interactable = siblingObj.GetComponent<BaseInteractable>();
                        if (interactable != null)
                        {
                            string type = IdentifyTypeFromInteractable(interactable, siblingObj.name.ToLower());
                            if (type != "unknown")
                            {
                                CreateBeacon(siblingObj, type, siblingId);
                            }
                        }
                        else
                        {
                            // Some objects like BossPylon don't inherit from BaseInteractable
                            // Check by name pattern instead
                            string lowerName = siblingObj.name.ToLower();
                            if (lowerName.Contains("pylon") || lowerName.Contains("charge"))
                            {
                                string type = IdentifyType(lowerName);
                                if (type != "unknown")
                                {
                                    CreateBeacon(siblingObj, type, siblingId);
                                }
                            }
                        }
                    }
                    catch { }
                }
            }
            catch { }
        }

        /// <summary>
        /// Extrae el nombre base de un GameObject (sin Clone, números, etc.)
        /// Ej: "PotSmall(Clone) (2)" -> "PotSmall"
        /// </summary>
        private string GetBaseName(string fullName)
        {
            if (string.IsNullOrEmpty(fullName)) return "";

            string name = fullName;

            // Remover " (N)" al final (duplicados de Unity)
            int parenIndex = name.LastIndexOf(" (");
            if (parenIndex > 0)
            {
                string afterParen = name.Substring(parenIndex + 2);
                if (afterParen.Length > 0 && afterParen[afterParen.Length - 1] == ')')
                {
                    // Verificar si es un número
                    string numPart = afterParen.Substring(0, afterParen.Length - 1);
                    if (int.TryParse(numPart, out _))
                    {
                        name = name.Substring(0, parenIndex);
                    }
                }
            }

            // Remover "(Clone)" o " (Clone)"
            name = name.Replace("(Clone)", "").Replace(" (Clone)", "").Trim();

            return name;
        }

        // Para logging de jerarquía solo una vez
        private bool hierarchyLogged = false;

        private void ScanForInteractables()
        {
            if (playerTransform == null || !audioReady) return;

            // Solo escanear en escenas de gameplay - excluir menús
            bool isMenuScene = lastSceneName == "MainMenu" ||
                               lastSceneName == "BootScene" ||
                               lastSceneName == "LoadingScreen" ||
                               lastSceneName.Contains("Menu") ||
                               string.IsNullOrEmpty(lastSceneName);

            if (isMenuScene)
            {
                hierarchyLogged = false;
                return;
            }

            try
            {
                Vector3 playerPos = playerTransform.position;

                // Log de jerarquía del jugador (solo una vez por escena)
                if (!hierarchyLogged)
                {
                    LogPlayerHierarchy();
                    hierarchyLogged = true;
                }

                // Búsqueda por nombre
                ScanRootObjectsByName(playerPos);

                // Búsqueda específica de todos los Pickups activos en la escena
                ScanAllPickups(playerPos);

                // Búsqueda específica de todos los cofres (incluyendo gold chests)
                ScanAllChests(playerPos);

                // Escanear contenedores conocidos de interactables
                ScanInteractableContainers(playerPos);
            }
            catch (Exception e)
            {
                Plugin.Log.LogDebug($"[DirectionalAudio] ScanForInteractables error: {e.Message}");
            }
        }

        /// <summary>
        /// Escanea contenedores conocidos donde se encuentran los interactables.
        /// Esto permite encontrar TODOS los objetos, no solo el primero.
        /// </summary>
        private void ScanInteractableContainers(Vector3 playerPos)
        {
            // Nombres comunes de contenedores donde Unity/el juego coloca objetos
            string[] containerNames = {
                "Interactables", "Objects", "Props", "World", "Level",
                "Environment", "Spawned", "Generated", "Map", "Gameplay",
                "Decorations", "Breakables", "Destructibles"
            };

            foreach (var containerName in containerNames)
            {
                try
                {
                    var container = GameObject.Find(containerName);
                    if (container != null)
                    {
                        ScanContainerForInteractables(container.transform, playerPos, 0, 3);
                    }
                }
                catch { }
            }

            // También escanear desde el padre del jugador (si está en la escena)
            if (playerTransform != null && playerTransform.parent != null)
            {
                // Subir hasta la raíz de la escena y escanear
                Transform sceneRoot = playerTransform.parent;
                while (sceneRoot.parent != null)
                {
                    sceneRoot = sceneRoot.parent;
                }
                ScanContainerForInteractables(sceneRoot, playerPos, 0, 4);
            }
        }

        /// <summary>
        /// Escanea un contenedor recursivamente buscando interactables.
        /// </summary>
        private void ScanContainerForInteractables(Transform container, Vector3 playerPos, int depth, int maxDepth)
        {
            if (container == null || depth > maxDepth) return;

            try
            {
                int childCount = container.childCount;
                for (int i = 0; i < childCount; i++)
                {
                    try
                    {
                        var child = container.GetChild(i);
                        if (child == null || !child.gameObject.activeInHierarchy) continue;

                        var childObj = child.gameObject;
                        int id = childObj.GetInstanceID();

                        // Skip si ya tenemos beacon o fue interactuado
                        if (activeBeacons.ContainsKey(id) || interactedObjects.Contains(id)) continue;

                        // Verificar distancia
                        float distance = Vector3.Distance(playerPos, childObj.transform.position);
                        if (distance > detectionRadius) continue;

                        // Verificar si tiene BaseInteractable
                        var interactable = childObj.GetComponent<BaseInteractable>();
                        if (interactable != null)
                        {
                            string type = IdentifyTypeFromInteractable(interactable, childObj.name.ToLower());
                            if (type != "unknown")
                            {
                                CreateBeacon(childObj, type, id);
                            }
                        }

                        // Recursión para hijos
                        if (child.childCount > 0)
                        {
                            ScanContainerForInteractables(child, playerPos, depth + 1, maxDepth);
                        }
                    }
                    catch { }
                }
            }
            catch { }
        }

        private void ScanAllPickups(Vector3 playerPos)
        {
            try
            {
                // En IL2CPP, buscar pickups por nombres comunes de GameObject
                // Los pickups suelen tener nombres como "Pickup", "Gold", "Xp", "Health", etc.
                string[] pickupPatterns = {
                    "Pickup", "Gold", "Xp", "XP", "Health", "Borgor",
                    "Silver", "Coin", "Orb", "Drop", "Loot"
                };

                foreach (var pattern in pickupPatterns)
                {
                    try
                    {
                        // Buscar objeto directo
                        var obj = GameObject.Find(pattern);
                        if (obj != null)
                        {
                            ProcessPickupObject(obj, playerPos);
                            // Escanear hermanos si tiene padre
                            if (obj.transform.parent != null)
                            {
                                ScanChildrenForPickups(obj.transform.parent, playerPos);
                            }
                        }

                        // Buscar con (Clone)
                        var objClone = GameObject.Find(pattern + "(Clone)");
                        if (objClone != null)
                        {
                            ProcessPickupObject(objClone, playerPos);
                            if (objClone.transform.parent != null)
                            {
                                ScanChildrenForPickups(objClone.transform.parent, playerPos);
                            }
                        }
                    }
                    catch { }
                }

                // También buscar en contenedores conocidos de pickups
                string[] pickupContainers = { "Pickups", "Drops", "Loot", "Items", "Spawned" };
                foreach (var containerName in pickupContainers)
                {
                    try
                    {
                        var container = GameObject.Find(containerName);
                        if (container != null)
                        {
                            ScanChildrenForPickups(container.transform, playerPos);
                        }
                    }
                    catch { }
                }
            }
            catch (Exception e)
            {
                Plugin.Log.LogDebug($"[DirectionalAudio] ScanAllPickups error: {e.Message}");
            }
        }

        // Counter for ScanAllChests logging
        private static int chestScanCounter = 0;

        /// <summary>
        /// Búsqueda específica y agresiva de todos los cofres (incluyendo gold chests).
        /// Los gold chests son InteractableChest con precio > 0.
        /// </summary>
        private void ScanAllChests(Vector3 playerPos)
        {
            try
            {
                chestScanCounter++;
                // Log every 50 scans to confirm method is running
                if (chestScanCounter % 50 == 1)
                {
                    Plugin.Log.LogInfo($"[DirectionalAudio] ScanAllChests running (scan #{chestScanCounter})");
                }

                // Patrones de nombres para buscar cofres
                string[] chestPatterns = {
                    "Chest", "Chest(Clone)", "Chest (Clone)",
                    "GoldChest", "GoldChest(Clone)", "GoldChest (Clone)",
                    "InteractableChest", "InteractableChest(Clone)"
                };

                foreach (var pattern in chestPatterns)
                {
                    try
                    {
                        var chest = GameObject.Find(pattern);
                        if (chest != null && chest.activeInHierarchy)
                        {
                            // Procesar este cofre
                            ProcessChestObject(chest, playerPos);

                            // IMPORTANTE: Escanear el contenedor padre para encontrar TODOS los cofres
                            // incluyendo gold chests que podrían no aparecer con GameObject.Find
                            if (chest.transform.parent != null)
                            {
                                ScanContainerForChests(chest.transform.parent, playerPos, 0, 2);
                            }
                        }
                    }
                    catch { }
                }

                // También buscar en contenedores específicos de cofres
                string[] chestContainers = { "Chests", "Interactables", "Objects", "Spawned", "Generated" };
                foreach (var containerName in chestContainers)
                {
                    try
                    {
                        var container = GameObject.Find(containerName);
                        if (container != null)
                        {
                            ScanContainerForChests(container.transform, playerPos, 0, 3);
                        }
                    }
                    catch { }
                }
            }
            catch (Exception e)
            {
                Plugin.Log.LogDebug($"[DirectionalAudio] ScanAllChests error: {e.Message}");
            }
        }

        /// <summary>
        /// Escanea un contenedor específicamente buscando objetos con componente InteractableChest.
        /// </summary>
        private void ScanContainerForChests(Transform container, Vector3 playerPos, int depth, int maxDepth)
        {
            if (container == null || depth > maxDepth) return;

            try
            {
                int childCount = container.childCount;
                for (int i = 0; i < childCount; i++)
                {
                    try
                    {
                        var child = container.GetChild(i);
                        if (child == null || !child.gameObject.activeInHierarchy) continue;

                        var childObj = child.gameObject;

                        // Procesar si parece un cofre (por nombre o componente)
                        string lowerName = childObj.name.ToLower();
                        if (lowerName.Contains("chest"))
                        {
                            ProcessChestObject(childObj, playerPos);
                        }
                        else
                        {
                            // También verificar si tiene el componente InteractableChest
                            var chestComponent = childObj.GetComponent<InteractableChest>();
                            if (chestComponent != null)
                            {
                                ProcessChestObject(childObj, playerPos);
                            }
                        }

                        // Recursión para hijos
                        if (child.childCount > 0)
                        {
                            ScanContainerForChests(child, playerPos, depth + 1, maxDepth);
                        }
                    }
                    catch { }
                }
            }
            catch { }
        }

        /// <summary>
        /// Procesa un objeto cofre específico y crea un beacon si es válido.
        /// NOTA: No verificamos distancia aquí - los cofres son importantes y deben tener beacon siempre.
        /// La distancia se verifica en UpdateBeacons al reproducir el sonido.
        /// </summary>
        private void ProcessChestObject(GameObject obj, Vector3 playerPos)
        {
            if (obj == null || !obj.activeInHierarchy) return;

            int id = obj.GetInstanceID();
            if (activeBeacons.ContainsKey(id) || interactedObjects.Contains(id)) return;

            try
            {
                float distance = Vector3.Distance(playerPos, obj.transform.position);

                // Verificar si tiene el componente InteractableChest
                var chest = obj.GetComponent<InteractableChest>();
                if (chest == null)
                {
                    // También verificar como BaseInteractable genérico
                    var interactable = obj.GetComponent<BaseInteractable>();
                    if (interactable == null)
                    {
                        Plugin.Log.LogDebug($"[DirectionalAudio] Chest object {obj.name} has no InteractableChest or BaseInteractable component");
                        return;
                    }

                    // Si tiene BaseInteractable y el nombre contiene "chest", crear beacon SIN verificar distancia
                    if (obj.name.ToLower().Contains("chest"))
                    {
                        CreateBeacon(obj, "chest", id);
                        Plugin.Log.LogInfo($"[DirectionalAudio] CHEST FOUND (BaseInteractable): {obj.name} at distance {distance:F0}");
                    }
                    return;
                }

                // Tiene InteractableChest - crear beacon SIN verificar distancia
                // Log información del cofre
                try
                {
                    var chestType = chest.chestType;
                    Plugin.Log.LogInfo($"[DirectionalAudio] CHEST FOUND (InteractableChest): {obj.name}, Type: {chestType}, Distance: {distance:F0}");
                }
                catch
                {
                    Plugin.Log.LogInfo($"[DirectionalAudio] CHEST FOUND (InteractableChest): {obj.name}, Distance: {distance:F0}");
                }

                CreateBeacon(obj, "chest", id);
            }
            catch (Exception e)
            {
                Plugin.Log.LogDebug($"[DirectionalAudio] ProcessChestObject error for {obj?.name}: {e.Message}");
            }
        }

        private void ScanChildrenForPickups(Transform parent, Vector3 playerPos)
        {
            if (parent == null) return;

            try
            {
                for (int i = 0; i < parent.childCount; i++)
                {
                    var child = parent.GetChild(i);
                    if (child == null) continue;

                    ProcessPickupObject(child.gameObject, playerPos);

                    // Recursión limitada
                    if (child.childCount > 0)
                    {
                        ScanChildrenForPickups(child, playerPos);
                    }
                }
            }
            catch { }
        }

        private void ProcessPickupObject(GameObject obj, Vector3 playerPos)
        {
            if (obj == null || !obj.activeInHierarchy) return;

            int id = obj.GetInstanceID();
            if (activeBeacons.ContainsKey(id)) return;

            try
            {
                // Verificar si tiene componente Pickup
                var pickup = obj.GetComponent<Pickup>();
                if (pickup == null) return;

                float distance = Vector3.Distance(playerPos, obj.transform.position);
                if (distance > detectionRadius) return;

                string type = IdentifyTypeFromPickup(pickup);
                if (type != "unknown")
                {
                    CreateBeacon(obj, type, id);
                    Plugin.Log.LogInfo($"[DirectionalAudio] Found pickup: {obj.name} -> {type}");
                }
            }
            catch { }
        }

        private void ScanAllChildren(Transform parent, Vector3 playerPos)
        {
            if (parent == null) return;

            try
            {
                // Procesar el padre también
                ProcessFoundObject(parent.gameObject, playerPos);

                // Escanear todos los hijos recursivamente (profundidad 10)
                ScanChildrenRecursive(parent, playerPos, 0, 10);
            }
            catch { }
        }

        private void ScanChildrenRecursive(Transform parent, Vector3 playerPos, int depth, int maxDepth)
        {
            if (parent == null || depth > maxDepth) return;

            try
            {
                for (int i = 0; i < parent.childCount; i++)
                {
                    var child = parent.GetChild(i);
                    if (child == null) continue;

                    // Intentar procesar TODOS los objetos, no solo los que coinciden por nombre
                    ProcessFoundObject(child.gameObject, playerPos);

                    // Recursión para hijos
                    if (child.childCount > 0)
                    {
                        ScanChildrenRecursive(child, playerPos, depth + 1, maxDepth);
                    }
                }
            }
            catch { }
        }

        // Counter para limitar logging
        private int scanLogCounter = 0;

        private void ProcessFoundObject(GameObject obj, Vector3 playerPos)
        {
            if (obj == null) return;

            int id = obj.GetInstanceID();
            if (activeBeacons.ContainsKey(id)) return;

            try
            {
                float distance = Vector3.Distance(playerPos, obj.transform.position);
                if (distance > detectionRadius) return;

                string type = "unknown";

                // Primero verificar si es un Pickup (item suelto en el suelo)
                var pickup = obj.GetComponent<Pickup>();
                if (pickup != null)
                {
                    type = IdentifyTypeFromPickup(pickup);
                    Plugin.Log.LogInfo($"[DirectionalAudio] Found Pickup: {obj.name} -> {type}");
                }
                else
                {
                    // Si no es Pickup, verificar si es BaseInteractable
                    var interactable = obj.GetComponent<BaseInteractable>();
                    if (interactable != null)
                    {
                        type = IdentifyTypeFromInteractable(interactable, obj.name.ToLower());
                        Plugin.Log.LogInfo($"[DirectionalAudio] Found Interactable: {obj.name} -> {type}");
                    }
                }

                if (type != "unknown")
                {
                    CreateBeacon(obj, type, id);
                }
            }
            catch (Exception e)
            {
                // Log solo ocasionalmente para no llenar el log
                if (scanLogCounter++ % 100 == 0)
                {
                    Plugin.Log.LogDebug($"[DirectionalAudio] ProcessFoundObject error on {obj?.name}: {e.Message}");
                }
            }
        }

        private string IdentifyTypeFromPickup(Pickup pickup)
        {
            try
            {
                EPickup pickupType = pickup.ePickup;

                switch (pickupType)
                {
                    case EPickup.Xp:
                        return "pickup_xp";
                    case EPickup.Gold:
                        return "pickup_gold";
                    case EPickup.Health:
                        return "pickup_health";
                    case EPickup.Silver:
                        return "pickup_silver";
                    // Special powerups
                    case EPickup.Nuke:
                    case EPickup.Shield:
                    case EPickup.Rage:
                    case EPickup.Haste:
                    case EPickup.Magnet:
                    case EPickup.Time:
                    case EPickup.Stonks:
                        return "pickup_special";
                    default:
                        return "pickup_xp"; // Default to XP sound
                }
            }
            catch
            {
                return "pickup_xp";
            }
        }

        private string IdentifyType(string name)
        {
            if (name.Contains("chest")) return "chest";
            // Shrines including charge shrines and pylons
            if (name.Contains("shrine") || name.Contains("moai") || name.Contains("charge") || name.Contains("pylon")) return "shrine";
            if (name.Contains("portal")) return "portal";
            if (name.Contains("borgor") || name.Contains("health") || name.Contains("gift")) return "health";
            if (name.Contains("gold") || name.Contains("coin")) return "gold";
            // Vasijas/Pots
            if (name.Contains("pot") || name.Contains("urn") || name.Contains("vase") || name.Contains("jar") || name.Contains("breakable")) return "urn";
            if (name.Contains("music") || name.Contains("jukebox") || name.Contains("boombox") || name.Contains("microwave")) return "music";
            if (name.Contains("npc") || name.Contains("merchant") || name.Contains("shop") || name.Contains("vendor") || name.Contains("shady") || name.Contains("character")) return "npc";
            // Boss spawner and special portals
            if (name.Contains("boss") || name.Contains("spawner") || name.Contains("ghost")) return "portal";
            // Crypt/Tomb/Coffin - use shrine sound (mysterious)
            if (name.Contains("crypt") || name.Contains("coffin") || name.Contains("tomb") || name.Contains("grave") || name.Contains("statue") || name.Contains("skeleton")) return "shrine";
            // Cages - use default
            if (name.Contains("cage") || name.Contains("unlock")) return "default";
            // Environmental interactables
            if (name.Contains("tumbleweed") || name.Contains("bananarang")) return "default";
            if (name.Contains("interactable")) return "default";
            return "unknown";
        }

        private string IdentifyTypeFromInteractable(BaseInteractable interactable, string objName)
        {
            // Primero intentar por nombre del objeto (más confiable)
            string typeFromName = IdentifyType(objName);
            if (typeFromName != "unknown") return typeFromName;

            // También verificar el nombre del tipo de componente
            string typeName = interactable.GetType().Name.ToLower();
            if (typeName.Contains("chest")) return "chest";
            if (typeName.Contains("shrine")) return "shrine";
            if (typeName.Contains("portal")) return "portal";
            if (typeName.Contains("pot")) return "urn";
            if (typeName.Contains("npc") || typeName.Contains("merchant") || typeName.Contains("shady")) return "npc";

            // Si no encontramos por nombre, intentar obtener el texto de interacción
            // Wrapped in try-catch because GetInteractString() can throw errors
            // (e.g., when player stats aren't available in menu)
            string interactText = null;
            try
            {
                interactText = interactable.GetInteractString();
            }
            catch
            {
                // GetInteractString failed, use default type
                return "default";
            }

            if (!string.IsNullOrEmpty(interactText))
            {
                string lowerText = interactText.ToLower();

                // Español e inglés para cofres/chests
                if (lowerText.Contains("chest") || lowerText.Contains("cofre") ||
                    lowerText.Contains("baúl") || lowerText.Contains("baul") ||
                    lowerText.Contains("open") || lowerText.Contains("abrir") ||
                    lowerText.Contains("oro") || lowerText.Contains("gold"))
                    return "chest";

                // Español e inglés para santuarios
                if (lowerText.Contains("shrine") || lowerText.Contains("santuario") ||
                    lowerText.Contains("altar") || lowerText.Contains("pray") ||
                    lowerText.Contains("rezar") || lowerText.Contains("orar"))
                    return "shrine";

                // Español e inglés para portales
                if (lowerText.Contains("portal") || lowerText.Contains("door") ||
                    lowerText.Contains("puerta") || lowerText.Contains("enter") ||
                    lowerText.Contains("entrar") || lowerText.Contains("exit") ||
                    lowerText.Contains("salir") || lowerText.Contains("next"))
                    return "portal";

                // Español e inglés para vasijas/urnas (objetos rompibles)
                if (lowerText.Contains("urn") || lowerText.Contains("urna") ||
                    lowerText.Contains("vase") || lowerText.Contains("vasija") ||
                    lowerText.Contains("jar") || lowerText.Contains("jarra") ||
                    lowerText.Contains("break") || lowerText.Contains("rompe") ||
                    lowerText.Contains("destroy") || lowerText.Contains("destruir") ||
                    lowerText.Contains("pot") || lowerText.Contains("olla"))
                    return "urn";

                // Español e inglés para comida/salud
                if (lowerText.Contains("health") || lowerText.Contains("salud") ||
                    lowerText.Contains("heal") || lowerText.Contains("curar") ||
                    lowerText.Contains("food") || lowerText.Contains("comida") ||
                    lowerText.Contains("borgor") || lowerText.Contains("burger") ||
                    lowerText.Contains("hamburguesa"))
                    return "health";

                // NPCs/merchants
                if (lowerText.Contains("npc") || lowerText.Contains("merchant") ||
                    lowerText.Contains("shop") || lowerText.Contains("tienda") ||
                    lowerText.Contains("vendor") || lowerText.Contains("vendedor") ||
                    lowerText.Contains("talk") || lowerText.Contains("hablar") ||
                    lowerText.Contains("buy") || lowerText.Contains("comprar"))
                    return "npc";

                // Música
                if (lowerText.Contains("music") || lowerText.Contains("música") ||
                    lowerText.Contains("musica") || lowerText.Contains("jukebox") ||
                    lowerText.Contains("play") || lowerText.Contains("listen") ||
                    lowerText.Contains("escuchar"))
                    return "music";

                Plugin.Log.LogDebug($"[DirectionalAudio] Unknown interactable: {objName} -> {interactText}");
            }

            // Si hay cualquier interactuable, darle sonido default
            return "default";
        }

        private void CreateBeacon(GameObject target, string type, int id)
        {
            // Check for duplicate position
            Vector3 pos = target.transform.position;
            string posKey = $"{pos.x:F1}_{pos.y:F1}_{pos.z:F1}";
            if (activePositions.Contains(posKey))
            {
                return; // Already have a beacon at this position
            }

            // Obtener clip específico para este tipo, o usar el default
            AudioClip clipToUse = null;
            if (typeClips.ContainsKey(type))
                clipToUse = typeClips[type];
            else if (defaultClip != null)
                clipToUse = defaultClip;

            if (clipToUse == null) return;

            try
            {
                // Obtener configuración para este tipo
                var config = typeConfigs.ContainsKey(type) ? typeConfigs[type] : typeConfigs["default"];

                // Crear GameObject con AudioSource en la posición del objetivo
                var audioObj = new GameObject($"Beacon_{type}_{id}");
                audioObj.transform.position = pos;

                // NO usar DontDestroyOnLoad para los beacons individuales
                // Esto permite que se limpien naturalmente con la escena

                var source = audioObj.AddComponent<AudioSource>();
                source.clip = clipToUse;
                source.spatialBlend = 1.0f;  // 100% 3D
                source.rolloffMode = AudioRolloffMode.Linear;
                source.minDistance = 1f;
                source.maxDistance = detectionRadius;
                source.dopplerLevel = 0f;
                source.spread = 60f;
                source.pitch = config.pitch;
                source.volume = config.volume;
                source.loop = false;
                source.playOnAwake = false;

                var beacon = new AudioBeaconData
                {
                    Target = target,
                    AudioObject = audioObj,
                    Source = source,
                    Type = type,
                    Pitch = config.pitch,
                    Interval = config.interval,
                    Volume = config.volume,
                    NextPlayTime = Time.time + UnityEngine.Random.Range(0f, config.interval),
                    PosKey = posKey
                };

                activeBeacons[id] = beacon;
                activePositions.Add(posKey);
                Plugin.Log.LogInfo($"[DirectionalAudio] Created beacon for {type} at {pos} (clip: {clipToUse.name})");
            }
            catch (Exception e)
            {
                Plugin.Log.LogError($"[DirectionalAudio] CreateBeacon error: {e.Message}");
            }
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

            // 2. Chest window open check (entire duration, not just animation)
            if (ChestAnimationTracker.IsChestWindowOpen || ChestAnimationTracker.IsChestAnimationPlaying)
            {
                return true;
            }

            // 3. MenuStateTracker - checks for upgrade buttons, chest windows, etc.
            if (MenuStateTracker.IsAnyMenuOpen)
            {
                return true;
            }

            // 3.5. EncounterMenuTracker - checks for shrine/encounter menus
            if (EncounterMenuTracker.IsEncounterMenuOpen)
            {
                return true;
            }

            // 4. DeathCamera check - cached reference
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

            // 5. Death screen detection - check for death-related buttons
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

        private void UpdateBeacons()
        {
            if (playerTransform == null || !audioReady) return;

            // Wait for scene start delay (cinematic/intro)
            if (Time.time - sceneLoadTime < sceneStartDelay)
            {
                return;
            }

            // No reproducir sonidos si hay un menú abierto
            if (IsMenuOpen())
            {
                return;
            }

            Vector3 playerPos = playerTransform.position;

            foreach (var kvp in activeBeacons)
            {
                var beacon = kvp.Value;
                if (beacon == null || beacon.Source == null || beacon.AudioObject == null) continue;

                try
                {
                    // Intentar actualizar posición desde el Target si existe
                    try
                    {
                        if (beacon.Target != null)
                        {
                            var targetPos = beacon.Target.transform.position;
                            beacon.AudioObject.transform.position = targetPos;
                        }
                    }
                    catch
                    {
                        // Target fue destruido, pero seguimos usando la última posición conocida
                    }

                    // Usar la posición actual del AudioObject (última conocida)
                    var beaconPos = beacon.AudioObject.transform.position;

                    // Calcular distancia
                    float distance = Vector3.Distance(playerPos, beaconPos);
                    if (distance > detectionRadius) continue;

                    // Verificar que el AudioSource tenga clip - usar el clip específico del tipo
                    if (beacon.Source.clip == null)
                    {
                        if (typeClips.ContainsKey(beacon.Type))
                            beacon.Source.clip = typeClips[beacon.Type];
                        else if (defaultClip != null)
                            beacon.Source.clip = defaultClip;
                    }

                    // Intervalo dinámico basado en distancia
                    float dynamicInterval = beacon.Interval * (0.3f + (distance / detectionRadius) * 0.7f);

                    // Reproducir si es tiempo
                    if (Time.time >= beacon.NextPlayTime)
                    {
                        // Verificar que todo siga válido antes de reproducir
                        if (beacon.Source.clip == null)
                        {
                            Plugin.Log.LogWarning($"[DirectionalAudio] Beacon {beacon.Type} lost clip, reassigning...");
                            if (typeClips.ContainsKey(beacon.Type))
                                beacon.Source.clip = typeClips[beacon.Type];
                            else if (defaultClip != null)
                                beacon.Source.clip = defaultClip;
                        }

                        if (beacon.Source.clip != null)
                        {
                            beacon.Source.Play();
                            Plugin.Log.LogDebug($"[DirectionalAudio] Playing {beacon.Type} (clip: {beacon.Source.clip.name}) at dist {distance:F0}");
                        }
                        else
                        {
                            Plugin.Log.LogWarning($"[DirectionalAudio] Beacon {beacon.Type} has no clip!");
                        }
                        beacon.NextPlayTime = Time.time + dynamicInterval;
                    }
                }
                catch (Exception e)
                {
                    Plugin.Log.LogWarning($"[DirectionalAudio] Beacon update error: {e.Message}");
                }
            }
        }

        private void CleanupBeacons()
        {
            // Limpiar beacons de objetos destruidos
            var toRemove = new List<int>();

            foreach (var kvp in activeBeacons)
            {
                try
                {
                    var beacon = kvp.Value;
                    if (beacon == null)
                    {
                        toRemove.Add(kvp.Key);
                        continue;
                    }

                    // Verificar si nuestro AudioObject sigue existiendo
                    try
                    {
                        if (beacon.AudioObject == null)
                        {
                            toRemove.Add(kvp.Key);
                            continue;
                        }
                        // Intentar acceder - si falla, nuestro objeto fue destruido
                        var _ = beacon.AudioObject.transform.position;
                    }
                    catch
                    {
                        toRemove.Add(kvp.Key);
                        continue;
                    }

                    // IMPORTANTE: Verificar si el Target fue destruido o desactivado
                    // Esto aplica a TODOS los beacons, no solo pickups
                    try
                    {
                        if (beacon.Target == null || !beacon.Target.activeInHierarchy)
                        {
                            // Target fue destruido o desactivado, eliminar beacon
                            if (beacon.AudioObject != null)
                            {
                                UnityEngine.Object.Destroy(beacon.AudioObject);
                            }
                            if (!string.IsNullOrEmpty(beacon.PosKey))
                            {
                                activePositions.Remove(beacon.PosKey);
                            }
                            toRemove.Add(kvp.Key);
                            Plugin.Log.LogDebug($"[DirectionalAudio] Removed beacon for destroyed object: {beacon.Type}");
                            continue;
                        }

                        // Verificar si el interactable ya no puede ser interactuado (fue usado)
                        // Esto captura casos como BossSpawner que permanece activo pero ya fue usado
                        if (!beacon.Type.StartsWith("pickup_"))
                        {
                            var interactable = beacon.Target.GetComponent<BaseInteractable>();
                            if (interactable != null)
                            {
                                try
                                {
                                    if (!interactable.CanInteract())
                                    {
                                        // El interactable ya no puede ser usado, eliminar beacon
                                        if (beacon.AudioObject != null)
                                        {
                                            UnityEngine.Object.Destroy(beacon.AudioObject);
                                        }
                                        if (!string.IsNullOrEmpty(beacon.PosKey))
                                        {
                                            activePositions.Remove(beacon.PosKey);
                                        }
                                        toRemove.Add(kvp.Key);
                                        Plugin.Log.LogDebug($"[DirectionalAudio] Removed beacon for used interactable: {beacon.Type}");
                                        continue;
                                    }
                                }
                                catch { } // CanInteract puede fallar, ignorar
                            }
                        }
                    }
                    catch
                    {
                        // Target fue destruido, eliminar beacon
                        if (beacon.AudioObject != null)
                        {
                            try { UnityEngine.Object.Destroy(beacon.AudioObject); } catch { }
                        }
                        if (!string.IsNullOrEmpty(beacon.PosKey))
                        {
                            activePositions.Remove(beacon.PosKey);
                        }
                        toRemove.Add(kvp.Key);
                        continue;
                    }

                    // Verificación adicional para pickups
                    if (beacon.Type.StartsWith("pickup_"))
                    {
                        try
                        {
                            // Si el target es null o fue destruido, eliminar beacon
                            if (beacon.Target == null || !beacon.Target.activeInHierarchy)
                            {
                                if (beacon.AudioObject != null)
                                {
                                    UnityEngine.Object.Destroy(beacon.AudioObject);
                                }
                                toRemove.Add(kvp.Key);
                                Plugin.Log.LogDebug($"[DirectionalAudio] Removed beacon for collected/destroyed pickup");
                                continue;
                            }
                        }
                        catch
                        {
                            // El objeto fue destruido, eliminar beacon
                            if (beacon.AudioObject != null)
                            {
                                try { UnityEngine.Object.Destroy(beacon.AudioObject); } catch { }
                            }
                            toRemove.Add(kvp.Key);
                        }
                    }
                }
                catch
                {
                    toRemove.Add(kvp.Key);
                }
            }

            foreach (var id in toRemove)
            {
                try
                {
                    if (activeBeacons.TryGetValue(id, out var beacon))
                    {
                        // Remove position from tracking
                        if (!string.IsNullOrEmpty(beacon?.PosKey))
                        {
                            activePositions.Remove(beacon.PosKey);
                        }
                        Plugin.Log.LogInfo($"[DirectionalAudio] Removed beacon (AudioObject destroyed): {beacon?.Type}");
                    }
                }
                catch { }
                activeBeacons.Remove(id);
            }
        }

        /// <summary>
        /// Registra un interactuable descubierto (llamado desde BaseInteractablePatch)
        /// Solo registra si NO existe ya un beacon (evita crear después de interacción)
        /// También escanea hermanos para encontrar objetos similares cercanos.
        /// </summary>
        public void RegisterDiscoveredInteractable(BaseInteractable interactable)
        {
            if (interactable == null || !audioReady) return;
            if (playerTransform == null) return;

            // Solo en gameplay
            bool isMenuScene = lastSceneName == "MainMenu" ||
                               lastSceneName == "BootScene" ||
                               lastSceneName == "LoadingScreen" ||
                               lastSceneName.Contains("Menu") ||
                               string.IsNullOrEmpty(lastSceneName);
            if (isMenuScene) return;

            try
            {
                var obj = interactable.gameObject;
                if (obj == null) return;

                int id = obj.GetInstanceID();
                Vector3 playerPos = playerTransform.position;

                // Registrar este objeto si no existe beacon ni fue interactuado
                if (!activeBeacons.ContainsKey(id) && !interactedObjects.Contains(id))
                {
                    float distance = Vector3.Distance(playerPos, obj.transform.position);
                    if (distance <= detectionRadius)
                    {
                        string type = IdentifyTypeFromInteractable(interactable, obj.name.ToLower());
                        if (type != "unknown")
                        {
                            CreateBeacon(obj, type, id);
                            Plugin.Log.LogInfo($"[DirectionalAudio] Registered via hover: {type} at {obj.transform.position}");
                        }
                    }
                }

                // IMPORTANTE: Escanear hermanos para encontrar objetos similares
                // Esto permite descubrir todos los pots/chests cuando el jugador encuentra uno
                ScanSiblingsForDuplicates(obj, playerPos);
            }
            catch (Exception e)
            {
                Plugin.Log.LogDebug($"[DirectionalAudio] RegisterDiscoveredInteractable error: {e.Message}");
            }
        }

        /// <summary>
        /// Quita el beacon de un interactuable después de interactuar con él
        /// </summary>
        public void RemoveInteractedBeacon(BaseInteractable interactable)
        {
            if (interactable == null) return;

            try
            {
                var obj = interactable.gameObject;
                if (obj == null) return;

                int id = obj.GetInstanceID();

                // Marcar como interactuado para no volver a crear beacon
                interactedObjects.Add(id);

                // Quitar beacon si existe
                if (activeBeacons.TryGetValue(id, out var beacon))
                {
                    if (beacon?.AudioObject != null)
                    {
                        UnityEngine.Object.Destroy(beacon.AudioObject);
                    }
                    if (!string.IsNullOrEmpty(beacon?.PosKey))
                    {
                        activePositions.Remove(beacon.PosKey);
                    }
                    activeBeacons.Remove(id);
                    Plugin.Log.LogInfo($"[DirectionalAudio] Removed beacon after interaction: {obj.name}");
                }
            }
            catch (Exception e)
            {
                Plugin.Log.LogDebug($"[DirectionalAudio] RemoveInteractedBeacon error: {e.Message}");
            }
        }

        void OnDestroy()
        {
            foreach (var beacon in activeBeacons.Values)
            {
                try
                {
                    if (beacon?.AudioObject != null)
                    {
                        Destroy(beacon.AudioObject);
                    }
                }
                catch { }
            }
            activeBeacons.Clear();
            Instance = null;
            Plugin.Log.LogInfo("[DirectionalAudio] Destroyed");
        }
    }
}
