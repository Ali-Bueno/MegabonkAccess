using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class OutlineButton : MonoBehaviour, ISelectHandler, IEventSystemHandler, IDeselectHandler
{
	public RawImage outline;

	public void OnSelect(BaseEventData eventData)
	{
	}

	public void OnDeselect(BaseEventData eventData)
	{
	}
}
