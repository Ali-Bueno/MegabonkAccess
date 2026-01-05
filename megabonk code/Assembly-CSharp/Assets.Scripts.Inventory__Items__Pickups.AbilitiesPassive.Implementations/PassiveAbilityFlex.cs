using System;
using Assets.Scripts.Actors;
using UnityEngine.Localization;

namespace Assets.Scripts.Inventory__Items__Pickups.AbilitiesPassive.Implementations;

public class PassiveAbilityFlex : PassiveAbility
{
	public static Action<bool> A_FlexReady;

	private static float cooldown;

	private static float minCooldown;

	private static float maxCooldown;

	private float cooldownReductionPerLevel;

	private float radius;

	private static float flexReadyAtTime;

	public float damagePerFlex;

	private int stacks;

	private bool canFlex;

	private DamageContainer reuseDc;

	private string damageSource;

	public override void Init()
	{
	}

	public override void Cleanup()
	{
	}

	private void OnLevelup(int level)
	{
	}

	public override void Tick()
	{
	}

	private void OnCheckStopDamage(DamageContainer dc, bool shieldDamage)
	{
	}

	private float GetDamage()
	{
		return 0f;
	}

	private float GetKnockback()
	{
		return 0f;
	}

	private void UseFlex()
	{
	}

	private bool HasFlex()
	{
		return false;
	}

	public override EPassive GetPassiveType()
	{
		return default(EPassive);
	}

	public override string GetDescription(LocalizedString localizedString)
	{
		return null;
	}
}
