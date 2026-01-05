using System;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Game.Combat.EnemySpecialAttacks.Implementations;
using UnityEngine;

public class EnemySpecialAttackManyRandom : EnemySpecialAttackPrefab
{
	private sealed class _003C_003Ec__DisplayClass8_0
	{
		public EnemySpecialAttackManyRandom _003C_003E4__this;

		public Vector3 playerPos;

		internal void _003CDoAttack_003Eb__0()
		{
		}
	}

	private sealed class _003C_003Ec__DisplayClass8_1
	{
		public Vector3 pos;

		public _003C_003Ec__DisplayClass8_0 CS_0024_003C_003E8__locals1;

		internal void _003CDoAttack_003Eb__1()
		{
		}
	}

	private sealed class _003CDoAttack_003Ed__8 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public EnemySpecialAttackManyRandom _003C_003E4__this;

		private _003C_003Ec__DisplayClass8_0 _003C_003E8__1;

		private float _003Cstep_003E5__2;

		private int _003Ci_003E5__3;

		object IEnumerator<object>.Current => null;

		object IEnumerator.Current => null;

		public _003CDoAttack_003Ed__8(int _003C_003E1__state)
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

	public bool grounded;

	public bool predictive;

	public int circles;

	private int numToSpawn;

	private int numSpawned;

	public float delayBetweenCircles;

	public float margin;

	protected override void Init()
	{
	}

	private IEnumerator DoAttack()
	{
		return null;
	}

	private void SpawnHitEffect(Vector3 pos)
	{
	}
}
