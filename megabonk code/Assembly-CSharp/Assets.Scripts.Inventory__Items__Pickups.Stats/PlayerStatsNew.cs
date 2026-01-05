using System;
using System.Collections.Generic;
using Assets.Scripts._Data.ShopItems;
using Assets.Scripts._Data.Tomes;
using Assets.Scripts.Menu.Shop;

namespace Assets.Scripts.Inventory__Items__Pickups.Stats;

public class PlayerStatsNew
{
	public Dictionary<EStat, float> stats;

	public Dictionary<EStat, float> rawStats;

	public Dictionary<EStat, StatComponents> statValuesMap;

	private PlayerInventory playerInventory;

	public static Action<EStat> A_StatUpdate;

	private HashSet<EStat> queuedUpdateStats;

	private Dictionary<EStat, HashSet<EShopItem>> statToShopItems;

	private bool ignoreShopItems;

	private readonly List<EStat> statsToUpdateBuffer;

	public PlayerStatsNew(PlayerInventory inventory, bool ignoreShopItems = false)
	{
	}

	public void OnDestroy()
	{
	}

	public void Tick()
	{
	}

	private void TryPopStatUpdatesQueue()
	{
	}

	public void ForceUpdateStats()
	{
	}

	private void QueueUpdateStatTome(ETome eTome, EStat stat)
	{
	}

	private void QueueUpdateStat(EStat stat)
	{
	}

	private void UpdateStat(EStat stat)
	{
	}

	private void ApplyStatModifier(StatModifier modifier, int amount, ref float flatValues, ref float additionValues, ref float multiplicationValues)
	{
	}

	private float CheckFinalValue(EStat stat, float value)
	{
		return 0f;
	}

	public static float GetBaseValue(EStat stat)
	{
		return 0f;
	}

	public float GetStat(EStat stat)
	{
		return 0f;
	}

	public float GetRawStat(EStat stat)
	{
		return 0f;
	}

	public float GetUnclampedStat(EStat stat)
	{
		return 0f;
	}
}
