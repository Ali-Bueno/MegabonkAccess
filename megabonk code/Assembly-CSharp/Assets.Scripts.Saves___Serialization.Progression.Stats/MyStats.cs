using System;

namespace Assets.Scripts.Saves___Serialization.Progression.Stats;

public static class MyStats
{
	private static bool hasUnsavedChanges;

	public static Action<string, MyStat> A_StatUpdated;

	private static float nextSaveTimeReady;

	private static float saveCooldown;

	public static void Init()
	{
	}

	public static void Cleanup()
	{
	}

	public static void AddValue(EMyStat statName, float value)
	{
	}

	public static void AddValue(string statName, float value)
	{
	}

	private static void SetValueInternal(string statName, MyStat stat, float value)
	{
	}

	public static void SetValueForce(string statName, float value)
	{
	}

	public static bool HasStat(string statName)
	{
		return false;
	}

	public static float GetStat(string statName)
	{
		return 0f;
	}

	private static void OnProgressionLoaded()
	{
	}

	private static void OnProgressionSaved()
	{
	}

	private static void OnPause(bool paused)
	{
	}
}
