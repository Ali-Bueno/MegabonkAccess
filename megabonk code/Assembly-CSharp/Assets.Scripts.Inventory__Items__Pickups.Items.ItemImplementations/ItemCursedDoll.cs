using System;
using System.Collections.Generic;
using Assets.Scripts.Actors;
using Assets.Scripts.Actors.Enemies;
using Assets.Scripts.Inventory__Items__Pickups.Stats;
using UnityEngine.Localization;

namespace Assets.Scripts.Inventory__Items__Pickups.Items.ItemImplementations;

public class ItemCursedDoll : ItemBase
{
	[Serializable]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9;

		public static Predicate<Enemy> _003C_003E9__10_0;

		internal bool _003CTick_003Eb__10_0(Enemy enemy)
		{
			return false;
		}
	}

	private int maxNumCursedEnemies;

	private float damageMaxHpPercentage;

	private int enemiesCursedPerDoll;

	private int maxNumCursesPerCheck;

	private DamageContainer reuseDc;

	private string damageSource;

	private HashSet<Enemy> cursedEnemies;

	private float attackCooldown;

	private float nextAttackTime;

	protected override void OnInitOrAmountChanged()
	{
	}

	public override void Tick()
	{
	}

	private void OnEnemyDied(Enemy enemy)
	{
	}

	public override void Init()
	{
	}

	public override void Cleanup()
	{
	}

	public ItemCursedDoll(ItemInventory itemInventoryRef)
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
