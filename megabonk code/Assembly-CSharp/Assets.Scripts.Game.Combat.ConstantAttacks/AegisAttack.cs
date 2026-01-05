using System;
using Assets.Scripts.Menu.Shop;
using UnityEngine;

namespace Assets.Scripts.Game.Combat.ConstantAttacks;

public class AegisAttack : ConstantAttack
{
	public RandomSfx shieldUseSfx;

	public RandomSfx shieldRegenSfx;

	public Transform renderer;

	public AegisRenderer aegisRenderer;

	public Transform[] particles;

	public ParticleSystem rootParticles;

	private bool isActive;

	private int currentAmount;

	private float minAegisCooldown;

	private float shieldReadyAtTime;

	public static Action<int> A_Used;

	public static Action<int> A_Regen;

	private float nextAmountTime;

	protected override void Init()
	{
	}

	private void FixedUpdate()
	{
	}

	public void RegenShield()
	{
	}

	private void AmplifyShield()
	{
	}

	private void ResetNextAmountTime()
	{
	}

	private int GetMaxShields()
	{
		return 0;
	}

	public void UseShield(Vector3 enemyFeetPosition)
	{
	}

	public bool IsActive()
	{
		return false;
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
}
