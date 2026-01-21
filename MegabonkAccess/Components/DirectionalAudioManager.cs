using System;
using System.Collections.Generic;
using UnityEngine;
using Il2CppInterop.Runtime.Injection;
using Il2CppInterop.Runtime;
using Assets.Scripts.Inventory__Items__Pickups.Pickups;
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
        private float detectionRadius = 120f;  // Increased 150%
        private float nextScanTime = 0f;
        private float nextAudioSearchTime = 0f;

        // Jugador
        private Transform playerTransform = null;
        private float nextPlayerSearchTime = 0f;

        // Scene tracking
        private string lastSceneName = "";
        private float sceneLoadTime = 0f;
        private float sceneStartDelay = 4f;  // Wait 4 seconds after scene load before playing beacons

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
                    Plugin.Log.LogDebug($"[DirectionalAudio] Using camera position (no player found)");
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
            // Base names for interactables (without Clone suffix)
            string[] baseNames = {
                // Shrines/Santuarios (both naming conventions)
                "ShrineMaoi", "ShrineBalance", "ShrineChallenge",
                "ShrineGreed", "ShrineCursed", "ShrineMagnet", "Shrine",
                "ShrineHealth", "ShrineGold", "ShrinePower", "ShrineSpeed",
                "CursedShrine", "GreedShrine", "BalanceShrine", "MagnetShrine",
                "ChallengeShrine", "MaoiShrine", "HealthShrine", "GoldShrine",
                // Chests/Cofres
                "Chest", "ChestSmall", "ChestBig", "ChestGold", "ChestSilver",
                "TreasureChest", "GoldChest", "SilverChest",
                "SmallChest", "BigChest",
                // Portals
                "Portal", "PortalFinal", "ExitPortal", "BossPortal",
                // Pots/Vasijas (all combinations)
                "Pot", "PotSmall", "PotBig", "PotSilver", "PotGold",
                "PotSmallSilver", "PotSmallGold", "PotBigSilver", "PotBigGold",
                "SmallPot", "BigPot", "SilverPot", "GoldPot",
                "Urn", "Vase", "Jar", "Breakable",
                // NPCs
                "NPC", "Merchant", "ShadyGuy", "Vendor", "Shopkeeper",
                // Music/Revienta música
                "Boombox", "Microwave", "MusicBuster", "MusicBox",
                "Jukebox", "Radio", "Speaker", "MusicPlayer",
                // Otros
                "Borgor", "Health", "Gift", "HealthPickup",
                "Coffin", "Crypt", "Cage", "Tomb",
                "BossSpawner", "Gravestone", "Statue",
                "Interactable", "Interactive"
            };

            foreach (var baseName in baseNames)
            {
                // Try multiple naming patterns that Unity uses
                string[] patterns = {
                    baseName,
                    baseName + "(Clone)",
                    baseName + " (Clone)",
                };

                // Also try numbered variants (Unity names duplicates this way)
                for (int i = 1; i <= 20; i++)
                {
                    TryFindAndCreateBeacon($"{baseName}(Clone) ({i})", playerPos);
                    TryFindAndCreateBeacon($"{baseName} (Clone) ({i})", playerPos);
                    TryFindAndCreateBeacon($"{baseName} ({i})", playerPos);
                }

                foreach (var pattern in patterns)
                {
                    TryFindAndCreateBeacon(pattern, playerPos);
                }
            }
        }

        private void TryFindAndCreateBeacon(string objName, Vector3 playerPos)
        {
            try
            {
                var obj = GameObject.Find(objName);
                if (obj == null || !obj.activeInHierarchy) return;

                int id = obj.GetInstanceID();
                if (activeBeacons.ContainsKey(id)) return;

                float distance = Vector3.Distance(playerPos, obj.transform.position);
                if (distance > detectionRadius) return;

                string type = IdentifyType(objName.ToLower());
                if (type != "unknown")
                {
                    CreateBeacon(obj, type, id);
                    Plugin.Log.LogInfo($"[DirectionalAudio] Created beacon: {objName} -> {type} at dist {distance:F0}");
                }
            }
            catch { }

            // También buscar por prefijos comunes (sin Clone exacto)
            string[] prefixes = {
                "Shrine", "Chest", "Portal", "Pot", "NPC", "Borgor",
                "Interactable", "Pickup", "Health", "Gold"
            };

            foreach (var prefix in prefixes)
            {
                try
                {
                    // Intentar variaciones comunes
                    var obj = GameObject.Find(prefix);
                    if (obj != null) ProcessFoundObject(obj, playerPos);

                    obj = GameObject.Find(prefix + "(Clone)");
                    if (obj != null) ProcessFoundObject(obj, playerPos);
                }
                catch { }
            }
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
            }
            catch (Exception e)
            {
                Plugin.Log.LogDebug($"[DirectionalAudio] ScanForInteractables error: {e.Message}");
            }
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
            if (name.Contains("shrine") || name.Contains("moai")) return "shrine";
            if (name.Contains("portal")) return "portal";
            if (name.Contains("borgor") || name.Contains("health")) return "health";
            if (name.Contains("gold") || name.Contains("coin")) return "gold";
            // Vasijas/Pots
            if (name.Contains("pot") || name.Contains("urn") || name.Contains("vase") || name.Contains("jar") || name.Contains("breakable")) return "urn";
            if (name.Contains("music") || name.Contains("jukebox") || name.Contains("boombox") || name.Contains("microwave")) return "music";
            if (name.Contains("npc") || name.Contains("merchant") || name.Contains("shop") || name.Contains("vendor") || name.Contains("shady")) return "npc";
            // Boss spawner
            if (name.Contains("boss") || name.Contains("spawner")) return "portal";
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
            // Check if game is paused (pause menu, any modal dialog)
            if (Time.timeScale < 0.1f)
            {
                Plugin.Log.LogDebug($"[DirectionalAudio] Menu detected: TimeScale={Time.timeScale}");
                return true;
            }

            // Check MenuStateTracker flags (for upgrade/chest menus)
            if (MenuStateTracker.IsAnyMenuOpen)
            {
                Plugin.Log.LogDebug("[DirectionalAudio] Menu detected: MenuStateTracker");
                return true;
            }

            // Check if Player object exists and is active
            try
            {
                var player = GameObject.Find("Player");
                if (player == null || !player.activeInHierarchy)
                {
                    Plugin.Log.LogDebug("[DirectionalAudio] Menu detected: Player not found/inactive");
                    return true;
                }
            }
            catch { }


            // Check for DeathCamera directly (death animation)
            try
            {
                var deathCam = GameObject.Find("DeathCamera");
                if (deathCam != null && deathCam.activeInHierarchy)
                {
                    var camComponent = deathCam.GetComponent<Camera>();
                    if (camComponent != null && camComponent.enabled)
                    {
                        Plugin.Log.LogDebug("[DirectionalAudio] Animation detected: DeathCamera active");
                        return true;
                    }
                }
            }
            catch { }

            // Check Camera.main - log what it is for debugging
            try
            {
                var mainCam = Camera.main;
                if (mainCam != null)
                {
                    string camName = mainCam.gameObject.name;
                    // If it's DeathCamera or any camera other than the main gameplay camera
                    if (camName.Contains("Death") || camName.Contains("death"))
                    {
                        Plugin.Log.LogDebug($"[DirectionalAudio] Menu detected: Camera is {camName}");
                        return true;
                    }
                }
                else
                {
                    // No main camera - probably in a menu/transition
                    Plugin.Log.LogDebug("[DirectionalAudio] Menu detected: No main camera");
                    return true;
                }
            }
            catch { }

            // Check for death/stats screens and item windows
            // NOTE: "DeathScreen" and "DeathPanel" removed - they always exist (just hidden)
            // We detect death via the DeathCamera check above
            try
            {
                string[] menuWindowNames = {
                    // Death/Stats screens (only ones that are actually destroyed/created dynamically)
                    "StatsScreen", "DeathStats", "RunStats", "EndScreen", "EndRunScreen",
                    "GameOverScreen", "GameOver", "ResultScreen", "ResultsScreen",
                    "RunEndScreen", "RunEnd", "ScoreScreen", "FinalStats", "RunSummary", "Summary",
                    // Item windows
                    "ItemWindow", "ItemWindowUi", "RewardWindow", "RewardPanel",
                    "LootWindow", "LootPanel", "PickupWindow", "ItemPickup",
                    "ChestReward", "ChestItem", "ItemPanel"
                };

                foreach (var windowName in menuWindowNames)
                {
                    var window = GameObject.Find(windowName);
                    if (window != null && window.activeInHierarchy)
                    {
                        Plugin.Log.LogDebug($"[DirectionalAudio] Menu detected: {windowName}");
                        return true;
                    }
                }
            }
            catch { }

            // Check for death-specific buttons that only appear when death screen is visible
            try
            {
                string[] deathButtons = {
                    "ContinueButton", "Continue", "RestartButton", "Restart",
                    "RetryButton", "Retry", "MainMenuButton", "MainMenu",
                    "QuitButton", "StatsButton", "NextButton", "ProceedButton",
                    "SkipButton", "EndRunButton", "ViewStatsButton"
                };

                foreach (var buttonName in deathButtons)
                {
                    var btn = GameObject.Find(buttonName);
                    if (btn != null && btn.activeInHierarchy)
                    {
                        Plugin.Log.LogDebug($"[DirectionalAudio] Menu detected: Death button - {buttonName}");
                        return true;
                    }
                }
            }
            catch { }

            // Check for EventSystem - if it has a selected object, a UI is focused
            try
            {
                var eventSystem = UnityEngine.EventSystems.EventSystem.current;
                if (eventSystem != null && eventSystem.currentSelectedGameObject != null)
                {
                    string selectedName = eventSystem.currentSelectedGameObject.name.ToLower();
                    // If a button or UI element is selected, we're probably in a menu
                    // Including death-related buttons
                    if (selectedName.Contains("button") || selectedName.Contains("resume") ||
                        selectedName.Contains("quit") || selectedName.Contains("option") ||
                        selectedName.Contains("setting") || selectedName.Contains("pause") ||
                        selectedName.Contains("take") || selectedName.Contains("leave") ||
                        selectedName.Contains("discard") || selectedName.Contains("banish") ||
                        selectedName.Contains("continue") || selectedName.Contains("restart") ||
                        selectedName.Contains("retry") || selectedName.Contains("stats") ||
                        selectedName.Contains("menu") || selectedName.Contains("skip") ||
                        selectedName.Contains("next") || selectedName.Contains("proceed"))
                    {
                        Plugin.Log.LogDebug($"[DirectionalAudio] Menu detected: UI selected - {selectedName}");
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
                Plugin.Log.LogDebug("[DirectionalAudio] UpdateBeacons skipped - menu is open");
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

                // Si ya existe un beacon O si ya fue interactuado, no registrar
                if (activeBeacons.ContainsKey(id) || interactedObjects.Contains(id)) return;

                Vector3 playerPos = playerTransform.position;
                float distance = Vector3.Distance(playerPos, obj.transform.position);
                if (distance > detectionRadius) return;

                string type = IdentifyTypeFromInteractable(interactable, obj.name.ToLower());
                if (type != "unknown")
                {
                    CreateBeacon(obj, type, id);
                    Plugin.Log.LogInfo($"[DirectionalAudio] Registered via hover: {type} at {obj.transform.position}");
                }
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
