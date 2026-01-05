using Assets.Scripts.Actors.Enemies;
using UnityEngine;

namespace Assets.Scripts.Inventory__Items__Pickups.Weapons.Projectiles;

public class ProjectileHoming : ProjectileBase
{
	private Enemy enemyTarget;

	protected override bool TryInit(int projectileIndex)
	{
		return false;
	}

	protected override void FindMovementDirection()
	{
	}

	private bool HasBounces()
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

	private void DestroySelf()
	{
	}
}
