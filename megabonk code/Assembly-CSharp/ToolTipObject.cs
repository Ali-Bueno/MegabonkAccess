using UnityEngine;
using UnityEngine.EventSystems;

public class ToolTipObject : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler
{
	public string text;

	private float hoverTimeForShow;

	private float startedHoveringTime;

	private bool hovering;

	private bool showed;

	public void OnPointerEnter(PointerEventData eventData)
	{
	}

	private void Update()
	{
	}

	public void OnPointerExit(PointerEventData eventData)
	{
	}

	private void CloseTooltip()
	{
	}

	public void OnDisable()
	{
	}
}
