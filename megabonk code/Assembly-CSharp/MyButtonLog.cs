using System;
using Actors.Enemies;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MyButtonLog : MyButton
{
	public TextMeshProUGUI t_enemyName;

	public EEnemy eEnemy;

	public static Action<EEnemy> A_EnemySelected;

	public static Action A_ClaimedReward;

	public GameObject claimAlert;

	public GameObject greenLoggedIcon;

	public MaskableGraphic background;

	public Color defaultColor;

	public Color hoverColor;

	public override void StartHover()
	{
	}

	public override void StopHover()
	{
	}

	public void SetEnemy(EEnemy enemy, int enemyIndex)
	{
	}

	public void Claim()
	{
	}

	protected override void OnClick()
	{
	}
}
