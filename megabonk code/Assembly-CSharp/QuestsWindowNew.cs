using System.Collections.Generic;
using Assets.Scripts._Data.Progression;
using Assets.Scripts.Saves___Serialization.Progression.Achievements;
using TMPro;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.UI;

public class QuestsWindowNew : Window
{
	private sealed class _003C_003Ec__DisplayClass25_0
	{
		public EAchievementType type;

		internal bool _003CCreateTabs_003Eb__1(MyAchievement a)
		{
			return false;
		}
	}

	public Button backBtn;

	public GameObject questPrefab;

	public GameObject tabPrefab;

	public ButtonNavigationSelectionOnly tabNavigation;

	public TabVerticalNavigation tabVertNavigation;

	public LocalizedString localizedGeneral;

	public LocalizedString localizedCharacters;

	public LocalizedString localizedWeapons;

	public LocalizedString localizedChallenges;

	public LocalizedString localizedItems;

	public LocalizedString localizedTomes;

	public LocalizedString localizedSkins;

	public LocalizedString localizedHats;

	private List<MyButtonQuest> questButtons;

	private EAchievementType achievementTab;

	public RawImage progressBar;

	public TextMeshProUGUI t_totalProgress;

	public MyButtonToggle toggleHideCompleted;

	private List<EAchievementType> tabsEnums;

	private new void Awake()
	{
	}

	private new void Start()
	{
	}

	private new void OnEnable()
	{
	}

	private new void OnDestroy()
	{
	}

	private void OnToggle(bool on)
	{
	}

	private void Refresh()
	{
	}

	private void CreateTabs()
	{
	}

	private void OnTabSelected(int index)
	{
	}

	private void OnQuestButtonHover(MyButtonQuest btn)
	{
	}

	private int GetAchievementTypeIndex(int index)
	{
		return 0;
	}

	private LocalizedString GetTabLocalizedString(EAchievementType achType)
	{
		return null;
	}

	private bool _003CRefresh_003Eb__23_0(MyAchievement a)
	{
		return false;
	}

	private int _003CRefresh_003Eb__23_1(MyAchievement a, MyAchievement b)
	{
		return 0;
	}

	private int _003CCreateTabs_003Eb__25_0(EAchievementType a, EAchievementType b)
	{
		return 0;
	}
}
