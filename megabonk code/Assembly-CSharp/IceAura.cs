using Assets.Scripts.Game.Combat.ConstantAttacks;
using Assets.Scripts.Menu.Shop;
using UnityEngine;

public class IceAura : ConstantAttack
{
	private float defaultRadius;

	public AttackMuzzle attackMuzzle;

	private float radius;

	private float cooldown;

	private float oldRadius;

	private float scaleTimer;

	private float scaleOverTime;

	private float minCooldown;

	public ParticleSystem psRing;

	public ParticleSystem psSmoke;

	public ParticleSystem psSnow;

	private ParticleSystem.EmissionModule emissionSmoke;

	private ParticleSystem.EmissionModule emissionSnow;

	private bool inited;

	private float nextCheckDamageTime;

	protected override void Init()
	{
	}

	protected override void OnWeaponStatUpdate(EStat stat, EWeapon weapon)
	{
	}

	protected override void OnStatUpdate(EStat stat)
	{
	}

	public override float GetAuraRotationSpeed()
	{
		return 0f;
	}

	private void UpdateSize()
	{
	}

	private void Update()
	{
	}

	private void UpdateCooldown()
	{
	}

	private void RefreshParticles()
	{
	}

	private void InitParticles()
	{
	}

	private float GetFreezeTime()
	{
		return 0f;
	}

	private void FixedUpdate()
	{
	}
}
