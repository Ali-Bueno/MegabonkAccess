using System.Collections.Generic;
using Assets.Scripts.Actors;
using UnityEngine;

namespace Assets.Scripts.Inventory__Items__Pickups.Weapons;

public class Firefield : MonoBehaviour
{
	private float collisionCooldown;

	private float spawnTime;

	private float aliveTime;

	private float spawnRadius;

	private Vector3 normal;

	private WeaponBase weaponBase;

	private float damage;

	private string damageSource;

	private DamageContainer recycledDx;

	private float nextCheckDamageTime;

	private static Dictionary<Collider, int> numTimesEnemiesHitThisTick;

	private static bool hasDamage;

	private static float damageThisTick;

	private float visualRadius;

	private float desiredVisualRadius;

	public void Set(Vector3 pos, Vector3 fallbackPos, float radius, float duration, float damage, WeaponBase weaponBase, string damageSource)
	{
	}

	protected void FixedUpdate()
	{
	}

	private bool IsWeaponAttack()
	{
		return false;
	}

	private void LateUpdate()
	{
	}

	private void CheckDamage()
	{
	}

	private void TryPopDamage()
	{
	}

	private float GetEffectiveRadius()
	{
		return 0f;
	}

	private float GetHitboxRadius()
	{
		return 0f;
	}

	protected void Update()
	{
	}

	private void OnDrawGizmosSelected()
	{
	}
}
