using System;
using System.Collections.Generic;
using Assets.Scripts.Menu.Shop;

namespace Assets.Scripts.Inventory__Items__Pickups.Stats;

public class StatInventory
{
	public Dictionary<EStat, List<StatModifier>> permanentChanges;

	public Dictionary<EStat, List<TemporaryStat>> temporaryChanges;

	public Dictionary<string, StatModifier> movingStats;

	public static Action<EStat> A_StatsChanged;

	private HashSet<EStat> refreshStats;

	public void ChangeStat(StatModifier stat, bool permanent, float timeout, bool addToShrineLog)
	{
	}

	public void ChangeMovingStat(string name, StatModifier statModifier)
	{
	}

	public void RemoveMovingStat(string name)
	{
	}

	public void Tick()
	{
	}
}
