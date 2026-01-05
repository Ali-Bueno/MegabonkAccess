using System.Collections.Generic;
using Assets.Scripts.Actors;
using Assets.Scripts.Inventory__Items__Pickups.Stats;
using UnityEngine;

namespace Assets.Scripts.Inventory__Items__Pickups.Items.ItemImplementations;

public class ItemBobDead : ItemBase
{
	private string damageSource;

	public const int maxGhosts = 80;

	private float unitsPerProjectile;

	private float minSpawnTime;

	private float nextCheckTime;

	private float accumulatedDistance;

	private Vector3 lastPos;

	protected override void OnInitOrAmountChanged()
	{
	}

	public override void Tick()
	{
	}

	private float GetDamage()
	{
		return 0f;
	}

	private void SpawnGhost()
	{
	}

	private float GetDuration()
	{
		return 0f;
	}

	public ItemBobDead(ItemInventory itemInventoryRef)
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
