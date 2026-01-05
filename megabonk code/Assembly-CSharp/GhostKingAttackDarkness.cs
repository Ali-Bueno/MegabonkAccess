using System;
using Assets.Scripts.Actors.Enemies;
using Assets.Scripts.Game.Combat.EnemySpecialAttacks.Implementations;
using MilkShake;
using UnityEngine;

public class GhostKingAttackDarkness : EnemySpecialAttackPrefab
{
	public GameObject blastSphere;

	public AudioSource audioStart;

	public AudioSource audioCharge;

	public AudioSource audioBlast;

	public AudioSource audioLampSave;

	public ParticleSystem[] chargeParticles;

	public ParticleSystem blastParticles;

	public ShakePreset shakePreset;

	public static Action<float> A_LightIntensity;

	public static Action A_DarknessAttackSetEnemyTarget;

	public static Action A_Explode;

	private float timer;

	private float explodeAtTime;

	private float unchargeTime;

	private float sphereScaleBeforeBlast;

	private bool hasBlasted;

	private bool hasDamaged;

	private float blastToDamageDelay;

	private bool enemyDied;

	protected override void Init()
	{
	}

	private void FixedUpdate()
	{
	}

	private void Blast()
	{
	}

	private void BlastDamage()
	{
	}

	private void FinishAttack()
	{
	}

	protected override void OnEnemyDied(Enemy enemy)
	{
	}
}
