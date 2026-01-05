using Assets.Scripts.Actors;
using Assets.Scripts.Inventory__Items__Pickups.Stats;
using UnityEngine;

namespace Assets.Scripts.Inventory__Items__Pickups.Items.ItemImplementations;

public class ItemGoldenSneakers : ItemBase
{
	private float goldPerMeter;

	private float goldPerMeterBase;

	private float checkInterval;

	private float nextCheckTime;

	private Vector3 lastPos;

	private float accumulatedGold;

	public ItemGoldenSneakers(ItemInventory itemInventoryRef)
		: base(null)
	{
	}

	protected override void OnInitOrAmountChanged()
	{
	}

	public override void Tick()
	{
	}

	public override void ProcOnHitEffects(DamageContainer dc)
	{
	}

	public override bool HasOnHitEffectProc()
	{
		return false;
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
}
