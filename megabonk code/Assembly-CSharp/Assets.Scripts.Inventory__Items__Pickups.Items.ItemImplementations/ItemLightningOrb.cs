using System.Collections.Generic;
using Assets.Scripts.Actors;
using Assets.Scripts.Inventory__Items__Pickups.Stats;
using UnityEngine;

namespace Assets.Scripts.Inventory__Items__Pickups.Items.ItemImplementations;

public class ItemLightningOrb : ItemBase
{
	public float procChancePerAmount;

	private float procChance;

	private float stunChancePerAmount;

	private float stunChance;

	private float baseRadius;

	public float damageRatio;

	public float damageRatioPerAmount;

	private float foundEnemiesAtTime;

	private string damageSource;

	private DamageContainer yepDc;

	private List<int> availableIndexes;

	private int numEnemies;

	private Collider[] enemies;

	public ItemLightningOrb(ItemInventory itemInventoryRef)
		: base(null)
	{
	}

	protected override void OnInitOrAmountChanged()
	{
	}

	public override void Tick()
	{
	}

	public override void ProcOnHitEffects(DamageContainer dc)
	{
	}

	public override bool HasOnHitEffectProc()
	{
		return false;
	}

	private void TryProcStun(DamageContainer dc, float overrideProcCoefficient = -1f)
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
