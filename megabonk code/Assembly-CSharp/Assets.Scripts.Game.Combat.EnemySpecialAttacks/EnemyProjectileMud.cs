using Assets.Scripts.Game.Combat.EnemySpecialAttacks.Implementations;
using UnityEngine;

namespace Assets.Scripts.Game.Combat.EnemySpecialAttacks;

public class EnemyProjectileMud : EnemySpecialAttackPrefab
{
	public GameObject hitEffect;

	public ParticleSystem mudParticles;

	public Transform slamParticles;

	public Transform preParticles;

	public bool grounded;

	public bool predictive;

	protected override void Init()
	{
	}

	private void SpawnHitEffect()
	{
	}
}
