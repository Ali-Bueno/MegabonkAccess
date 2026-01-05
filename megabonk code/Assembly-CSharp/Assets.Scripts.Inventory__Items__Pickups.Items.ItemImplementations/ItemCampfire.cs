using Assets.Scripts.Actors;
using Assets.Scripts.Inventory__Items__Pickups.Stats;
using UnityEngine;

namespace Assets.Scripts.Inventory__Items__Pickups.Items.ItemImplementations;

public class ItemCampfire : ItemBase
{
	private float healthRegenPerMinutePerAmount;

	private float healthRegen;

	public Campfire campfire;

	private Vector3 campfirePos;

	private float setupTime;

	private float distThreshold;

	private float startCampfireTime;

	private bool isCampActive;

	protected override void OnInitOrAmountChanged()
	{
	}

	public ItemCampfire(ItemInventory itemInventoryRef)
		: base(null)
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

	private void CreateCamp()
	{
	}

	private void RemoveCamp()
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
}
