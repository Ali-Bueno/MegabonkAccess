using System;
using System.Collections.Generic;
using Assets.Scripts.Actors;
using Assets.Scripts.Actors.Enemies;
using Assets.Scripts.Saves___Serialization.Progression.Achievements;

namespace Assets.Scripts.Saves___Serialization.Progression.Stats;

public static class RunStats
{
	private static Dictionary<string, float> stats;

	public static Dictionary<string, DamageSource> damageSources;

	public static List<MyAchievement> achievements;

	public static Action<string, float> A_StatChange;

	public static void Init()
	{
	}

	public static void Cleanup()
	{
	}

	private static void OnNewRun()
	{
	}

	private static void Reset()
	{
	}

	public static void AddValue(EMyStat stat, int value)
	{
	}

	public static int GetStat(EMyStat stat)
	{
		return 0;
	}

	public static void AddValue(string stat, int value)
	{
	}

	public static int GetStat(string stat)
	{
		return 0;
	}

	public static void AddAchievement(MyAchievement achievement)
	{
	}

	private static void OnEnemyDamaged(Enemy enemy, DamageContainer dc)
	{
	}
}
