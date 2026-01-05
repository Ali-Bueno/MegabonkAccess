using System.Collections.Generic;
using Assets.Scripts.Actors;
using Assets.Scripts.Actors.Enemies;
using Assets.Scripts.Inventory__Items__Pickups.Stats;

namespace Assets.Scripts.Inventory__Items__Pickups.Items.ItemImplementations;

public class ItemBloodyCleaver : ItemBase
{
	private int bloodmarkStacksPerLifestealPerAmount;

	private int bloodmarkStacksPerLifesteal;

	private float bloodmarkChancePerAmount;

	private float totalBloodmarkChance;

	private static string damageSource;

	private DamageContainer dc;

	private Dictionary<Enemy, int> lifestealProcTracker;

	protected override void OnInitOrAmountChanged()
	{
	}

	public override void Init()
	{
	}

	public override void Cleanup()
	{
	}

	public override void ProcOnHitEffects(DamageContainer dc)
	{
	}

	public override bool HasOnHitEffectProc()
	{
		return false;
	}

	private void OnLifestealProc(Enemy enemy, int lifestealAmount)
	{
	}

	public override void Tick()
	{
	}

	public ItemBloodyCleaver(ItemInventory itemInventoryRef)
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

	protected override Dictionary<string, object> GetLocalizationKeys()
	{
		return null;
	}
}
