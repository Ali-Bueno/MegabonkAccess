using Assets.Scripts.Actors;
using Assets.Scripts.Inventory__Items__Pickups.Stats;

namespace Assets.Scripts.Inventory__Items__Pickups.Items.ItemImplementations;

public class ItemGlovesPoison : ItemBase
{
	public float readyAtTime;

	private float cooldown;

	private float baseDamageMultiplier;

	private float baseRadius;

	private int poisonStacksPerAmount;

	private static string damageSource;

	private DamageContainer reuseDc;

	private EffectPlayer fx;

	public ItemGlovesPoison(ItemInventory itemInventoryRef)
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

	private float GetDamage()
	{
		return 0f;
	}

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

	public override void PreAttack(DamageContainer dc, StatComponents itemAttackModifier)
	{
	}

	public override bool HasPreAttackProc()
	{
		return false;
	}
}
