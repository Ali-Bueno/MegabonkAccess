using System.Collections.Generic;
using Assets.Scripts.Menu.Shop;

namespace Assets.Scripts.Inventory__Items__Pickups.Stats;

public static class StatUtility
{
	public static string GetUpgradeDescriptionWeapon(List<StatModifier> modifiers, WeaponData weaponData)
	{
		return null;
	}

	public static string GetUpgradeDescriptionTome(List<StatModifier> modifiers, TomeData tomeData)
	{
		return null;
	}

	public static string GetUpgradeDescriptionWeaponModifier(StatModifier modifier, WeaponData weaponData, string color = "#ffffff")
	{
		return null;
	}

	public static string GetUpgradeDescriptionTomeModifier(StatModifier modifier, TomeData tomeData, string color = "#ffffff")
	{
		return null;
	}

	public static string GetUpgradeDescriptionStat(StatModifier modifier, string color = "#ffffff")
	{
		return null;
	}

	public static string EncapsulateNumber(string number, string color)
	{
		return null;
	}

	public static string EncapsulateNumber(float number, string color)
	{
		return null;
	}

	public static string GetModificationString(StatModifier modifier, bool addOneToMultiplication = true)
	{
		return null;
	}

	public static string GetModificationString(EStatModifyType modifyType, EStat stat, float value, bool addOneToMultiplication = true, bool usePrefix = true)
	{
		return null;
	}

	public static string GetWeaponModificationString(EStatModifyType modifyType, EStat stat, float value, bool addOneToMultiplication = true)
	{
		return null;
	}

	private static string ModifyStatName(string statName, EWeapon eWeapon)
	{
		return null;
	}

	public static float GetRarityValue(float value, ERarity rarity, int decimals = 2)
	{
		return 0f;
	}

	public static EStatCategory GetStatCategory(EStat eStat)
	{
		return default(EStatCategory);
	}
}
