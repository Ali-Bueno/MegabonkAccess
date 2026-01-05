using HarmonyLib;
using TMPro;
using UnityEngine;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;

namespace MegabonkAccess
{
    public static class SettingsValuePatch
    {
        // Helper to safely find components recursively
        private static void SafeGetComponentsInChildrenRecursive<T>(Transform parent, List<T> list) where T : Component
        {
            if (parent == null || !parent.gameObject.activeInHierarchy) return;
            
            var comp = parent.GetComponent<T>();
            if (comp != null) list.Add(comp);

            int childCount = parent.childCount;
            for (int i = 0; i < childCount; i++)
            {
                SafeGetComponentsInChildrenRecursive(parent.GetChild(i), list);
            }
        }

        private static List<T> SafeGetComponentsInChildren<T>(Transform parent) where T : Component
        {
            var list = new List<T>();
            SafeGetComponentsInChildrenRecursive(parent, list);
            return list;
        }

        [HarmonyPatch(typeof(SliderSetting), "ControllerInputDir")]
        public static class SliderSetting_ControllerInputDir_Patch
        {
            [HarmonyPostfix]
            public static void Postfix(SliderSetting __instance)
            {
                if (__instance == null) return;
                
                // For sliders, TMP_InputField is usually unique and correct
                var inputField = __instance.GetComponentInChildren<TMP_InputField>(); // Standard unity method often works for this specific component? 
                // If standard fails, use our safe one
                if (inputField == null)
                {
                    var list = SafeGetComponentsInChildren<TMP_InputField>(__instance.transform);
                    if (list.Count > 0) inputField = list[0];
                }

                if (inputField != null)
                {
                    TolkUtil.Speak(inputField.text);
                }
            }
        }

        [HarmonyPatch(typeof(EnumSetting), "ControllerInputDir")]
        public static class EnumSetting_ControllerInputDir_Patch
        {
            // State to hold previous texts: InstanceID -> Text
            public static void Prefix(EnumSetting __instance, out Dictionary<int, string> __state)
            {
                __state = new Dictionary<int, string>();
                if (__instance == null) return;

                var tmps = SafeGetComponentsInChildren<TextMeshProUGUI>(__instance.transform);
                foreach (var tmp in tmps)
                {
                    __state[tmp.GetInstanceID()] = tmp.text;
                }
            }

            [HarmonyPostfix]
            public static void Postfix(EnumSetting __instance, Dictionary<int, string> __state)
            {
                if (__instance == null) return;
                
                string textToSpeak = "";
                var tmps = SafeGetComponentsInChildren<TextMeshProUGUI>(__instance.transform);

                // Strategy 1: Find the text that CHANGED
                foreach (var tmp in tmps)
                {
                    int id = tmp.GetInstanceID();
                    if (__state != null && __state.ContainsKey(id))
                    {
                        if (__state[id] != tmp.text)
                        {
                            textToSpeak = tmp.text;
                            break;
                        }
                    }
                }

                // Strategy 2: If no text changed (maybe update is delayed?), use heuristics
                if (string.IsNullOrEmpty(textToSpeak))
                {
                    // Filter out likely Label candidates
                    var candidates = new List<TextMeshProUGUI>();
                    foreach(var tmp in tmps)
                    {
                         string name = tmp.gameObject.name.ToLower();
                         // Skip likely label names
                         if (name.Contains("title") || name.Contains("label") || name.Contains("header")) continue;
                         // Skip if text matches component name exactly (often placeholders)
                         if (tmp.text == tmp.gameObject.name) continue;
                         
                         candidates.Add(tmp);
                    }

                    if (candidates.Count == 1)
                    {
                        textToSpeak = candidates[0].text;
                    }
                    else if (candidates.Count > 1)
                    {
                        // If multiple, usually the last one is the value (rendered on top/right)
                        // Or look for "Value" in name
                        var valueComp = candidates.FirstOrDefault(c => c.gameObject.name.ToLower().Contains("value"));
                        if (valueComp != null) textToSpeak = valueComp.text;
                        else textToSpeak = candidates[candidates.Count - 1].text;
                    }
                    else if (tmps.Count > 0)
                    {
                        // Fallback to last component found if everything was filtered
                        textToSpeak = tmps[tmps.Count - 1].text;
                    }
                }

                if (!string.IsNullOrEmpty(textToSpeak))
                {
                    TolkUtil.Speak(SanitizeText(textToSpeak));
                }
            }
        }

        private static string SanitizeText(string text)
        {
            if (string.IsNullOrEmpty(text)) return "";

            // Remove Unity rich text tags: <...>
            string result = System.Text.RegularExpressions.Regex.Replace(text, "<.*?>", string.Empty);
            
            // Remove multiple spaces or weird characters if any
            result = result.Trim();

            return result;
        }
    }
}