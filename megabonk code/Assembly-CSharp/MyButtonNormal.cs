using UnityEngine;
using UnityEngine.UI;

public class MyButtonNormal : MyButton
{
	public MaskableGraphic background;

	public Color defaultColor;

	public Color hoverColor;

	private bool colorInited;

	public override void StartHover()
	{
	}

	public override void StopHover()
	{
	}

	private void SetColor(Color c)
	{
	}

	protected override void OnClick()
	{
	}
}
