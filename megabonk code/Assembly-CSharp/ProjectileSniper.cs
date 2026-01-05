using Assets.Scripts.Inventory__Items__Pickups.Weapons;
using Assets.Scripts.Inventory__Items__Pickups.Weapons.Projectiles;
using UnityEngine;

public class ProjectileSniper : ProjectileBase
{
	public Vector3 attackDir;

	private float bulletSpeed;

	private float maxDistance;

	private float distTravelled;

	private RaycastHit hitRaycast;

	protected new static readonly RaycastHit[] raycastBuffer;

	protected override bool TryInit(int projectileIndex)
	{
		return false;
	}

	private Vector3 GetShootingPosition()
	{
		return default(Vector3);
	}

	private Vector3 GetAttackDir(int projectileIndex)
	{
		return default(Vector3);
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

	public void Hitscan(WeaponBase weaponBase, float radius)
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
