using System.Collections.Generic;
using Assets.Scripts.Actors;
using Assets.Scripts.Inventory__Items__Pickups.Stats;

namespace Assets.Scripts.Inventory__Items__Pickups.Items.ItemImplementations;

public class ItemEagleClaw : ItemBase
{
	public float procChancePerAmount;

	private float procChance;

	public float damageAddition;

	public float damageAdditionPerAmount;

	private float knockupForce;

	protected override void OnInitOrAmountChanged()
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

	public ItemEagleClaw(ItemInventory itemInventoryRef)
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

	protected override Dictionary<string, object> GetLocalizationKeys()
	{
		return null;
	}
}
