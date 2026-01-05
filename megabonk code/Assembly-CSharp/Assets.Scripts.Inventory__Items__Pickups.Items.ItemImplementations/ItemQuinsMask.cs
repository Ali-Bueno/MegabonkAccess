using System.Collections.Generic;
using Assets.Scripts.Actors;
using Assets.Scripts.Inventory__Items__Pickups.Stats;

namespace Assets.Scripts.Inventory__Items__Pickups.Items.ItemImplementations;

public class ItemQuinsMask : ItemBase
{
	private float thornsPerAmount;

	private float baseRadius;

	private float radiusPerAmount;

	private float maxRadius;

	private float radius;

	private float damageSpreadMultiplier;

	private float procChance;

	private HashSet<string> damageSources;

	private DamageContainer procDc;

	private string damageSource;

	private string aegisDamageSource;

	private int maxProcsPerTick;

	private int numProcsThisTick;

	protected override void OnInitOrAmountChanged()
	{
	}

	public ItemQuinsMask(ItemInventory itemInventoryRef)
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

	public override void Tick()
	{
	}

	protected override Dictionary<string, object> GetLocalizationKeys()
	{
		return null;
	}
}
