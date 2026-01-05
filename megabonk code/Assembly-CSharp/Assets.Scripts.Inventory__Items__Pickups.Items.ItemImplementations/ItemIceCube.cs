using System;
using System.Collections.Generic;
using Assets.Scripts.Actors;
using Assets.Scripts.Inventory__Items__Pickups.Stats;

namespace Assets.Scripts.Inventory__Items__Pickups.Items.ItemImplementations;

public class ItemIceCube : ItemBase
{
	public float procChancePerAmount;

	private float procChance;

	private float freezeChancePerAmount;

	private float freezeChance;

	public float damageRatio;

	public float damageRatioPerAmount;

	private string damageSource;

	private DamageContainer reuseDc;

	public static Action A_FreezeEnemy;

	public ItemIceCube(ItemInventory itemInventoryRef)
		: base(null)
	{
	}

	protected override void OnInitOrAmountChanged()
	{
	}

	public override void ProcOnHitEffects(DamageContainer dc)
	{
	}

	public override bool HasOnHitEffectProc()
	{
		return false;
	}

	private void TryProcFreeze(DamageContainer dc, float overrideProcCoefficient = -1f)
	{
	}

	public override void Init()
	{
	}

	public override void Cleanup()
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

	protected override Dictionary<string, object> GetLocalizationKeys()
	{
		return null;
	}
}
