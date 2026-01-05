using System.Collections.Generic;
using Assets.Scripts.Actors;
using Assets.Scripts.Inventory__Items__Pickups.Stats;
using UnityEngine;
using UnityEngine.Localization;

namespace Assets.Scripts.Inventory__Items__Pickups.Items.ItemImplementations;

public class ItemCactus : ItemBase
{
	private float damagePerAmount;

	private int numProjectilesPerAmount;

	private float damage;

	private int numProjectiles;

	public static string damageSource;

	private List<Vector3> projectileDirections;

	protected static readonly RaycastHit[] raycastBuffer;

	protected override void OnInitOrAmountChanged()
	{
	}

	public override void Init()
	{
	}

	public override void Cleanup()
	{
	}

	private void OnTakeDamage(PlayerHealth ph, DamageContainer dc, bool isShieldDamage)
	{
	}

	public ItemCactus(ItemInventory itemInventoryRef)
		: base(null)
	{
	}

	public override void Tick()
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
