using Assets.Scripts.Actors;
using Assets.Scripts.Inventory__Items__Pickups.Stats;

namespace Assets.Scripts.Inventory__Items__Pickups.Items.ItemImplementations;

public class ItemEnergyCore : ItemBase
{
	private int orbsPerAmount;

	private int numOrbs;

	private float range;

	private float cooldown;

	private float cooldownPerOrb;

	private float nextSpawnTime;

	private int orbsLeftToShoot;

	private float nextOrbTime;

	private string damageSource;

	protected override void OnInitOrAmountChanged()
	{
	}

	private float GetDamage()
	{
		return 0f;
	}

	public override void Tick()
	{
	}

	private void FireOrb(int index)
	{
	}

	public ItemEnergyCore(ItemInventory itemInventoryRef)
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
}
