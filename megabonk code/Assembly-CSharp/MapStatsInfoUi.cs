using System.Collections.Generic;
using Assets.Scripts._Data.MapsAndStages;
using Assets.Scripts.Game.Other;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MapStatsInfoUi : MonoBehaviour
{
	public TextMeshProUGUI t_mapName;

	public TextMeshProUGUI t_mapRuns;

	public TextMeshProUGUI t_tier;

	public TextMeshProUGUI t_highscore;

	public TextMeshProUGUI t_fastestTime;

	public RawImage characterIconPrefab;

	public RawImage mapIcon;

	private List<RawImage> characterIcons;

	private EMap currentMap;

	private int currentTier;

	private void Awake()
	{
	}

	private void OnDestroy()
	{
	}

	private void OnRunConfigChanged(RunConfig runConfig)
	{
	}

	public void SetConfig(RunConfig runConfig)
	{
	}
}
