using UnityEngine;

public class InvertedSettingTroll : MonoBehaviour
{
	private BetterSetting betterSetting;

	private static int trollStage;

	private float startedTrollingTime;

	private float trollCooldownSeconds;

	private void Start()
	{
	}

	private void OnDestroy()
	{
	}

	private void OnSettingUpdated(string settingName, object oldValue, object newValue)
	{
	}

	private void Refresh()
	{
	}
}
