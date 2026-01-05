using System;
using System.Collections.Generic;
using Assets.Scripts.Settings___Saves.SaveFiles;
using Assets.Scripts.UI.Menu.Windows;
using UnityEngine;

public class Settings : MonoBehaviour
{
	private sealed class _003C_003Ec__DisplayClass29_0
	{
		public int index;

		public Predicate<SettingHeader> _003C_003E9__0;

		internal bool _003CCreateGenericSettings_003Eb__0(SettingHeader h)
		{
			return false;
		}
	}

	public GameObject enumPrefab;

	public GameObject sliderPrefab;

	public GameObject resolutionPrefab;

	public GameObject controlPrefab;

	public GameObject controlPrefabNew;

	public GameObject controllerDisplayPrefab;

	public GameObject headerPrefab;

	public GameObject languagePrefab;

	public Transform videoContent;

	public Transform gameContent;

	public Transform audioContent;

	public Transform controlContent;

	public Transform visualsContent;

	public List<BetterSetting> settings;

	public GameObject resolutionWindow;

	public Window settingsWindow;

	public GameObject btn_resetSettings;

	public GameObject b_resetControls;

	public TabsExplicitNavigation gameContentNav;

	public TabsExplicitNavigation settingsNav;

	public static Action A_ResetRewiredControls;

	public static Settings Instance;

	private void Awake()
	{
	}

	private void Start()
	{
	}

	private void OnEnable()
	{
	}

	private void Rebuild()
	{
	}

	private void OnDisable()
	{
	}

	private void OnDestroy()
	{
	}

	private void UpdateSettings()
	{
	}

	private void CreateGenericSettings(Action<string, object, CFSettings> saveAction, Transform contentParent, CFSettings cfSettings)
	{
	}

	private GameObject GetSettingPrefab(SettingType settingType)
	{
		return null;
	}

	public void TryResetSaveFile()
	{
	}

	public void ResetControls()
	{
	}

	private void ResetSaveFile()
	{
	}

	public void RefreshSettings()
	{
	}

	private void OnResButtonClicked()
	{
	}

	private void OnResChanged(int resIndex)
	{
	}
}
