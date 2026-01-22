using HarmonyLib;
using UnityEngine;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using TMPro;

namespace MegabonkAccess
{
    [HarmonyPatch(typeof(CharacterInfoUI), "OnCharacterSelected")]
    public static class CharacterInfoUI_OnCharacterSelected_Patch
    {
        private static string lastAnnouncement = "";
        private static float lastAnnouncementTime = 0f;

        // Texts to skip (button labels, etc)
        private static readonly HashSet<string> SkipTexts = new HashSet<string>(System.StringComparer.OrdinalIgnoreCase)
        {
            "Skin", "Skins", "Confirmar", "Confirm", "Challenges", "Back", "Buy", "Purchase",
            "Play", "Settings", "Quit", "Exit", "Cancel", "OK", "Yes", "No",
            "Santa hat", "Hat", "Weapon", "Passive", "Arma", "Pasiva", "Passiva"
        };

        [HarmonyPostfix]
        public static void Postfix(CharacterInfoUI __instance)
        {
            if (__instance == null) return;

            try
            {
                Transform root = __instance.transform;

                // Check if character is locked by looking for active requirements
                bool isLocked = IsCharacterLocked(root);

                StringBuilder sb = new StringBuilder();

                if (isLocked)
                {
                    // Character is locked - read name and requirements only
                    string charName = FindTextByObjectName(root, "t_name");
                    if (!string.IsNullOrEmpty(charName))
                    {
                        sb.Append(charName).Append(". ");
                    }

                    sb.Append("Locked. ");

                    // Get requirements
                    string requirements = GetRequirementsText(root);
                    if (!string.IsNullOrEmpty(requirements))
                    {
                        sb.Append("To unlock: ").Append(requirements);
                    }
                }
                else
                {
                    // Character is unlocked - read all relevant info
                    var allTexts = GetAllTextComponents(root);

                    foreach (var tmp in allTexts)
                    {
                        if (tmp == null) continue;

                        string text = SanitizeText(tmp.text);
                        if (string.IsNullOrEmpty(text)) continue;

                        // Skip if it's a known button/label
                        if (SkipTexts.Contains(text)) continue;

                        // Skip very short texts (likely labels)
                        if (text.Length < 4) continue;

                        // Skip texts that are mostly numbers or progress
                        if (IsProgressOrNumber(text)) continue;

                        // Skip texts with garbage patterns
                        if (HasGarbagePattern(text)) continue;

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
                    Plugin.Log.LogInfo($"CharacterInfoUI speaking: {result}");
                    TolkUtil.SpeakFromSpecializedPatch(result);
                }
            }
            catch (System.Exception e)
            {
                Plugin.Log.LogError($"CharacterInfoUI patch error: {e.Message}");
            }
        }

        private static bool IsCharacterLocked(Transform root)
        {
            // Look for reqContainer or requirements that are active
            var reqContainer = FindChildByName(root, "reqContainer");
            if (reqContainer != null && reqContainer.gameObject.activeInHierarchy)
            {
                // Check if there are active requirement prefabs inside
                for (int i = 0; i < reqContainer.childCount; i++)
                {
                    var child = reqContainer.GetChild(i);
                    if (child != null && child.gameObject.activeInHierarchy)
                    {
                        // Found an active requirement
                        return true;
                    }
                }
            }

            // Also check for any object with "Requirement" in name that's active
            return HasActiveRequirements(root);
        }

        private static bool HasActiveRequirements(Transform parent)
        {
            if (parent == null) return false;

            string name = parent.name.ToLower();
            if ((name.Contains("requirement") || name.Contains("reqcontainer")) && parent.gameObject.activeInHierarchy)
            {
                // Check if it has active children
                for (int i = 0; i < parent.childCount; i++)
                {
                    var child = parent.GetChild(i);
                    if (child != null && child.gameObject.activeInHierarchy)
                    {
                        return true;
                    }
                }
            }

            // Recursively check children
            for (int i = 0; i < parent.childCount; i++)
            {
                if (HasActiveRequirements(parent.GetChild(i)))
                {
                    return true;
                }
            }

            return false;
        }

        private static string GetRequirementsText(Transform root)
        {
            StringBuilder sb = new StringBuilder();
            CollectRequirementsText(root, sb);
            return sb.ToString();
        }

        private static void CollectRequirementsText(Transform parent, StringBuilder sb)
        {
            if (parent == null) return;

            string name = parent.name.ToLower();

            // If this is a requirement prefab or container, get its text
            bool isReqObject = (name.Contains("requirement") || name.Contains("reqprefab") ||
                               (name.StartsWith("req") && parent.gameObject.activeInHierarchy));

            if (isReqObject && parent.gameObject.activeInHierarchy)
            {
                // First try to find specific t_requirement text (the mission description)
                string reqText = FindTextByObjectName(parent, "t_requirement");
                if (!string.IsNullOrEmpty(reqText) && !HasGarbagePattern(reqText))
                {
                    if (sb.Length > 0) sb.Append(". ");
                    sb.Append(reqText);

                    // Also get progress text
                    string progressText = FindTextByObjectName(parent, "t_progress");
                    if (!string.IsNullOrEmpty(progressText) && !HasGarbagePattern(progressText))
                    {
                        sb.Append(" (").Append(progressText).Append(")");
                    }
                }
                else
                {
                    // Fallback: get all texts from this requirement
                    var texts = GetAllTextComponents(parent);
                    foreach (var tmp in texts)
                    {
                        if (tmp == null) continue;
                        string text = SanitizeText(tmp.text);
                        if (string.IsNullOrEmpty(text) || text.Length < 3) continue;
                        if (HasGarbagePattern(text)) continue;

                        if (sb.Length > 0) sb.Append(". ");
                        sb.Append(text);
                    }
                }
                return; // Don't recurse into requirement prefabs
            }

            // Recurse into children
            for (int i = 0; i < parent.childCount; i++)
            {
                CollectRequirementsText(parent.GetChild(i), sb);
            }
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

        private static string FindTextByObjectName(Transform root, string objectName)
        {
            var obj = FindChildByName(root, objectName);
            if (obj == null) return "";

            var tmp = obj.GetComponent<TextMeshProUGUI>();
            if (tmp == null) return "";

            return SanitizeText(tmp.text);
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

        private static bool IsProgressOrNumber(string text)
        {
            string cleaned = Regex.Replace(text, @"[^\d]", "");
            if (cleaned.Length == 0) return false;

            float ratio = (float)cleaned.Length / text.Replace(" ", "").Length;
            if (ratio > 0.5f) return true;

            if (Regex.IsMatch(text, @"\d+\s*/\s*\d+")) return true;

            return false;
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

        private static string SanitizeText(string text)
        {
            if (string.IsNullOrEmpty(text)) return "";
            string result = Regex.Replace(text, "<.*?>", string.Empty);
            result = Regex.Replace(result, @"[\r\n]+", " ");
            result = Regex.Replace(result, @"\s+", " ");
            // Remove garbage suffixes (6+ fsde characters at end)
            result = Regex.Replace(result, @"\s*[fsde]{6,}\s*$", "", RegexOptions.IgnoreCase);
            result = Regex.Replace(result, @"\s*[sd]{4,}\s*$", "", RegexOptions.IgnoreCase);
            return result.Trim();
        }
    }
}
