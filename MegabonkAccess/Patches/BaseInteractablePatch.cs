using HarmonyLib;
using UnityEngine;

namespace MegabonkAccess
{
    /// <summary>
    /// Universal patch for all interactables (shrines, chests, NPCs, etc.)
    /// Announces the interaction text when hovering over any BaseInteractable.
    /// </summary>
    [HarmonyPatch(typeof(BaseInteractable), "StartHover")]
    public static class BaseInteractable_StartHover_Patch
    {
        private static string lastAnnouncement = "";

        [HarmonyPostfix]
        public static void Postfix(BaseInteractable __instance)
        {
            if (__instance == null) return;

            try
            {
                // Log object name and parent for debugging (to understand scene structure)
                var go = __instance.gameObject;
                string parentName = go.transform.parent != null ? go.transform.parent.name : "ROOT";
                Plugin.Log.LogInfo($"[Interactable] Name: {go.name}, Parent: {parentName}, Type: {__instance.GetType().Name}");

                // Get the interaction string from the interactable
                string interactText = __instance.GetInteractString();

                if (string.IsNullOrEmpty(interactText)) return;

                // Clean up the text - remove all TextMeshPro tags
                string cleanText = SanitizeText(interactText);

                // Only speak if different from last announcement and not empty after cleaning
                if (!string.IsNullOrEmpty(cleanText) && cleanText != lastAnnouncement)
                {
                    lastAnnouncement = cleanText;
                    Plugin.Log.LogInfo($"BaseInteractable speaking: {cleanText}");
                    TolkUtil.Speak(cleanText);
                }

                // Register for directional audio beacon
                try
                {
                    var audioManager = MegabonkAccess.Components.DirectionalAudioManager.Instance;
                    if (audioManager != null)
                    {
                        audioManager.RegisterDiscoveredInteractable(__instance);
                    }
                }
                catch { }
            }
            catch (System.Exception e)
            {
                Plugin.Log.LogError($"BaseInteractable patch error: {e.Message}");
            }
        }

        private static string SanitizeText(string text)
        {
            if (string.IsNullOrEmpty(text)) return "";

            // Remove all TextMeshPro rich text tags including:
            // - Standard tags: <color>, <size>, <b>, <i>, etc.
            // - Sprite tags: <sprite name=xxx>, <sprite index=xxx>
            // - Any other tags with attributes
            string result = System.Text.RegularExpressions.Regex.Replace(text, "<[^>]+>", string.Empty);

            // Remove excessive whitespace and newlines
            result = System.Text.RegularExpressions.Regex.Replace(result, @"[\r\n]+", " ");
            result = System.Text.RegularExpressions.Regex.Replace(result, @"\s+", " ");

            return result.Trim();
        }
    }

    /// <summary>
    /// Patch to remove audio beacon after interacting with an object.
    /// </summary>
    [HarmonyPatch(typeof(BaseInteractable), "Interact")]
    public static class BaseInteractable_Interact_Patch
    {
        [HarmonyPostfix]
        public static void Postfix(BaseInteractable __instance)
        {
            if (__instance == null) return;

            try
            {
                // Remove the audio beacon for this interactable
                var audioManager = MegabonkAccess.Components.DirectionalAudioManager.Instance;
                if (audioManager != null)
                {
                    audioManager.RemoveInteractedBeacon(__instance);
                }
            }
            catch { }
        }
    }
}
