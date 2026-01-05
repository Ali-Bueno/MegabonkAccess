using TMPro;
using UnityEngine;

public class DebugUI : MonoBehaviour
{
	public TextMeshProUGUI t_fps;

	public TextMeshProUGUI t_speed;

	public TextMeshProUGUI t_ram;

	private float fpsTimer;

	private int frameCount;

	private float fpsUpdateInterval;

	private float[] speedSamples;

	private int speedSampleIndex;

	private float sampleSpeedInterval;

	private float sampleRamInterval;

	private void Awake()
	{
	}

	private void OnDestroy()
	{
	}

	private void OnSettingUpdated(string setting, object oldValue, object newValue)
	{
	}

	private void Update()
	{
	}

	private void UpdateFps()
	{
	}

	private void SampleSpeed()
	{
	}

	private void SampleRam()
	{
	}
}
