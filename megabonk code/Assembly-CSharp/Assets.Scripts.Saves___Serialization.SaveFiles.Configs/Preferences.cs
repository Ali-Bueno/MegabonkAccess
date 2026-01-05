using System.Collections.Generic;
using Assets.Scripts._Data.Hats;

namespace Assets.Scripts.Saves___Serialization.SaveFiles.Configs;

public class Preferences
{
	public Dictionary<ECharacter, int> characterSkins;

	public Dictionary<ECharacter, EHat> characterHats;

	public ECharacter selectedCharacter;

	public bool hasShownUnlocks;

	public bool hasShownQuests;

	public bool hasShownShop;

	public bool hasShownLeaderboards;

	public bool hasShownQuickQuests;

	public bool hasShownWarningForChestSkip;

	public void Init()
	{
	}

	public void SetCharacterHat(ECharacter character, EHat hat)
	{
	}

	public EHat GetCharacterHat(ECharacter character)
	{
		return default(EHat);
	}
}
