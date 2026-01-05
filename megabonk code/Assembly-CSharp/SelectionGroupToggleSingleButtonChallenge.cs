using System;
using TMPro;
using UnityEngine;

public class SelectionGroupToggleSingleButtonChallenge : SelectionGroupToggleSingleButton
{
	public static Action<SelectionGroupToggleSingleButtonChallenge> A_ChallengeHovered;

	public TextMeshProUGUI t_name;

	public TextMeshProUGUI t_silver;

	public GameObject completedIcon;

	public GameObject completedOverlay;

	private bool _003CisShowing_003Ek__BackingField;

	private ChallengeData _003CchallengeData_003Ek__BackingField;

	public bool isShowing
	{
		get
		{
			return _003CisShowing_003Ek__BackingField;
		}
		private set
		{
			_003CisShowing_003Ek__BackingField = value;
		}
	}

	public ChallengeData challengeData
	{
		get
		{
			return _003CchallengeData_003Ek__BackingField;
		}
		private set
		{
			_003CchallengeData_003Ek__BackingField = value;
		}
	}

	public void Set(ChallengeData challengeData)
	{
	}

	private void SetVisible()
	{
	}

	private void SetHidden()
	{
	}

	public override void StartHover()
	{
	}

	public override void StopHover()
	{
	}
}
