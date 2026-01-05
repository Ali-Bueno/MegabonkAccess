using Assets.Scripts.Objects;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.UI.HUD;

public class ColorFilterUI : MonoBehaviour
{
	public CanvasGroup group;

	public RawImage i_color;

	private bool usingFilter;

	private float fadeSeconds;

	private float interpValue;

	public void ResetFilter()
	{
	}

	private void Awake()
	{
	}

	private void OnDestroy()
	{
	}

	private void OnFilterEnter(ColorFilter filter)
	{
	}

	private void OnFilterExit(ColorFilter filter)
	{
	}

	private void Update()
	{
	}
}
