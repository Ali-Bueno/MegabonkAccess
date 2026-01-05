using System.Collections.Generic;
using Actors.Enemies;
using Assets.Scripts.Actors;
using Assets.Scripts.Actors.Enemies;

namespace Assets.Scripts.Saves___Serialization.Progression.Stats;

public class StatTrackingUtility
{
	private static HashSet<EEnemy> skeletonEnemies;

	private static HashSet<EEnemy> wispEnemies;

	private static HashSet<EEnemy> goblinEnemies;

	private static Dictionary<ECharacter, string> keysKillsCharacters;

	private static Dictionary<EEnemy, string> keysKillsEnemies;

	private static Dictionary<string, string> keysKillsSources;

	public static bool IsSkeleton(Enemy enemy)
	{
		return false;
	}

	public static bool IsWisp(Enemy enemy)
	{
		return false;
	}

	public static bool IsGoblin(Enemy enemy)
	{
		return false;
	}

	public static string GetKeyKillsCharacter(ECharacter character)
	{
		return null;
	}

	public static string GetKeyKillsEnemy(Enemy enemy)
	{
		return null;
	}

	public static string GetKeyKillsSource(DamageContainer dc)
	{
		return null;
	}
}
