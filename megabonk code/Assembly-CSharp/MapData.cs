using Assets.Scripts._Data.MapsAndStages;
using Assets.Scripts.Audio.Music;
using Assets.Scripts.Game.MapGeneration;
using Assets.Scripts.Saves___Serialization.Progression.Achievements;
using UnityEngine;

public class MapData : UnlockableBase
{
	public StageData[] stages;

	public EMap eMap;

	public Texture icon;

	public Texture mapIconBig;

	public EMapType mapType;

	public MyAchievement achievementRequirement;

	public int unlockOrder;

	public GameObject[] shrines;

	public RandomMapObject[] randomObjectsOverride;

	public float numShrinesMultiplier;

	public float numChestsMultiplier;

	public float numShrinesPotsAndOtherMultiplier;

	public float stageDuration;

	public AudioClip ambience;

	public MusicTrack[] musicTracks;

	public MusicTrack bossTrack;

	public bool isWaterDamaging;

	public Material finalStageMaterial;

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
