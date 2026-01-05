using UnityEngine;
using UnityEngine.UI;

public class AutoScrollRect : MonoBehaviour
{
	public ScrollRect scrollRect;

	public RectTransform viewport;

	public RectTransform content;

	public GameObject lastSelected;

	private void Update()
	{
	}

	private void EnsureVisible(RectTransform target, float padding = 20f)
	{
	}

	public void ManualRefresh()
	{
	}
}
