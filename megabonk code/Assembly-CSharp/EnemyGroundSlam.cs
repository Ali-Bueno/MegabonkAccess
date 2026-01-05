using Assets.Scripts.Game.Combat.EnemySpecialAttacks.Implementations;
using UnityEngine;

public class EnemyGroundSlam : EnemySpecialAttackPrefab
{
	public GameObject hitEffect;

	public AudioSource hitSfx;

	private float finalRadius;

	protected override void Init()
	{
	}

	private void SpawnHitEffect()
	{
	}
}
