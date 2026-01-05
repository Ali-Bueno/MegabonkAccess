using System;
using System.Collections.Generic;
using Assets.Scripts._Data.Progression;
using Assets.Scripts.Saves___Serialization.Progression.Achievements;
using Assets.Scripts.Saves___Serialization.Progression.Stats;

namespace Assets.Scripts.Saves___Serialization.Progression.Unlocks;

public static class MyAchievements
{
	[Serializable]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9;

		public static Func<MyAchievement, bool> _003C_003E9__44_1;

		public static Func<MyAchievement, bool> _003C_003E9__44_2;

		internal bool _003CGetAchievementTypeProgress_003Eb__44_1(MyAchievement a)
		{
			return false;
		}

		internal bool _003CGetAchievementTypeProgress_003Eb__44_2(MyAchievement a)
		{
			return false;
		}
	}

	private sealed class _003C_003Ec__DisplayClass44_0
	{
		public EAchievementType achievementType;

		internal bool _003CGetAchievementTypeProgress_003Eb__0(MyAchievement a)
		{
			return false;
		}
	}

	public static bool testUnlockEverything;

	private static bool hasUnsavedChanges;

	public static Action<MyAchievement> A_Unlocked;

	public static Action<string> A_TryUnlock;

	private static Dictionary<string, List<MyAchievement>> statTrackers;

	private static bool startedTracking;

	public static int fakeCharacters;

	public static int fakeWeapons;

	public static int fakeItems;

	public static int fakeMaps;

	public static int fakeTomes;

	public static int fakeAchievements;

	private static HashSet<MyStat> queuedStatNames;

	private static float statTrackersCooldown;

	private static float nextStatTrackersCheck;

	private static float nextSaveTimeReady;

	private static float saveCooldown;

	public static bool IsTestUnlockEverything()
	{
		return false;
	}

	public static void Init()
	{
	}

	public static void Cleanup()
	{
	}

	private static void TryStartStatTracking()
	{
	}

	public static bool TryUnlock(string unlockName)
	{
		return false;
	}

	private static bool AreAchievementsDisabled()
	{
		return false;
	}

	private static void OnStatUpdated(string statName, MyStat stat)
	{
	}

	public static void Update()
	{
	}

	public static bool IsAchievementDone(string achName)
	{
		return false;
	}

	public static bool CheckAchievementValue(string achievementName, int value)
	{
		return false;
	}

	public static int GetAchievementTargetValue(string achName)
	{
		return 0;
	}

	public static float GetAchievementTargetValueFloat(string achName)
	{
		return 0f;
	}

	public static bool IsUnlocked(UnlockableBase unlockable, out string requirementsString)
	{
		requirementsString = null;
		return false;
	}

	public static bool IsUnlocked(MyAchievement myAchievement)
	{
		return false;
	}

	public static bool IsUnlockedInternalNameAch(string achName)
	{
		return false;
	}

	private static bool IsUnlocked(string unlockName)
	{
		return false;
	}

	public static bool IsPurchased(UnlockableBase unlockable)
	{
		return false;
	}

	public static bool IsAvailable(UnlockableBase unlockable)
	{
		return false;
	}

	public static bool IsActivated(UnlockableBase unlockable)
	{
		return false;
	}

	public static bool CanToggleActivation(UnlockableBase unlockable)
	{
		return false;
	}

	private static void OnProgressionSaved()
	{
	}

	private static void OnProgressionLoaded()
	{
	}

	private static void OnDataLoaded()
	{
	}

	private static void OnPause(bool paused)
	{
	}

	public static int NumCompletedAchievements()
	{
		return 0;
	}

	public static int NumTotalAchievements()
	{
		return 0;
	}

	public static bool AreAllQuestsCompleted()
	{
		return false;
	}

	public static void GetAchievementTypeProgress(EAchievementType achievementType, out int completed, out int total, out int unclaimed)
	{
		completed = default(int);
		total = default(int);
		unclaimed = default(int);
	}
}
