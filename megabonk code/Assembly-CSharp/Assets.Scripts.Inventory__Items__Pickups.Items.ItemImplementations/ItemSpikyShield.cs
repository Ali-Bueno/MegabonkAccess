using System.Collections.Generic;
using Assets.Scripts.Actors;
using Assets.Scripts.Inventory__Items__Pickups.Stats;

namespace Assets.Scripts.Inventory__Items__Pickups.Items.ItemImplementations;

public class ItemSpikyShield : ItemBase
{
	private float armorPerAmount;

	private float retaliationPerArmorPerAmount;

	private float lastStoredArmor;

	private float nextUpdateTime;

	protected override void OnInitOrAmountChanged()
	{
	}

	private void UpdateRetaliation()
	{
	}

	public override void Tick()
	{
	}

	public ItemSpikyShield(ItemInventory itemInventoryRef)
		: base(null)
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
