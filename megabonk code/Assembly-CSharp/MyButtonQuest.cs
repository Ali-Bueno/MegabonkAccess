using System;
using Assets.Scripts.Saves___Serialization.Progression.Achievements;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MyButtonQuest : MyButton
{
	public TextMeshProUGUI t_description;

	public TextMeshProUGUI t_reward;

	public TextMeshProUGUI t_progress;

	public TextMeshProUGUI t_claimAmount;

	public RawImage i_icon;

	public RawImage i_progressBar;

	public RawImage i_outline;

	public RawImage i_background;

	public MaskableGraphic i_colorBg;

	public MaskableGraphic i_colorOutline;

	public MaskableGraphic i_completeCheck;

	public GameObject claimOverlay;

	public GameObject incompleteOverlay;

	public GameObject rewardContainer;

	public GameObject hoveringOverlay;

	private MyAchievement _003Cachievement_003Ek__BackingField;

	public Color bgColorDefault;

	public Color bgColorCompleted;

	public static Action<MyButtonQuest> A_Select;

	public static Action<MyButtonQuest> A_Hover;

	public MyAchievement achievement
	{
		get
		{
			return _003Cachievement_003Ek__BackingField;
		}
		private set
		{
			_003Cachievement_003Ek__BackingField = value;
		}
	}

	public void Set(MyAchievement achievement)
	{
	}

	public override void StartHover()
	{
	}

	public override void StopHover()
	{
	}

	protected override void OnClick()
	{
	}

	public void TryClaimButton()
	{
	}

	private void Claim()
	{
	}
}
