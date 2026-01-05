using System;
using System.Collections.Generic;
using Assets.Scripts._Data.ShopItems;
using Assets.Scripts.Saves___Serialization.Progression;
using Assets.Scripts.Saves___Serialization.Progression.Achievements;

namespace Assets.Scripts.Saves___Serialization.SaveFiles;

[Serializable]
public class ProgressionSaveFile
{
	public int gold;

	public int silver;

	public Dictionary<EShopItem, int> shopItems;

	public Dictionary<ECharacter, CharacterProgression> characterProgression;

	public HashSet<string> achievements;

	public HashSet<string> claimedAchievements;

	public HashSet<string> purchases;

	public HashSet<string> inactivated;

	public bool hasNewQuestDone;

	public MenuMeta menuMeta;

	public HashSet<string> newUnlockables;

	public HashSet<string> newShopItems;

	public HashSet<string> newMaps;

	public static Action<int> A_SilverChanged;

	public static Action<MyAchievement> A_AchievementClaimed;

	public static Action<UnlockableBase> A_UnlockablePurchased;

	public void Init()
	{
	}

	public void OnDestroy()
	{
	}

	public void CompleteAchievement(MyAchievement achievement)
	{
	}

	public bool PurchaseUnlockable(UnlockableBase unlockable)
	{
		return false;
	}

	public bool HasUnclaimedQuests()
	{
		return false;
	}

	public bool PurchaseShopItem(ShopItemData shopItemData)
	{
		return false;
	}

	public bool RefundShopItem(ShopItemData shopItemData)
	{
		return false;
	}

	public void AddSilver(int change)
	{
	}

	public void RemoveSilver(int change)
	{
	}

	public void ClaimAchievement(MyAchievement achievement)
	{
	}

	public bool HasShopItem(EShopItem eShopItem)
	{
		return false;
	}

	public int GetShopItemLevel(EShopItem eShopItem)
	{
		return 0;
	}

	private void OnGameOver()
	{
	}

	public CharacterProgression GetCharacterProgression(ECharacter character)
	{
		return null;
	}
}
