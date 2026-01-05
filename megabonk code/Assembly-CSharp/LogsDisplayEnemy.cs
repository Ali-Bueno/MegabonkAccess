using System.Collections.Generic;
using Actors.Enemies;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LogsDisplayEnemy : MonoBehaviour
{
	public TextMeshProUGUI t_enemyName;

	public TextMeshProUGUI t_enemyDescription;

	public TextMeshProUGUI t_enemyStats;

	public TextMeshProUGUI t_enemyMaps;

	public TextMeshProUGUI t_killsCounter;

	public TextMeshProUGUI t_challengeCounter;

	public TextMeshProUGUI t_reward;

	public RawImage enemyRenderer;

	public RawImage barProgress;

	public RawImage i_rewardCoin;

	public List<RawImage> challengeProgress;

	public Color dotColorIncomplete;

	public Color dotColorComplete;

	public Material rainbow;

	public Texture unknownTexture;

	public Texture renderTexture;

	private EEnemy eEnemy;

	private void Awake()
	{
	}

	private void OnDestroy()
	{
	}

	private void OnClaimedReward()
	{
	}

	public void SetEnemy(EEnemy eEnemy)
	{
	}
}
