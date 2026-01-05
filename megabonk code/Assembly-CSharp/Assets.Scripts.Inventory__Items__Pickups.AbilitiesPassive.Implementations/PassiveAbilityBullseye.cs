using System.Collections.Generic;
using Assets.Scripts.Actors;
using Assets.Scripts.Actors.Enemies;
using UnityEngine.Localization;

namespace Assets.Scripts.Inventory__Items__Pickups.AbilitiesPassive.Implementations;

public class PassiveAbilityBullseye : PassiveAbility
{
	private float critDamagePerLevel;

	public const int MAX_MARKERS = 20;

	private float markDuration;

	private float markCooldown;

	private float markReadyAtTime;

	private float explosionRadius;

	private float maxExplosionRadius;

	private float explosionDamage;

	private static float minCooldown;

	private static float maxCooldown;

	private float cooldownReductionPerLevel;

	private static Dictionary<Enemy, float> markedEnemies;

	public static string damageSource;

	private DamageContainer reuseDc;

	private bool isExplosionDamage;

	public override void Init()
	{
	}

	public override void Cleanup()
	{
	}

	private void OnLevelup(int level)
	{
	}

	private void OnStageStarted()
	{
	}

	private void OnEnemySpawned(Enemy enemy)
	{
	}

	private void OnEnemyDamaged(Enemy enemy, DamageContainer dc)
	{
	}

	private void OnEnemyReleasedFromPool(Enemy enemy)
	{
	}

	private void Reset()
	{
	}

	public static bool IsMarkedEnemy(Enemy enemy)
	{
		return false;
	}

	public override void Tick()
	{
	}

	public override EPassive GetPassiveType()
	{
		return default(EPassive);
	}

	public override string GetDescription(LocalizedString localizedString)
	{
		return null;
	}
}
