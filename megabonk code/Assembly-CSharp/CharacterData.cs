using System.Collections.Generic;
using Assets.Scripts.Audio.Music;
using Assets.Scripts.Inventory__Items__Pickups.Stats;
using Assets.Scripts.Saves___Serialization.Progression.Achievements;
using UnityEngine;

public class CharacterData : UnlockableBase
{
	public ECharacter eCharacter;

	public Texture icon;

	public List<StatModifier> statModifiers;

	public GameObject prefab;

	public AudioClip[] audioFootsteps;

	public MusicTrack themeSong;

	public WeaponData weapon;

	public PassiveData passive;

	public float colliderHeight;

	public float colliderWidth;

	public Dictionary<EStatCategory, float> categoryScores;

	public Dictionary<EStatCategory, float> categoryRatios;

	public List<StatCategoryRatio> StatCategoryRatios;

	public MyAchievement achievementRequirement;

	public int numQuestsRequiredForVisibilityInCharacterSelection;

	public void Init()
	{
	}

	public override Texture GetIcon()
	{
		return null;
	}

	public override MyAchievement GetUnlockRequirement()
	{
		return null;
	}

	public bool IsBlackedOutInCharacterSelectionScreen()
	{
		return false;
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

	public int GetDisplayRank()
	{
		return 0;
	}
}
