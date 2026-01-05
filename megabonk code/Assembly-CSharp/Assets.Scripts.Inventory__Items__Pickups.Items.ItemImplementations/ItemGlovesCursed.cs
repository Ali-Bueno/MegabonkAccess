using System.Collections.Generic;
using Assets.Scripts.Actors;
using Assets.Scripts.Inventory__Items__Pickups.Stats;

namespace Assets.Scripts.Inventory__Items__Pickups.Items.ItemImplementations;

public class ItemGlovesCursed : ItemBase
{
	public float procChancePerAmount;

	private float procChance;

	private float difficultyPerAmount;

	private float maxHpMultiplierPerAmount;

	private float baseDamageMultiplier;

	private float baseRadius;

	private static string damageSource;

	private DamageContainer reuseDc;

	private EffectPlayer fx;

	private int maxProcsPerTick;

	private int numProcsThisTick;

	public ItemGlovesCursed(ItemInventory itemInventoryRef)
		: base(null)
	{
	}

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

	private float GetDamage()
	{
		return 0f;
	}

	public override void Tick()
	{
	}

	protected override Dictionary<string, object> GetLocalizationKeys()
	{
		return null;
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
}
