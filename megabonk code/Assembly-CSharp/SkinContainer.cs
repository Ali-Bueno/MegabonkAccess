using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SkinContainer : MyButton, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler
{
	public RawImage skinIcon;

	public GameObject locked;

	public GameObject notSelectedOverlay;

	public GameObject purchaseOverlay;

	public TextMeshProUGUI t_price;

	public SkinData skin;

	public static Action<SkinContainer> A_Hover;

	public static Action<SkinContainer> A_HoverMouse;

	public static Action<SkinContainer> A_HoverMouseExit;

	public static Action<SkinData> A_Purchased;

	public void SetSkin(SkinData skin)
	{
	}

	public void SetSelected(bool isSelected)
	{
	}

	public override void StartHover()
	{
	}

	private bool IsLocked()
	{
		return false;
	}

	private bool NeedPurchase()
	{
		return false;
	}

	public ECharacter GetCharacter()
	{
		return default(ECharacter);
	}

	public override void StopHover()
	{
	}

	private void OnDisable()
	{
	}

	protected override void OnClick()
	{
	}

	private void TooltipHoverEnter()
	{
	}

	private void TooltipHoverExit()
	{
	}

	public void OnPointerEnter(PointerEventData eventData)
	{
	}

	public void OnPointerExit(PointerEventData eventData)
	{
	}

	private void _003COnClick_003Eb__18_0()
	{
	}
}
