using Assets.Scripts.Actors;
using Assets.Scripts.Inventory__Items__Pickups.Stats;

namespace Assets.Scripts.Inventory__Items__Pickups.Items.ItemImplementations;

public class ItemFlappyFeathers : ItemBase
{
	private float speedBoostPerAmount;

	private float jumpHeightAdditionPerAmount;

	private float speedBoost;

	protected override void OnInitOrAmountChanged()
	{
	}

	private void OnJumped(PlayerMovement pm)
	{
	}

	public override void Init()
	{
	}

	public override void Cleanup()
	{
	}

	public ItemFlappyFeathers(ItemInventory itemInventoryRef)
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
