using Assets.Scripts.Game.Combat.ConstantAttacks;
using Assets.Scripts.Menu.Shop;
using UnityEngine;

public class CombatAura : ConstantAttack
{
	private float defaultRadius;

	public ParticleSystem[] particles;

	private Color[] defaultColors;

	private float radius;

	private float cooldown;

	private float oldRadius;

	private float scaleTimer;

	private float scaleOverTime;

	private float fadeMultiplier;

	private float minSizeMultiplier;

	private float maxSizeMultiplier;

	private float minCooldown;

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

	private void FixedUpdate()
	{
	}
}
