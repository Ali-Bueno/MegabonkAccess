using System;
using UnityEngine;
using UnityEngine.UI;

public class MyButtonSetting : MyButton
{
	public BetterSetting betterSetting;

	public MaskableGraphic background;

	public Color defaultColor;

	public Color hoverColor;

	public Action A_StartHover;

	public Action A_StopHover;

	private float nextUpdateTime;

	private int holdingDir;

	private float cooldownTimer;

	private float multiplier;

	private float canUseHorizontalTime;

	public override void StartHover()
	{
	}

	private void ResetCanUseHorizontalTime()
	{
	}

	public override void StopHover()
	{
	}

	protected override void OnClick()
	{
	}

	private new void Update()
	{
	}

	private void ResetCooldown()
	{
	}
}
