using Assets.Scripts.Actors;
using Assets.Scripts.Actors.Enemies;
using Assets.Scripts.Inventory__Items__Pickups.Stats;
using UnityEngine.Localization;

namespace Assets.Scripts.Inventory__Items__Pickups.Items.ItemImplementations;

public class ItemDemonicBlood : ItemBase
{
	private static readonly float hpPerStack;

	private int maxStacksPerAmount;

	private int stacks;

	private int maxStacks;

	private int lastUsedStacks;

	private float nextUpdateTime;

	protected override void OnInitOrAmountChanged()
	{
	}

	private void OnEnemyDied(Enemy enemy, DamageContainer deathSource)
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

	public ItemDemonicBlood(ItemInventory itemInventoryRef)
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
