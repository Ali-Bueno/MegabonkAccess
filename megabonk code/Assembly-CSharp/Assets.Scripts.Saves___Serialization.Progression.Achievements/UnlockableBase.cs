using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization;

namespace Assets.Scripts.Saves___Serialization.Progression.Achievements;

public abstract class UnlockableBase : ScriptableObject, IComparable<UnlockableBase>
{
	public bool isEnabled;

	public bool showInUnlocks;

	public bool canAlwaysToggle;

	public string author;

	public int price;

	public int sortingPriority;

	public LocalizedString localizedName;

	public LocalizedString localizedDescription;

	public List<LocalizationKey> serializedLocalizationKeys;

	public List<LocalizationKey> serializedLocalizationKeysName;

	public virtual string GetName()
	{
		return null;
	}

	public virtual string GetDescription()
	{
		return null;
	}

	private Dictionary<string, string> GetKeysDesc()
	{
		return null;
	}

	private Dictionary<string, string> GetKeysName()
	{
		return null;
	}

	public virtual int GetPrice()
	{
		return 0;
	}

	public abstract Texture GetIcon();

	public abstract MyAchievement GetUnlockRequirement();

	public abstract UnlockableBase GetUnlockableRequirement();

	public abstract string GetUnlockableTypeDisplayString();

	public abstract string GetInternalName();

	public bool CanBuy()
	{
		return false;
	}

	public virtual int CompareTo(UnlockableBase other)
	{
		return 0;
	}
}
