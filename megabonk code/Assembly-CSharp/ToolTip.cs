using TMPro;
using UnityEngine;

public class ToolTip : MonoBehaviour
{
	public TextMeshProUGUI t_tip;

	public CanvasGroup group;

	public Canvas parentCanvas;

	public RectTransform backDrop;

	public static ToolTip Instance;

	private bool visible;

	private bool useMouse;

	private float x;

	private float speed;

	private float offset;

	private void Awake()
	{
	}

	private void OnDestroy()
	{
	}

	public void SetTip(string text)
	{
	}

	public void SetTip(string text, RectTransform uiElement)
	{
	}

	public void HideTip()
	{
	}

	private void Update()
	{
	}
}
