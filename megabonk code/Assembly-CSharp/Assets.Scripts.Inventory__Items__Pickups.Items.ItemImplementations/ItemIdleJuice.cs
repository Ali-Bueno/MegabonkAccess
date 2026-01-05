using Assets.Scripts.Actors;
using Assets.Scripts.Inventory__Items__Pickups.Stats;
using UnityEngine;
using UnityEngine.Localization;

namespace Assets.Scripts.Inventory__Items__Pickups.Items.ItemImplementations;

public class ItemIdleJuice : ItemBase
{
	private float damagePerAmount;

	private float maxDamage;

	private float damagePerSecond;

	private Vector3 campfirePos;

	private float setupTime;

	private float distThreshold;

	private float startCampfireTime;

	private bool isCampActive;

	private float currentDamage;

	private float nextUpdateDamageTime;

	private float updateDamageInterval;

	protected override void OnInitOrAmountChanged()
	{
	}

	public override void Tick()
	{
	}

	private void CreateCamp()
	{
	}

	private void RemoveCamp()
	{
	}

	public ItemIdleJuice(ItemInventory itemInventoryRef)
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

	public override string GetDescription(LocalizedString localizedString)
	{
		return null;
	}
}
