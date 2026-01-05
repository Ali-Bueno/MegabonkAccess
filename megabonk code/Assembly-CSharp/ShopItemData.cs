using Assets.Scripts._Data.ShopItems;
using Assets.Scripts.Saves___Serialization.Progression.Achievements;
using UnityEngine;

public class ShopItemData : UnlockableBase
{
	public EShopItem eShopItem;

	public Texture icon;

	public int maxLevel;

	public MyAchievement unlockRequirement;

	public bool canRefund;

	public float value;

	public int sortingOrder;

	public int linearIncrease;

	public float exponentialMultiplier;

	public override Texture GetIcon()
	{
		return null;
	}

	public override MyAchievement GetUnlockRequirement()
	{
		return null;
	}

	public override UnlockableBase GetUnlockableRequirement()
	{
		return null;
	}

	public override string GetUnlockableTypeDisplayString()
	{
		return null;
	}

	public override string GetInternalName()
	{
		return null;
	}

	private int GetLevelPrice(int level)
	{
		return 0;
	}

	public override int GetPrice()
	{
		return 0;
	}

	public int GetRefundPrice()
	{
		return 0;
	}

	public int GetLevel()
	{
		return 0;
	}

	public bool IsMaxLevel()
	{
		return false;
	}

	public new bool CanBuy()
	{
		return false;
	}

	public bool CanRefund()
	{
		return false;
	}

	public int GetMaxLevel()
	{
		return 0;
	}

	public override int CompareTo(UnlockableBase other)
	{
		return 0;
	}
}
