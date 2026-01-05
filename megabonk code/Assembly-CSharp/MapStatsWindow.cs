using System.Collections.Generic;
using Assets.Scripts.Game.Other;
using TMPro;
using UnityEngine;

public class MapStatsWindow : MonoBehaviour
{
	public TextMeshProUGUI t_mapSpecs;

	public SelectionGroupToggleSingle tierSelection;

	public SelectionGroupToggleSingle challengeSelection;

	public SelectionGroupToggleSingleButtonTier[] tierButtons;

	public MapSelectionUi mapSelectionUi;

	public MyButton btnChallenges;

	public GameObject newChallengesIndicator;

	private Dictionary<int, float> tierSilverMultipliers;

	private void Start()
	{
	}

	private void Awake()
	{
	}

	private void OnDestroy()
	{
	}

	private void OnInfoChanged(SelectionGroupToggleSingleButton btn)
	{
	}

	private void OnRunConfigChanged(RunConfig runConfig)
	{
	}

	private void OnMapSelected(SelectionGroupToggleSingleButton mapButton, MapData mapData)
	{
	}

	public void RefreshTiers()
	{
	}

	private void Refresh()
	{
	}
}
