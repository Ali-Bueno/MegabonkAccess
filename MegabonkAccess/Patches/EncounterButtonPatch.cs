using HarmonyLib;
using UnityEngine;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using TMPro;

namespace MegabonkAccess
{
    /// <summary>
    /// Tracks if encounter/shrine menu is open for audio beacon pausing.
    /// </summary>
    public static class EncounterMenuTracker
    {
        public static bool IsEncounterMenuOpen { get; private set; } = false;
        private static float lastEncounterTime = 0f;

        public static void OnEncounterHover()
        {
            IsEncounterMenuOpen = true;
            lastEncounterTime = Time.unscaledTime;
        }

        public static void Update()
        {
            // Auto-close after 2 seconds of no hover activity
            if (IsEncounterMenuOpen && Time.unscaledTime - lastEncounterTime > 2.0f)
            {
                IsEncounterMenuOpen = false;
            }
        }
    }

    /// <summary>
    /// Patch for EncounterButton to announce shrine/encounter options.
    /// Hooks StartHover which is called when navigating between shrine options.
    /// Uses Transform-based search compatible with IL2CPP.
    /// </summary>
    [HarmonyPatch(typeof(EncounterButton), "StartHover")]
    public static class EncounterButton_StartHover_Patch
    {
        private static string lastAnnouncement = "";
        private static float lastAnnouncementTime = 0f;

        private static readonly HashSet<string> SkipTexts = new HashSet<string>(System.StringComparer.OrdinalIgnoreCase)
        {
            "Select", "Seleccionar", "Choose", "Elegir", "Take", "Tomar",
            "Accept", "Aceptar", "Cancel", "Cancelar", "Back", "Volver"
        };

        [HarmonyPostfix]
        public static void Postfix(EncounterButton __instance)
        {
            if (__instance == null) return;

            try
            {
                // Mark encounter menu as open
                EncounterMenuTracker.OnEncounterHover();

                Transform root = __instance.transform;
                var texts = GetTextsFromTransform(root);

                StringBuilder sb = new StringBuilder();

                foreach (var text in texts)
                {
                    if (string.IsNullOrEmpty(text)) continue;
                    if (text.Length < 3) continue;
                    if (SkipTexts.Contains(text)) continue;
                    if (HasGarbagePattern(text)) continue;
                    if (IsProgressText(text)) continue;

                    sb.Append(text).Append(". ");
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
                    Plugin.Log.LogInfo($"EncounterButton speaking: {result}");
                    TolkUtil.SpeakFromSpecializedPatch(result);
                }
            }
            catch (System.Exception e)
            {
                Plugin.Log.LogError($"EncounterButton patch error: {e.Message}");
            }
        }

        private static List<string> GetTextsFromTransform(Transform parent)
        {
            var list = new List<string>();
            CollectTexts(parent, list);
            return list;
        }

        private static void CollectTexts(Transform parent, List<string> list)
        {
            if (parent == null) return;

            var tmp = parent.GetComponent<TextMeshProUGUI>();
            if (tmp != null)
            {
                string text = SanitizeText(tmp.text);
                if (!string.IsNullOrEmpty(text))
                {
                    list.Add(text);
                }
            }

            for (int i = 0; i < parent.childCount; i++)
            {
                CollectTexts(parent.GetChild(i), list);
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
    }
}
