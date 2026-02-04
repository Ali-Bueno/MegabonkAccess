using HarmonyLib;
using Assets.Scripts.Game.Spawning;
using TMPro;
using UnityEngine;

namespace MegabonkAccess.Patches
{
    /// <summary>
    /// Patch para leer los mensajes de alerta del juego (enjambres, jefes, tiempo).
    /// </summary>
    [HarmonyPatch(typeof(AlertUi))]
    public static class AlertUiPatch
    {
        private static string lastAlertText = "";
        private static float lastAlertTime = 0f;
        private const float DEBOUNCE_TIME = 1.0f;

        /// <summary>
        /// Lee el texto de la alerta y lo anuncia.
        /// </summary>
        private static void ReadAlertText(AlertUi instance, string source)
        {
            try
            {
                if (instance == null) return;

                // Debounce para evitar repeticiones
                if (Time.time - lastAlertTime < DEBOUNCE_TIME) return;

                // Leer el texto de la alerta
                var alertText = instance.t_alert;
                if (alertText == null)
                {
                    Plugin.Log.LogDebug($"[AlertUi] {source}: t_alert is null");
                    return;
                }

                string text = alertText.text;
                if (string.IsNullOrEmpty(text))
                {
                    Plugin.Log.LogDebug($"[AlertUi] {source}: text is empty");
                    return;
                }

                // Evitar repetir el mismo mensaje
                if (text == lastAlertText) return;

                lastAlertText = text;
                lastAlertTime = Time.time;

                Plugin.Log.LogInfo($"[AlertUi] {source}: {text}");
                TolkUtil.Speak(text);
            }
            catch (System.Exception e)
            {
                Plugin.Log.LogDebug($"[AlertUi] {source} error: {e.Message}");
            }
        }

        /// <summary>
        /// Patch para SetAlert - se llama cuando se configura una alerta de ola.
        /// </summary>
        [HarmonyPatch("SetAlert")]
        [HarmonyPostfix]
        public static void SetAlert_Postfix(AlertUi __instance, EWaveType waveType)
        {
            Plugin.Log.LogInfo($"[AlertUi] SetAlert called with waveType: {waveType}");
            ReadAlertText(__instance, $"SetAlert({waveType})");
        }

        /// <summary>
        /// Patch para SetAlertBoss - anuncia la llegada de un jefe.
        /// </summary>
        [HarmonyPatch("SetAlertBoss")]
        [HarmonyPostfix]
        public static void SetAlertBoss_Postfix(AlertUi __instance)
        {
            Plugin.Log.LogInfo("[AlertUi] SetAlertBoss called");
            ReadAlertText(__instance, "SetAlertBoss");
        }

        /// <summary>
        /// Patch para SetAlertTimesUp - anuncia que el tiempo se acabó.
        /// </summary>
        [HarmonyPatch("SetAlertTimesUp")]
        [HarmonyPostfix]
        public static void SetAlertTimesUp_Postfix(AlertUi __instance)
        {
            Plugin.Log.LogInfo("[AlertUi] SetAlertTimesUp called");
            ReadAlertText(__instance, "SetAlertTimesUp");
        }

        /// <summary>
        /// Patch para OnSwarmStarted - cuando empieza un enjambre.
        /// </summary>
        [HarmonyPatch("OnSwarmStarted")]
        [HarmonyPostfix]
        public static void OnSwarmStarted_Postfix(AlertUi __instance)
        {
            Plugin.Log.LogInfo("[AlertUi] OnSwarmStarted called");
            ReadAlertText(__instance, "OnSwarmStarted");
        }

        /// <summary>
        /// Patch para OnFinalSwarmStarted - cuando empieza el enjambre final.
        /// </summary>
        [HarmonyPatch("OnFinalSwarmStarted")]
        [HarmonyPostfix]
        public static void OnFinalSwarmStarted_Postfix(AlertUi __instance)
        {
            Plugin.Log.LogInfo("[AlertUi] OnFinalSwarmStarted called");
            ReadAlertText(__instance, "OnFinalSwarmStarted");
        }
    }
}
