using Assets.Scripts.Inventory__Items__Pickups.Weapons;
using Assets.Scripts.Inventory__Items__Pickups.Weapons.Projectiles;
using UnityEngine;

public class ProjectileKatana : ProjectileBase
{
	public float testMultiplier;

	protected override bool TryInit(int projectileIndex)
	{
		return false;
	}

	public void CheckZone(WeaponBase weaponBase, float radius, GameObject hitEffect = null)
	{
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
