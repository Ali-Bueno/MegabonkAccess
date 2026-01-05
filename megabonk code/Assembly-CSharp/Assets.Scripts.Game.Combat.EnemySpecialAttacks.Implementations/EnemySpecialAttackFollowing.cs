using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Game.Combat.EnemySpecialAttacks.Implementations;

public class EnemySpecialAttackFollowing : EnemySpecialAttackPrefab
{
	private sealed class _003C_003Ec__DisplayClass5_0
	{
		public Vector3 pos;

		public EnemySpecialAttackFollowing _003C_003E4__this;

		internal void _003CDoAttack_003Eb__0()
		{
		}
	}

	private sealed class _003CDoAttack_003Ed__5 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public EnemySpecialAttackFollowing _003C_003E4__this;

		private int _003Ci_003E5__2;

		private float _003Celapsed_003E5__3;

		object IEnumerator<object>.Current => null;

		object IEnumerator.Current => null;

		public _003CDoAttack_003Ed__5(int _003C_003E1__state)
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

	public float delayBetweenHits;

	public int numHits;

	private int numSpawned;

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
