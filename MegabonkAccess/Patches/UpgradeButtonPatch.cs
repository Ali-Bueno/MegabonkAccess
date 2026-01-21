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

        [HarmonyPostfix]
        public static void Postfix(UpgradeButton __instance)
        {
            if (__instance == null) return;

            try
            {
                // Find all TextMeshProUGUI components in children
                var allTexts = GetAllTextComponents(__instance.transform);

                if (allTexts.Count == 0)
                {
                    Plugin.Log.LogWarning("UpgradeButton: No text components found");
                    return;
                }

                StringBuilder sb = new StringBuilder();

                foreach (var tmp in allTexts)
                {
                    if (tmp == null) continue;

                    string text = SanitizeText(tmp.text);
                    if (string.IsNullOrEmpty(text)) continue;

                    // Skip very short texts (like "Lvl")
                    if (text.Length < 3) continue;

                    // Skip known labels/tags that don't add value
                    string textLower = text.ToLower();
                    if (textLower == "new" || textLower == "nuevo" || textLower == "lvl" ||
                        textLower == "level" || textLower == "nivel") continue;

                    sb.Append(text).Append(". ");
                }

                string result = sb.ToString();

                // Speak if we have content
                // Allow re-reading same content after 0.3s (moved to different button and back)
                float currentTime = UnityEngine.Time.unscaledTime;
                bool isDifferent = result != lastAnnouncement;
                bool enoughTimePassed = (currentTime - lastAnnouncementTime) > 0.3f;

                if (!string.IsNullOrEmpty(result) && (isDifferent || enoughTimePassed))
                {
                    lastAnnouncement = result;
                    lastAnnouncementTime = currentTime;
                    Plugin.Log.LogInfo($"UpgradeButton speaking: {result}");
                    TolkUtil.Speak(result);
                }
            }
            catch (System.Exception e)
            {
                Plugin.Log.LogError($"UpgradeButton patch error: {e.Message}");
            }
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

            int childCount = parent.childCount;
            for (int i = 0; i < childCount; i++)
            {
                GetTextComponentsRecursive(parent.GetChild(i), list);
            }
        }

        private static string SanitizeText(string text)
        {
            if (string.IsNullOrEmpty(text)) return "";
            // Remove rich text tags
            string result = Regex.Replace(text, "<.*?>", string.Empty);
            // Remove newlines and excessive whitespace
            result = Regex.Replace(result, @"[\r\n]+", " ");
            result = Regex.Replace(result, @"\s+", " ");
            return result.Trim();
        }
    }
}
