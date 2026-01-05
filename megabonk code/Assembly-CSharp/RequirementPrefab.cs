using Assets.Scripts.Saves___Serialization.Progression.Achievements;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RequirementPrefab : MonoBehaviour
{
	public GameObject checkMark;

	public GameObject progress;

	public TextMeshProUGUI t_requirement;

	public RawImage progressBar;

	public TextMeshProUGUI t_progress;

	public void Set(MyAchievement ach)
	{
	}

	public void Set(UnlockableBase unlockable)
	{
	}

	public void HideBar()
	{
	}
}
