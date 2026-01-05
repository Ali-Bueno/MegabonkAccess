using Assets.Scripts.Saves___Serialization.Progression.Achievements;
using TMPro;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.UI;

public class QuickQuestContainer : MonoBehaviour
{
	public RawImage icon;

	public RawImage progress;

	public TextMeshProUGUI t_name;

	public TextMeshProUGUI t_desc;

	public TextMeshProUGUI t_progress;

	private MyAchievement currentAchievement;

	private void Awake()
	{
	}

	private void OnDestroy()
	{
	}

	private void OnLocaleChanged(Locale obj)
	{
	}

	public void SetQuest(MyAchievement ach)
	{
	}
}
