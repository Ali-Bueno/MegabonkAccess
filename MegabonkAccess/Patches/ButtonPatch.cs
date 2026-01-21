using HarmonyLib;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace MegabonkAccess
{
    [HarmonyPatch(typeof(ButtonNavigationBackdropAndText), "Select")]
    public static class ButtonNavigationBackdropAndText_Select_Patch
    {
        [HarmonyPostfix]
        public static void Postfix(ButtonNavigationBackdropAndText __instance)
        {
            if (__instance == null) return;

            // Skip if a specialized patch recently spoke
            if (TolkUtil.ShouldSkipGenericPatch())
            {
                return;
            }

            // Check if we're in a specialized menu WINDOW (not just any button with these names)
            Transform parent = __instance.transform;

            // Walk up the hierarchy to check for specialized menu WINDOWS (not main menu buttons)
            for (int i = 0; i < 10 && parent != null; i++)
            {
                string parentName = parent.name ?? "";
                // Only skip if we're inside an actual window, not a main menu button
                if (parentName == "ShopWindow" ||
                    parentName == "UnlocksWindow" ||
                    parentName == "CharacterSelectWindow" ||
                    parentName == "CharacterSelect" ||
                    parentName.Contains("Window") && (parentName.Contains("Shop") || parentName.Contains("Unlock") || parentName.Contains("Character")))
                {
                    Plugin.Log.LogDebug($"ButtonNavigation: SKIPPING - in specialized window: {parentName}");
                    return;
                }
                parent = parent.parent;
            }

            string textToSpeak = "";

            // Try to find text in the 'text' field
            if (__instance.text != null)
            {
                var tmp = __instance.text.GetComponent<TextMeshProUGUI>();
                if (tmp != null)
                {
                    textToSpeak = tmp.text;
                }
                else
                {
                    var legacyText = __instance.text.GetComponent<Text>();
                    if (legacyText != null)
                    {
                        textToSpeak = legacyText.text;
                    }
                }
            }

            // If found, speak it
            if (!string.IsNullOrEmpty(textToSpeak))
            {
                Plugin.Log.LogDebug($"ButtonNavigation speaking: {textToSpeak}");
                TolkUtil.Speak(textToSpeak);
            }
        }
    }
}
