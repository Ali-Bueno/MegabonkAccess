using System.Collections.Generic;
using Assets.Scripts.Actors.Enemies;
using Assets.Scripts.Inventory__Items__Pickups.Weapons.Projectiles;
using UnityEngine;

public class ProjectileBlackHole : ProjectileBase
{
	public float collisionCooldown;

	private float forwardOffset;

	private float upOffset;

	private Vector3 pushDir;

	private Vector3 defaultSize;

	private float startFadeTime;

	private float maxSize;

	private Vector3 desiredPosition;

	private Vector3 startPosition;

	private float moveTime;

	private float nextCheckDamageTime;

	private HashSet<Enemy> suckedEnemies;

	private float moveTimer;

	private Vector3 startScaleSize;

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

	private void OnDisable()
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
