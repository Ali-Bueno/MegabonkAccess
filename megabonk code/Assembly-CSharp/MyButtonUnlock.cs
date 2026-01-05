using System;

public class MyButtonUnlock : MyButtonNormal
{
	public UnlockContainer unlockContainer;

	public static Action<UnlockContainer> A_Clicked;

	public override void StartHover()
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
}
