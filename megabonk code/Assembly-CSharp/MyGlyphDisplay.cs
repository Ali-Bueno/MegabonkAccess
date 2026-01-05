using Rewired;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MyGlyphDisplay : MonoBehaviour
{
	public Image i_glyph;

	public TextMeshProUGUI t_text;

	private RectTransform rectTransform;

	public GameObject hoverOverlay;

	public bool autoHeight;

	public bool autoWidth;

	private ActionElementMap elementMap;

	public void Hover(bool isHovering)
	{
	}

	public void SetAction(string action)
	{
	}

	public void Set(ActionElementMap elementMap)
	{
	}

	private void RefreshGlyphSize()
	{
	}
}
