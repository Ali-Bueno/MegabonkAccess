using Assets.Scripts.Actors;
using Assets.Scripts.Inventory__Items__Pickups.Stats;

namespace Assets.Scripts.Inventory__Items__Pickups.Items.ItemImplementations;

public class ItemGoldenShield : ItemBase
{
	private float chancePerAmount;

	private float chance;

	private int extraGoldFromOverload;

	private int goldPerAmount;

	private int goldOnHit;

	private float cooldown;

	private float readyAtTime;

	private float nextSelfDamageReadyTime;

	private float selfDamageCooldown;

	protected override void OnInitOrAmountChanged()
	{
	}

	private void OnPlayerTakeDamage(PlayerHealth playerHealth, DamageContainer dc, bool b)
	{
	}

	private int GetGold()
	{
		return 0;
	}

	public override void Init()
	{
	}

	public override void Cleanup()
	{
	}

	public ItemGoldenShield(ItemInventory itemInventoryRef)
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
}
