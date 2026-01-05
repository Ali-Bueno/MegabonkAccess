using System.Collections.Generic;
using Assets.Scripts.Inventory__Items__Pickups.Stats;
using Assets.Scripts.Menu.Shop;
using Assets.Scripts.UI.InGame.Rewards;

namespace Assets.Scripts.Inventory__Items__Pickups.Upgrades;

public class EncounterUtility
{
	public static List<EStat> upgradableStatsShrines;

	public static List<EStat> upgradableStatsChaosAndGamble;

	private static List<EStat> upgradableStatsBalanceShrine;

	public static List<EStat> GetRandomStats(int amount)
	{
		return null;
	}

	public static List<EStat> GetRandomStatsChaosAndGamble(int amount)
	{
		return null;
	}

	public static List<EStat> GetRandomStatsBalanceShrine(int amount)
	{
		return null;
	}

	public static List<EncounterOffer> GetRandomStatOffers(int amount, bool forceLegendary = false, bool useShrineStats = true)
	{
		return null;
	}

	public static List<EncounterOffer> GetBalanceShrineOffers(int amount)
	{
		return null;
	}

	private static float GetRandomStatValue(EStat stat, out EStatModifyType type)
	{
		type = default(EStatModifyType);
		return 0f;
	}
}
