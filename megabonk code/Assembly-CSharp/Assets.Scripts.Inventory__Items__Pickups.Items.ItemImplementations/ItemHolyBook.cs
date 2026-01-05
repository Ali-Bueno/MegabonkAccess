using System;
using System.Collections.Generic;
using Assets.Scripts.Actors;
using Assets.Scripts.Inventory__Items__Pickups.Stats;

namespace Assets.Scripts.Inventory__Items__Pickups.Items.ItemImplementations;

public class ItemHolyBook : ItemBase
{
	public static Action<float> A_OnUse;

	private float maxHpPerAmount;

	private float hpRegenPerAmount;

	private float overhealPerAmount;

	private float radius;

	private float radiusPerAmount;

	private float healsThisTick;

	private float nextDamageTime;

	private float cooldown;

	private string damageSource;

	private DamageContainer dc;

	protected override void OnInitOrAmountChanged()
	{
	}

	public ItemHolyBook(ItemInventory itemInventoryRef)
		: base(null)
	{
	}

	public override void Init()
	{
	}

	public override void Cleanup()
	{
	}

	private void OnHeal(PlayerHealth ph, float hpHealed, bool isShield)
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
