using System.Collections.Generic;
using Assets.Scripts.Actors;
using Assets.Scripts.Inventory__Items__Pickups.Stats;

namespace Assets.Scripts.Inventory__Items__Pickups.Items.ItemImplementations;

public class ItemBeefyRing : ItemBase
{
	private int maxHpPerStack;

	private float powerPerHpPerAmount;

	private int lastStoredMaxHp;

	private float nextUpdateTime;

	protected override void OnInitOrAmountChanged()
	{
	}

	private void RefreshPower()
	{
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

	public ItemBeefyRing(ItemInventory itemInventoryRef)
		: base(null)
	{
	}

	public override void ProcOnHitEffects(DamageContainer dc)
	{
	}

	public override void PreAttack(DamageContainer dc, StatComponents itemAttackModifier)
	{
	}

	public override bool HasPreAttackProc()
	{
		return false;
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
