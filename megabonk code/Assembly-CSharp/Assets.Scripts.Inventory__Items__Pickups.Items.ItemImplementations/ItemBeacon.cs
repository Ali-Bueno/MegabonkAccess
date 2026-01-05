using Assets.Scripts.Actors;
using Assets.Scripts.Inventory__Items__Pickups.Stats;
using UnityEngine.Localization;

namespace Assets.Scripts.Inventory__Items__Pickups.Items.ItemImplementations;

public class ItemBeacon : ItemBase
{
	private int extraShrinesPerAmount;

	private float healingRadiusPerAmount;

	private float healingFractionPerInterval;

	public float GetHealingPerInterval()
	{
		return 0f;
	}

	public float GetRadius()
	{
		return 0f;
	}

	public int GetExtraShrines()
	{
		return 0;
	}

	public ItemBeacon(ItemInventory itemInventoryRef)
		: base(null)
	{
	}

	public override void Init()
	{
	}

	public override void Cleanup()
	{
	}

	protected override void OnInitOrAmountChanged()
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

	public override string GetDescription(LocalizedString localizedString)
	{
		return null;
	}
}
