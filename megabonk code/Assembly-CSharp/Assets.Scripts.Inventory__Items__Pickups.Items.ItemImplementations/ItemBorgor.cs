using Assets.Scripts.Actors;
using Assets.Scripts.Actors.Enemies;
using Assets.Scripts.Inventory__Items__Pickups.Stats;
using UnityEngine.Localization;

namespace Assets.Scripts.Inventory__Items__Pickups.Items.ItemImplementations;

public class ItemBorgor : ItemBase
{
	public const int maxAmountAbsolute = 20;

	private const float maxSpawnDistance = 35f;

	private float baseChance;

	private float chancePerAmount;

	private float ratioHeal;

	private int flatHealPerAmount;

	private int flatHeal;

	private float chance;

	protected override void OnInitOrAmountChanged()
	{
	}

	private void OnEnemyDied(Enemy enemy, DamageContainer deathSource)
	{
	}

	public override void Init()
	{
	}

	public override void Cleanup()
	{
	}

	public static int GetMaxAmount()
	{
		return 0;
	}

	public ItemBorgor(ItemInventory itemInventoryRef)
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

	public override string GetDescription(LocalizedString localizedString)
	{
		return null;
	}
}
