using Assets.Scripts.Actors.Enemies;

namespace Assets.Scripts.Inventory.Stats;

public static class EnemyStats
{
	private static float overrideMaxSpeedAtTime;

	private static float maxSpeedMultiplier;

	private static float maxSpeedMultiplierOverride;

	private static int maxStunsAndFreezes;

	private static float startStunImmunityAtTime;

	private static float decreaseCcImmunityOverTime;

	private static int lastFoundCcCap;

	private static float lastFoundCcCapTime;

	public static float GetHp(Enemy enemy)
	{
		return 0f;
	}

	public static float GetSpeed(EnemyData enemyData)
	{
		return 0f;
	}

	private static float GetMaxSpeed()
	{
		return 0f;
	}

	public static float GetDamage(Enemy enemy)
	{
		return 0f;
	}

	public static float GetEliteChance(EnemyData enemyData)
	{
		return 0f;
	}

	public static float GetKnockbackResistance(Enemy enemy)
	{
		return 0f;
	}

	public static int GetCapCC()
	{
		return 0;
	}

	private static float GetParkourMultiplier()
	{
		return 0f;
	}
}
