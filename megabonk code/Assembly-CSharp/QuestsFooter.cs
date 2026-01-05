using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class QuestsFooter : MonoBehaviour
{
	public UnlockContainer achievementContainer;

	public TextMeshProUGUI t_description;

	public TextMeshProUGUI t_unlock;

	public TextMeshProUGUI t_reward;

	public GameObject checkMark;

	public RawImage i_progressBar;

	public TextMeshProUGUI t_progress;

	private void Awake()
	{
	}

	private void OnDestroy()
	{
	}

	private void SetEmpty()
	{
	}

	private void OnAchievementHover(MyButtonQuest questButton)
	{
	}
}
