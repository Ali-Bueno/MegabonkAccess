using HarmonyLib;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;
using UnityEngine.UI;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;

namespace MegabonkAccess
{
    [HarmonyPatch(typeof(MyButton), "OnSelect")]
    public static class MyButton_OnSelect_Patch
    {
        // Reuse safe component search logic
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

        [HarmonyPostfix]
        public static void Postfix(MyButton __instance)
        {
            if (__instance == null) return;

            try 
            {
                // Check if it's a setting button
                var settingBtn = __instance as MyButtonSetting;
                if (settingBtn != null)
                {
                    BetterSetting betterSetting = null;

                    // 1. Try to find the component safely
                    var betterSettings = SafeGetComponentsInChildren<BetterSetting>(settingBtn.transform);
                    if (betterSettings.Count > 0) betterSetting = betterSettings[0];
                    
                    // 2. Fallback to reflection for field betterSetting
                    if (betterSetting == null)
                    {
                        var field = AccessTools.Field(typeof(MyButtonSetting), "betterSetting");
                        if (field != null)
                        {
                            betterSetting = field.GetValue(settingBtn) as BetterSetting;
                        }
                    }

                    if (betterSetting != null)
                    {
                        SpeakSetting(betterSetting);
                        return;
                    }
                }
            }
            catch (System.Exception e)
            {
                 Plugin.Log.LogError($"Error checking MyButtonSetting in Patch: {e}");
            }

            // Generic button handling (if not a setting or failed)
            string textToSpeak = "";
            var tmps = SafeGetComponentsInChildren<TextMeshProUGUI>(__instance.transform);
            if (tmps.Count > 0)
            {
                // Concatenate all visible text for generic buttons? 
                // Usually just the first one is enough (Button Text)
                textToSpeak = tmps[0].text;
            }
            else
            {
                var legacyTexts = SafeGetComponentsInChildren<Text>(__instance.transform);
                if (legacyTexts.Count > 0)
                {
                    textToSpeak = legacyTexts[0].text;
                }
            }
            
            if (string.IsNullOrEmpty(textToSpeak))
            {
                textToSpeak = __instance.name;
            }

            if (!string.IsNullOrEmpty(textToSpeak))
            {
                TolkUtil.Speak(SanitizeText(textToSpeak));
            }
        }

        private static void SpeakSetting(BetterSetting setting)
        {
            string label = "";
            string value = "";

            try
            {
                // 1. Get Label (settingName)
                TextMeshProUGUI settingNameRef = null;
                try {
                    var nameField = AccessTools.Field(typeof(BetterSetting), "settingName");
                    if (nameField != null) settingNameRef = nameField.GetValue(setting) as TextMeshProUGUI;
                } catch {}

                if (settingNameRef != null)
                {
                    label = settingNameRef.text;
                }

                // 2. Get Value Text
                
                // Strategy A: Try known fields via Reflection (Direct Source)
                if (string.IsNullOrEmpty(value))
                {
                    var slider = setting as SliderSetting;
                    if (slider != null)
                    {
                        try {
                            var field = AccessTools.Field(typeof(SliderSetting), "valueText");
                            if (field != null) 
                            {
                                var input = field.GetValue(slider) as TMP_InputField;
                                if (input != null) value = input.text;
                            }
                        } catch {}
                    }
                    
                    var enumSet = setting as EnumSetting;
                    if (enumSet != null)
                    {
                        try {
                            var field = AccessTools.Field(typeof(EnumSetting), "valueText");
                            if (field != null)
                            {
                                var tmp = field.GetValue(enumSet) as TextMeshProUGUI;
                                if (tmp != null) value = tmp.text;
                            }
                        } catch {}
                    }
                }

                // Strategy B: Component Search Fallback
                if (string.IsNullOrEmpty(value))
                {
                    var allTmps = SafeGetComponentsInChildren<TextMeshProUGUI>(setting.transform);
                    var candidates = new List<TextMeshProUGUI>();

                    foreach (var tmp in allTmps)
                    {
                        // Exclude Label
                        if (settingNameRef != null && tmp.GetInstanceID() == settingNameRef.GetInstanceID()) continue;
                        // Exclude Title if it matches label text exactly (duplicate check)
                        if (tmp.text == label) continue;

                        candidates.Add(tmp);
                    }

                    if (candidates.Count > 0)
                    {
                        // Priority 1: Object name contains "Value"
                        var valObj = candidates.FirstOrDefault(c => c.gameObject.name.ToLower().Contains("value"));
                        if (valObj != null) 
                        {
                            value = valObj.text;
                        }
                        else 
                        {
                            // Priority 2: The Last text component (usually rendered on top/right)
                            value = candidates[candidates.Count - 1].text;
                        }
                    }

                    // Special case for Slider input field if not found via TMP
                    if (string.IsNullOrEmpty(value) && setting is SliderSetting)
                    {
                        var inputs = SafeGetComponentsInChildren<TMP_InputField>(setting.transform);
                        if (inputs.Count > 0) value = inputs[0].text;
                    }
                }
            }
            catch(System.Exception e)
            {
                Plugin.Log.LogError($"Error in SpeakSetting: {e}");
            }

            // Final Output Construction
            string fullText;
            if (!string.IsNullOrEmpty(label) && !string.IsNullOrEmpty(value))
            {
                // Avoid reading "Shake: Shake" if label and value are somehow identical
                if (label.Equals(value, System.StringComparison.OrdinalIgnoreCase)) 
                    fullText = label;
                else
                    fullText = $"{label}: {value}";
            }
            else if (!string.IsNullOrEmpty(value))
            {
                fullText = value;
            }
            else
            {
                fullText = label;
            }

            TolkUtil.Speak(SanitizeText(fullText));
        }

        private static string SanitizeText(string text)
        {
            if (string.IsNullOrEmpty(text)) return "";
            string result = System.Text.RegularExpressions.Regex.Replace(text, "<.*?>", string.Empty);
            return result.Trim();
        }
    }
}