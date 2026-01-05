using System.Collections.Generic;
using Assets.Scripts.Inventory__Items__Pickups.Weapons.Projectiles;
using UnityEngine;

public class ProjectileWhirlwind : ProjectileBase
{
	public Rigidbody rb;

	private Dictionary<Collider, float> enemyHitCooldowns;

	private float hitCooldown;

	private Vector3 startDirection;

	private float maxSpeed;

	private float speed;

	private float nextCheckDamageTime;

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

	private Vector3 GetRaycastPosition()
	{
		return default(Vector3);
	}

	protected override void StepMovement()
	{
	}

	private void CheckRadiusDamage()
	{
	}

	protected override bool CheckCollision(Collider collider, Vector3 normal)
	{
		return false;
	}

	private bool HitEnemy(Collider collider)
	{
		return false;
	}

	protected override void MyUpdate()
	{
	}

	protected override void FindMovementDirection()
	{
	}
}
