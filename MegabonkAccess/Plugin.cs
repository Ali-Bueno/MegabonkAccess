using System.IO;
using System.Reflection;
using BepInEx;
using BepInEx.Logging;
using BepInEx.Unity.IL2CPP;
using HarmonyLib;
using UnityEngine;
using MegabonkAccess.Components;

namespace MegabonkAccess;

[BepInPlugin(MyPluginInfo.PLUGIN_GUID, MyPluginInfo.PLUGIN_NAME, MyPluginInfo.PLUGIN_VERSION)]
public class Plugin : BasePlugin
{
    internal static new ManualLogSource Log;
    internal static string PluginPath;
    private Harmony _harmony;
    private static GameObject _audioManagerObject;

    public override void Load()
    {
        // Plugin startup logic
        Log = base.Log;
        Log.LogInfo($"Plugin {MyPluginInfo.PLUGIN_GUID} is loaded!");

        // Get plugin directory path
        PluginPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        Log.LogInfo($"Plugin path: {PluginPath}");

        TolkUtil.Load();
        TolkUtil.Speak("Megabonk Accessibility Loaded");

        // Patches will handle all accessibility features
        _harmony = new Harmony(MyPluginInfo.PLUGIN_GUID);
        _harmony.PatchAll();

        Log.LogInfo("All patches applied successfully");

        // Crear el sistema de audio direccional 3D
        InitializeDirectionalAudio();
    }

    private void InitializeDirectionalAudio()
    {
        try
        {
            Log.LogInfo("[Plugin] Initializing directional 3D audio system...");

            // Crear GameObject persistente para el manager de audio
            _audioManagerObject = new GameObject("MegabonkAccessibility_DirectionalAudio");
            GameObject.DontDestroyOnLoad(_audioManagerObject);

            // Añadir el sistema de beacons para objetos interactuables
            _audioManagerObject.AddComponent<DirectionalAudioManager>();

            // Añadir el sistema de paredes (suavizado) + sonido de colisión
            _audioManagerObject.AddComponent<WallNavigationAudio>();

            // Añadir el sistema de anuncios de enemigos (TTS)
            _audioManagerObject.AddComponent<EnemyAnnouncementSystem>();

            // Añadir el sistema de audio direccional para enemigos (sonido sintético)
            _audioManagerObject.AddComponent<EnemyAudioSystem>();

            Log.LogInfo("[Plugin] All audio systems created successfully!");
        }
        catch (System.Exception e)
        {
            Log.LogError($"[Plugin] Failed to create directional audio system: {e.Message}");
        }
    }

    public override bool Unload()
    {
        // Limpiar el sistema de audio
        if (_audioManagerObject != null)
        {
            GameObject.Destroy(_audioManagerObject);
            _audioManagerObject = null;
        }

        _harmony?.UnpatchSelf();
        return base.Unload();
    }
}
