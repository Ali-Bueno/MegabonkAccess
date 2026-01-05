using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Game.Other.Water;

public class WaterFilterUI : MonoBehaviour
{
	public CanvasGroup group;

	public RawImage i_color;

	private bool usingFilter;

	private float fadeSeconds;

	private void Awake()
	{
	}

	private void OnDestroy()
	{
	}

	private void OnFilterEnter(global::Water filter)
	{
	}

	private void OnFilterExit(global::Water filter)
	{
	}

	private void Update()
	{
	}
}
