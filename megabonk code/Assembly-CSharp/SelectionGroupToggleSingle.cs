using System;
using System.Collections.Generic;
using UnityEngine;

public class SelectionGroupToggleSingle : MonoBehaviour
{
	private sealed class _003C_003Ec__DisplayClass14_0
	{
		public SelectionGroupToggleSingleButton b;

		public SelectionGroupToggleSingle _003C_003E4__this;

		internal void _003CFindButtons_003Eb__0()
		{
		}
	}

	public Action<SelectionGroupToggleSingleButton> A_ButtonSelected;

	public int startIndex;

	public bool canSelectMultiple;

	public bool canSelectNothing;

	public bool selectDefaultOnAwake;

	private SelectionGroupToggleSingleButton lastButton;

	private List<SelectionGroupToggleSingleButton> buttons;

	private List<SelectionGroupToggleSingleButton> _003CselectedButtons_003Ek__BackingField;

	private HashSet<SelectionGroupToggleSingleButton> registeredButtons;

	public List<SelectionGroupToggleSingleButton> selectedButtons
	{
		get
		{
			return _003CselectedButtons_003Ek__BackingField;
		}
		private set
		{
			_003CselectedButtons_003Ek__BackingField = value;
		}
	}

	private void Awake()
	{
	}

	private void OnTransformChildrenChanged()
	{
	}

	public void FindButtons()
	{
	}

	private void SelectButton(SelectionGroupToggleSingleButton btn)
	{
	}

	private void DeselectButton(SelectionGroupToggleSingleButton btn)
	{
	}

	public void SetNone()
	{
	}

	private void OnButtonSelect(SelectionGroupToggleSingleButton newBtn)
	{
	}

	public SelectionGroupToggleSingleButton GetButton(int index)
	{
		return null;
	}

	public void ForceSelect(int index)
	{
	}

	public int GetSelectedIndex()
	{
		return 0;
	}
}
