using System;
using Assets.Scripts.Saves___Serialization.SaveFiles;
using Assets.Scripts.Settings___Saves.SaveFiles.ConfigSaves;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
	private static bool USE_ENCRYPTION;

	private static int settingsVersion;

	private static ulong steamIdSave;

	private const string configName = "config.json";

	private const string statsName = "stats.json";

	private const string progressionName = "progression.json";

	public const string controllersName = "controller_config.json";

	public ConfigSaveFile config;

	public StatsSaveFile stats;

	public ProgressionSaveFile progression;

	private static SaveManager _003CInstance_003Ek__BackingField;

	public static Action A_SavesLoaded;

	public static Action A_ProgressionSaved;

	private static string cloudDirectory;

	private static string localDirectory;

	private const string lastSteamIdKey = "saves_last_steamid";

	public static bool loaded;

	private bool usingNoSave;

	public static SaveManager Instance
	{
		get
		{
			return _003CInstance_003Ek__BackingField;
		}
		private set
		{
			_003CInstance_003Ek__BackingField = value;
		}
	}

	public void Init()
	{
	}

	private void Awake()
	{
	}

	private void OnDestroy()
	{
	}

	private void OnApplicationQuit()
	{
	}

	public void SaveConfig()
	{
	}

	public void SaveStats()
	{
	}

	public void SaveProgression()
	{
	}

	private void SaveTemp(string serializedJson, string filePath, bool encrypt)
	{
	}

	private static string GetDataPath()
	{
		return null;
	}

	private static string GetCloudFolder()
	{
		return null;
	}

	private static string GetLocalFolder()
	{
		return null;
	}

	private string GetConfigPath()
	{
		return null;
	}

	private string GetStatsPath()
	{
		return null;
	}

	private string GetProgressionPath()
	{
		return null;
	}

	public static string GetControllersPath()
	{
		return null;
	}

	public static string GetControllersDir()
	{
		return null;
	}

	public void Load(bool loadBackup)
	{
	}

	public void LoadNoSave()
	{
	}

	public bool Load(ulong steamId, bool loadBackup, out string failReason, out string failPath)
	{
		failReason = null;
		failPath = null;
		return false;
	}

	public void NewSaveConfig()
	{
	}

	public void ResetAll()
	{
	}

	public void SaveControllers()
	{
	}

	public void LoadControllers()
	{
	}
}
