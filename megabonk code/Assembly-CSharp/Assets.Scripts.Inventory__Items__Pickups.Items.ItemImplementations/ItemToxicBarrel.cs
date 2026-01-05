using System;
using Assets.Scripts.Actors;
using Assets.Scripts.Inventory__Items__Pickups.Stats;

namespace Assets.Scripts.Inventory__Items__Pickups.Items.ItemImplementations;

public class ItemToxicBarrel : ItemBase
{
	public static Action<float> A_OnUse;

	private float radius;

	private float radiusPerAmount;

	private int poisonStacksPerAmount;

	private int poisonStacks;

	private float cooldown;

	private float readyAtTime;

	private float poisonDuration;

	private string damageSource;

	private DamageContainer dc;

	protected override void OnInitOrAmountChanged()
	{
	}

	public override void Init()
	{
	}

	public override void Cleanup()
	{
	}

	private void OnTakeDamage(PlayerHealth ph, DamageContainer dc, bool shieldDamage)
	{
	}

	private void Activate()
	{
	}

	public override void Tick()
	{
	}

	public ItemToxicBarrel(ItemInventory itemInventoryRef)
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
