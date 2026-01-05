using Assets.Scripts._Data.Progression;
using Assets.Scripts.Saves___Serialization.Progression.Achievements;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MyButtonTabsQuest : MyButtonTabs
{
	public TextMeshProUGUI t_progress;

	public TextMeshProUGUI t_unlcaimed;

	public RawImage i_progressBar;

	public GameObject unclaimedUi;

	private EAchievementType achievementType;

	private int unclaimed;

	private new void Awake()
	{
	}

	private void OnDestroy()
	{
	}

	public void Set(EAchievementType achievementType)
	{
	}

	private void OnClaimed(MyAchievement achievement)
	{
	}
}
