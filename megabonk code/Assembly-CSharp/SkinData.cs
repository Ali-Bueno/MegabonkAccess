using System;
using Assets.Scripts._Data;
using Assets.Scripts.Saves___Serialization.Progression.Achievements;
using UnityEngine;

public class SkinData : UnlockableBase, IComparable<SkinData>
{
	public Texture icon;

	public Material[] materials;

	public ECharacter character;

	public MyAchievement unlockRequirement;

	public ESkinType skinType;

	public override string GetName()
	{
		return null;
	}

	public override string GetDescription()
	{
		return null;
	}

	public override int GetPrice()
	{
		return 0;
	}

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

	public int CompareTo(SkinData other)
	{
		return 0;
	}
}
