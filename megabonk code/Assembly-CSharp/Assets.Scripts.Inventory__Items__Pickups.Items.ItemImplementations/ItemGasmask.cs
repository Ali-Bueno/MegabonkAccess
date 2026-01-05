using System.Collections.Generic;
using Assets.Scripts.Actors;
using Assets.Scripts.Inventory__Items__Pickups.Stats;

namespace Assets.Scripts.Inventory__Items__Pickups.Items.ItemImplementations;

public class ItemGasmask : ItemBase
{
	private float armorPerStack;

	private float overhealPerStack;

	private float maxArmorPerAmount;

	private float maxOverhealPerAmount;

	private float maxArmor;

	private float maxOverheal;

	private int lastStoredStacks;

	private float updateInverval;

	private float nextUpdateTime;

	protected override void OnInitOrAmountChanged()
	{
	}

	private void UpdateRetaliation()
	{
	}

	private int GetNumPoisonedEnemies()
	{
		return 0;
	}

	private void OnStageStarted()
	{
	}

	public override void Tick()
	{
	}

	public ItemGasmask(ItemInventory itemInventoryRef)
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
