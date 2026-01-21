using HarmonyLib;
using UnityEngine;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using TMPro;

namespace MegabonkAccess
{
    /// <summary>
    /// Patch for ShopFooter to announce shop item info when selected.
    /// Hooks the footer which displays the actual item description.
    /// </summary>
    [HarmonyPatch(typeof(ShopFooter), "Set")]
    public static class ShopFooter_Set_Patch
    {
        private static string lastAnnouncement = "";
        private static float lastAnnouncementTime = 0f;

        [HarmonyPostfix]
        public static void Postfix(ShopFooter __instance)
        {
            if (__instance == null) return;

            // Store reference for delayed reading
            var instanceRef = __instance;

            // Schedule the reading after a short delay to allow UI to update
            TolkUtil.ScheduleDelayedAction(() => ReadShopInfo(instanceRef));
        }

        private static void ReadShopInfo(ShopFooter instance)
        {
            if (instance == null) return;

            try
            {
                // Find all TextMeshProUGUI components in the footer
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

                    // Remove garbage placeholder text from the string
                    text = RemoveGarbageText(text);
                    if (string.IsNullOrEmpty(text)) continue;

                    // Skip very short texts and common button labels
                    if (text.Length < 2) continue;

                    string textLower = text.ToLower();
                    if (textLower == "buy" || textLower == "comprar" ||
                        textLower == "refund" || textLower == "reembolso" ||
                        textLower == "back" || textLower == "volver") continue;

                    sb.Append(text).Append(". ");
                }

                string result = sb.ToString();

                // Allow re-reading after 0.3s
                float currentTime = Time.unscaledTime;
                bool isDifferent = result != lastAnnouncement;
                bool enoughTimePassed = (currentTime - lastAnnouncementTime) > 0.3f;

                if (!string.IsNullOrEmpty(result) && (isDifferent || enoughTimePassed))
                {
                    lastAnnouncement = result;
                    lastAnnouncementTime = currentTime;
                    Plugin.Log.LogInfo($"Shop footer speaking: {result}");
                    TolkUtil.SpeakFromSpecializedPatch(result);
                }
            }
            catch (System.Exception e)
            {
                Plugin.Log.LogError($"ShopFooter patch error: {e.Message}");
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
            string result = Regex.Replace(text, "<.*?>", string.Empty);
            result = Regex.Replace(result, @"[\r\n]+", " ");
            result = Regex.Replace(result, @"\s+", " ");
            return result.Trim();
        }

        private static string RemoveGarbageText(string text)
        {
            if (string.IsNullOrEmpty(text)) return text;

            // Remove garbage placeholder patterns like "fsd fsdfesf efsdfes efs"
            // These are sequences of only f, s, d, e letters
            string result = Regex.Replace(text, @"\s+[fsde]+(\s+[fsde]+)+\s*$", "", RegexOptions.IgnoreCase);

            // Also remove if garbage is in the middle (after a period or sentence)
            result = Regex.Replace(result, @"\.\s*[fsde]+(\s+[fsde]+)+", ".", RegexOptions.IgnoreCase);

            return result.Trim();
        }
    }
}
