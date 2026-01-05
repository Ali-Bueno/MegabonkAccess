using System;
using System.Collections.Generic;
using Assets.Scripts._Data.MapsAndStages;

namespace Assets.Scripts.Saves___Serialization.Progression;

[Serializable]
public class MenuMeta
{
	public EMap lastSelectedMap;

	public Dictionary<EMap, MapProgress> mapsProgress;

	private int numRunsForUnlocks;

	private int numRunsForLeaderboards;

	private int numRunsForQuests;

	private int numRunsForQuickQuests;

	private int numRunsForShop;

	public bool hasVisitedUnlocks;

	public bool hasVisitedQuests;

	public bool hasVisitedShop;

	public bool HasMenuUnlocks()
	{
		return false;
	}

	public bool HasMenuQuests()
	{
		return false;
	}

	public bool HasMenuShop()
	{
		return false;
	}

	public bool HasQuickQuests()
	{
		return false;
	}

	public bool HasLeaderboards()
	{
		return false;
	}

	public MapProgress GetMapProgress(EMap map)
	{
		return null;
	}

	private void VerifyMap(EMap map)
	{
	}

	public void SetTier(EMap map, int tier)
	{
	}

	public void SetTierCompletion(EMap map, int tier)
	{
	}

	public int GetLastSelectedTier(EMap map)
	{
		return 0;
	}

	public bool IsTierCompleted(EMap map, int tier)
	{
		return false;
	}

	public int GetHighestCompletedTier(EMap map)
	{
		return 0;
	}
}
