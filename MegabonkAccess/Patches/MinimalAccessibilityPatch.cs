using System;
using Assets.Scripts.Inventory__Items__Pickups.Interactables;
using HarmonyLib;
using UnityEngine;

namespace MegabonkAccess.Patches
{
    /// <summary>
    /// Absolutely minimal patches - only for interactables
    /// This is the safest approach that we know works
    /// </summary>

    // Announce when hovering over interactables
    [HarmonyPatch(typeof(DetectInteractables), "StartHovering")]
    public static class DetectInteractables_StartHovering_Announce
    {
        private static float lastAnnouncedTime;

        [HarmonyPostfix]
        public static void Postfix(GameObject newObject)
        {
            try
            {
                if (newObject == null) return;

                // Simple cooldown to prevent spam
                if (Time.time - lastAnnouncedTime < 1.5f) return;

                var interactable = newObject.GetComponent<BaseInteractable>();
                if (interactable != null)
                {
                    string message = "";

                    // Try to get the interact string
                    try
                    {
                        message = interactable.GetInteractString();
                    }
                    catch
                    {
                        // If that fails, use type name
                        string typeName = interactable.GetType().Name;
                        message = CleanTypeName(typeName);
                    }

                    if (!string.IsNullOrEmpty(message))
                    {
                        // Translate and speak
                        message = TranslateMessage(message);
                        TolkUtil.Speak(message, true);

                        Plugin.Log.LogInfo($"[MinimalAccessibility] Announced: {message}");
                        lastAnnouncedTime = Time.time;
                    }
                }
            }
            catch (Exception e)
            {
                Plugin.Log.LogError($"[MinimalAccessibility] Error in StartHovering: {e.Message}");
            }
        }

        private static string CleanTypeName(string typeName)
        {
            // Remove common prefixes/suffixes
            typeName = typeName.Replace("Interactable", "");
            typeName = typeName.Replace("interactable", "");

            // Add spaces before capital letters
            string result = "";
            for (int i = 0; i < typeName.Length; i++)
            {
                if (i > 0 && char.IsUpper(typeName[i]) && !char.IsUpper(typeName[i - 1]))
                {
                    result += " ";
                }
                result += typeName[i];
            }

            return result.Trim();
        }

        private static string TranslateMessage(string message)
        {
            // Basic translations for common interactions
            message = message.Replace("Open", "Abrir");
            message = message.Replace("Activate", "Activar");
            message = message.Replace("Talk to", "Hablar con");
            message = message.Replace("Use", "Usar");
            message = message.Replace("Enter", "Entrar");
            message = message.Replace("Leave", "Salir");
            message = message.Replace("Pick up", "Recoger");
            message = message.Replace("Interact", "Interactuar");

            // Object translations
            message = message.Replace("Chest", "Cofre");
            message = message.Replace("Portal", "Portal");
            message = message.Replace("Shrine", "Santuario");
            message = message.Replace("Door", "Puerta");
            message = message.Replace("Crypt", "Cripta");
            message = message.Replace("Grave", "Tumba");
            message = message.Replace("Coffin", "Ataúd");

            return message;
        }
    }

    // Simple confirmation when interacting
    [HarmonyPatch(typeof(BaseInteractable), "Interact")]
    public static class BaseInteractable_Interact_Confirm
    {
        [HarmonyPrefix]
        public static void Prefix()
        {
            try
            {
                // Simple interaction sound/announcement
                TolkUtil.Speak("OK", true);
            }
            catch (Exception e)
            {
                Plugin.Log.LogDebug($"[MinimalAccessibility] Interact error: {e.Message}");
            }
        }
    }
}