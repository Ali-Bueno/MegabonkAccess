using System;
using System.Collections.Generic;

namespace Assets.Scripts.Saves___Serialization.Progression.Challenges;

public class ChallengesTracker
{
	public const string MODIFIER_NO_MOVEMENT = "no_movement";

	public const string MODIFIER_NO_ITEMS = "no_items";

	public const string MODIFIER_NO_WEAPONS = "no_weapons";

	public const string MODIFIER_INVERTED_CONTROLS = "inverted_controls";

	public const string MODIFIER_BLIND = "blind";

	public const string MODIFIER_SPEEDRUN = "speedrun";

	public const string MODIFIER_CRYPT = "crypt";

	public const string MODIFIER_MINIMALIST = "minimalist";

	public const string MODIFIER_NO_XP = "no_xp";

	private static ChallengeWinCondition winCondition;

	public static ChallengeModifier[] challengeModifiers;

	private static HashSet<string> modifierNames;

	public const float silverAddPerChallenge = 0.01f;

	private static bool victory;

	public static Action<ChallengeData> A_ChallengeCompleted;

	public static void Init()
	{
	}

	public static void Cleanup()
	{
	}

	private static void OnNewRunStarted()
	{
	}

	public static ChallengeData GetCurrentChallenge()
	{
		return null;
	}

	public static void Tick()
	{
	}

	private static void CleanupChallengeModifiers()
	{
	}

	public static void CompleteChallenge()
	{
	}

	public static bool HasChallengeModifier(string internalName)
	{
		return false;
	}

	public static List<string> GetChallengeModifiers()
	{
		return null;
	}

	private static void OnInventoryInitialized(PlayerInventory pinv)
	{
	}

	public static bool HasChallenge()
	{
		return false;
	}

	private static void OnGameOver()
	{
	}

	private static void OnStagebossDefeated()
	{
	}
}
