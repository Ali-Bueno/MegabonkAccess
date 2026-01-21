using HarmonyLib;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;
using UnityEngine.UI;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts._Data;
using Assets.Scripts.Inventory__Items__Pickups.Stats;
using Assets.Scripts.Inventory__Items__Pickups;

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

            // Skip if a specialized patch recently spoke
            if (TolkUtil.ShouldSkipGenericPatch())
            {
                return;
            }

            // Ignore buttons handled by separate patches
            string typeName = __instance.GetType().Name;
            string objName = __instance.name ?? "";

            // Log for debugging
            Plugin.Log.LogDebug($"MyButton_OnSelect: type={typeName}, name={objName}");

            // Skip if it's a specialized button type (check by type name since IL2CPP 'is' can be unreliable)
            if (typeName == "MyButtonCharacter" ||
                typeName == "MyButtonShop" ||
                typeName == "MyButtonUnlock")
            {
                Plugin.Log.LogDebug($"MyButton_OnSelect: SKIPPING specialized button type={typeName}");
                return;
            }

            // Also skip if we're inside a specialized window (shop, unlock, character select)
            Transform parent = __instance.transform;
            for (int i = 0; i < 15 && parent != null; i++)
            {
                string parentName = parent.name ?? "";
                if (parentName.Contains("ShopWindow") ||
                    parentName.Contains("UnlocksWindow") ||
                    parentName.Contains("UnlocksUi") ||
                    parentName.Contains("CharacterSelect"))
                {
                    Plugin.Log.LogDebug($"MyButton_OnSelect: SKIPPING - inside window: {parentName}");
                    return;
                }
                parent = parent.parent;
            }

            string textToSpeak = "";

            try
            {
                if (typeName == "UpgradeButton")
                {
                    textToSpeak = GetUpgradeButtonText(__instance);
                }
                else if (typeName == "EncounterButton")
                {
                    textToSpeak = GetEncounterButtonText(__instance);
                }
            }
            catch (System.Exception e)
            {
                Plugin.Log.LogError($"Error in Upgrade/Encounter logic: {e}");
            }

            // --- Generic Fallback ---
            if (string.IsNullOrEmpty(textToSpeak))
            {
                try 
                {
                    var settingBtn = __instance as MyButtonSetting;
                    if (settingBtn != null)
                    {
                        // Logic for Settings...
                        // Simply reuse previous robust logic or keep it minimal
                        // To save tokens/complexity, I'll rely on generic text search for now
                        // since SettingsValuePatch handles the *changes*.
                        // But we want "Label: Value".
                        // Let's rely on generic text search finding "Label Value" if they are children.
                        
                        // Or try to find BetterSetting component
                        var betterSettings = SafeGetComponentsInChildren<BetterSetting>(settingBtn.transform);
                        if (betterSettings.Count > 0)
                        {
                            SpeakSetting(betterSettings[0]);
                            return;
                        }
                    }
                }
                catch {}

                var tmps = SafeGetComponentsInChildren<TextMeshProUGUI>(__instance.transform);
                if (tmps.Count > 0) textToSpeak = tmps[0].text;
                else
                {
                    var legacyTexts = SafeGetComponentsInChildren<Text>(__instance.transform);
                    if (legacyTexts.Count > 0) textToSpeak = legacyTexts[0].text;
                }
                
                if (string.IsNullOrEmpty(textToSpeak)) textToSpeak = __instance.name;
            }

            // --- Tooltip Logic ---
            string tooltipText = "";
            try
            {
                var tooltipObj = __instance.GetComponent<ToolTipObject>(); 
                if (tooltipObj == null) tooltipObj = __instance.GetComponentInChildren<ToolTipObject>();

                if (tooltipObj != null)
                {
                    var field = AccessTools.Field(typeof(ToolTipObject), "text");
                    if (field != null)
                    {
                        var val = field.GetValue(tooltipObj) as string;
                        if (!string.IsNullOrEmpty(val)) tooltipText = val;
                    }
                }
            }
            catch {}

            // Combine
            string finalSpeech = SanitizeText(textToSpeak);
            if (!string.IsNullOrEmpty(tooltipText))
            {
                finalSpeech = $"{finalSpeech}. {SanitizeText(tooltipText)}";
            }

            if (!string.IsNullOrEmpty(finalSpeech))
            {
                TolkUtil.Speak(finalSpeech);
            }
        }

        private static string GetUpgradeButtonText(MyButton instance)
        {
            // Use component search pattern (same as CharacterInfoUIPatch)
            // This bypasses IL2CPP field obfuscation issues
            var allTexts = SafeGetComponentsInChildren<TextMeshProUGUI>(instance.transform);
            var sb = new System.Text.StringBuilder();
            
            foreach (var tmp in allTexts)
            {
                if (tmp == null) continue;
                
                string text = SanitizeText(tmp.text);
                if (string.IsNullOrEmpty(text)) continue;
                
                // Skip very short texts (likely labels like "Lvl")
                if (text.Length < 3) continue;
                
                sb.Append(text).Append(". ");
            }
            
            return sb.ToString();
        }

        private static string GetEncounterButtonText(MyButton instance)
        {
            // Use component search pattern for consistency
            var allTexts = SafeGetComponentsInChildren<TextMeshProUGUI>(instance.transform);
            var sb = new System.Text.StringBuilder();
            
            foreach (var tmp in allTexts)
            {
                if (tmp == null) continue;
                
                string text = SanitizeText(tmp.text);
                if (string.IsNullOrEmpty(text)) continue;
                if (text.Length < 3) continue;
                
                sb.Append(text).Append(". ");
            }
            
            return sb.ToString();
        }


        private static void SpeakSetting(BetterSetting setting)
        {
            // Simplified logic for brevity/robustness
            string label = "";
            string value = "";
            try {
                var nameField = AccessTools.Field(typeof(BetterSetting), "settingName");
                if (nameField != null) 
                {
                    var tmp = nameField.GetValue(setting) as TextMeshProUGUI;
                    if (tmp != null) label = tmp.text;
                }
                
                // Try to find value component
                var allTmps = SafeGetComponentsInChildren<TextMeshProUGUI>(setting.transform);
                foreach(var tmp in allTmps)
                {
                    if (tmp.text != label) 
                    {
                        value = tmp.text;
                        break; // Assume first non-label is value
                    }
                }
            } catch {}

            string text = string.IsNullOrEmpty(value) ? label : $"{label}: {value}";
            TolkUtil.Speak(SanitizeText(text));
        }

        private static string SanitizeText(string text)
        {
            if (string.IsNullOrEmpty(text)) return "";
            string result = System.Text.RegularExpressions.Regex.Replace(text, "<.*?>", string.Empty);
            return result.Trim();
        }
    }
}