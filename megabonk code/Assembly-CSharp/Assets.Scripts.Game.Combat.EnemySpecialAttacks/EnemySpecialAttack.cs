using System;
using System.Collections.Generic;
using Assets.Scripts.Actors.Enemies;
using UnityEngine;

namespace Assets.Scripts.Game.Combat.EnemySpecialAttacks;

[Serializable]
public class EnemySpecialAttack : IComparer<EnemySpecialAttack>
{
	public bool isEnabled;

	public int priority;

	public string attackName;

	public GameObject attackPrefab;

	public float attackChargeTime;

	public float attackRadius;

	public float attackCooldown;

	public float attackCooldownMax;

	public float initialCooldown;

	public float duration;

	public float nextSpecialAttackCooldown;

	public float triggerDistance;

	public float endLag;

	public float damageMultiplier;

	public float GetDamage(Enemy enemy)
	{
		return 0f;
	}

	public int Compare(EnemySpecialAttack x, EnemySpecialAttack y)
	{
		return 0;
	}
}
