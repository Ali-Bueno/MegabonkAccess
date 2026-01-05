using UnityEngine;

public class LanguageSettingButton : MonoBehaviour
{
	public BetterSetting betterSetting;

	private void Awake()
	{
	}

	private void OnDestroy()
	{
	}

	private void OnSettingUpdated(string settingName, object oldValue, object newValue)
	{
	}
}
