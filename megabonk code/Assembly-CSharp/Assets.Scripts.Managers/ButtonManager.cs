using System;

namespace Assets.Scripts.Managers;

public class ButtonManager
{
	private static MyButton selectedButton2;

	public static Action<MyButton> A_ButtonHover;

	public static bool enabled;

	public static void Refresh()
	{
	}

	public static void SetFirstButton(MyButton button)
	{
	}

	public static void ForceHoverButton(MyButton btn)
	{
	}

	public static void StartedHoveringButton(MyButton button)
	{
	}

	public static void SetNull()
	{
	}

	public static MyButton GetCurrentButton()
	{
		return null;
	}
}
