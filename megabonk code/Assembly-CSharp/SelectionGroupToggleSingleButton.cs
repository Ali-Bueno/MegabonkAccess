using UnityEngine;

public class SelectionGroupToggleSingleButton : MyButton
{
	public GameObject[] enableOnSelect;

	public GameObject unselectableOverlay;

	private bool _003CcanSelect_003Ek__BackingField;

	private bool _003CisSelected_003Ek__BackingField;

	public bool canSelect
	{
		get
		{
			return _003CcanSelect_003Ek__BackingField;
		}
		set
		{
			_003CcanSelect_003Ek__BackingField = value;
		}
	}

	public bool isSelected
	{
		get
		{
			return _003CisSelected_003Ek__BackingField;
		}
		private set
		{
			_003CisSelected_003Ek__BackingField = value;
		}
	}

	public void Select()
	{
	}

	public void Deselect()
	{
	}

	public override void StartHover()
	{
	}

	public override void StopHover()
	{
	}

	protected override void OnClick()
	{
	}

	public void CanSelect(bool b)
	{
	}
}
