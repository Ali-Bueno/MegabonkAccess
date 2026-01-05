using Assets.Scripts.Game.Combat.EnemySpecialAttacks.Implementations;
using UnityEngine;

public class EnemySpecialAttackCactusProjectile : EnemySpecialAttackPrefab
{
	public bool grounded;

	public bool predictive;

	private float timer;

	private Vector3 impactPos;

	private Vector3 startPos;

	public TrailRenderer trailRenderer;

	private float arcHeight;

	protected override void Init()
	{
	}

	private void Update()
	{
	}

	private void SpawnHitEffect()
	{
	}
}
