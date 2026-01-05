using Assets.Scripts.Actors;
using Assets.Scripts.Inventory__Items__Pickups.Stats;
using UnityEngine.Localization;

namespace Assets.Scripts.Inventory__Items__Pickups.Items.ItemImplementations;

public class ItemMedkit : ItemBase
{
	private float hpRegenPerAmount;

	protected override void OnInitOrAmountChanged()
	{
	}

	public ItemMedkit(ItemInventory itemInventoryRef)
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
