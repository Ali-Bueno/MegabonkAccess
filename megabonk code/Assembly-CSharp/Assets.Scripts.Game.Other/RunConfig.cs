using System.Collections.Generic;

namespace Assets.Scripts.Game.Other;

public class RunConfig
{
	public MapData mapData;

	public StageData stageData;

	public int mapTierIndex;

	public ChallengeData challenge;

	public int musicTrackIndex;

	private Dictionary<int, float> tierSilverMultipliers;

	public float GetEnemyHp(float hp)
	{
		return 0f;
	}

	public float GetEnemySpeed(float speed)
	{
		return 0f;
	}

	public float GetEnemyDamage(float value)
	{
		return 0f;
	}

	private int GetIndexToMultiplier()
	{
		return 0;
	}

	public float GetSilverMultiplier()
	{
		return 0f;
	}

	public string GetFormattedSilverMultiplier()
	{
		return null;
	}
}
