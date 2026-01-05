using UnityEngine;
using UnityEngine.UI;

public class MyButtonTabs : MyButton
{
	public MaskableGraphic background;

	public MaskableGraphic text;

	public GameObject associatedContent;

	public Color selectedColor;

	public Color defaultColor;

	private bool selected;

	private void Start()
	{
	}

	public void Select()
	{
	}

	public void Deselect(MyButtonTabs newButton)
	{
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
