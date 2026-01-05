using System;
using UnityEngine;
using UnityEngine.UI;

public class MyButtonSettingRes : MyButton
{
	public MaskableGraphic background;

	public Color defaultColor;

	public Color hoverColor;

	public static Action A_Clicked;

	public override void StartHover()
	{
	}

	public override void StopHover()
	{
	}

	protected override void OnClick()
	{
	}
}
