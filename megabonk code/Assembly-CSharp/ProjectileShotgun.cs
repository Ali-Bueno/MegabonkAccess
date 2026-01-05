using Assets.Scripts.Inventory__Items__Pickups.Weapons;
using Assets.Scripts.Inventory__Items__Pickups.Weapons.Projectiles;
using UnityEngine;

public class ProjectileShotgun : ProjectileBase
{
	public ParticleSystem psBullets;

	private ParticleSystem.EmissionModule psBulletsEmission;

	public float testMultiplier;

	private float forwardOffset;

	private float upOffset;

	private Vector3 attackDir;

	protected override bool TryInit(int projectileIndex)
	{
		return false;
	}

	private Vector3 GetShootingPosition()
	{
		return default(Vector3);
	}

	private Vector3 GetAttackDir()
	{
		return default(Vector3);
	}

	private void SetBurstCount()
	{
	}

	private float GetRange()
	{
		return 0f;
	}

	public void CheckZone(WeaponBase weaponBase)
	{
	}

	private int GetRawQuantity()
	{
		return 0;
	}

	private float GetRadius()
	{
		return 0f;
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

	protected override void FindMovementDirection()
	{
	}

	protected override bool CheckCollision(Collider collider, Vector3 normal)
	{
		return false;
	}

	protected override void StepMovement()
	{
	}

	protected override void CheckSpawnCollision()
	{
	}
}
