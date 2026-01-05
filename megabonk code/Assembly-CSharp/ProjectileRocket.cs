using Assets.Scripts.Inventory__Items__Pickups.Weapons.Projectiles;
using UnityEngine;

public class ProjectileRocket : ProjectileBase
{
	public Rocket rocket;

	private string damageSource;

	private void Awake()
	{
	}

	protected override bool TryInit(int projectileIndex)
	{
		return false;
	}

	protected override Vector3 GetMovementDirection()
	{
		return default(Vector3);
	}

	private void OnDestroy()
	{
	}

	private void OnRocketDone()
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

	protected override void StepMovement()
	{
	}
}
