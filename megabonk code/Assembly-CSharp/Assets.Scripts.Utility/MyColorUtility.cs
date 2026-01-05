using System.Collections.Generic;
using Assets.Scripts._Data.Progression;
using Assets.Scripts.Game.Combat;
using Assets.Scripts.Inventory__Items__Pickups;
using Assets.Scripts.Inventory__Items__Pickups.Items;
using Assets.Scripts.Inventory__Items__Pickups.Pickups;
using Assets.Scripts.Inventory__Items__Pickups.Stats;
using UnityEngine;

namespace Assets.Scripts.Utility;

public static class MyColorUtility
{
	public const string white = "#ffffff";

	public static string positiveColorString;

	public static string negativeColorString;

	public static Color aegisColor;

	public static Color weakAegisColor;

	public static Color bleedColor;

	public static Color tier1Color;

	public static Color tier2Color;

	public static Color tier3Color;

	private static Dictionary<EStatCategory, Color> statCategoryColors;

	private static Color hasteColor;

	private static Color magnetColor;

	private static Color shieldColor;

	private static Color timeFreezeColor;

	private static Color healthColor;

	private static Color rageColor;

	private static Color stonksColor;

	private static Color newColor;

	private static Color commonColor;

	private static Color uncommonColor;

	private static Color rareColor;

	private static Color epicColor;

	private static Color legendaryColor;

	public static Color interactOutlineColor;

	public static Color interactDisabledOutlineColor;

	public static string requirementCompletedColor;

	public static string requirementMissingColor;

	public static Color evadeColor;

	public static Color evadePhantomColor;

	public static Color critMegaColor;

	public static Color bonkColor;

	public static Color poisonColor;

	public static Color fireColor;

	public static Color executeColor;

	public static Color echoColor;

	public static Color bloodmarkColor;

	private static Color easyColor;

	private static Color mediumColor;

	private static Color hardColor;

	private static Color cookedColor;

	private static Color rankTier1Color;

	private static Color rankTier2Color;

	private static Color rankTier3Color;

	private static Color rankTier4Color;

	private static Color rankTier5Color;

	private static Color rankTier6Color;

	public static void Init()
	{
	}

	public static Color GetStatCategoryColor(EStatCategory statCategory)
	{
		return default(Color);
	}

	private static Color StringToColor(string s)
	{
		return default(Color);
	}

	public static Color PickupToColor(EPickup ePickup)
	{
		return default(Color);
	}

	public static Color RarityToColor(ERarity rarity)
	{
		return default(Color);
	}

	public static Color GetRarityColorBackground(ERarity rarity)
	{
		return default(Color);
	}

	public static Color GetRarityColorBackground(EItemRarity rarity)
	{
		return default(Color);
	}

	public static Color GetItemRarityColor(EItemRarity rarity)
	{
		return default(Color);
	}

	public static Color GetDamageEffectColor(EDamageEffect effect)
	{
		return default(Color);
	}

	public static string GetStatTextColor(bool isPositive)
	{
		return null;
	}

	public static Color GetRedToGreenGradient(float t)
	{
		return default(Color);
	}

	public static Color GetHealthBarColor(EHpBarColor color)
	{
		return default(Color);
	}

	public static Color GetTierColor(int tier)
	{
		return default(Color);
	}

	public static Color GetRankColor(int rank)
	{
		return default(Color);
	}

	public static Color DifficultyToColor(EAchievementDifficulty difficulty)
	{
		return default(Color);
	}

	public static Color GetHexToColor(string hex)
	{
		return default(Color);
	}

	public static string ColorToHex(Color color)
	{
		return null;
	}
}
