using System;
using System.Collections.Generic;
using Assets.Scripts.Actors.Enemies;

namespace Assets.Scripts.Game.Combat.EnemySpecialAttacks;

public class SpecialAttackController
{
	[Serializable]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9;

		public static Func<EnemySpecialAttack, int> _003C_003E9__8_0;

		public static Func<EnemySpecialAttack, int> _003C_003E9__8_1;

		internal int _003CTick_003Eb__8_0(EnemySpecialAttack a)
		{
			return 0;
		}

		internal int _003CTick_003Eb__8_1(EnemySpecialAttack _)
		{
			return 0;
		}
	}

	private static bool enabled;

	private HashSet<EnemySpecialAttack> attacks;

	private Dictionary<EnemySpecialAttack, float> cooldowns;

	private float updateRate;

	private float nextCheckTime;

	private Enemy enemy;

	private bool isAttacking;

	private float attackOverAtTime;

	private EnemySpecialAttack currentAttack;

	public SpecialAttackController(Enemy enemy)
	{
	}

	public void Tick()
	{
	}

	private void UseSpecialAttack(EnemySpecialAttack attack)
	{
	}

	private void FinishAttack()
	{
	}
}
