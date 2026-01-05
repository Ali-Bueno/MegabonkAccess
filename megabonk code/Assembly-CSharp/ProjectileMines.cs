using Assets.Scripts.Inventory__Items__Pickups.Weapons.Projectiles;
using UnityEngine;

public class ProjectileMines : ProjectileBase
{
	public Rigidbody rb;

	private float checkInterval;

	private float nextCheckTime;

	private float checkRadius;

	private float scaleInTime;

	private float spawnedAtTime;

	private float scaleMultiplier;

	protected override bool TryInit(int projectileIndex)
	{
		return false;
	}

	private void Update()
	{
	}

	protected override void MyFixedUpdate()
	{
	}

	private void Explode()
	{
	}

	private void Timeout()
	{
	}

	protected override void CheckSpawnCollision()
	{
	}

	protected override Vector3 GetMovementDirection()
	{
		return default(Vector3);
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
