using Assets.Scripts.Inventory__Items__Pickups.Weapons.Projectiles;
using UnityEngine;

public class ProjectilePoisonFlask : ProjectileBase
{
	public Rigidbody rb;

	private float defaultProjectileRadius;

	private float maxProjectileSpeed;

	protected static Collider[] enemyCollidersBuffer;

	public float explosionRadius;

	public EffectPlayer effect;

	private Vector3 explosionSizeDefault;

	protected override bool TryInit(int projectileIndex)
	{
		return false;
	}

	private float GetSpeed()
	{
		return 0f;
	}

	protected override void StepMovement()
	{
	}

	protected override bool HitEnemy(Collider collider, Vector3 normal)
	{
		return false;
	}

	protected override void HitOther(Collider collider, Vector3 normal)
	{
	}

	private float GetExplosionRadius()
	{
		return 0f;
	}

	private float GetPoisonDuration()
	{
		return 0f;
	}

	private int GetNumPoisonStacks()
	{
		return 0;
	}

	private void ExplodeFlask()
	{
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

	protected override Vector3 GetMovementDirection()
	{
		return default(Vector3);
	}
}
