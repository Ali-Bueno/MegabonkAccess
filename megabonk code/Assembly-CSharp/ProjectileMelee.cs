using System.Collections.Generic;
using Assets.Scripts.Inventory__Items__Pickups.Weapons;
using Assets.Scripts.Inventory__Items__Pickups.Weapons.Projectiles;
using UnityEngine;

public class ProjectileMelee : ProjectileBase
{
	public class MeleeHit
	{
		public Vector3 pos;

		public Vector3 dir;

		public MeleeHit(Vector3 pos, Vector3 dir)
		{
		}
	}

	public Vector3 colliderOffset;

	public float testMultiplier;

	private float forwardOffset;

	private float upOffset;

	private List<MeleeHit> effectHits;

	private bool useAudio;

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

	protected override void MyUpdate()
	{
	}

	protected override void FindMovementDirection()
	{
	}

	public void CheckZone(WeaponBase weaponBase, float radius, GameObject hitEffect = null)
	{
	}

	private void SpawnEffect()
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
}
