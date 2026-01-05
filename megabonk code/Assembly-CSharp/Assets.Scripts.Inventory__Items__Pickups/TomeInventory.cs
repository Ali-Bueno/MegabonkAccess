using System;
using System.Collections.Generic;
using Assets.Scripts._Data.Tomes;
using Assets.Scripts.Inventory__Items__Pickups.Stats;
using Assets.Scripts.Menu.Shop;

namespace Assets.Scripts.Inventory__Items__Pickups;

public class TomeInventory
{
	private bool isMaxed;

	public static Action<ETome, EStat> A_TomeUpgrade;

	public Dictionary<ETome, int> tomeLevels;

	public Dictionary<EStat, HashSet<ETome>> statToTomes;

	public Dictionary<ETome, StatModifier> tomeUpgrade;

	public void AddTome(TomeData tomeData, List<StatModifier> upgradeOffer, ERarity rarity)
	{
	}

	public void AddMaxedTome(TomeData tomeData)
	{
	}

	public int GetTomeLevel(ETome tome)
	{
		return 0;
	}

	public int GetNumTomes()
	{
		return 0;
	}

	private void CheckMaxed()
	{
	}

	private bool IsMaxLevel(ETome eTome)
	{
		return false;
	}

	public bool IsMaxed()
	{
		return false;
	}

	public bool HasTome(ETome eTome)
	{
		return false;
	}
}
