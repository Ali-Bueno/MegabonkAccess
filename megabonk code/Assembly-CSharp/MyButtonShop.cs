using System;

public class MyButtonShop : MyButtonNormal
{
	public ShopContainer shopContainer;

	public static Action<ShopContainer> A_Clicked;

	public static Action<ShopContainer> A_Select;

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
