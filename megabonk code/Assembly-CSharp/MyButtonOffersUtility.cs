using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MyButtonOffersUtility : MyButton
{
	public TextMeshProUGUI t_amount;

	public TextMeshProUGUI t_price;

	public GameObject disbaledOverlay;

	public MaskableGraphic background;

	public Color defaultColor;

	public Color hoverColor;

	private bool colorInited;

	private bool cantAfford;

	private float refreshedAtTime;

	private void SetColor(Color c)
	{
	}

	public void Enable()
	{
	}

	public void Disable()
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

	public void SetAmount(int n, int price)
	{
	}
}
