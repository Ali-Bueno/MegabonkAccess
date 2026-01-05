using Assets.Scripts.Actors;
using Assets.Scripts.Inventory__Items__Pickups.Stats;
using UnityEngine.Localization;

namespace Assets.Scripts.Inventory__Items__Pickups.Items.ItemImplementations;

public class ItemPumpkin : ItemBase
{
	private int extraPotsPerAmount;

	private float rewardMultiplierPerAmount;

	public float GetRewardMultiplier()
	{
		return 0f;
	}

	public int GetExtraPotsSmall()
	{
		return 0;
	}

	public int GetExtraPotsBig()
	{
		return 0;
	}

	public ItemPumpkin(ItemInventory itemInventoryRef)
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
