using System.Collections.Generic;
using Assets.Scripts.Inventory__Items__Pickups.Weapons.Projectiles;
using UnityEngine;

public class ProjectileAxe : ProjectileBase
{
	public float collisionCooldown;

	public TrailRenderer trailRenderer;

	private float forwardOffset;

	private float upOffset;

	public RandomSfx sfx;

	public GameObject sfxLoop;

	private Vector3 pushDir;

	private static readonly RaycastHit[] _raycastHitBuffer;

	private Vector3 desiredPosition;

	private Vector3 startPosition;

	private float moveTime;

	private float nextCheckDamageTime;

	private static Dictionary<Collider, int> numTimesEnemiesHitThisTick;

	private static bool hasDamage;

	private static float damageThisTick;

	private float moveTimer;

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

	private void LateUpdate()
	{
	}

	private void CheckDamage()
	{
	}

	private void TryPopDamage()
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

	private void OnDrawGizmosSelected()
	{
	}
}
