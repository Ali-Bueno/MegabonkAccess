using System;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Actors.Player;
using Assets.Scripts.Inventory__Items__Pickups.Weapons.Projectiles;
using UnityEngine;

namespace Assets.Scripts.Inventory__Items__Pickups.Weapons.Attacks;

public class WeaponAttack : MonoBehaviour
{
	private sealed class _003CStartAttack_003Ed__22 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public WeaponAttack _003C_003E4__this;

		private float _003Ctimer_003E5__2;

		private int _003Cquantity_003E5__3;

		private float _003CburstInterval_003E5__4;

		private int _003Ci_003E5__5;

		object IEnumerator<object>.Current => null;

		object IEnumerator.Current => null;

		public _003CStartAttack_003Ed__22(int _003C_003E1__state)
		{
		}

		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			return false;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		void IEnumerator.Reset()
		{
		}
	}

	public GameObject prefabProjectile;

	public GameObject prefabMuzzle;

	public GameObject prefabHit;

	public WeaponBase weaponBase;

	protected MyPlayer player;

	private bool attackDone;

	public float projectileSizeMultiplier;

	public Action A_SpawnedProjectile;

	public static Action<ProjectileBase> A_SpawnedProjectileSuccessfully;

	private float expirationTime;

	private bool isAttacking;

	private int maxNumProjectilesWithoutInterval;

	private float timer;

	private int attackQuantity;

	private int attackQuantityCurrent;

	private float burstInterval;

	private static readonly WaitForEndOfFrame waitEndOfFrame;

	private EnemyScanContainer lastCheckSphere;

	private EnemyScanContainer reuseContainer;

	public bool lastWasSkip;

	private float muzzleCooldown;

	private AttackMuzzle muzzle;

	public void SetAttack(WeaponBase weaponBase, MyPlayer player)
	{
	}

	private void StartAttackNoCoroutine()
	{
	}

	private void FixedUpdate()
	{
	}

	private void FixedUpdateAttack()
	{
	}

	private void StopAttackNoCoroutine()
	{
	}

	private IEnumerator StartAttack()
	{
		return null;
	}

	protected virtual void SpawnProjectile(int projectileIndex)
	{
	}

	public float GetSize()
	{
		return 0f;
	}

	public void ProjectileDone(ProjectileBase projectile)
	{
	}

	public void ProjectileHit(Vector3 hitPos, Vector3 moveDir, bool hitEnemy, bool useSfx)
	{
	}

	public void SuccessfullySpawnedProjectile(ProjectileBase projectile)
	{
	}

	private void Update()
	{
	}

	private void AttackTimeout()
	{
	}

	private Vector3 GetProjectilePosition()
	{
		return default(Vector3);
	}

	private Quaternion GetProjectileRotation()
	{
		return default(Quaternion);
	}
}
