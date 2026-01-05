using HarmonyLib;
using UnityEngine;

namespace MegabonkAccess
{
    [HarmonyPatch(typeof(TooltipNew), "Set")]
    public static class TooltipNew_Set_Patch
    {
        [HarmonyPostfix]
        public static void Postfix(string text)
        {
            if (!string.IsNullOrEmpty(text))
            {
                // TolkUtil.Speak ensures it interrupts properly if configured, 
                // but here we might want to let the button name finish?
                // Usually Speak() interrupts. 
                // If Tooltip appears immediately after button select, it might cut off the button name.
                // But Tooltips usually appear on Hover. 
                // Does "Set" get called on Controller select? 
                // If the game uses mouse simulation for controller, yes.
                
                // Let's assume it works.
                TolkUtil.Speak(SanitizeText(text));
            }
        }

        private static string SanitizeText(string text)
        {
            if (string.IsNullOrEmpty(text)) return "";
            string result = System.Text.RegularExpressions.Regex.Replace(text, "<.*?>", string.Empty);
            return result.Trim();
        }
    }
}
