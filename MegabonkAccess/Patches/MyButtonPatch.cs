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

            // Ignore Character Buttons (handled by separate patch)
            if (__instance.GetType().Name == "MyButtonCharacter" || __instance is MyButtonCharacter)
            {
                return;
            }

            string textToSpeak = "";

            try
            {
                string typeName = __instance.GetType().Name;
                
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
            var sb = new System.Text.StringBuilder();
            
            // Try to read private fields
            var type = instance.GetType();
            
            // Basic UI Text fallback first (safest)
            string name = GetTextViaReflection(instance, "t_name");
            string rarity = GetTextViaReflection(instance, "t_rarity");
            string level = GetTextViaReflection(instance, "t_level");
            string desc = GetTextViaReflection(instance, "t_description");

            if (!string.IsNullOrEmpty(name)) sb.Append(name).Append(". ");
            if (!string.IsNullOrEmpty(rarity)) sb.Append(rarity).Append(". ");
            if (!string.IsNullOrEmpty(level)) sb.Append(level).Append(". ");
            if (!string.IsNullOrEmpty(desc)) sb.Append(desc).Append(". ");

            // If UI text found, good. If not, try Data?
            // Attempting Data via reflection invoke to avoid MissingMethodException
            if (sb.Length < 5) 
            {
                // Try IUpgradable
                try {
                    var upgradableField = AccessTools.Field(type, "upgradable");
                    var upgradable = upgradableField?.GetValue(instance); // Object
                    if (upgradable != null)
                    {
                        // Dynamic invoke GetUpgradeDescription
                        // Method signature: GetUpgradeDescription(int, List<StatModifier>, ERarity)
                        // This is hard to invoke safely if types mismatch.
                        // Try simple GetName()
                        var getName = AccessTools.Method(upgradable.GetType(), "GetName");
                        if (getName != null) sb.Append(getName.Invoke(upgradable, null)).Append(". ");
                    }
                } catch {}
            }

            return sb.ToString();
        }

        private static string GetEncounterButtonText(MyButton instance)
        {
            string desc = GetTextViaReflection(instance, "t_description");
            string rarity = GetTextViaReflection(instance, "t_rarity");
            return $"{rarity}. {desc}";
        }

        private static string GetTextViaReflection(object instance, string fieldName)
        {
            try
            {
                var field = AccessTools.Field(instance.GetType(), fieldName);
                if (field != null)
                {
                    var tmp = field.GetValue(instance) as TextMeshProUGUI;
                    if (tmp != null) return tmp.text;
                }
            }
            catch {}
            return "";
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