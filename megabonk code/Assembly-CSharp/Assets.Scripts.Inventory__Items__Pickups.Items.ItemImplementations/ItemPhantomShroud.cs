using Assets.Scripts.Actors;
using Assets.Scripts.Actors.Enemies;
using Assets.Scripts.Inventory__Items__Pickups.Stats;
using UnityEngine.Localization;

namespace Assets.Scripts.Inventory__Items__Pickups.Items.ItemImplementations;

public class ItemPhantomShroud : ItemBase
{
	private float evasionPerAmount;

	private float damageMultiplierBase;

	private float damageMultiplierPerAmount;

	private float speedAdditionBase;

	private float speedAdditionPerAmount;

	private float timeout;

	private float attackSpeedPerStack;

	private float damagePerStack;

	private int stacks;

	private int maxStacks;

	private bool hasEvaded;

	private float speedResetAtTime;

	private bool hasSpeed;

	protected override void OnInitOrAmountChanged()
	{
	}

	private void OnEvade(Enemy enemy)
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

	public override void Init()
	{
	}

	public override void Cleanup()
	{
	}

	public ItemPhantomShroud(ItemInventory itemInventoryRef)
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

	public override string GetDescription(LocalizedString localizedString)
	{
		return null;
	}
}
