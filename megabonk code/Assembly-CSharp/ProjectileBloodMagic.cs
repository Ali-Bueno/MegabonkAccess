using Assets.Scripts.Actors.Enemies;
using Assets.Scripts.Inventory__Items__Pickups.Weapons.Projectiles;
using UnityEngine;

public class ProjectileBloodMagic : ProjectileBase
{
	private Enemy target;

	protected override bool TryInit(int projectileIndex)
	{
		return false;
	}

	protected override void CheckSpawnCollision()
	{
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

	protected override void StepMovement()
	{
	}
}
