using System;
using TMPro;
using UnityEngine;

namespace Assets.Scripts.UI.Mouse;

public class ToolTipsText : MonoBehaviour
{
	public delegate void HoverOnLinkEvent(string keyword, Vector3 mousePos);

	public delegate void CloseTooltipEvent();

	private TMP_Text tmpTextBox;

	private Canvas canvas;

	private UnityEngine.Camera camera;

	private RectTransform textBoxRectTransform;

	private int currentlyActiveLinkedElement;

	public static Action<string, Vector2> A_OpenTooltip;

	public static Action<string> A_CloseTooltip;

	private float readyTime;

	private Vector3 lastPos;

	private bool hasVisibleMouse;

	public static event HoverOnLinkEvent OnHoverOnLinkEvent
	{
		add
		{
		}
		remove
		{
		}
	}

	public static event CloseTooltipEvent OnCloseTooltipEvent
	{
		add
		{
		}
		remove
		{
		}
	}

	private void Awake()
	{
	}

	private void OnEnable()
	{
	}

	private void Update()
	{
	}

	private void CheckForLinkAtMousePosition()
	{
	}

	private Vector3 GetLinkPosition(TMP_LinkInfo linkInfo, float verticalOffset = 10f)
	{
		return default(Vector3);
	}

	private void OnDisable()
	{
	}
}
