using System;
using System.Collections.Generic;
using Assets.Scripts.Actors;
using Assets.Scripts.Actors.Enemies;
using Assets.Scripts.Inventory__Items__Pickups.Stats;
using Assets.Scripts.Inventory__Items__Pickups.Weapons.Projectiles;
using UnityEngine;

namespace Assets.Scripts.Inventory__Items__Pickups.Weapons;

public static class WeaponUtility
{
	public static Action<DamageContainer> A_CreateDamageContainerPreAttack;

	private static StatComponents itemModifier;

	private static DamageContainer weaponDc;

	private static DamageContainer otherDc;

	private static List<int> availableIndexes;

	public static DamageContainer GetDamageContainer(WeaponBase weaponBase, ProjectileBase projectile, Enemy enemy, Vector3 direction, float forceDamage = -1f)
	{
		return null;
	}

	public static DamageContainer GetDamageContainer(DamageContainer recycleDc, float baseDamage, float procCoefficient, string damageSourceName, Vector3 direction, Enemy enemy)
	{
		return null;
	}

	private static float GetWeaponDamage(WeaponBase weaponBase, float forceDamage)
	{
		return 0f;
	}

	private static float GetNewDamage(float baseDamage, StatComponents itemModifierStatComponents)
	{
		return 0f;
	}

	public static float GetDamage(WeaponBase weaponBase)
	{
		return 0f;
	}

	private static float GetDamage(float damage)
	{
		return 0f;
	}

	private static float GetDcCritMultiplier(float critChance, DamageContainer dc)
	{
		return 0f;
	}

	public static float GetAttackSizeMultiplier(WeaponBase weaponBase)
	{
		return 0f;
	}

	public static int GetAttackQuantity(WeaponBase weaponBase)
	{
		return 0;
	}

	public static int GetProjectileBounces(WeaponBase weaponBase)
	{
		return 0;
	}

	public static float GetProjectileSpeed(WeaponBase weaponBase)
	{
		return 0f;
	}

	public static float GetDuration(WeaponBase weaponBase)
	{
		return 0f;
	}

	public static float GetBurstInterval(WeaponBase weaponBase)
	{
		return 0f;
	}

	public static float GetWeaponCooldown(WeaponBase weaponBase)
	{
		return 0f;
	}

	public static float GetCritChance(WeaponBase weaponBase)
	{
		return 0f;
	}

	public static float GetCritDamageMultiplier(WeaponBase weaponBase)
	{
		return 0f;
	}

	public static float GetKnockback(WeaponBase weaponBase)
	{
		return 0f;
	}

	public static float GetDamageProjectile(ProjectileBase projectile)
	{
		return 0f;
	}

	public static float GetWeaponRange(WeaponBase weaponBase)
	{
		return 0f;
	}

	public static int GetMaxProjectilesPoolSize(EWeapon weapon)
	{
		return 0;
	}

	public static int GetMaxProjectileHitsPoolSize(EWeapon weapon)
	{
		return 0;
	}

	public static int GetMaxProjectileDonePoolSize(EWeapon weapon)
	{
		return 0;
	}

	public static int GetMaxAttacksPoolSize(EWeapon weapon)
	{
		return 0;
	}

	public static void WeaponAttack(WeaponBase weapon)
	{
	}

	public static void LightningStrike(Enemy enemy, int bounces, DamageContainer dc, float bounceRange, float bounceProcCoefficient)
	{
	}

	private static void ChainLightning(Enemy initialEnemy, int numBounces, float bounceRange, DamageContainer sourceDc, float bounceProcCoefficient)
	{
	}
}
