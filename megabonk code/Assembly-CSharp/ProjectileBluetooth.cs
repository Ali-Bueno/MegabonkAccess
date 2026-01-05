using Assets.Scripts.Actors.Enemies;
using Assets.Scripts.Inventory__Items__Pickups.Weapons.Projectiles;
using UnityEngine;

public class ProjectileBluetooth : ProjectileBase
{
	protected Enemy target;

	private GameObject lastTarget;

	protected override bool TryInit(int projectileIndex)
	{
		return false;
	}

	protected override void FindMovementDirection()
	{
	}

	protected override Vector3 GetMovementDirection()
	{
		return default(Vector3);
	}

	protected override void StepMovement()
	{
	}

	private void HitTarget()
	{
	}

	protected override bool HitEnemy(Collider collider, Vector3 normal)
	{
		return false;
	}

	protected override bool CheckCollision(Collider collider, Vector3 normal)
	{
		return false;
	}

	protected override void CheckSpawnCollision()
	{
	}

	protected override void HitOther(Collider collider, Vector3 normal)
	{
	}

	protected override void MyUpdate()
	{
	}

	protected override void MyFixedUpdate()
	{
	}
}
