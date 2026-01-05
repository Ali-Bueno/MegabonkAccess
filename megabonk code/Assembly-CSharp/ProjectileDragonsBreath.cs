using System.Collections.Generic;
using Assets.Scripts.Actors.Enemies;
using Assets.Scripts.Game.Combat.ConstantAttacks;
using Assets.Scripts.Menu.Shop;
using UnityEngine;

public class ProjectileDragonsBreath : ConstantAttack
{
	public ParticleSystem ps;

	public AudioSource sfx;

	public AudioClip sfxStart;

	public AudioClip sfxLoop;

	private float defaultVolume;

	private ParticleSystem.VelocityOverLifetimeModule[] velocities;

	private ParticleSystem[] particles;

	private float startTime;

	private float stopTime;

	private float previousStopTime;

	private float stopHitboxTime;

	private Dictionary<Collider, float> enemyHitCooldowns;

	private float enemyHitCooldown;

	private float hitboxCooldown;

	private float nextHitboxTime;

	private bool isActive;

	private float range;

	private float duration;

	private float rotationSpeed;

	private float cooldown;

	private float minCooldown;

	private Vector3 attackDir;

	private float nextFindTargetTime;

	private float findTargetInterval;

	private Enemy enemyTarget;

	private float lingerTime;

	private float scaleTimer;

	private float scaleOverTime;

	private float oldRange;

	private float scale;

	private float oldScale;

	protected override void Init()
	{
	}

	private void Update()
	{
	}

	private void FindClosestTarget()
	{
	}

	private void FixedUpdate()
	{
	}

	private bool HitEnemy(Collider collider)
	{
		return false;
	}

	private void StepActive()
	{
	}

	private bool IsAttacking()
	{
		return false;
	}

	private void SizeUpdate()
	{
	}

	protected override void OnWeaponStatUpdate(EStat stat, EWeapon weapon)
	{
	}

	protected override void OnStatUpdate(EStat stat)
	{
	}

	private void UpdateSize()
	{
	}

	private void UpdateCooldown()
	{
	}

	public override bool IsManualRotation()
	{
		return false;
	}

	public override float GetAuraRotationSpeed()
	{
		return 0f;
	}

	private void UpdateSfx()
	{
	}

	private void OnDrawGizmosSelected()
	{
	}
}
