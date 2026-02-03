using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Il2CppInterop.Runtime.Injection;
using Assets.Scripts.Actors.Enemies;
using MegabonkAccess.Patches;

namespace MegabonkAccess.Components
{
    /// <summary>
    /// Sistema automático de anuncios de enemigos cercanos para accesibilidad.
    /// Busca enemigos por nombre de GameObject (compatible con IL2CPP).
    /// </summary>
    public class EnemyAnnouncementSystem : MonoBehaviour
    {
        public static EnemyAnnouncementSystem Instance { get; private set; }

        // Configuración
        private float dangerDistance = 20f;           // Distance to consider "close"
        private float maxTrackingDistance = 50f;      // Max distance to track enemies
        private float directionChangeCooldown = 3f;   // Cooldown between direction announcements
        private float threatAnnounceCooldown = 4f;    // Cooldown between threat announcements
        private float directionChangeThreshold = 45f; // Degrees to trigger direction change
        private float enemyScanInterval = 0.5f;

        // Estado
        private float lastDirectionAnnounceTime = 0f;
        private float lastThreatAnnounceTime = 0f;
        private float nextEnemyScanTime = 0f;
        private float nextThreatLogTime = 0f;
        private Vector3 lastForwardDirection = Vector3.forward;
        private HashSet<int> knownCloseEnemies = new HashSet<int>();
        private HashSet<int> knownBossesElites = new HashSet<int>();
        private string lastAnnouncedContent = "";

        // Cache de enemigos encontrados
        private List<Enemy> cachedEnemies = new List<Enemy>();

        // Referencias
        private Transform playerTransform = null;
        private Transform cameraTransform = null;
        private float nextPlayerSearchTime = 0f;

        // Scene tracking
        private string lastSceneName = "";
        private float sceneLoadTime = 0f;
        private float sceneStartDelay = 4f;

        // Nombres de enemigos para buscar (basado en EEnemy enum)
        private static readonly string[] EnemyNames = {
            "Skeleton", "GoldenSkeleton", "XpSkeleton", "ArmoredSkeleton",
            "SkeletonDusty", "ArmoredSkeletonDusty", "Ghoul", "MinibossPig",
            "Mummy", "Slime", "Goblin", "GoblinStrong", "GoblinTank",
            "MinibossGolem", "Ghost", "GreaterGhost", "SkeletonMage",
            "Ent1", "Ent2", "Ent3", "BoomerSpider", "Golem", "Bee",
            "MinibossGolemSand", "Scorpion", "MinibossScorpion", "Wisp",
            "CactusShooter", "ScorpionMedium", "MummyTank", "MummyAncient",
            "Tumblebone", "Pharaoh1", "Pharaoh2", "Pharaoh3", "Bandit",
            "Bush", "GhostRed", "GhostPurple", "Zombie", "Head",
            "GhostKing", "GhostGrave1", "GhostGrave2", "GhostGrave3",
            "GhostGrave4", "GhostInvincible", "Ghostham", "CalciumDad",
            "Enemy" // Generic fallback
        };

        static EnemyAnnouncementSystem()
        {
            ClassInjector.RegisterTypeInIl2Cpp<EnemyAnnouncementSystem>();
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
            Plugin.Log.LogInfo("[EnemyAnnouncement] Initialized - scanning enemies by GameObject name");
        }

        private float nextDebugLogTime = 0f;

        void Update()
        {
            try
            {
                CheckSceneChange();

                if (Time.time >= nextDebugLogTime)
                {
                    nextDebugLogTime = Time.time + 5f;
                    Plugin.Log.LogInfo($"[EnemyAnnouncement] DEBUG - Scene: {lastSceneName}, " +
                        $"Player: {(playerTransform != null ? "OK" : "NULL")}, " +
                        $"CachedEnemies: {cachedEnemies.Count}");
                }

                if (IsMenuScene()) return;
                if (IsMenuOpen()) return;
                if (Time.time - sceneLoadTime < sceneStartDelay) return;

                if (Time.time >= nextPlayerSearchTime)
                {
                    FindPlayer();
                    nextPlayerSearchTime = Time.time + 2f;
                }

                if (playerTransform == null || cameraTransform == null) return;

                // Scan for enemies periodically
                if (Time.time >= nextEnemyScanTime)
                {
                    ScanForEnemies();
                    nextEnemyScanTime = Time.time + enemyScanInterval;
                }

                CheckDirectionChange();
                CheckNewThreats();
            }
            catch (Exception e)
            {
                Plugin.Log.LogDebug($"[EnemyAnnouncement] Update error: {e.Message}");
            }
        }

        private int scanCounter = 0;

        private void ScanForEnemies()
        {
            cachedEnemies.Clear();
            scanCounter++;

            try
            {
                // Cleanup dead enemies from tracker
                EnemyTracker.CleanupDeadEnemies();

                // Get enemies from tracker (populated by Harmony patches)
                foreach (var enemy in EnemyTracker.GetActiveEnemies())
                {
                    if (enemy != null)
                    {
                        cachedEnemies.Add(enemy);
                    }
                }

                // Log status periodically
                if (scanCounter % 20 == 1)
                {
                    Plugin.Log.LogInfo($"[EnemyAnnouncement] EnemyTracker has {EnemyTracker.Count} enemies, cached {cachedEnemies.Count}");
                }
            }
            catch (Exception e)
            {
                Plugin.Log.LogDebug($"[EnemyAnnouncement] ScanForEnemies error: {e.Message}");
            }
        }

        private void SearchSceneRoot(bool shouldLog)
        {
            // Buscar todos los root objects conocidos y escanear sus hijos
            string[] rootNames = {
                "World", "Level", "Map", "Game", "Gameplay",
                "Environment", "Spawned", "Generated", "Enemies",
                "---Enemies---", "---World---", "---Game---"
            };

            foreach (var rootName in rootNames)
            {
                try
                {
                    var root = GameObject.Find(rootName);
                    if (root != null)
                    {
                        if (shouldLog)
                            Plugin.Log.LogInfo($"[EnemyAnnouncement] Scanning root: {rootName} ({root.transform.childCount} children)");

                        ScanContainerForEnemies(root.transform, 0, 5);
                    }
                }
                catch { }
            }

            // También buscar desde el padre del jugador
            if (playerTransform != null)
            {
                Transform current = playerTransform.parent;
                int level = 0;
                while (current != null && level < 5)
                {
                    if (shouldLog && level == 0)
                        Plugin.Log.LogInfo($"[EnemyAnnouncement] Scanning from player parent: {current.name}");

                    ScanContainerForEnemies(current, 0, 3);
                    current = current.parent;
                    level++;
                }
            }
        }

        private void TryFindEnemy(string name, bool shouldLog)
        {
            try
            {
                var obj = GameObject.Find(name);
                if (obj != null && obj.activeInHierarchy)
                {
                    var enemy = obj.GetComponent<Enemy>();
                    if (enemy != null && !cachedEnemies.Contains(enemy))
                    {
                        cachedEnemies.Add(enemy);
                        if (shouldLog)
                            Plugin.Log.LogInfo($"[EnemyAnnouncement] Found enemy by name: {name}");
                    }

                    if (obj.transform.parent != null)
                    {
                        ScanSiblingsForEnemies(obj.transform.parent);
                    }
                }
            }
            catch { }
        }

        private void ScanSiblingsForEnemies(Transform parent)
        {
            if (parent == null) return;

            try
            {
                int childCount = parent.childCount;
                for (int i = 0; i < childCount && i < 100; i++) // Limit to prevent performance issues
                {
                    try
                    {
                        var child = parent.GetChild(i);
                        if (child == null || !child.gameObject.activeInHierarchy) continue;

                        var enemy = child.GetComponent<Enemy>();
                        if (enemy != null && !cachedEnemies.Contains(enemy))
                        {
                            cachedEnemies.Add(enemy);
                        }
                    }
                    catch { }
                }
            }
            catch { }
        }

        private void SearchEnemyContainers(bool shouldLog)
        {
            string[] containerNames = { "Enemies", "EnemyContainer", "Spawned", "Wave", "---Enemies---" };

            foreach (var containerName in containerNames)
            {
                try
                {
                    var container = GameObject.Find(containerName);
                    if (container != null)
                    {
                        if (shouldLog)
                            Plugin.Log.LogInfo($"[EnemyAnnouncement] Found container: {containerName}");
                        ScanContainerForEnemies(container.transform, 0, 3);
                    }
                }
                catch { }
            }
        }

        private void ScanContainerForEnemies(Transform container, int depth, int maxDepth)
        {
            if (container == null || depth > maxDepth) return;

            try
            {
                int childCount = container.childCount;
                for (int i = 0; i < childCount && i < 200; i++)
                {
                    try
                    {
                        var child = container.GetChild(i);
                        if (child == null || !child.gameObject.activeInHierarchy) continue;

                        var enemy = child.GetComponent<Enemy>();
                        if (enemy != null && !cachedEnemies.Contains(enemy))
                        {
                            cachedEnemies.Add(enemy);
                            Plugin.Log.LogDebug($"[EnemyAnnouncement] Found enemy in container: {child.name}");
                        }

                        if (child.childCount > 0)
                        {
                            ScanContainerForEnemies(child, depth + 1, maxDepth);
                        }
                    }
                    catch { }
                }
            }
            catch { }
        }

        private void CheckSceneChange()
        {
            try
            {
                var currentScene = UnityEngine.SceneManagement.SceneManager.GetActiveScene().name;
                if (currentScene != lastSceneName)
                {
                    lastSceneName = currentScene;
                    sceneLoadTime = Time.time;
                    playerTransform = null;
                    cameraTransform = null;
                    cachedEnemies.Clear();
                    knownCloseEnemies.Clear();
                    knownBossesElites.Clear();
                    lastForwardDirection = Vector3.forward;
                    lastAnnouncedContent = "";

                    // Clear enemy tracker on scene change
                    EnemyTracker.Clear();
                    Plugin.Log.LogInfo($"[EnemyAnnouncement] Scene changed to {currentScene}, cleared enemy tracker");
                }
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

        private void CheckDirectionChange()
        {
            if (Time.time - lastDirectionAnnounceTime < directionChangeCooldown) return;
            if (cachedEnemies.Count == 0) return;

            Vector3 currentForward = cameraTransform.forward;
            currentForward.y = 0;
            currentForward.Normalize();

            float angleDiff = Vector3.Angle(lastForwardDirection, currentForward);

            if (angleDiff >= directionChangeThreshold)
            {
                lastForwardDirection = currentForward;

                var enemiesAhead = GetEnemiesInDirection(currentForward, 60f);
                if (enemiesAhead.Count > 0)
                {
                    string announcement = BuildCompactAnnouncement(enemiesAhead);
                    if (!string.IsNullOrEmpty(announcement) && announcement != lastAnnouncedContent)
                    {
                        Plugin.Log.LogInfo($"[EnemyAnnouncement] Direction change: {announcement}");
                        TolkUtil.Speak(announcement);
                        lastAnnouncedContent = announcement;
                        lastDirectionAnnounceTime = Time.time;
                    }
                }
            }
        }

        private void CheckNewThreats()
        {
            float timeSinceLastAnnounce = Time.time - lastThreatAnnounceTime;
            if (timeSinceLastAnnounce < threatAnnounceCooldown)
            {
                // Only log this occasionally to avoid spam
                if (scanCounter % 40 == 1)
                {
                    Plugin.Log.LogDebug($"[EnemyAnnouncement] Threat check skipped - cooldown {timeSinceLastAnnounce:F1}s < {threatAnnounceCooldown}s");
                }
                return;
            }

            Vector3 playerPos = playerTransform.position;
            var newThreats = new List<EnemyInfo>();
            var currentCloseEnemies = new HashSet<int>();
            var currentBossesElites = new HashSet<int>();

            int enemiesInRange = 0;
            int deadCount = 0;
            int farCount = 0;
            int errorCount = 0;
            float closestDistance = float.MaxValue;

            // Only log start occasionally
            bool shouldLogDetails = Time.time >= nextThreatLogTime;

            foreach (var enemy in cachedEnemies)
            {
                try
                {
                    if (enemy == null) continue;
                    if (enemy.IsDead())
                    {
                        deadCount++;
                        continue;
                    }

                    int enemyId = enemy.GetInstanceID();
                    Vector3 enemyPos = enemy.GetCenterPosition();
                    float distance = Vector3.Distance(playerPos, enemyPos);

                    if (distance > maxTrackingDistance)
                    {
                        farCount++;
                        continue;
                    }

                    enemiesInRange++;
                    if (distance < closestDistance) closestDistance = distance;

                    bool isBoss = enemy.IsBoss() || enemy.IsStageBoss() || enemy.IsFinalBoss();
                    bool isElite = enemy.IsElite();

                    if (distance <= dangerDistance)
                    {
                        currentCloseEnemies.Add(enemyId);
                        if (!knownCloseEnemies.Contains(enemyId))
                        {
                            newThreats.Add(CreateEnemyInfo(enemy, enemyPos, playerPos, distance, isBoss, isElite));
                        }
                    }

                    if (isBoss || isElite)
                    {
                        currentBossesElites.Add(enemyId);
                        if (!knownBossesElites.Contains(enemyId))
                        {
                            if (!newThreats.Any(t => t.Name == GetEnemyDisplayName(enemy) && t.IsBoss == isBoss && t.IsElite == isElite))
                            {
                                newThreats.Add(CreateEnemyInfo(enemy, enemyPos, playerPos, distance, isBoss, isElite));
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    errorCount++;
                    if (errorCount <= 3)
                    {
                        Plugin.Log.LogDebug($"[EnemyAnnouncement] Enemy process error: {ex.Message}");
                    }
                }
            }

            // Log status every 5 seconds
            if (Time.time >= nextThreatLogTime)
            {
                nextThreatLogTime = Time.time + 5f;
                Plugin.Log.LogInfo($"[EnemyAnnouncement] Threats: {enemiesInRange} inRange, {currentCloseEnemies.Count} close, {deadCount} dead, {farCount} far, {errorCount} errors, closest={closestDistance:F1}, new={newThreats.Count}");
            }

            knownCloseEnemies = currentCloseEnemies;
            knownBossesElites = currentBossesElites;

            if (newThreats.Count > 0)
            {
                string announcement = BuildThreatAnnouncement(newThreats);
                if (!string.IsNullOrEmpty(announcement))
                {
                    Plugin.Log.LogInfo($"[EnemyAnnouncement] New threat: {announcement}");
                    TolkUtil.Speak(announcement);
                    lastThreatAnnounceTime = Time.time;
                }
            }
        }

        private List<EnemyInfo> GetEnemiesInDirection(Vector3 direction, float coneAngle)
        {
            var result = new List<EnemyInfo>();
            Vector3 playerPos = playerTransform.position;

            foreach (var enemy in cachedEnemies)
            {
                try
                {
                    if (enemy == null || enemy.IsDead()) continue;

                    Vector3 enemyPos = enemy.GetCenterPosition();
                    float distance = Vector3.Distance(playerPos, enemyPos);
                    if (distance > maxTrackingDistance) continue;

                    Vector3 toEnemy = (enemyPos - playerPos);
                    toEnemy.y = 0;
                    toEnemy.Normalize();

                    float angle = Vector3.Angle(direction, toEnemy);
                    if (angle <= coneAngle / 2)
                    {
                        bool isBoss = enemy.IsBoss() || enemy.IsStageBoss() || enemy.IsFinalBoss();
                        bool isElite = enemy.IsElite();

                        result.Add(new EnemyInfo
                        {
                            Name = GetEnemyDisplayName(enemy),
                            IsBoss = isBoss,
                            IsElite = isElite,
                            Distance = distance,
                            Direction = GetLocalizedText("dir_front", "ahead"),
                            Angle = angle
                        });
                    }
                }
                catch { }
            }

            return result;
        }

        private EnemyInfo CreateEnemyInfo(Enemy enemy, Vector3 enemyPos, Vector3 playerPos, float distance, bool isBoss, bool isElite)
        {
            Vector3 forward = cameraTransform.forward;
            forward.y = 0;
            forward.Normalize();

            Vector3 toEnemy = (enemyPos - playerPos);
            toEnemy.y = 0;
            toEnemy.Normalize();

            float angle = Vector3.SignedAngle(forward, toEnemy, Vector3.up);

            return new EnemyInfo
            {
                Name = GetEnemyDisplayName(enemy),
                IsBoss = isBoss,
                IsElite = isElite,
                Distance = distance,
                Direction = GetDirectionFromAngle(angle),
                Angle = angle
            };
        }

        private string GetDirectionFromAngle(float angle)
        {
            if (angle >= -45 && angle <= 45) return GetLocalizedText("dir_front", "ahead");
            if (angle > 45 && angle <= 135) return GetLocalizedText("dir_right", "right");
            if (angle < -45 && angle >= -135) return GetLocalizedText("dir_left", "left");
            return GetLocalizedText("dir_back", "behind");
        }

        private string GetEnemyDisplayName(Enemy enemy)
        {
            // Try to get the localized name from EnemyData.GetName()
            try
            {
                var enemyData = enemy.enemyData;
                if (enemyData != null)
                {
                    string localizedName = enemyData.GetName();
                    if (!string.IsNullOrEmpty(localizedName))
                    {
                        return localizedName;
                    }

                    // Fallback: try ScriptableObject.name (contains enemy type like "Skeleton")
                    string soName = enemyData.name;
                    if (!string.IsNullOrEmpty(soName))
                    {
                        return soName;
                    }
                }
            }
            catch (Exception ex)
            {
                Plugin.Log.LogDebug($"[EnemyAnnouncement] GetName error: {ex.Message}");
            }

            // Final fallback: use GameObject name
            try
            {
                string name = enemy.gameObject.name;
                name = name.Replace("(Clone)", "").Replace(" (Clone)", "").Trim();

                // Remove trailing numbers like "Enemy1" -> "Enemy"
                if (name.Length > 0)
                {
                    int lastNonDigit = name.Length - 1;
                    while (lastNonDigit >= 0 && char.IsDigit(name[lastNonDigit]))
                    {
                        lastNonDigit--;
                    }
                    if (lastNonDigit >= 0 && lastNonDigit < name.Length - 1)
                    {
                        name = name.Substring(0, lastNonDigit + 1);
                    }
                }

                return string.IsNullOrEmpty(name) ? "Enemigo" : name;
            }
            catch
            {
                return "Enemigo";
            }
        }

        private string BuildCompactAnnouncement(List<EnemyInfo> enemies)
        {
            if (enemies.Count == 0) return null;

            // Group by type, prioritize bosses/elites
            var groups = enemies
                .GroupBy(e => new { e.Name, e.IsBoss, e.IsElite })
                .OrderByDescending(g => g.Any(e => e.IsBoss))
                .ThenByDescending(g => g.Any(e => e.IsElite))
                .ThenByDescending(g => g.Count())
                .Take(3) // Max 3 enemy types
                .ToList();

            var parts = new List<string>();
            foreach (var group in groups)
            {
                int count = group.Count();
                string entry = "";

                if (group.Key.IsBoss) entry = GetLocalizedText("prefix_boss", "Jefe") + " ";
                else if (group.Key.IsElite) entry = GetLocalizedText("prefix_elite", "Élite") + " ";

                if (count > 1)
                    entry += $"{count} {group.Key.Name}";
                else
                    entry += group.Key.Name;

                parts.Add(entry);
            }

            // Add total count if there are more enemy types not shown
            int totalTypes = enemies.GroupBy(e => e.Name).Count();
            if (totalTypes > 3)
            {
                int othersCount = enemies.Count - groups.Sum(g => g.Count());
                if (othersCount > 0)
                    parts.Add($"+{othersCount} más");
            }

            return string.Join(", ", parts);
        }

        private string BuildThreatAnnouncement(List<EnemyInfo> threats)
        {
            if (threats.Count == 0) return null;

            // Group by direction AND enemy type for compact output
            // e.g., "3 Esqueletos adelante, 2 Goblins atrás"
            var directionGroups = threats
                .GroupBy(t => new { t.Direction, t.Name, t.IsBoss, t.IsElite })
                .OrderByDescending(g => g.Any(t => t.IsBoss))
                .ThenByDescending(g => g.Any(t => t.IsElite))
                .ThenByDescending(g => g.Count())
                .ThenBy(g => g.Min(t => t.Distance))
                .Take(4) // Max 4 groups to announce
                .ToList();

            var parts = new List<string>();
            foreach (var group in directionGroups)
            {
                int count = group.Count();
                string entry = "";

                // Prefix for boss/elite
                if (group.Key.IsBoss) entry = GetLocalizedText("prefix_boss", "Jefe") + " ";
                else if (group.Key.IsElite) entry = GetLocalizedText("prefix_elite", "Élite") + " ";

                // Count + name + direction
                if (count > 1)
                    entry += $"{count} {group.Key.Name} {group.Key.Direction}";
                else
                    entry += $"{group.Key.Name} {group.Key.Direction}";

                parts.Add(entry);
            }

            // If there are more threats not mentioned
            int totalThreats = threats.Count;
            int mentionedThreats = directionGroups.Sum(g => g.Count());
            if (totalThreats > mentionedThreats && totalThreats > 4)
            {
                parts.Add($"+{totalThreats - mentionedThreats} más");
            }

            return string.Join(", ", parts);
        }

        private string GetLocalizedText(string key, string defaultText)
        {
            // Use Spanish by default for this accessibility mod
            switch (key)
            {
                case "dir_front": return "adelante";
                case "dir_back": return "atrás";
                case "dir_left": return "izquierda";
                case "dir_right": return "derecha";
                case "prefix_boss": return "Jefe";
                case "prefix_elite": return "Élite";
                case "close": return "cerca";
                default: return defaultText;
            }
        }

        void OnDestroy()
        {
            Instance = null;
            Plugin.Log.LogInfo("[EnemyAnnouncement] Destroyed");
        }

        private class EnemyInfo
        {
            public string Name;
            public bool IsBoss;
            public bool IsElite;
            public float Distance;
            public string Direction;
            public float Angle;
        }
    }
}
