using Assets.Scripts.Inventory__Items__Pickups.Weapons.Projectiles;
using UnityEngine;

public class ProjectileArrow : ProjectileBase
{
	public TrailRenderer trailRenderer;

	private float upOffset;

	private Vector3 pushDir;

	private float trailStartWidth;

	private static Vector3 baseDir;

	private float speedReduction;

	private float nextCheckDamageTime;

	protected override bool TryInit(int projectileIndex)
	{
		return false;
	}

	private float GetAngle(int projectileIndex, int maxIndex)
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

	private float GetRadius()
	{
		return 0f;
	}

	private void OnDrawGizmosSelected()
	{
	}
}
