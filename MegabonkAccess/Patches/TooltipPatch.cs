using HarmonyLib;
using UnityEngine;

namespace MegabonkAccess
{
    /// <summary>
    /// Patch for TooltipNew to announce tooltip text when shown.
    /// This catches ALL tooltips in the game (items, abilities, stats, etc.)
    /// </summary>
    [HarmonyPatch(typeof(TooltipNew), "Set")]
    public static class TooltipNew_Set_Patch
    {
        private static string lastTooltip = "";
        private static float lastTooltipTime = 0f;

        [HarmonyPostfix]
        public static void Postfix(string text)
        {
            // Log ALL calls to Set, even empty ones
            Plugin.Log.LogInfo($"TooltipNew.Set called with: '{text ?? "NULL"}'");

            if (string.IsNullOrEmpty(text)) return;

            try
            {
                // Clean the text
                string cleanText = SanitizeText(text);
                Plugin.Log.LogInfo($"Tooltip after sanitize: '{cleanText}'");

                if (string.IsNullOrEmpty(cleanText)) return;

                // Avoid repeating the same tooltip too quickly (within 0.5s)
                // But allow re-reading if enough time has passed
                float currentTime = Time.unscaledTime;
                if (cleanText == lastTooltip && (currentTime - lastTooltipTime) < 0.5f)
                {
                    Plugin.Log.LogInfo($"Tooltip skipped (duplicate): '{cleanText}'");
                    return;
                }

                lastTooltip = cleanText;
                lastTooltipTime = currentTime;

                Plugin.Log.LogInfo($"Tooltip speaking: {cleanText}");
                TolkUtil.Speak(cleanText);
            }
            catch (System.Exception e)
            {
                Plugin.Log.LogError($"Tooltip patch error: {e.Message}");
            }
        }

        private static string SanitizeText(string text)
        {
            if (string.IsNullOrEmpty(text)) return "";
            // Remove rich text tags
            string result = System.Text.RegularExpressions.Regex.Replace(text, "<.*?>", string.Empty);
            // Remove newlines and excessive whitespace
            result = System.Text.RegularExpressions.Regex.Replace(result, @"[\r\n]+", " ");
            result = System.Text.RegularExpressions.Regex.Replace(result, @"\s+", " ");
            return result.Trim();
        }
    }
}
