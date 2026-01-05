using System;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Game.Combat.EnemySpecialAttacks.Implementations;
using UnityEngine;

public class EnemySpecialAttackHitscanMultiple : EnemySpecialAttackPrefab
{
	private sealed class _003C_003Ec__DisplayClass7_0
	{
		public Vector3 startPos;

		public Vector3 dir;

		public EnemySpecialAttackHitscanMultiple _003C_003E4__this;

		internal void _003CDoAttack_003Eb__0()
		{
		}
	}

	private sealed class _003CDoAttack_003Ed__7 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public EnemySpecialAttackHitscanMultiple _003C_003E4__this;

		private int _003Ci_003E5__2;

		object IEnumerator<object>.Current => null;

		object IEnumerator.Current => null;

		public _003CDoAttack_003Ed__7(int _003C_003E1__state)
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

	public float delayBetweenAttacks;

	public int numToSpawn;

	private int numSpawned;

	public float maxRange;

	public Vector3 attackOffset;

	public float randomPositionRadius;

	protected override void Init()
	{
	}

	private IEnumerator DoAttack()
	{
		return null;
	}

	private void SpawnHitEffect(Vector3 pos, Vector3 dir)
	{
	}
}
