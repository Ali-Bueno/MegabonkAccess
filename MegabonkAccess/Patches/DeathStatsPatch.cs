using HarmonyLib;
using UnityEngine;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using TMPro;

namespace MegabonkAccess
{
    /// <summary>
    /// Tracks death stats screen state and provides keyboard navigation.
    /// </summary>
    public static class DeathStatsTracker
    {
        public static bool IsActive { get; private set; } = false;
        public static List<string> StatsItems { get; private set; } = new List<string>();
        public static int CurrentIndex { get; private set; } = 0;
        public static string LastDeathText { get; set; } = "";

        private static float lastInputTime = 0f;
        private static float inputCooldown = 0.2f;
        private static DeathScreen cachedDeathScreen = null;

        public static void Activate(List<string> items)
        {
            StatsItems = items;
            CurrentIndex = 0;
            IsActive = true;
            lastInputTime = Time.unscaledTime;

            // Announce that stats screen is open
            if (StatsItems.Count > 0)
            {
                string intro = "Run statistics. Use up and down arrows to navigate. Press Enter to continue.";
                Plugin.Log.LogInfo($"Death stats activated with {StatsItems.Count} items");
                TolkUtil.Speak(intro);

                // Read first item after a short delay
                TolkUtil.ScheduleDelayedAction(() =>
                {
                    if (IsActive && StatsItems.Count > 0)
                    {
                        ReadCurrentItem();
                    }
                }, 2.0f);
            }
        }

        public static void Deactivate()
        {
            IsActive = false;
            StatsItems.Clear();
            CurrentIndex = 0;
            cachedDeathScreen = null;
            LastDeathText = "";
        }

        public static void SetDeathScreen(DeathScreen screen)
        {
            cachedDeathScreen = screen;
        }

        public static void ProcessInput()
        {
            if (!IsActive || StatsItems.Count == 0) return;

            float currentTime = Time.unscaledTime;
            if (currentTime - lastInputTime < inputCooldown) return;

            // Arrow Down - next item
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                lastInputTime = currentTime;
                if (CurrentIndex < StatsItems.Count - 1)
                {
                    CurrentIndex++;
                    ReadCurrentItem();
                }
                else
                {
                    // At the end
                    TolkUtil.Speak("End of statistics. Press Enter to continue.");
                }
            }
            // Arrow Up - previous item
            else if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                lastInputTime = currentTime;
                if (CurrentIndex > 0)
                {
                    CurrentIndex--;
                    ReadCurrentItem();
                }
                else
                {
                    TolkUtil.Speak("Beginning of statistics.");
                }
            }
            // Enter or Space - continue to next screen
            else if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))
            {
                lastInputTime = currentTime;
                Continue();
            }
        }

        private static void ReadCurrentItem()
        {
            if (CurrentIndex >= 0 && CurrentIndex < StatsItems.Count)
            {
                string item = StatsItems[CurrentIndex];
                string position = $"{CurrentIndex + 1} de {StatsItems.Count}. ";
                Plugin.Log.LogInfo($"Death stats reading: {position}{item}");
                TolkUtil.Speak(position + item);
            }
        }

        private static void Continue()
        {
            if (cachedDeathScreen != null)
            {
                try
                {
                    Plugin.Log.LogInfo("Death stats: continuing to next screen");
                    cachedDeathScreen.ShowStats();
                    Deactivate();
                }
                catch (System.Exception e)
                {
                    Plugin.Log.LogError($"Error continuing from death stats: {e.Message}");
                }
            }
            else
            {
                // Try to find death screen
                var deathScreenObj = GameObject.Find("DeathScreen");
                if (deathScreenObj != null)
                {
                    var deathScreen = deathScreenObj.GetComponent<DeathScreen>();
                    if (deathScreen != null)
                    {
                        deathScreen.ShowStats();
                        Deactivate();
                    }
                }
            }
        }
    }

    /// <summary>
    /// Patch for DeathScreen.StartDeathScreen to detect when death occurs.
    /// </summary>
    [HarmonyPatch(typeof(DeathScreen), "StartDeathScreen")]
    public static class DeathScreen_StartDeathScreen_Patch
    {
        [HarmonyPostfix]
        public static void Postfix(DeathScreen __instance)
        {
            Plugin.Log.LogInfo("DeathScreen.StartDeathScreen called!");
            if (__instance != null)
            {
                DeathStatsTracker.SetDeathScreen(__instance);

                // Try to read the death text from the game UI after a short delay
                TolkUtil.ScheduleDelayedAction(() => ReadDeathText(__instance), 0.5f);

                // Stats collection is now handled by ShowStats patch when that method is called
            }
        }

        private static void ReadDeathText(DeathScreen deathScreen)
        {
            try
            {
                Transform root = deathScreen.transform;
                Plugin.Log.LogInfo($"ReadDeathText: searching in {root.name}");

                // Only look for specific death message objects - no fallbacks that read all texts
                string[] deathTextNames = { "t_dead", "DeathText", "YouDied", "GameOver", "t_title" };

                foreach (var name in deathTextNames)
                {
                    var textObj = FindChildByNameStatic(root, name);
                    if (textObj != null)
                    {
                        Plugin.Log.LogInfo($"ReadDeathText: found object {name}");

                        // Try direct component
                        var tmp = textObj.GetComponent<TMPro.TextMeshProUGUI>();
                        if (tmp != null && !string.IsNullOrEmpty(tmp.text))
                        {
                            string deathText = SanitizeTextStatic(tmp.text);
                            if (!string.IsNullOrEmpty(deathText) && !IsButtonLabel(deathText))
                            {
                                Plugin.Log.LogInfo($"Death text found: {deathText}");
                                DeathStatsTracker.LastDeathText = deathText;
                                TolkUtil.Speak(deathText);
                                return;
                            }
                        }

                        // Try children (t_dead might be UiAnimation with text child)
                        var childTexts = textObj.GetComponentsInChildren<TMPro.TextMeshProUGUI>();
                        if (childTexts != null)
                        {
                            foreach (var childTmp in childTexts)
                            {
                                if (childTmp != null && !string.IsNullOrEmpty(childTmp.text))
                                {
                                    string deathText = SanitizeTextStatic(childTmp.text);
                                    if (!string.IsNullOrEmpty(deathText) && !IsButtonLabel(deathText))
                                    {
                                        Plugin.Log.LogInfo($"Death text found in child: {deathText}");
                                        DeathStatsTracker.LastDeathText = deathText;
                                        TolkUtil.Speak(deathText);
                                        return;
                                    }
                                }
                            }
                        }
                    }
                }

                // Fallback: find first visible text in deadUiWindow (but not buttons)
                var deadWindow = FindChildByNameStatic(root, "deadUiWindow");
                if (deadWindow == null) deadWindow = FindChildByNameStatic(root, "DeadUiWindow");
                if (deadWindow == null) deadWindow = FindChildByNameStatic(root, "DeadWindow");

                if (deadWindow != null)
                {
                    Plugin.Log.LogInfo($"ReadDeathText: found deadWindow, active: {deadWindow.gameObject.activeInHierarchy}");
                    var texts = deadWindow.GetComponentsInChildren<TMPro.TextMeshProUGUI>();
                    if (texts != null)
                    {
                        foreach (var tmp in texts)
                        {
                            if (tmp != null && !string.IsNullOrEmpty(tmp.text))
                            {
                                string text = SanitizeTextStatic(tmp.text);
                                // Skip button labels and short texts
                                if (IsButtonLabel(text)) continue;
                                if (text.Length < 5) continue;

                                Plugin.Log.LogInfo($"Death text (fallback): {text}");
                                DeathStatsTracker.LastDeathText = text;
                                TolkUtil.Speak(text);
                                return;
                            }
                        }
                    }
                }

                Plugin.Log.LogWarning("ReadDeathText: no death text found");
            }
            catch (System.Exception e)
            {
                Plugin.Log.LogError($"Error reading death text: {e.Message}");
            }
        }

        private static bool IsButtonLabel(string text)
        {
            if (string.IsNullOrEmpty(text)) return true;
            string lower = text.ToLower().Trim();

            // Button labels to skip
            return lower == "continue" || lower == "continuar" ||
                   lower == "confirm" || lower == "confirmar" ||
                   lower == "stats" || lower == "estadisticas" || lower == "estadísticas" ||
                   lower == "restart" || lower == "reiniciar" ||
                   lower == "menu" || lower == "menú" ||
                   lower == "quit" || lower == "salir" ||
                   lower == "back" || lower == "volver" ||
                   lower.Contains("press enter") || lower.Contains("presiona enter") ||
                   lower.Contains("press space") || lower.Contains("presiona espacio");
        }

        private static Transform FindChildByNameStatic(Transform parent, string name)
        {
            if (parent == null) return null;

            for (int i = 0; i < parent.childCount; i++)
            {
                var child = parent.GetChild(i);
                if (child != null && child.name.Equals(name, System.StringComparison.OrdinalIgnoreCase))
                {
                    return child;
                }

                var found = FindChildByNameStatic(child, name);
                if (found != null) return found;
            }

            return null;
        }

        private static string SanitizeTextStatic(string text)
        {
            if (string.IsNullOrEmpty(text)) return "";
            string result = Regex.Replace(text, "<.*?>", string.Empty);
            result = Regex.Replace(result, @"[\r\n]+", " ");
            result = Regex.Replace(result, @"\s+", " ");
            return result.Trim();
        }

        private static void CollectAndActivateStats()
        {
            Plugin.Log.LogInfo("Attempting to collect death stats...");

            // Find stats UI by searching scene
            var statsUiObj = GameObject.Find("DeathStatsUi");
            if (statsUiObj == null) statsUiObj = GameObject.Find("StatsWindow");
            if (statsUiObj == null) statsUiObj = GameObject.Find("statsWindow");
            if (statsUiObj == null) statsUiObj = GameObject.Find("DeathStats");

            // Also try to find by component
            if (statsUiObj == null)
            {
                var deathScreen = GameObject.Find("DeathScreen");
                if (deathScreen != null)
                {
                    Plugin.Log.LogInfo("Found DeathScreen, searching children...");
                    statsUiObj = FindChildWithTexts(deathScreen.transform);
                }
            }

            if (statsUiObj == null)
            {
                Plugin.Log.LogWarning("Could not find stats UI object");
                // Try to read any visible text in death screen area
                var deathScreen = GameObject.Find("DeathScreen");
                if (deathScreen != null)
                {
                    var items = CollectAllVisibleTexts(deathScreen.transform);
                    if (items.Count > 0)
                    {
                        Plugin.Log.LogInfo($"Found {items.Count} texts from DeathScreen");
                        DeathStatsTracker.Activate(items);
                    }
                }
                return;
            }

            Plugin.Log.LogInfo($"Found stats UI: {statsUiObj.name}");
            var collectedItems = CollectStatsFromTransform(statsUiObj.transform);
            if (collectedItems.Count > 0)
            {
                DeathStatsTracker.Activate(collectedItems);
            }
        }

        private static GameObject FindChildWithTexts(Transform parent)
        {
            if (parent == null) return null;

            // Look for object with multiple TextMeshProUGUI components (likely the stats panel)
            for (int i = 0; i < parent.childCount; i++)
            {
                var child = parent.GetChild(i);
                if (child == null || !child.gameObject.activeInHierarchy) continue;

                var texts = child.GetComponentsInChildren<TextMeshProUGUI>();
                if (texts != null && texts.Length > 3)
                {
                    return child.gameObject;
                }

                var found = FindChildWithTexts(child);
                if (found != null) return found;
            }
            return null;
        }

        private static List<string> CollectStatsFromTransform(Transform root)
        {
            var items = new List<string>();
            CollectTextsRecursive(root, items);
            return items;
        }

        private static void CollectTextsRecursive(Transform parent, List<string> items)
        {
            if (parent == null) return;

            var tmp = parent.GetComponent<TextMeshProUGUI>();
            if (tmp != null && tmp.enabled && tmp.gameObject.activeInHierarchy)
            {
                string text = SanitizeText(tmp.text);
                if (!string.IsNullOrEmpty(text) && text.Length > 2 && !IsSkipText(text) && !HasGarbagePattern(text))
                {
                    // Log what we're finding
                    Plugin.Log.LogInfo($"CollectTextsRecursive: found '{text}' in {parent.name}");
                    items.Add(text);
                }
            }

            for (int i = 0; i < parent.childCount; i++)
            {
                CollectTextsRecursive(parent.GetChild(i), items);
            }
        }

        private static List<string> CollectAllVisibleTexts(Transform root)
        {
            var items = new List<string>();
            CollectVisibleTextsRecursive(root, items);
            return items;
        }

        private static void CollectVisibleTextsRecursive(Transform parent, List<string> items)
        {
            if (parent == null || !parent.gameObject.activeInHierarchy) return;

            var tmp = parent.GetComponent<TextMeshProUGUI>();
            if (tmp != null && tmp.enabled)
            {
                string text = SanitizeText(tmp.text);
                if (!string.IsNullOrEmpty(text) && text.Length > 2 && !IsSkipText(text) && !HasGarbagePattern(text))
                {
                    Plugin.Log.LogInfo($"CollectVisibleTexts: '{text}' in {parent.name}");
                    items.Add(text);
                }
            }

            for (int i = 0; i < parent.childCount; i++)
            {
                CollectVisibleTextsRecursive(parent.GetChild(i), items);
            }
        }

        private static bool IsSkipText(string text)
        {
            string lower = text.ToLower();

            // Skip death text if it was already spoken
            if (!string.IsNullOrEmpty(DeathStatsTracker.LastDeathText) &&
                text.Contains(DeathStatsTracker.LastDeathText.Substring(0, System.Math.Min(10, DeathStatsTracker.LastDeathText.Length))))
            {
                return true;
            }

            // Button labels
            if (lower == "continue" || lower == "continuar" || lower == "confirm" ||
                lower == "confirmar" || lower == "restart" || lower == "reiniciar" ||
                lower == "menu" || lower == "quit" || lower == "salir" ||
                lower == "back" || lower == "volver") return true;

            // UI element names and labels
            if (lower == "footer" || lower == "header" || lower == "video" || lower == "game" ||
                lower == "audio" || lower == "music" || lower == "settings" || lower == "options" ||
                lower == "dmg" || lower == "dps" || lower == "lvl" || lower == "origen" ||
                lower == "inventario" || lower == "inventory" || lower == "resumen" || lower == "summary" ||
                lower == "quests" || lower == "misiones" || lower == "daño" || lower == "damage") return true;

            return false;
        }

        private static bool HasGarbagePattern(string text)
        {
            if (string.IsNullOrEmpty(text)) return false;
            // Garbage patterns
            if (Regex.IsMatch(text, @"([sd]{2,}\s*){3,}", RegexOptions.IgnoreCase)) return true;
            if (Regex.IsMatch(text, @"([a-z]{1,2}\s+){5,}", RegexOptions.IgnoreCase)) return true;
            if (Regex.IsMatch(text, @"[d]{4,}$", RegexOptions.IgnoreCase)) return true; // ends with dddd
            if (Regex.IsMatch(text, @"dsda$", RegexOptions.IgnoreCase)) return true; // ends with dsda
            // Long sequences of fsde (6+) catches garbage but not words like "alrededor" (only 4)
            if (Regex.IsMatch(text, @"[fsde]{6,}", RegexOptions.IgnoreCase)) return true;
            // Pure numbers with formatting
            if (Regex.IsMatch(text, @"^\s*[\d.,\s]+\s*$")) return true;
            if (Regex.IsMatch(text, @"^\s*[\d.,\s]+[a-zA-Z]{1,2}\s*$")) return true; // like "999.9Ud"
            return false;
        }

        private static string SanitizeText(string text)
        {
            if (string.IsNullOrEmpty(text)) return "";
            string result = Regex.Replace(text, "<.*?>", string.Empty);
            result = Regex.Replace(result, @"[\r\n]+", " ");
            result = Regex.Replace(result, @"\s+", " ");
            // Remove garbage suffixes
            result = Regex.Replace(result, @"\s*[fsde]{6,}\s*$", "", RegexOptions.IgnoreCase);
            result = Regex.Replace(result, @"\s*[sd]{4,}\s*$", "", RegexOptions.IgnoreCase);
            return result.Trim();
        }
    }

    /// <summary>
    /// Patch for DeathScreen.ShowStats to collect and announce run statistics.
    /// </summary>
    [HarmonyPatch(typeof(DeathScreen), "ShowStats")]
    public static class DeathScreen_ShowStats_Patch
    {
        // Whitelist of valid stat-related object name patterns
        private static readonly string[] ValidStatObjectNames = new string[]
        {
            "t_stat", "t_kills", "t_time", "t_level", "t_gold", "t_silver", "t_unlock",
            "t_character", "t_name", "t_record", "t_tier", "t_rank", "t_score",
            "stat", "kills", "time", "level", "gold", "silver", "unlock", "record"
        };

        [HarmonyPostfix]
        public static void Postfix(DeathScreen __instance)
        {
            Plugin.Log.LogInfo("DeathScreen.ShowStats called!");
            if (__instance == null) return;

            try
            {
                DeathStatsTracker.SetDeathScreen(__instance);
                Transform root = __instance.transform;

                List<string> items = new List<string>();

                // Find the StatsWindows container - stats are ONLY in there
                var statsWindows = FindChildByName(root, "StatsWindows");
                if (statsWindows == null) statsWindows = FindChildByName(root, "statsWindows");
                if (statsWindows == null) statsWindows = FindChildByName(root, "W_Stats");

                if (statsWindows != null)
                {
                    Plugin.Log.LogInfo($"ShowStats found stats container: {statsWindows.name}");
                    // Collect texts ONLY from within StatsWindows
                    CollectStatsFromStatsWindow(statsWindows, items);
                }
                else
                {
                    Plugin.Log.LogInfo("ShowStats: StatsWindows not found, logging UI tree:");
                    LogUiTree(root, "");
                }

                // Log what we found
                Plugin.Log.LogInfo($"ShowStats collected {items.Count} items");

                if (items.Count > 0)
                {
                    DeathStatsTracker.Activate(items);
                }
                else
                {
                    Plugin.Log.LogWarning("DeathScreen: No stats items found from whitelist search");
                    // Just announce that stats are available but we couldn't read them
                    TolkUtil.Speak("Statistics screen. Press Enter to continue.");
                }
            }
            catch (System.Exception e)
            {
                Plugin.Log.LogError($"DeathScreen_ShowStats patch error: {e.Message}");
            }
        }

        private static void LogUiTree(Transform parent, string indent)
        {
            if (parent == null || !parent.gameObject.activeInHierarchy) return;

            var tmp = parent.GetComponent<TextMeshProUGUI>();
            if (tmp != null)
            {
                string text = SanitizeText(tmp.text);
                Plugin.Log.LogInfo($"{indent}[{parent.name}] Text: '{text}'");
            }
            else
            {
                Plugin.Log.LogInfo($"{indent}[{parent.name}]");
            }

            for (int i = 0; i < parent.childCount; i++)
            {
                LogUiTree(parent.GetChild(i), indent + "  ");
            }
        }

        private static void CollectStatsFromStatsWindow(Transform statsWindow, List<string> items)
        {
            if (statsWindow == null) return;

            // Collect all text components within the stats window
            CollectStatsWindowTexts(statsWindow, items);
        }

        private static void CollectStatsWindowTexts(Transform parent, List<string> items)
        {
            if (parent == null || !parent.gameObject.activeInHierarchy) return;

            string objName = parent.name.ToLower();

            // ONLY collect from specific stat object names - nothing else!
            bool isStatObject = objName == "t_stats" || objName == "t_unlock" || objName == "t_silver" ||
                               objName == "t_gold" || objName == "t_kills" || objName == "t_time" ||
                               objName == "t_level" || objName == "t_score";

            if (isStatObject)
            {
                var tmp = parent.GetComponent<TextMeshProUGUI>();
                if (tmp != null && !string.IsNullOrEmpty(tmp.text))
                {
                    string text = SanitizeText(tmp.text);
                    Plugin.Log.LogInfo($"[Stats] Collected from '{parent.name}': '{text}'");

                    if (!string.IsNullOrEmpty(text) && text.Length > 1)
                    {
                        items.Add(text);
                    }
                }
            }

            // Recurse into children
            for (int i = 0; i < parent.childCount; i++)
            {
                CollectStatsWindowTexts(parent.GetChild(i), items);
            }
        }

        private static bool IsValidStatText(string text)
        {
            if (string.IsNullOrEmpty(text)) return false;

            string lower = text.ToLower();

            // Skip garbage patterns
            if (HasGarbagePattern(text)) return false;

            // Skip known non-stat texts
            if (lower == "continue" || lower == "continuar" || lower == "confirm" ||
                lower == "confirmar" || lower == "restart" || lower == "reiniciar" ||
                lower == "menu" || lower == "quit" || lower == "salir" ||
                lower == "footer" || lower == "header" || lower == "video" || lower == "game" ||
                lower == "audio" || lower == "music" || lower == "settings" || lower == "options")
            {
                return false;
            }

            // Skip single word labels that are too short
            if (text.Length < 3 && !text.Contains(":") && !char.IsDigit(text[0])) return false;

            return true;
        }

        private static string FormatStatText(string objName, string text)
        {
            // If the text already contains meaningful info, return it as-is
            if (text.Contains(":") || text.Contains("-") || text.Contains("/") ||
                text.Contains("GOLD") || text.Contains("SILVER") || text.Contains("KILLS") ||
                text.Contains("Kills") || text.Contains("Level") || text.Contains("Time"))
            {
                return text;
            }

            // Add context from object name for standalone values
            if (objName.Contains("gold") && !text.ToLower().Contains("gold"))
                return "Gold: " + text;
            if (objName.Contains("silver") && !text.ToLower().Contains("silver"))
                return "Silver: " + text;
            if (objName.Contains("kills") && !text.ToLower().Contains("kill"))
                return "Kills: " + text;
            if (objName.Contains("level") && !text.ToLower().Contains("level"))
                return "Level: " + text;
            if (objName.Contains("time") && !text.ToLower().Contains("time"))
                return "Time: " + text;
            if (objName.Contains("unlock") && !text.ToLower().Contains("unlock"))
                return "Unlocks: " + text;

            return text;
        }

        private static string FindTextByName(Transform root, string name)
        {
            var obj = FindChildByName(root, name);
            if (obj == null) return "";

            var tmp = obj.GetComponent<TextMeshProUGUI>();
            if (tmp == null) return "";

            return SanitizeText(tmp.text);
        }

        private static Transform FindChildByName(Transform parent, string name)
        {
            if (parent == null) return null;

            for (int i = 0; i < parent.childCount; i++)
            {
                var child = parent.GetChild(i);
                if (child != null && child.name.Equals(name, System.StringComparison.OrdinalIgnoreCase))
                {
                    return child;
                }

                var found = FindChildByName(child, name);
                if (found != null) return found;
            }

            return null;
        }

        private static List<string> CollectInventoryItems(Transform parent)
        {
            var items = new List<string>();
            if (parent == null) return items;

            for (int i = 0; i < parent.childCount; i++)
            {
                var child = parent.GetChild(i);
                if (child == null || !child.gameObject.activeInHierarchy) continue;

                // Try to find item name text
                var texts = GetAllTextComponents(child);
                foreach (var tmp in texts)
                {
                    if (tmp == null) continue;
                    string text = SanitizeText(tmp.text);
                    if (!string.IsNullOrEmpty(text) && text.Length > 1)
                    {
                        items.Add(text);
                        break; // Just get first meaningful text per item
                    }
                }
            }

            return items;
        }

        private static List<string> GetAllTexts(Transform parent)
        {
            var list = new List<string>();
            var texts = GetAllTextComponents(parent);

            foreach (var tmp in texts)
            {
                if (tmp == null) continue;
                string text = SanitizeText(tmp.text);
                if (!string.IsNullOrEmpty(text) && text.Length > 2)
                {
                    // Skip button labels and garbage
                    if (IsSkipText(text)) continue;
                    if (HasGarbagePattern(text)) continue;

                    list.Add(text);
                }
            }

            return list;
        }

        private static bool IsSkipText(string text)
        {
            string lower = text.ToLower();

            // Skip death text if it was already spoken
            if (!string.IsNullOrEmpty(DeathStatsTracker.LastDeathText) &&
                text.Contains(DeathStatsTracker.LastDeathText.Substring(0, System.Math.Min(10, DeathStatsTracker.LastDeathText.Length))))
            {
                return true;
            }

            // Button labels
            if (lower == "continue" || lower == "continuar" || lower == "confirm" ||
                lower == "confirmar" || lower == "restart" || lower == "reiniciar" ||
                lower == "menu" || lower == "quit" || lower == "salir" ||
                lower == "back" || lower == "volver") return true;

            // UI element names and labels
            if (lower == "footer" || lower == "header" || lower == "video" || lower == "game" ||
                lower == "audio" || lower == "music" || lower == "settings" || lower == "options" ||
                lower == "dmg" || lower == "dps" || lower == "lvl" || lower == "origen" ||
                lower == "inventario" || lower == "inventory" || lower == "resumen" || lower == "summary" ||
                lower == "quests" || lower == "misiones" || lower == "daño" || lower == "damage") return true;

            return false;
        }

        private static bool HasGarbagePattern(string text)
        {
            if (string.IsNullOrEmpty(text)) return false;
            // Garbage patterns
            if (Regex.IsMatch(text, @"([sd]{2,}\s*){3,}", RegexOptions.IgnoreCase)) return true;
            if (Regex.IsMatch(text, @"([a-z]{1,2}\s+){5,}", RegexOptions.IgnoreCase)) return true;
            if (Regex.IsMatch(text, @"[d]{4,}$", RegexOptions.IgnoreCase)) return true; // ends with dddd
            if (Regex.IsMatch(text, @"dsda$", RegexOptions.IgnoreCase)) return true; // ends with dsda
            // Long sequences of fsde (6+) catches garbage but not words like "alrededor" (only 4)
            if (Regex.IsMatch(text, @"[fsde]{6,}", RegexOptions.IgnoreCase)) return true;
            // Pure numbers with formatting
            if (Regex.IsMatch(text, @"^\s*[\d.,\s]+\s*$")) return true;
            if (Regex.IsMatch(text, @"^\s*[\d.,\s]+[a-zA-Z]{1,2}\s*$")) return true; // like "999.9Ud"
            return false;
        }

        private static List<TextMeshProUGUI> GetAllTextComponents(Transform parent)
        {
            var list = new List<TextMeshProUGUI>();
            GetTextComponentsRecursive(parent, list);
            return list;
        }

        private static void GetTextComponentsRecursive(Transform parent, List<TextMeshProUGUI> list)
        {
            if (parent == null) return;

            var comp = parent.GetComponent<TextMeshProUGUI>();
            if (comp != null) list.Add(comp);

            for (int i = 0; i < parent.childCount; i++)
            {
                GetTextComponentsRecursive(parent.GetChild(i), list);
            }
        }

        private static string SanitizeText(string text)
        {
            if (string.IsNullOrEmpty(text)) return "";
            string result = Regex.Replace(text, "<.*?>", string.Empty);
            result = Regex.Replace(result, @"[\r\n]+", " ");
            result = Regex.Replace(result, @"\s+", " ");
            // Remove garbage suffixes
            result = Regex.Replace(result, @"\s*[fsde]{6,}\s*$", "", RegexOptions.IgnoreCase);
            result = Regex.Replace(result, @"\s*[sd]{4,}\s*$", "", RegexOptions.IgnoreCase);
            return result.Trim();
        }
    }

    /// <summary>
    /// Patch DeathScreen.Update to process keyboard input for stats navigation.
    /// </summary>
    [HarmonyPatch(typeof(DeathScreen), "Update")]
    public static class DeathScreen_Update_Patch
    {
        [HarmonyPostfix]
        public static void Postfix()
        {
            DeathStatsTracker.ProcessInput();
        }
    }

    /// <summary>
    /// Patch to detect when death screen is closed/hidden.
    /// </summary>
    [HarmonyPatch(typeof(DeathScreen), "GoToMenu")]
    public static class DeathScreen_GoToMenu_Patch
    {
        [HarmonyPostfix]
        public static void Postfix()
        {
            DeathStatsTracker.Deactivate();
        }
    }

    [HarmonyPatch(typeof(DeathScreen), "Restart")]
    public static class DeathScreen_Restart_Patch
    {
        [HarmonyPostfix]
        public static void Postfix()
        {
            DeathStatsTracker.Deactivate();
        }
    }
}
