using System;
using System.Collections.Generic;
using Assets.Scripts.Settings___Saves.SaveFiles;
using TMPro;
using UnityEngine;
using UnityEngine.Localization;

public abstract class BetterSetting : MonoBehaviour
{
	protected int value;

	protected int settingType;

	protected string[] options;

	public TextMeshProUGUI settingName;

	private string description;

	private Settings settings;

	public GameObject disabledOverlay;

	public TextMeshProUGUI t_disabledText;

	private bool hasSubscribed;

	private RectTransform rectTransform;

	private bool subscribed;

	private Action<string, object, CFSettings> saveAction;

	protected string _settingName;

	protected object _settingValue;

	private CFSettings cfSettings;

	private HashSet<string> hiddenSettings;

	private HashSet<string> advancedSettings;

	private bool mouseOver;

	protected void Awake()
	{
	}

	private void TrySubscribe()
	{
	}

	private void Start()
	{
	}

	protected void OnDestroy()
	{
	}

	private void OnSettingUpdated(string settingName, object oldValue, object newValue)
	{
	}

	private void Update()
	{
	}

	public virtual void SetSetting(Action<string, object, CFSettings> saveAction, string settingName, object currentValue, Settings settings, CFSettings cfSettings)
	{
	}

	private void CheckVisibility()
	{
	}

	private void OnLocaleChanged(Locale locale)
	{
	}

	private void RefreshLanguage()
	{
	}

	public void UpdateValue()
	{
	}

	public abstract void ControllerInputDir(int dir, float multiplier);

	protected void SaveValue()
	{
	}

	protected virtual void OnSetting()
	{
	}

	protected abstract void ShowValue();

	private void OnMouseEnter()
	{
	}

	private void CustomPointerHandler()
	{
	}

	private void CheckExtraScripts()
	{
	}

	public void Disable(string disableText)
	{
	}

	public void Enable()
	{
	}

	public bool IsDisabled()
	{
		return false;
	}
}
