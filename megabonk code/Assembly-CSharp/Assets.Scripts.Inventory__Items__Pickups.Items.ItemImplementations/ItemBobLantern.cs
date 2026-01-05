using Assets.Scripts.Actors;
using Assets.Scripts.Inventory__Items__Pickups.Stats;
using UnityEngine;
using UnityEngine.Localization;

namespace Assets.Scripts.Inventory__Items__Pickups.Items.ItemImplementations;

public class ItemBobLantern : ItemBase
{
	private float cooldownMin;

	private float cooldownMax;

	private float cooldownReductionPerAmount;

	private float cooldown;

	private float nextExplodeTime;

	private float radius;

	private float radiusMin;

	private float radiusMax;

	private float radiusPerAmount;

	private GameObject explosionPrefab;

	protected override void OnInitOrAmountChanged()
	{
	}

	public override void Tick()
	{
	}

	private void RefreshExplosionSize()
	{
	}

	private void Explode()
	{
	}

	public ItemBobLantern(ItemInventory itemInventoryRef)
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
