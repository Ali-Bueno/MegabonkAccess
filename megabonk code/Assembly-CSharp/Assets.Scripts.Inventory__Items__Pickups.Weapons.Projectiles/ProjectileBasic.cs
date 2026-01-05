using UnityEngine;

namespace Assets.Scripts.Inventory__Items__Pickups.Weapons.Projectiles;

public class ProjectileBasic : ProjectileBase
{
	protected GameObject currentTarget;

	protected override bool TryInit(int projectileIndex)
	{
		return false;
	}

	protected override void FindMovementDirection()
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

	private void OnCollisionEnter(Collision collision)
	{
	}

	private void OnTriggerEnter(Collider collider)
	{
	}
}
