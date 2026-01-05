using System;
using System.Collections.Generic;
using Assets.Scripts.Inventory__Items__Pickups.Stats;
using Assets.Scripts.Menu.Shop;
using TMPro;
using UnityEngine;

public class ChallengesUi : Window
{
	[Serializable]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9;

		public static Func<ChallengeData, bool> _003C_003E9__18_0;

		public static Comparison<ChallengeData> _003C_003E9__18_1;

		internal bool _003CRefresh_003Eb__18_0(ChallengeData a)
		{
			return false;
		}

		internal int _003CRefresh_003Eb__18_1(ChallengeData a, ChallengeData b)
		{
			return 0;
		}
	}

	public GameObject challengeButtonPrefab;

	public SelectionGroupToggleSingle challengesSelectionGroup;

	private List<SelectionGroupToggleSingleButtonChallenge> challengeButtons;

	public MapSelectionUi mapSelectionUi;

	public MyButton btn_confirm;

	private SelectionGroupToggleSingleButton hoverBtn;

	private Color completedColor;

	private Color notCompletedColor;

	public TextMeshProUGUI t_name;

	public TextMeshProUGUI t_stats;

	public TextMeshProUGUI t_description;

	public TextMeshProUGUI t_silver;

	public TextMeshProUGUI t_completed;

	public TextMeshProUGUI t_author;

	public TextMeshProUGUI t_header;

	public TextMeshProUGUI t_winCondition;

	public TextMeshProUGUI t_reward;

	public TextMeshProUGUI t_leaderboards;

	private new void Awake()
	{
	}

	private new void Start()
	{
	}

	private new void OnDestroy()
	{
	}

	private void OnChallengeHovered(SelectionGroupToggleSingleButtonChallenge btn)
	{
	}

	private void UpdateStatsText(ChallengeData challengeData)
	{
	}

	private bool IsNegativeModifier(StatModifier statModifier)
	{
		return false;
	}

	private bool IsOppositeStat(EStat stat)
	{
		return false;
	}

	private void SetEmpty()
	{
	}

	private void SetHidden(ChallengeData challengeData)
	{
	}

	private new void OnEnable()
	{
	}

	private void Refresh()
	{
	}

	public void SetNone()
	{
	}

	private void OnChallengeSelected(SelectionGroupToggleSingleButton btn)
	{
	}
}
