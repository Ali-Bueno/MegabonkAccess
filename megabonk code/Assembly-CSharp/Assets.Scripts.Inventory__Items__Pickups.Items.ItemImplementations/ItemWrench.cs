using Assets.Scripts.Actors;
using Assets.Scripts.Inventory__Items__Pickups.Stats;
using UnityEngine.Localization;

namespace Assets.Scripts.Inventory__Items__Pickups.Items.ItemImplementations;

public class ItemWrench : ItemBase
{
	private float chargeSpeedIncrease;

	private float chargeRewardIncrease;

	public float GetChargeSpeedIncrease()
	{
		return 0f;
	}

	public float GetChargeRewardMultiplier()
	{
		return 0f;
	}

	protected override void OnInitOrAmountChanged()
	{
	}

	public ItemWrench(ItemInventory itemInventoryRef)
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
