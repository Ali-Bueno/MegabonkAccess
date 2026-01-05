using System.Collections.Generic;
using Assets.Scripts.Steam.LeaderboardsNew;
using TMPro;
using UnityEngine;

public class LeaderboardUiNew : MonoBehaviour
{
	public GameObject lbPrefab;

	private List<LeaderboardEntryUi> leaderboardEntries;

	public GameObject buffering;

	public ButtonNavigationSelectionOnly leaderboardTypeButtons;

	private static int lastSelectedTypeIndex;

	public TextMeshProUGUI t_reset;

	private SteamLeaderboardNew leaderboard;

	private int numEntriesToShow;

	private bool isWeekly;

	private bool isGlobal;

	private void Awake()
	{
	}

	private void OnDestroy()
	{
	}

	private void TryInit()
	{
	}

	private void Start()
	{
	}

	private void OnLeaderboardReady(SteamLeaderboardNew leaderboardReady)
	{
	}

	private void Refresh()
	{
	}

	private void OnLeaderboardTypeSelected(int index)
	{
	}
}
