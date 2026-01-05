using System;
using Assets.Scripts.Actors;
using Assets.Scripts.Actors.Enemies;
using Assets.Scripts.Inventory__Items__Pickups.Weapons;
using UnityEngine;

public class Rocket : MonoBehaviour
{
	private float damage;

	private float spawnedAtTime;

	private float projectileSpeed;

	public float projectileRadius;

	private float upTime;

	private float expirationTime;

	private WeaponBase weaponBase;

	private bool useGenericPool;

	private string damageSource;

	public Action A_ProjectileDone;

	private Vector3 startDirection;

	private Vector3 lastDirection;

	private Enemy targetEnemy;

	private Vector3 currentDir;

	private float nextFindTime;

	protected static readonly RaycastHit[] raycastBuffer;

	private float procCoefficient;

	private DamageContainer reuseDc;

	public void Set(Vector3 pos, float damage, float procCoefficient, WeaponBase weaponBase, bool useGenericPool, string damageSource)
	{
	}

	private void FixedUpdate()
	{
	}

	private Vector3 GetMovementDirection()
	{
		return default(Vector3);
	}

	public void SetTarget(Enemy targetEnemy)
	{
	}

	private void FindTarget()
	{
	}

	protected virtual void StepMovement()
	{
	}

	protected virtual void CheckSpawnCollision()
	{
	}

	protected virtual bool CheckCollision(Collider collider, Vector3 normal)
	{
		return false;
	}

	private bool HitEnemy(Collider collider, Vector3 normal)
	{
		return false;
	}

	private void HitOther(Collider collider, Vector3 normal)
	{
	}

	private void CheckTimeout()
	{
	}

	protected void ProjectileDone()
	{
	}
}
