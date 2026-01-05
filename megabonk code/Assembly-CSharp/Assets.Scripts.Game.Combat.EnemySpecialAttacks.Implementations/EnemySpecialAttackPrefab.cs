using System;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Actors;
using Assets.Scripts.Actors.Enemies;
using UnityEngine;

namespace Assets.Scripts.Game.Combat.EnemySpecialAttacks.Implementations;

public abstract class EnemySpecialAttackPrefab : MonoBehaviour
{
	private sealed class _003CWaitForSecondsCustom_003Ed__18 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public float time;

		private float _003Ctimer_003E5__2;

		object IEnumerator<object>.Current => null;

		object IEnumerator.Current => null;

		public _003CWaitForSecondsCustom_003Ed__18(int _003C_003E1__state)
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

	public GameObject attackEffectPrefab;

	public EEnemyAttack eAttack;

	private EnemySpecialAttack _003CspecialAttack_003Ek__BackingField;

	protected Enemy enemy;

	protected CircleWarning circleWarning;

	private bool isActive;

	public EnemySpecialAttack specialAttack
	{
		get
		{
			return _003CspecialAttack_003Ek__BackingField;
		}
		private set
		{
			_003CspecialAttack_003Ek__BackingField = value;
		}
	}

	public void Set(EnemySpecialAttack attack, Enemy enemy)
	{
	}

	protected abstract void Init();

	protected void CreateWarningSphere(Vector3 pos, Action completeAction)
	{
	}

	protected bool CreateWarningHitscan(Vector3 pos, Vector3 dir, float distance, Action completeAction)
	{
		return false;
	}

	protected GameObject GetEffectPrefab()
	{
		return null;
	}

	private void Awake()
	{
	}

	private void OnDestroy()
	{
	}

	protected virtual void OnEnemyDied(Enemy enemy)
	{
	}

	protected void ReturnToPool()
	{
	}

	protected IEnumerator WaitForSecondsCustom(float time)
	{
		return null;
	}

	protected DcFlags GetDamageFlags()
	{
		return default(DcFlags);
	}
}
