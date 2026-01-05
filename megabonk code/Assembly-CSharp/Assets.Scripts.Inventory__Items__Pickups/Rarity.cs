using Assets.Scripts.Inventory__Items__Pickups.Items;

namespace Assets.Scripts.Inventory__Items__Pickups;

public static class Rarity
{
	public static ERarity GetUpgradeOfferRarity(float luck)
	{
		return default(ERarity);
	}

	public static ERarity GetEncounterOfferRarity(float luck)
	{
		return default(ERarity);
	}

	public static EItemRarity GetItemRarity(float luck)
	{
		return default(EItemRarity);
	}

	public static EItemRarity GetShadyGuyRarity(float luck, float[] customWeights = null)
	{
		return default(EItemRarity);
	}

	public static void CalculateRarityWeights(float[] rarityWeights, float luck)
	{
	}

	public static float GetMultiplier(ERarity rarity)
	{
		return 0f;
	}
}
