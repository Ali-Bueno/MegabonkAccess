using System.Collections.Generic;
using Assets.Scripts.Actors;
using Assets.Scripts.Actors.Enemies;
using Assets.Scripts.Inventory__Items__Pickups.Stats;
using UnityEngine;

namespace Assets.Scripts.Inventory__Items__Pickups.Items.ItemImplementations;

public class ItemSoulHarvester : ItemBase
{
	private string damageSource;

	public const int maxProjectiles = 100;

	private int numProjectiles;

	private float damageMultiplier;

	private float range;

	private Dictionary<GameObject, ItemProjectile> projectileLookup;

	public override void Init()
	{
	}

	public override void Cleanup()
	{
	}

	protected override void OnInitOrAmountChanged()
	{
	}

	private float GetDamage()
	{
		return 0f;
	}

	private void OnEnemyDied(Enemy enemy)
	{
	}

	private void SpawnProjectile(Vector3 pos)
	{
	}

	public override void Tick()
	{
	}

	public ItemSoulHarvester(ItemInventory itemInventoryRef)
		: base(null)
	{
	}

	public override void ProcOnHitEffects(DamageContainer dc)
	{
	}

	public override bool HasOnHitEffectProc()
	{
		return false;
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
