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
                TolkUtil.Speak(textToSpeak);
            }
        }
    }
}
