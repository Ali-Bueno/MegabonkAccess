using HarmonyLib;
using UnityEngine;
using System.Text;
using System.Text.RegularExpressions;

namespace MegabonkAccess
{
    /// <summary>
    /// Patch for EncounterButton to announce shrine/encounter options.
    /// Hooks StartHover which is called when navigating between shrine options.
    /// </summary>
    [HarmonyPatch(typeof(EncounterButton), "StartHover")]
    public static class EncounterButton_StartHover_Patch
    {
        private static string lastAnnouncement = "";

        [HarmonyPostfix]
        public static void Postfix(EncounterButton __instance)
        {
            if (__instance == null) return;

            try
            {
                StringBuilder sb = new StringBuilder();

                // Get description text
                if (__instance.t_description != null)
                {
                    string description = SanitizeText(__instance.t_description.text);
                    if (!string.IsNullOrEmpty(description))
                    {
                        sb.Append(description).Append(". ");
                    }
                }

                // Get rarity text
                if (__instance.t_rarity != null)
                {
                    string rarity = SanitizeText(__instance.t_rarity.text);
                    if (!string.IsNullOrEmpty(rarity))
                    {
                        sb.Append(rarity).Append(". ");
                    }
                }

                string result = sb.ToString();

                // Only speak if we have content AND it's different from last announcement
                if (!string.IsNullOrEmpty(result) && result != lastAnnouncement)
                {
                    lastAnnouncement = result;
                    Plugin.Log.LogInfo($"EncounterButton speaking: {result}");
                    TolkUtil.Speak(result);
                }
            }
            catch (System.Exception e)
            {
                Plugin.Log.LogError($"EncounterButton patch error: {e.Message}");
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
