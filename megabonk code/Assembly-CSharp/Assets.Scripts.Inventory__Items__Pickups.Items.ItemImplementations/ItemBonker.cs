using System.Collections.Generic;
using Assets.Scripts.Actors;
using Assets.Scripts.Inventory__Items__Pickups.Stats;

namespace Assets.Scripts.Inventory__Items__Pickups.Items.ItemImplementations;

public class ItemBonker : ItemBase
{
	private float baseChance;

	private float baseDamageMultiplier;

	private float chancePerStack;

	private float damageMultiplierPerStack;

	private float radiusPerStack;

	private float radius;

	private float maxRadius;

	private float chance;

	private float damageMultiplier;

	private string damageSource;

	private DamageContainer reuseDc;

	private int maxProcsPerTick;

	private int numProcsThisTick;

	protected override void OnInitOrAmountChanged()
	{
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

	public ItemBonker(ItemInventory itemInventoryRef)
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

	protected override Dictionary<string, object> GetLocalizationKeys()
	{
		return null;
	}
}
