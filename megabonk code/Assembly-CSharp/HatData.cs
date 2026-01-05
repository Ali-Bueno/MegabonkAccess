using System.Collections.Generic;
using Assets.Scripts._Data.Hats;
using Assets.Scripts.Saves___Serialization.Progression.Achievements;
using UnityEngine;

public class HatData : UnlockableBase
{
	public EHat eHat;

	public Texture icon;

	public MyAchievement unlockRequirement;

	public Mesh mesh;

	public Material material;

	public List<HatOrientation> orientations;

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
}
