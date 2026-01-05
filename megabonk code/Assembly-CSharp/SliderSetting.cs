using System;
using Assets.Scripts.Settings___Saves.SaveFiles;
using TMPro;
using UnityEngine.UI;

public class SliderSetting : BetterSetting
{
	public TMP_InputField valueText;

	public Slider slider;

	private bool useWholeNumbers;

	public override void SetSetting(Action<string, object, CFSettings> saveAction, string settingName, object currentValue, Settings settings, CFSettings cfSettings)
	{
	}

	public void UpdateValueSlider()
	{
	}

	public void UpdateValueInputField()
	{
	}

	public override void ControllerInputDir(int dir, float multiplier)
	{
	}

	private float GetValue()
	{
		return 0f;
	}

	protected override void ShowValue()
	{
	}
}
