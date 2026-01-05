using System.Collections.Generic;
using Assets.Scripts._Data;
using Assets.Scripts._Data.Progression;
using Assets.Scripts.Saves___Serialization.Progression;
using UnityEngine;
using UnityEngine.Localization;

namespace Assets.Scripts.Tools;

public class AchievementGenerator : MonoBehaviour
{
	public LocalizedString stageBossLocalizedKey;

	public LocalizedString tierLocalizedKey;

	public LocalizedString finalBossLocalizedKey;

	public LocalizedString rankLocalizedKey;

	public LocalizedString localizedKills;

	public LocalizedString localizedLevel;

	public LocalizedString localizedFinalBoss;

	public LocalizedString localizedSpeedrun;

	public LocalizedString localizedGold;

	public DataManager dataManager;

	private static Dictionary<(ECharacter, ESkinType), string> skinAchievementNameCache;

	private string GetPath()
	{
		return null;
	}

	public static int GetSkinAchValue(ESkinType skinType)
	{
		return 0;
	}

	private string GetSkinAchValueStat(ESkinType skinType, ECharacter character)
	{
		return null;
	}

	private LocalizedString GetLocalizedDescription(ESkinType skinType)
	{
		return null;
	}

	private List<LocalizationKey> GetLocalizedKeys(ESkinType skinType, CharacterData characterData)
	{
		return null;
	}

	public static string GetSkinAchievementName(ECharacter character, ESkinType skinType)
	{
		return null;
	}

	private static EAchievementDifficulty GetSkinDifficulty(ESkinType skinType)
	{
		return default(EAchievementDifficulty);
	}
}
