using System;
using UnityEngine;

public class MyButtonToggle : MyButton
{
	public Action<bool> A_Toggled;

	public GameObject toggleIcon;

	public void Set(bool on)
	{
	}

	public bool IsOn()
	{
		return false;
	}

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
