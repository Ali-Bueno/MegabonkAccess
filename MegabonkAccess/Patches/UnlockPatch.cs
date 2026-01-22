using HarmonyLib;
using UnityEngine;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using TMPro;

namespace MegabonkAccess
{
    /// <summary>
    /// Patch for UnlocksFooter to announce unlock item info when selected.
    /// Uses transform-based search compatible with IL2CPP.
    /// </summary>
    [HarmonyPatch(typeof(UnlocksFooter), "OnUnlockSelected")]
    public static class UnlocksFooter_OnUnlockSelected_Patch
    {
        private static string lastAnnouncement = "";
        private static float lastAnnouncementTime = 0f;

        private static readonly HashSet<string> SkipTexts = new HashSet<string>(System.StringComparer.OrdinalIgnoreCase)
        {
            "Buy", "Comprar", "Unlock", "Desbloquear", "Back", "Volver"
        };

        [HarmonyPostfix]
        public static void Postfix(UnlocksFooter __instance)
        {
            if (__instance == null) return;

            try
            {
                Transform root = __instance.transform;

                // Check if item is locked by looking for active requirements
                bool isLocked = HasActiveRequirements(root);

                StringBuilder sb = new StringBuilder();

                if (isLocked)
                {
                    // Item is locked - read name and requirements only
                    string name = FindTextByObjectName(root, "t_unlockName");
                    if (!string.IsNullOrEmpty(name))
                    {
                        sb.Append(name).Append(". ");
                    }

                    sb.Append("Bloqueado. ");

                    // Get requirements
                    string requirements = GetRequirementsText(root);
                    if (!string.IsNullOrEmpty(requirements))
                    {
                        sb.Append("Para desbloquear: ").Append(requirements);
                    }
                }
                else
                {
                    // Item is unlocked - read texts that are NOT inside requirement containers
                    var texts = GetTextsOutsideRequirements(root);
                    foreach (var text in texts)
                    {
                        if (string.IsNullOrEmpty(text)) continue;
                        if (text.Length < 4) continue;
                        if (SkipTexts.Contains(text)) continue;
                        if (HasGarbagePattern(text)) continue;
                        if (IsProgressText(text)) continue;

                        sb.Append(text).Append(". ");
                    }
                }

                string result = sb.ToString().Trim();

                // Prevent duplicate announcements
                float currentTime = Time.unscaledTime;
                bool isDifferent = result != lastAnnouncement;
                bool enoughTimePassed = (currentTime - lastAnnouncementTime) > 0.3f;

                if (!string.IsNullOrEmpty(result) && (isDifferent || enoughTimePassed))
                {
                    lastAnnouncement = result;
                    lastAnnouncementTime = currentTime;
                    Plugin.Log.LogInfo($"Unlock footer speaking: {result}");
                    TolkUtil.SpeakFromSpecializedPatch(result);
                }
            }
            catch (System.Exception e)
            {
                Plugin.Log.LogError($"UnlocksFooter patch error: {e.Message}");
            }
        }

        private static bool HasActiveRequirements(Transform parent)
        {
            if (parent == null) return false;

            string name = parent.name.ToLower();
            if ((name.Contains("requirement") || name.Contains("reqcontainer")) && parent.gameObject.activeInHierarchy)
            {
                // Check if it has active children
                for (int i = 0; i < parent.childCount; i++)
                {
                    var child = parent.GetChild(i);
                    if (child != null && child.gameObject.activeInHierarchy)
                    {
                        return true;
                    }
                }
            }

            // Recursively check children
            for (int i = 0; i < parent.childCount; i++)
            {
                if (HasActiveRequirements(parent.GetChild(i)))
                {
                    return true;
                }
            }

            return false;
        }

        private static string GetRequirementsText(Transform root)
        {
            StringBuilder sb = new StringBuilder();
            CollectRequirementsText(root, sb);
            return sb.ToString();
        }

        private static void CollectRequirementsText(Transform parent, StringBuilder sb)
        {
            if (parent == null) return;

            string name = parent.name.ToLower();

            // If this is a requirement prefab or container, get its text
            bool isReqObject = (name.Contains("requirement") || name.Contains("reqprefab") ||
                               (name.StartsWith("req") && parent.gameObject.activeInHierarchy));

            if (isReqObject && parent.gameObject.activeInHierarchy)
            {
                // First try to find specific t_requirement text (the mission description)
                string reqText = FindTextByObjectName(parent, "t_requirement");
                if (!string.IsNullOrEmpty(reqText) && !HasGarbagePattern(reqText))
                {
                    if (sb.Length > 0) sb.Append(". ");
                    sb.Append(reqText);

                    // Also get progress text
                    string progressText = FindTextByObjectName(parent, "t_progress");
                    if (!string.IsNullOrEmpty(progressText) && !HasGarbagePattern(progressText))
                    {
                        sb.Append(" (").Append(progressText).Append(")");
                    }
                }
                else
                {
                    // Fallback: get all texts from this requirement
                    var texts = GetAllTextComponents(parent);
                    foreach (var tmp in texts)
                    {
                        if (tmp == null) continue;
                        string text = SanitizeText(tmp.text);
                        if (string.IsNullOrEmpty(text) || text.Length < 3) continue;
                        if (HasGarbagePattern(text)) continue;

                        if (sb.Length > 0) sb.Append(". ");
                        sb.Append(text);
                    }
                }
                return;
            }

            // Recurse into children
            for (int i = 0; i < parent.childCount; i++)
            {
                CollectRequirementsText(parent.GetChild(i), sb);
            }
        }

        private static Transform FindChildByName(Transform parent, string targetName)
        {
            if (parent == null) return null;

            for (int i = 0; i < parent.childCount; i++)
            {
                var child = parent.GetChild(i);
                if (child != null && child.name.Equals(targetName, System.StringComparison.OrdinalIgnoreCase))
                {
                    return child;
                }

                var found = FindChildByName(child, targetName);
                if (found != null) return found;
            }

            return null;
        }

        private static string FindTextByObjectName(Transform root, string objectName)
        {
            var obj = FindChildByName(root, objectName);
            if (obj == null) return "";

            var tmp = obj.GetComponent<TextMeshProUGUI>();
            if (tmp == null) return "";

            return SanitizeText(tmp.text);
        }

        private static List<string> GetTextsOutsideRequirements(Transform parent)
        {
            var list = new List<string>();
            CollectTextsOutsideRequirements(parent, list, false);
            return list;
        }

        private static void CollectTextsOutsideRequirements(Transform parent, List<string> list, bool insideReq)
        {
            if (parent == null) return;

            string objName = parent.name.ToLower();
            bool isReqContainer = objName.Contains("requirement") || objName.Contains("reqcontainer") ||
                                  objName.Contains("reqprefab") || objName.StartsWith("req");

            // If we're entering a requirement container, mark it
            if (isReqContainer)
            {
                insideReq = true;
            }

            // Only collect text if we're NOT inside a requirement container
            if (!insideReq)
            {
                var tmp = parent.GetComponent<TextMeshProUGUI>();
                if (tmp != null)
                {
                    string text = SanitizeText(tmp.text);
                    if (!string.IsNullOrEmpty(text))
                    {
                        list.Add(text);
                    }
                }
            }

            // Recurse into children
            for (int i = 0; i < parent.childCount; i++)
            {
                CollectTextsOutsideRequirements(parent.GetChild(i), list, insideReq);
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

        private static bool HasGarbagePattern(string text)
        {
            if (string.IsNullOrEmpty(text)) return false;
            if (Regex.IsMatch(text, @"([sd]{2,}\s*){3,}", RegexOptions.IgnoreCase)) return true;
            if (Regex.IsMatch(text, @"([a-z]{1,2}\s+){5,}", RegexOptions.IgnoreCase)) return true;
            if (Regex.IsMatch(text, @"[fsde]{3,}", RegexOptions.IgnoreCase)) return true;
            return false;
        }

        private static bool IsProgressText(string text)
        {
            if (string.IsNullOrEmpty(text)) return false;
            // Match patterns like "100 / 10 000", "363 / 1.000", "5,000", "10.000"
            // Progress: number / number
            if (Regex.IsMatch(text, @"^\s*[\d.,\s]+\s*/\s*[\d.,\s]+\s*$")) return true;
            // Pure numbers with formatting: "5,000", "10.000", "100"
            if (Regex.IsMatch(text, @"^\s*[\d.,\s]+\s*$")) return true;
            return false;
        }

        private static string SanitizeText(string text)
        {
            if (string.IsNullOrEmpty(text)) return "";
            string result = Regex.Replace(text, "<.*?>", string.Empty);
            result = Regex.Replace(result, @"[\r\n]+", " ");
            result = Regex.Replace(result, @"\s+", " ");
            return result.Trim();
        }
    }
}
