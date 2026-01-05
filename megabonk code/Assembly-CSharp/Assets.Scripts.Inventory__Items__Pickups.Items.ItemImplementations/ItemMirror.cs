using System;
using Assets.Scripts.Actors;
using Assets.Scripts.Inventory__Items__Pickups.Stats;

namespace Assets.Scripts.Inventory__Items__Pickups.Items.ItemImplementations;

public class ItemMirror : ItemBase
{
	public static Action<bool> A_MirrorReady;

	public float cooldown;

	private float minCooldown;

	private float damageMultiplier;

	private float damagePerAmount;

	private float lastReflectedTime;

	private bool canReflect;

	private string damageSource;

	private DamageContainer reuseDc;

	protected override void OnInitOrAmountChanged()
	{
	}

	public override void Init()
	{
	}

	public override void Cleanup()
	{
	}

	public override void Tick()
	{
	}

	private bool IsReady()
	{
		return false;
	}

	private bool ReflectDamage(DamageContainer dc)
	{
		return false;
	}

	private void OnCheckStopDamage(DamageContainer dc, bool shieldDamage)
	{
	}

	public ItemMirror(ItemInventory itemInventoryRef)
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
}
