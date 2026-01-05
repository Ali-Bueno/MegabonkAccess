using Assets.Scripts.Inventory__Items__Pickups.Weapons.Projectiles;
using UnityEngine;

public class ProjectileExploding : ProjectileBasic
{
	public float explosionRadius;

	private float fxCooldown;

	public GameObject explosionEffect;

	private bool exploded;

	protected override bool TryInit(int projectileIndex)
	{
		return false;
	}

	protected override bool CheckCollision(Collider collider, Vector3 normal)
	{
		return false;
	}

	private void Hitscan(Collider collider)
	{
	}
}
