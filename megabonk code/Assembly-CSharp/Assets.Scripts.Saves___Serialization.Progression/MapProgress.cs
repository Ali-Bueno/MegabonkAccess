using System;
using System.Collections.Generic;

namespace Assets.Scripts.Saves___Serialization.Progression;

[Serializable]
public class MapProgress
{
	public HashSet<int> tierNotifications;

	public HashSet<int> tierChallengeNotifications;

	public bool newMapNotification;

	public int lastSelectTier;

	public List<int> completedTiers;

	public Dictionary<int, HashSet<ECharacter>> tierCompletionsWithCharacters;

	public Dictionary<int, int> numRunsByTier;

	public Dictionary<int, float> tierHighscores;

	public Dictionary<int, float> tierFastestTimes;

	public void OnRunFinished(ECharacter character, bool victory, int tier)
	{
	}

	public int GetNumTierRuns(int tier)
	{
		return 0;
	}

	public List<ECharacter> GetTierCompletionCharacters(int tier)
	{
		return null;
	}

	public void CompleteTier(int tier)
	{
	}

	public bool IsTierCompleted(int tier)
	{
		return false;
	}

	public void SetCompletedTime(float time)
	{
	}

	public void SetKills(int kills)
	{
	}

	public string GetTierHighscoreString(int tier)
	{
		return null;
	}

	public string GetTierFastestTimeString(int tier)
	{
		return null;
	}
}
