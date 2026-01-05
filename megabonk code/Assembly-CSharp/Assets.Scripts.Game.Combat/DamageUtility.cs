using Assets.Scripts.Actors;
using Assets.Scripts.Actors.Enemies;
using UnityEngine;

namespace Assets.Scripts.Game.Combat;

public class DamageUtility
{
	public const string enemyDamageSource = "Enemy";

	private static DamageContainer reuseDc;

	public static DamageContainer GetPlayerDamage(Enemy enemy, Vector3 direction, DcFlags flags)
	{
		return null;
	}

	public static DamageContainer GetPlayerDamage(float damage, float knockback, Vector3 direction, Enemy enemy, string damageSource, DcFlags flags)
	{
		return null;
	}

	public static bool CheckEvade(Enemy enemy)
	{
		return false;
	}

	public static bool GetCritDamageMultiplier(float critChance, out float multiplier)
	{
		multiplier = default(float);
		return false;
	}

	public static void ApplyExecute(DamageContainer dc)
	{
	}
}
