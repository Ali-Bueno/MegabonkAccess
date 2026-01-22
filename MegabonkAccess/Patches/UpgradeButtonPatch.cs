using HarmonyLib;
using UnityEngine;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using TMPro;

namespace MegabonkAccess
{
    /// <summary>
    /// Static class to track menu states for DirectionalAudioManager.
    /// Uses active object detection instead of timeouts.
    /// </summary>
    public static class MenuStateTracker
    {
        public static bool IsAnyMenuOpen
        {
            get
            {
                try
                {
                    // Check if any UpgradeButton is active (level-up menu)
                    var upgradeButton = GameObject.Find("UpgradeButton");
                    if (upgradeButton != null && upgradeButton.activeInHierarchy)
                    {
                        // Verify it has active parent (the menu panel)
                        var parent = upgradeButton.transform.parent;
                        if (parent != null && parent.gameObject.activeInHierarchy)
                        {
                            return true;
                        }
                    }

                    // Check for upgrade buttons with numbers (UpgradeButton (1), etc.)
                    for (int i = 0; i < 5; i++)
                    {
                        string name = i == 0 ? "UpgradeButton" : $"UpgradeButton ({i})";
                        var btn = GameObject.Find(name);
                        if (btn != null && btn.activeInHierarchy)
                        {
                            return true;
                        }
                    }

                    // Check for ChestWindowUi and variations
                    string[] chestWindowNames = {
                        "ChestWindowUi", "ChestWindowUi(Clone)", "ChestWindow", "ChestWindow(Clone)",
                        "ItemWindow", "ItemWindowUi", "ItemWindow(Clone)",
                        "RewardWindow", "RewardPanel", "LootWindow", "LootPanel",
                        "PickupWindow", "ItemPickup", "ChestReward", "ChestItem"
                    };

                    foreach (var windowName in chestWindowNames)
                    {
                        var window = GameObject.Find(windowName);
                        if (window != null && window.activeInHierarchy)
                        {
                            return true;
                        }
                    }

                    // Check for common item/reward buttons that indicate a menu is open
                    string[] buttonNames = {
                        "TakeButton", "LeaveButton", "DiscardButton", "BanishButton",
                        "AcceptButton", "DeclineButton", "PickupButton"
                    };

                    foreach (var buttonName in buttonNames)
                    {
                        var btn = GameObject.Find(buttonName);
                        if (btn != null && btn.activeInHierarchy)
                        {
                            return true;
                        }
                    }
                }
                catch { }

                return false;
            }
        }
    }

    /// <summary>
    /// Dedicated patch for UpgradeButton accessibility during level-up.
    /// Hooks StartHover which is called when navigating between upgrade options.
    /// </summary>
    [HarmonyPatch(typeof(UpgradeButton), "StartHover")]
    public static class UpgradeButton_StartHover_Patch
    {
        private static string lastAnnouncement = "";
        private static float lastAnnouncementTime = 0f;

        private static readonly HashSet<string> SkipTexts = new HashSet<string>(System.StringComparer.OrdinalIgnoreCase)
        {
            "New", "Nuevo", "Lvl", "Level", "Nivel", "Take", "Tomar", "Leave", "Dejar",
            "Discard", "Descartar", "Banish", "Desterrar", "Accept", "Aceptar"
        };

        [HarmonyPostfix]
        public static void Postfix(UpgradeButton __instance)
        {
            if (__instance == null) return;

            try
            {
                Transform root = __instance.transform;
                StringBuilder sb = new StringBuilder();

                // Read specific fields by object name
                string name = FindTextByName(root, "t_name");
                string description = FindTextByName(root, "t_description");
                string rarity = FindTextByName(root, "t_rarity");
                string level = FindTextByName(root, "t_level");

                // Exhaustive logging for Chunkers
                if (name != null && name.ToLower().Contains("chunkers"))
                {
                    Plugin.Log.LogInfo($"[UpgradeButton] === CHUNKERS DETECTED ===");
                    Plugin.Log.LogInfo($"[UpgradeButton] t_name: '{name}'");
                    Plugin.Log.LogInfo($"[UpgradeButton] t_description: '{description}'");
                    Plugin.Log.LogInfo($"[UpgradeButton] t_rarity: '{rarity}'");
                    Plugin.Log.LogInfo($"[UpgradeButton] t_level: '{level}'");
                    Plugin.Log.LogInfo($"[UpgradeButton] Full UI tree:");
                    LogAllTexts(root, "  ");
                    Plugin.Log.LogInfo($"[UpgradeButton] === END CHUNKERS ===");
                }

                // Build announcement
                if (!string.IsNullOrEmpty(name))
                {
                    sb.Append(name).Append(". ");
                }

                if (!string.IsNullOrEmpty(rarity) && !SkipTexts.Contains(rarity))
                {
                    sb.Append(rarity).Append(". ");
                }

                if (!string.IsNullOrEmpty(description) && !HasGarbagePattern(description))
                {
                    sb.Append(description).Append(". ");
                }

                if (!string.IsNullOrEmpty(level) && !SkipTexts.Contains(level))
                {
                    sb.Append(level).Append(". ");
                }

                // Also look for stat changes text (contains arrows like "0% → 15%")
                var statsText = FindTextByName(root, "t_stats");
                if (!string.IsNullOrEmpty(statsText) && !HasGarbagePattern(statsText))
                {
                    sb.Append(statsText).Append(". ");
                }

                // Fallback: collect other texts if we didn't find specific fields
                if (sb.Length == 0)
                {
                    var texts = GetTextsFromTransform(root, false);
                    foreach (var text in texts)
                    {
                        if (string.IsNullOrEmpty(text)) continue;
                        if (text.Length < 3) continue;
                        if (SkipTexts.Contains(text)) continue;
                        if (HasGarbagePattern(text)) continue;
                        if (IsProgressText(text)) continue;

                        sb.Append(text).Append(". ");
                    }
                }

                string result = sb.ToString().Trim();

                // Prevent duplicate announcements
                float currentTime = Time.unscaledTime;
                bool isDifferent = result != lastAnnouncement;
                bool enoughTimePassed = (currentTime - lastAnnouncementTime) > 0.3f;

                if (!string.IsNullOrEmpty(result) && (isDifferent || enoughTimePassed))
                {
                    lastAnnouncement = result;
                    lastAnnouncementTime = currentTime;
                    Plugin.Log.LogInfo($"UpgradeButton speaking: {result}");
                    TolkUtil.SpeakFromSpecializedPatch(result);
                }
            }
            catch (System.Exception e)
            {
                Plugin.Log.LogError($"UpgradeButton patch error: {e.Message}");
            }
        }

        private static List<string> GetTextsFromTransform(Transform parent, bool logAll = false)
        {
            var list = new List<string>();
            CollectTexts(parent, list, logAll);
            return list;
        }

        private static string FindTextByName(Transform root, string objectName)
        {
            var obj = FindChildByName(root, objectName);
            if (obj == null) return null;

            var tmp = obj.GetComponent<TextMeshProUGUI>();
            if (tmp == null) return null;

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

        private static void CollectTexts(Transform parent, List<string> list, bool logAll = false)
        {
            if (parent == null) return;

            var tmp = parent.GetComponent<TextMeshProUGUI>();
            if (tmp != null)
            {
                string text = SanitizeText(tmp.text);
                if (logAll)
                {
                    Plugin.Log.LogInfo($"  [UpgradeButton] Found text in '{parent.name}': '{text}'");
                }
                if (!string.IsNullOrEmpty(text))
                {
                    list.Add(text);
                }
            }

            for (int i = 0; i < parent.childCount; i++)
            {
                CollectTexts(parent.GetChild(i), list, logAll);
            }
        }

        private static bool HasGarbagePattern(string text)
        {
            if (string.IsNullOrEmpty(text)) return false;
            if (Regex.IsMatch(text, @"([sd]{2,}\s*){3,}", RegexOptions.IgnoreCase)) return true;
            if (Regex.IsMatch(text, @"([a-z]{1,2}\s+){5,}", RegexOptions.IgnoreCase)) return true;
            // Long sequences of fsde (6+) catches garbage but not words like "alrededor" (only 4)
            if (Regex.IsMatch(text, @"[fsde]{6,}", RegexOptions.IgnoreCase)) return true;
            return false;
        }

        private static bool IsProgressText(string text)
        {
            if (string.IsNullOrEmpty(text)) return false;
            if (Regex.IsMatch(text, @"^\s*[\d.,\s]+\s*/\s*[\d.,\s]+\s*$")) return true;
            if (Regex.IsMatch(text, @"^\s*[\d.,\s]+\s*$")) return true;
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

        private static void LogAllTexts(Transform parent, string indent)
        {
            if (parent == null) return;

            var tmp = parent.GetComponent<TextMeshProUGUI>();
            if (tmp != null)
            {
                string text = SanitizeText(tmp.text);
                Plugin.Log.LogInfo($"{indent}[{parent.name}] Text: '{text}'");
            }
            else
            {
                Plugin.Log.LogInfo($"{indent}[{parent.name}] (no text)");
            }

            for (int i = 0; i < parent.childCount; i++)
            {
                LogAllTexts(parent.GetChild(i), indent + "  ");
            }
        }
    }
}
