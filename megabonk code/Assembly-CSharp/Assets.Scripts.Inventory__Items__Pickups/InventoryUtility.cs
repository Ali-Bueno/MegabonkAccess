using System.Collections.Generic;
using Assets.Scripts._Data;
using Assets.Scripts.Inventory__Items__Pickups.Items;

namespace Assets.Scripts.Inventory__Items__Pickups;

public class InventoryUtility
{
	public const int MAX_WEAPON_LEVEL_BASE = 40;

	public const int MAX_TOME_LEVEL_BASE = 99;

	public static List<IUpgradable> GetRandomUpgrades()
	{
		return null;
	}

	public static List<ItemData> GetRandomItemsMoai(int moaiLuckMode)
	{
		return null;
	}

	public static List<ItemData> GetRandomItemsShadyGuy(EItemRarity itemRarity)
	{
		return null;
	}

	private static int GetNumUpgrades()
	{
		return 0;
	}

	private static bool CanUnlockItem(IUpgradable upgradable)
	{
		return false;
	}

	private static bool CanUnlockWeapons()
	{
		return false;
	}

	private static bool CanUnlockTomes()
	{
		return false;
	}

	public static int GetNumAvailableWeaponSlots()
	{
		return 0;
	}

	public static int GetNumAvailableTomeSlots()
	{
		return 0;
	}

	public static int GetNumMaxWeaponSlots()
	{
		return 0;
	}

	public static int GetNumMaxTomeSlots()
	{
		return 0;
	}

	public static int GetWeaponMaxLevel()
	{
		return 0;
	}

	public static int GetTomeMaxLevel()
	{
		return 0;
	}

	public static int GetNumExtraWeaponLevels()
	{
		return 0;
	}

	public static int GetNumExtraTomeLevels()
	{
		return 0;
	}
}
