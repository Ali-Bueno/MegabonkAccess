using System;
using UnityEngine;
using UnityEngine.UI;

public class ButtonNavigationSelectionOnly : MonoBehaviour
{
	private sealed class _003C_003Ec__DisplayClass7_0
	{
		public int index;

		public ButtonNavigationSelectionOnly _003C_003E4__this;

		internal void _003CInit_003Eb__0()
		{
		}
	}

	private MyButtonTabs[] buttons;

	public int current;

	public float cooldown;

	private float lastPressedTime;

	public Action<int> A_ButtonSelected;

	public int startButton;

	private void Start()
	{
	}

	private void Init()
	{
	}

	private void ReInit()
	{
	}

	public void ButtonPressed(int index, bool force = false)
	{
	}

	private bool CanPress()
	{
		return false;
	}

	public Button GetSelectedButton()
	{
		return null;
	}

	public int GetNumButtons()
	{
		return 0;
	}
}
