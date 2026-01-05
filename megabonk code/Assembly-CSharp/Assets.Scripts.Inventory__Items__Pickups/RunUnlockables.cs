using System;
using System.Collections.Generic;
using Assets.Scripts.Inventory__Items__Pickups.Items;
using Assets.Scripts.Saves___Serialization.Progression.Achievements;

namespace Assets.Scripts.Inventory__Items__Pickups;

public static class RunUnlockables
{
	public static HashSet<ItemData> banishedItems;

	public static HashSet<UnlockableBase> banishedUpgradables;

	public static Dictionary<EItemRarity, List<ItemData>> availableItems;

	public static Action A_Inited;

	private static int maxOverpoweredLamps;

	private static int maxAnvils;

	public static void Init()
	{
	}

	public static void Cleanup()
	{
	}

	private static void OnNewRunStarted()
	{
	}

	public static void Testing()
	{
	}

	private static void AddItemToPool(ItemData item)
	{
	}

	private static void OnItemAdded(EItem eItem)
	{
	}

	private static void OnItemRemoved(EItem eItem, bool whatever)
	{
	}

	private static void OnAchievementUnlocked(MyAchievement ach)
	{
	}

	public static void BanishItem(ItemData unlockable)
	{
	}

	public static void BanishUpgradable(UnlockableBase upgradable)
	{
	}
}
