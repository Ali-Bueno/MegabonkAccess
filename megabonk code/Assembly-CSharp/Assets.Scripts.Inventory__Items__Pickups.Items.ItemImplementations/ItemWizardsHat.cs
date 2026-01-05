using Assets.Scripts.Actors;
using Assets.Scripts.Inventory__Items__Pickups.Stats;
using UnityEngine.Localization;

namespace Assets.Scripts.Inventory__Items__Pickups.Items.ItemImplementations;

public class ItemWizardsHat : ItemBase
{
	private int tomeLevelsPerAmountMax;

	private int tomeLevelsPerAmountMin;

	private int startFalloffAtAmount;

	public int tomeLevels;

	protected override void OnInitOrAmountChanged()
	{
	}

	private int GetLevelsForAmount(int minPerAmount, int maxPerAmount)
	{
		return 0;
	}

	public ItemWizardsHat(ItemInventory itemInventoryRef)
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
