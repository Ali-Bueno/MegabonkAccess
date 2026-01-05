using System.Collections.Generic;
using Assets.Scripts.Inventory__Items__Pickups.Weapons;
using Assets.Scripts.Inventory__Items__Pickups.Weapons.Projectiles;
using UnityEngine;

public class ProjectileHeroSword : ProjectileBase
{
	public GameObject movingProjectile;

	private Vector3 movingProjectileDir;

	private Vector3 hitboxPos;

	private Quaternion movingProjectileRotation;

	private float movingProjectileDuration;

	private float startTime;

	public Vector3 colliderOffset;

	public float testMultiplier;

	private float forwardOffset;

	private float upOffset;

	private Vector3 posOffset;

	private float actualProjectileSpeed;

	private new HashSet<Collider> hitEnemies;

	private Vector3 movingProjectilePosition;

	protected override bool TryInit(int projectileIndex)
	{
		return false;
	}

	protected override Vector3 GetMovementDirection()
	{
		return default(Vector3);
	}

	protected override void MyFixedUpdate()
	{
	}

	protected override void MyUpdate()
	{
	}

	public void CheckZone(WeaponBase weaponBase, float radius, GameObject hitEffect = null)
	{
	}

	private void CheckColliderCustom(Collider collider, float damageMultiplier)
	{
	}

	private float GetRadius()
	{
		return 0f;
	}

	protected override void StepMovement()
	{
	}

	protected override void CheckSpawnCollision()
	{
	}

	protected override bool CheckCollision(Collider collider, Vector3 normal)
	{
		return false;
	}

	protected override void FindMovementDirection()
	{
	}
}
