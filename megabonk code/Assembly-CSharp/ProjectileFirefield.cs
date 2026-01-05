using Assets.Scripts.Inventory__Items__Pickups.Weapons;
using Assets.Scripts.Inventory__Items__Pickups.Weapons.Projectiles;
using UnityEngine;

public class ProjectileFirefield : ProjectileBase
{
	private float spawnTime;

	private float aliveTime;

	private float spawnRadius;

	private Vector3 normal;

	public Firefield firefield;

	private string damageSource;

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

	private void CheckDamage()
	{
	}

	protected override void MyUpdate()
	{
	}

	protected override void FindMovementDirection()
	{
	}

	protected override void StepMovement()
	{
	}

	protected override bool CheckCollision(Collider collider, Vector3 normal)
	{
		return false;
	}
}
