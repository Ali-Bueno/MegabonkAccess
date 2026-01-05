using Assets.Scripts.Actors;
using Assets.Scripts.Inventory__Items__Pickups.Stats;

namespace Assets.Scripts.Inventory__Items__Pickups.Items.ItemImplementations;

public class ItemGhost : ItemBase
{
	public const int maxGhosts = 100;

	private int numGhosts;

	private int numGhostsPerAmount;

	private string damageSource;

	protected override void OnInitOrAmountChanged()
	{
	}

	private void OnInteracted(BaseInteractable interactable, bool success)
	{
	}

	private void SpawnGhost()
	{
	}

	private float GetDuration()
	{
		return 0f;
	}

	private float GetDamage()
	{
		return 0f;
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

	public override void ProcOnHitEffects(DamageContainer dc)
	{
	}

	public override bool HasOnHitEffectProc()
	{
		return false;
	}

	public ItemGhost(ItemInventory itemInventoryRef)
		: base(null)
	{
	}
}
