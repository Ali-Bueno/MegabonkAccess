using Assets.Scripts.Actors;
using Assets.Scripts.Inventory__Items__Pickups.Stats;

namespace Assets.Scripts.Inventory__Items__Pickups.Items.ItemImplementations;

public class ItemWeebHeadset : ItemBase
{
	public float charmChancePerAmount;

	private float durationPerAmount;

	private float charmDuration;

	private float charmChance;

	private int maxProcsPerTick;

	private int numProcsThisTick;

	public ItemWeebHeadset(ItemInventory itemInventoryRef)
		: base(null)
	{
	}

	protected override void OnInitOrAmountChanged()
	{
	}

	public override void ProcOnHitEffects(DamageContainer dc)
	{
	}

	public override bool HasOnHitEffectProc()
	{
		return false;
	}

	public override void Tick()
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
}
