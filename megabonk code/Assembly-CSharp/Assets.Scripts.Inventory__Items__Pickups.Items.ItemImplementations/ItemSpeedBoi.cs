using System;
using System.Collections.Generic;
using Assets.Scripts.Actors;
using Assets.Scripts.Inventory__Items__Pickups.Stats;

namespace Assets.Scripts.Inventory__Items__Pickups.Items.ItemImplementations;

public class ItemSpeedBoi : ItemBase
{
	private float damageMultiplierDuringFreeze;

	private float duration;

	private float durationPerAmount;

	private float normalCooldown;

	private float slowdownReadyAtTime;

	public static Action A_Slowdown;

	private float slowdownHpRatio;

	public ItemSpeedBoi(ItemInventory itemInventoryRef)
		: base(null)
	{
	}

	public override void Init()
	{
	}

	public override void Cleanup()
	{
	}

	private void RefreshTimeScale()
	{
	}

	protected override void OnInitOrAmountChanged()
	{
	}

	private void OnTakeDamage(PlayerHealth ph, DamageContainer dc, bool shieldDamage)
	{
	}

	private void Slowdown()
	{
	}

	private void ResetStats()
	{
	}

	public override void Tick()
	{
	}

	public override void PreAttack(DamageContainer dc, StatComponents itemAttackModifier)
	{
	}

	public override bool HasPreAttackProc()
	{
		return false;
	}

	public override void ProcOnHitEffects(DamageContainer dc)
	{
	}

	public override bool HasOnHitEffectProc()
	{
		return false;
	}

	protected override Dictionary<string, object> GetLocalizationKeys()
	{
		return null;
	}
}
