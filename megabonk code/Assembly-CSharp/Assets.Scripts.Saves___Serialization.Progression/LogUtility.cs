using Actors.Enemies;

namespace Assets.Scripts.Saves___Serialization.Progression;

public static class LogUtility
{
	public static int numMaxChallenges;

	public static int GetNumMaxEntries()
	{
		return 0;
	}

	public static int GetNumUnlockedEntries()
	{
		return 0;
	}

	public static bool IsEntryUnlocked(EEnemy enemy)
	{
		return false;
	}

	public static void GetChallengeProgress(EEnemy eEnemy, out float currentChallengeProgress, out int numChallengesClaimed, out int numKills, out int numKillsForNextChallengeTier)
	{
		currentChallengeProgress = default(float);
		numChallengesClaimed = default(int);
		numKills = default(int);
		numKillsForNextChallengeTier = default(int);
	}

	public static bool HasUnclaimedReward(EEnemy eEnemy)
	{
		return false;
	}

	public static bool HasAnyUnclaimedReward()
	{
		return false;
	}

	public static bool HasClaimedAllRewards(EEnemy eEnemy)
	{
		return false;
	}

	public static int GetNumChallengeKills(EEnemy eEnemy, int tier)
	{
		return 0;
	}

	public static int GetReward(EEnemy eEnemy)
	{
		return 0;
	}
}
