using System.Reflection;
using UnityEngine;

namespace Assets.Scripts.Settings___Saves.SaveFiles;

public static class ConfigSettingsUtility
{
	public static SettingType GetSettingType(FieldInfo field)
	{
		return default(SettingType);
	}

	public static string CheckSettingName(string settingName)
	{
		return null;
	}

	public static string GetSettingDescription(string settingName)
	{
		return null;
	}

	public static string[] GetSettingValues(string settingName)
	{
		return null;
	}

	public static bool GetSliderWholeNumbers(string settingName)
	{
		return false;
	}

	public static void GetSliderRange(string settingName, out float min, out float max)
	{
		min = default(float);
		max = default(float);
	}

	private static string[] GetResolutionNames()
	{
		return null;
	}

	private static string[] GetLanguageNames()
	{
		return null;
	}

	public static Resolution[] GetMyResolutions()
	{
		return null;
	}

	public static string[] GetControllers()
	{
		return null;
	}

	public static bool AreResolutionSame(Resolution r1, Resolution r2)
	{
		return false;
	}

	private static string[] GetMonitorNames()
	{
		return null;
	}

	public static string SettingNameToReadable(string s)
	{
		return null;
	}

	public static string SettingNameToReadable(string s, CFSettings cfSettings)
	{
		return null;
	}

	public static string GetSettingEnumLocalized(string settingEnumValue)
	{
		return null;
	}

	public static float GetSliderIncrement(string settingName)
	{
		return 0f;
	}
}
