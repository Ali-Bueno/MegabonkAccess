using System.Collections.Generic;
using Assets.Scripts.Inventory__Items__Pickups.Weapons.Attacks;
using UnityEngine;

namespace Assets.Scripts.Inventory__Items__Pickups.Weapons.Projectiles;

public abstract class ProjectileBase : MonoBehaviour
{
	public WeaponBase weaponBase;

	protected WeaponAttack weaponAttack;

	public float projectileRadius;

	private float baseProjectileRadius;

	public Vector3 direction;

	public int bounces;

	public int maxBounces;

	protected bool timedOut;

	protected float expirationTime;

	protected float projectileSpeed;

	protected static readonly RaycastHit[] raycastBuffer;

	protected Collider lastHitEnemy;

	protected HashSet<Collider> hitEnemies;

	public void Set(WeaponBase weaponBase, WeaponAttack weaponAttack, int projectileIndex)
	{
	}

	protected float GetDuration()
	{
		return 0f;
	}

	protected abstract bool TryInit(int projectileIndex);

	private void FixedUpdate()
	{
	}

	protected virtual void CheckSpawnCollision()
	{
	}

	protected abstract Vector3 GetMovementDirection();

	protected virtual void StepMovement()
	{
	}

	private void Update()
	{
	}

	private void CheckTimeout()
	{
	}

	protected void ProjectileDone()
	{
	}

	protected abstract void MyFixedUpdate();

	protected abstract void MyUpdate();

	protected virtual bool CheckCollision(Collider collider, Vector3 normal)
	{
		return false;
	}

	protected virtual bool HitEnemy(Collider collider, Vector3 normal)
	{
		return false;
	}

	protected abstract void FindMovementDirection();

	protected virtual void HitOther(Collider collider, Vector3 normal)
	{
	}
}
