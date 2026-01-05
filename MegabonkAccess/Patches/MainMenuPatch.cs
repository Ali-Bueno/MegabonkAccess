using HarmonyLib;
using UnityEngine;

namespace MegabonkAccess
{
    [HarmonyPatch(typeof(MainMenu), "Start")]
    public static class MainMenu_Start_Patch
    {
        [HarmonyPostfix]
        public static void Postfix()
        {
            TolkUtil.Speak("Main Menu");
        }
    }
}
