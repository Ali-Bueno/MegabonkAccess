using System;
using Assets.Scripts.Inventory__Items__Pickups.Weapons.Projectiles;
using UnityEngine;

public class ProjectileDice : ProjectileBasic
{
	public float explosionRadius;

	public GameObject diceFx;

	public GameObject diceFx6;

	public RotateObjectRandomly rotator;

	private float fxCooldown;

	private float maxScale;

	private int diceRoll;

	public static Action A_RollSix;

	private string explosionFxName;

	private string explosionFxName6;

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
