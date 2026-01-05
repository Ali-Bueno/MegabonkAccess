using System.Collections.Generic;
using Assets.Scripts.Actors;
using Assets.Scripts.Inventory__Items__Pickups.Stats;
using UnityEngine;

namespace Assets.Scripts.Inventory__Items__Pickups.Items.ItemImplementations;

public class ItemSluttyCannon : ItemBase
{
	private float procChance;

	public float procChancePerAmount;

	public float damageRatio;

	public float damageRatioPerAmount;

	private string damageSource;

	private Dictionary<GameObject, Rocket> rocketLookup;

	private int maxProcsPerTick;

	private int numProcsThisTick;

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

	public override void Tick()
	{
	}

	public override void Init()
	{
	}

	public override void Cleanup()
	{
	}

	public override void PreAttack(DamageContainer dc, StatComponents itemAttackModifier)
	{
	}

	public override bool HasPreAttackProc()
	{
		return false;
	}

	public ItemSluttyCannon(ItemInventory itemInventoryRef)
		: base(null)
	{
	}

	protected override Dictionary<string, object> GetLocalizationKeys()
	{
		return null;
	}
}
