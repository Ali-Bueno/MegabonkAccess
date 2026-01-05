using System.Collections.Generic;
using Actors.Enemies;
using Assets.Scripts._Data.Progression;
using Assets.Scripts.Inventory__Items__Pickups;
using Assets.Scripts.Inventory__Items__Pickups.Items;
using Assets.Scripts.Menu.Shop;
using UnityEngine.Localization;

namespace Assets.Scripts.UI.Localization;

public class LocalizationUtility
{
	public static bool IsEnglish()
	{
		return false;
	}

	public static string GetLocalizedString(string table, string key, string defaultEnglishString, bool useEnglishDefaultIfAvailable = true)
	{
		return null;
	}

	public static string GetLocalizedString(string table, string key)
	{
		return null;
	}

	public static string GetLocalizedString(string table, string key, Dictionary<string, string> smartStrings)
	{
		return null;
	}

	public static string GetLocalizedDamageSource(string source)
	{
		return null;
	}

	public static bool HasLocalizedString(string table, string key)
	{
		return false;
	}

	public static LocalizedString GetLocalizedStringReference(string table, string key)
	{
		return null;
	}

	public static string GetStatName(EStat stat)
	{
		return null;
	}

	public static string GetStatDesc(EStat stat)
	{
		return null;
	}

	public static string GetCharacterName(ECharacter character)
	{
		return null;
	}

	public static string GetEnemyName(EEnemy enemy)
	{
		return null;
	}

	public static string GetRarity(ERarity rarity)
	{
		return null;
	}

	public static string GetRarity(EItemRarity rarity)
	{
		return null;
	}

	public static string GetAchievementType(EAchievementType achievementType)
	{
		return null;
	}

	public static string GetLanguageName(Locale locale)
	{
		return null;
	}

	public static string GetLanguageName(string code)
	{
		return null;
	}
}
