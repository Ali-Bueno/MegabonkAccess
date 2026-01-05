using System.Collections.Generic;
using Assets.Scripts.Actors;
using Assets.Scripts.Inventory__Items__Pickups.Stats;

namespace Assets.Scripts.Inventory__Items__Pickups.Items.ItemImplementations;

public class ItemBackpack : ItemBase
{
	private int projectilesPerAmount;

	protected override void OnInitOrAmountChanged()
	{
	}

	public ItemBackpack(ItemInventory itemInventoryRef)
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

	public override void ProcOnHitEffects(DamageContainer dc)
	{
	}

	public override bool HasOnHitEffectProc()
	{
		return false;
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
