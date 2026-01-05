using System;
using System.Collections.Generic;
using Assets.Scripts._Data.Progression;
using UnityEngine;
using UnityEngine.Localization;

namespace Assets.Scripts.Saves___Serialization.Progression.Achievements;

public class MyAchievement : ScriptableObject, IComparable<MyAchievement>
{
	public LocalizedString localizedName;

	public LocalizedString localizedDescription;

	public bool isEnabled;

	public bool isHidden;

	public string internalName;

	public string statName;

	public int targetValue;

	public float targetValueFloat;

	public string targetValueString;

	public Texture icon;

	public int sortingOrder;

	public EAchievementDifficulty difficulty;

	public EAchievementType achievementType;

	public List<LocalizationKey> serializedLocalizationKeys;

	public int achIteration;

	public bool useIterations;

	private UnlockableBase _003Cunlockable_003Ek__BackingField;

	public UnlockableBase unlockable
	{
		get
		{
			return _003Cunlockable_003Ek__BackingField;
		}
		private set
		{
			_003Cunlockable_003Ek__BackingField = value;
		}
	}

	public string GetUnlockDescription()
	{
		return null;
	}

	public virtual string GetDisplayName()
	{
		return null;
	}

	private Dictionary<string, string> GetKeys()
	{
		return null;
	}

	public Texture GetIcon()
	{
		return null;
	}

	public bool IsUsingTargetValue()
	{
		return false;
	}

	public bool IsTrackingStat()
	{
		return false;
	}

	public virtual string GetUnlockRequirement()
	{
		return null;
	}

	public string GetUnlockedString()
	{
		return null;
	}

	public string GetRewardString()
	{
		return null;
	}

	public void SetUnlockable(UnlockableBase unlockable)
	{
	}

	public bool IsCompleted()
	{
		return false;
	}

	public bool IsClaimed()
	{
		return false;
	}

	public float GetProgress()
	{
		return 0f;
	}

	public int GetCurrentValue()
	{
		return 0;
	}

	public bool IsHiddenInMenus()
	{
		return false;
	}

	private void OnValidate()
	{
	}

	public bool IsVisible()
	{
		return false;
	}

	public bool IsUnlocked()
	{
		return false;
	}

	public int GetSilverReward()
	{
		return 0;
	}

	public virtual int CompareTo(MyAchievement other)
	{
		return 0;
	}
}
