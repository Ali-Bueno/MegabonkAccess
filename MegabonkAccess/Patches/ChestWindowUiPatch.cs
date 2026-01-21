using HarmonyLib;
using UnityEngine;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using TMPro;

namespace MegabonkAccess
{
    /// <summary>
    /// Patch for ChestWindowUi to announce chest contents when opening.
    /// Hooks OpeningFinished which is called when the chest reveals its item.
    /// </summary>
    [HarmonyPatch(typeof(ChestWindowUi), "OpeningFinished")]
    public static class ChestWindowUi_OpeningFinished_Patch
    {
        private static string lastAnnouncement = "";

        // Texts to skip (button labels)
        private static readonly HashSet<string> SkipTexts = new HashSet<string>(System.StringComparer.OrdinalIgnoreCase)
        {
            "Open", "Abrir", "Take", "Tomar", "Coger",
            "Leave", "Dejar", "Banish", "Desterrar",
            "Discard", "Descartar", "Close", "Cerrar",
            "Back", "Volver", "Cancel", "Cancelar"
        };

        [HarmonyPostfix]
        public static void Postfix(ChestWindowUi __instance)
        {
            if (__instance == null) return;

            try
            {
                // Find all TextMeshProUGUI components in children
                var allTexts = GetAllTextComponents(__instance.transform);
                
                if (allTexts.Count == 0)
                {
                    Plugin.Log.LogWarning("ChestWindowUi: No text components found");
                    return;
                }

                StringBuilder sb = new StringBuilder();

                foreach (var tmp in allTexts)
                {
                    if (tmp == null) continue;
                    
                    string text = SanitizeText(tmp.text);
                    if (string.IsNullOrEmpty(text)) continue;
                    
                    // Skip button labels
                    if (SkipTexts.Contains(text)) continue;
                    
                    // Skip very short texts (likely labels)
                    if (text.Length < 3) continue;
                    
                    sb.Append(text).Append(". ");
                }

                string result = sb.ToString();
                
                // Only speak if we have content AND it's different from last announcement
                if (!string.IsNullOrEmpty(result) && result != lastAnnouncement)
                {
                    lastAnnouncement = result;
                    Plugin.Log.LogInfo($"ChestWindowUi speaking: {result}");
                    TolkUtil.Speak(result);
                }
            }
            catch (System.Exception e)
            {
                Plugin.Log.LogError($"ChestWindowUi patch error: {e.Message}");
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
            // Remove rich text tags
            string result = Regex.Replace(text, "<.*?>", string.Empty);
            // Remove newlines and excessive whitespace
            result = Regex.Replace(result, @"[\r\n]+", " ");
            result = Regex.Replace(result, @"\s+", " ");
            return result.Trim();
        }
    }
}
