using Assets.Scripts.Actors;
using Assets.Scripts.Inventory__Items__Pickups.Stats;
using UnityEngine.Localization;

namespace Assets.Scripts.Inventory__Items__Pickups.Items.ItemImplementations;

public class ItemCowardsCloak : ItemBase
{
	private float speedPerAmount;

	private float speedPerStack;

	private int maxStacks;

	private int stacksPerAmount;

	private float extraDurationPerAmount;

	private float stacksResetAtTime;

	private int stacks;

	protected override void OnInitOrAmountChanged()
	{
	}

	private void OnDamage(PlayerHealth ph, DamageContainer dc, bool shieldDamage)
	{
	}

	private void AddTemporaryStack()
	{
	}

	public override void Tick()
	{
	}

	private void RefreshStats()
	{
	}

	public override void Init()
	{
	}

	public override void Cleanup()
	{
	}

	public ItemCowardsCloak(ItemInventory itemInventoryRef)
		: base(null)
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
