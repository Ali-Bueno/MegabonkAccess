using System.Collections.Generic;
using Assets.Scripts.Inventory__Items__Pickups.Weapons.Projectiles;
using UnityEngine;

public class ProjectileBanana : ProjectileBase
{
	public Transform renderer;

	public TrailRenderer trailRenderer;

	private float trailStartWidth;

	private Vector3 startDirection;

	private Vector3 movementVelocity;

	private Dictionary<Collider, float> enemyHitCooldowns;

	private float hitCooldown;

	private float readyToCollectTime;

	private float sqrCollectDistance;

	private float maxSpeed;

	private float returnTime;

	private Vector3 dirToPlayer;

	public Rigidbody rb;

	private float nextCheckDamageTime;

	private static Dictionary<Collider, int> numTimesEnemiesHitThisTick;

	private static bool hasDamage;

	private static float damageThisTick;

	private float distToPlayer;

	private bool isCloseToPlayer;

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

	protected override void StepMovement()
	{
	}

	private bool IsUsingSphereCast()
	{
		return false;
	}

	private void CheckRadiusDamage()
	{
	}

	private void LateUpdate()
	{
	}

	private void TryPopDamage()
	{
	}

	private void CheckHitPlayer()
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
