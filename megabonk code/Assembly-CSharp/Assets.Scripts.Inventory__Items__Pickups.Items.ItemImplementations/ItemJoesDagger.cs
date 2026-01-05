using System.Collections.Generic;
using Assets.Scripts.Actors;
using Assets.Scripts.Actors.Enemies;
using Assets.Scripts.Inventory__Items__Pickups.Stats;

namespace Assets.Scripts.Inventory__Items__Pickups.Items.ItemImplementations;

public class ItemJoesDagger : ItemBase
{
	private float attackDamagePerProc;

	private float accumulatedDamaged;

	private float executionChancePerAmount;

	private float executionChance;

	private int stacks;

	private int maxStacks;

	private int lastUsedStacks;

	private float nextUpdateTime;

	private string damageSource;

	private const float maxRollsPerMinute = 200f;

	private float rollCooldown;

	private float nextRollTime;

	protected override void OnInitOrAmountChanged()
	{
	}

	public override void Tick()
	{
	}

	private void OnEnemyDamage(Enemy e, DamageContainer dc)
	{
	}

	public override void Init()
	{
	}

	public override void Cleanup()
	{
	}

	public ItemJoesDagger(ItemInventory itemInventoryRef)
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
