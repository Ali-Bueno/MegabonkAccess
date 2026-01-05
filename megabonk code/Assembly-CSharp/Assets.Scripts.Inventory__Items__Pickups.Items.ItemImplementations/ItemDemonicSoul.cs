using System.Collections.Generic;
using Assets.Scripts.Actors;
using Assets.Scripts.Actors.Enemies;
using Assets.Scripts.Inventory__Items__Pickups.Stats;

namespace Assets.Scripts.Inventory__Items__Pickups.Items.ItemImplementations;

public class ItemDemonicSoul : ItemBase
{
	private static readonly float attackDamagePerStack;

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

	public ItemDemonicSoul(ItemInventory itemInventoryRef)
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

	protected override Dictionary<string, object> GetLocalizationKeys()
	{
		return null;
	}
}
