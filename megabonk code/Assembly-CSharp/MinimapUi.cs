using UnityEngine;
using UnityEngine.UI;

public class MinimapUi : MonoBehaviour
{
	public Transform border;

	public Transform[] directionLetters;

	public RawImage jammer;

	private Color jammerColor;

	private Color jammerColorClear;

	private void Awake()
	{
	}

	private void OnDestroy()
	{
	}

	private void Update()
	{
	}

	private bool IsJammed()
	{
		return false;
	}

	private void OnRotationUpdated(float y)
	{
	}

	private void UpdateScale(float scale)
	{
	}

	private void OnSettingUpdated(string settingName, object oldValue, object newValue)
	{
	}
}
