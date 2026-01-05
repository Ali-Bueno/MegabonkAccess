using System.Collections.Generic;
using Assets.Scripts.Actors;
using UnityEngine;

namespace Assets.Scripts.Inventory__Items__Pickups.Weapons.Projectiles;

public class ProjectileDexecutioner : ProjectileBase
{
	private struct MeleeHit
	{
		public Vector3 pos;

		public Vector3 dir;

		public MeleeHit(Vector3 pos, Vector3 dir)
		{
			this.pos = default(Vector3);
			this.dir = default(Vector3);
		}
	}

	public Vector3 colliderOffset;

	public float testMultiplier;

	public float projectileDistance;

	private float forwardOffset;

	private float upOffset;

	public Vector3 attackDir;

	public float executionChance;

	private static readonly RaycastHit[] sphereHits;

	private DamageContainer dcExecute;

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
