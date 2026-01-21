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

            // Store reference for delayed reading
            var instanceRef = __instance;

            // Schedule the reading after a short delay to allow UI to update
            TolkUtil.ScheduleDelayedAction(() => ReadCharacterInfo(instanceRef));
        }

        private static void ReadCharacterInfo(CharacterInfoUI instance)
        {
            if (instance == null) return;

            try
            {
                // Find all TextMeshProUGUI components in children
                var allTexts = GetAllTextComponents(instance.transform);

                if (allTexts.Count == 0)
                {
                    return;
                }

                StringBuilder sb = new StringBuilder();

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

                    // Skip texts with garbage patterns like "sds sdd"
                    if (HasGarbagePattern(text)) continue;

                    // Skip if it looks like a challenge description
                    if (IsLikelyChallengeText(text)) continue;

                    sb.Append(text).Append(". ");
                }

                string result = sb.ToString();

                // Allow re-reading after 0.3s
                float currentTime = UnityEngine.Time.unscaledTime;
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
            // Remove all non-digit characters except spaces and check if mostly numbers
            string cleaned = Regex.Replace(text, @"[^\d]", "");
            if (cleaned.Length == 0) return false;
            
            // If more than 50% of the text is digits, it's probably a number/progress
            float ratio = (float)cleaned.Length / text.Replace(" ", "").Length;
            if (ratio > 0.5f) return true;
            
            // Check for patterns like "10,000 / 10,000"
            if (Regex.IsMatch(text, @"\d+\s*/\s*\d+")) return true;
            
            return false;
        }

        private static bool HasGarbagePattern(string text)
        {
            // Detect garbage like "sds sdd sds dd sdsdsdsdsds"
            if (Regex.IsMatch(text, @"([sd]{2,}\s*){3,}", RegexOptions.IgnoreCase)) return true;
            if (Regex.IsMatch(text, @"([a-z]{1,2}\s+){5,}", RegexOptions.IgnoreCase)) return true;
            return false;
        }

        private static bool IsLikelyChallengeText(string text)
        {
            string lower = text.ToLower();
            if ((lower.Contains("kill") || lower.Contains("defeat") || lower.Contains("collect")) 
                && HasGarbagePattern(text)) return true;
            return false;
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
