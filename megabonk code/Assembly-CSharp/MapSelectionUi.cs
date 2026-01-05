using System;
using Assets.Scripts.Game.Other;
using UnityEngine;

public class MapSelectionUi : Window
{
	public SelectionGroupToggleSingle mapSelectionGroup;

	public SelectionGroupToggleSingle tierSelectionGroup;

	public ChallengesUi challengesUi;

	private bool firstSelection;

	private SelectionGroupToggleSingleButton selectedBtn;

	private SelectionGroupToggleSingleButton mapBtn;

	public MapStatsWindow mapStatsWindow;

	public MapSelectionWindow mapButtonsWindow;

	public RunConfig runConfig;

	public MyButton btnConfirm;

	public GameObject jukebox;

	public static Action<RunConfig> A_RunConfigChanged;

	public static Action<SelectionGroupToggleSingleButton, MapData> A_MapSelected;

	public MapData defaultMapData;

	private bool isSelectingMap;

	private bool newMapSelected;

	public static bool isTestFight;

	public static Action A_MapSelectionEnabled;

	private new void Awake()
	{
	}

	private new void OnDestroy()
	{
	}

	public void Init()
	{
	}

	private void OnMapSelected(SelectionGroupToggleSingleButton btn)
	{
	}

	private void OnTierSelected(SelectionGroupToggleSingleButton btn)
	{
	}

	public void SetChallenge(ChallengeData challengeData)
	{
	}

	public void StartMap()
	{
	}

	public void StartBossFightTest()
	{
	}

	private new void OnDisable()
	{
	}

	private new void OnEnable()
	{
	}
}
