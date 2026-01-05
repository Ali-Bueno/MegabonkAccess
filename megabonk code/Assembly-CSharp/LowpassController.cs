using Assets.Scripts.Inventory__Items__Pickups.Stats;
using UnityEngine;
using UnityEngine.Audio;

public class LowpassController : MonoBehaviour
{
	public AudioLowPassFilter filter;

	private float defaultCutoff;

	private float desiredCutoff;

	private float lowCutoff;

	private bool isTimeFreeze;

	private bool isUnderwater;

	public AudioMixer audioMixer;

	private float lowpassFrequency;

	private void Awake()
	{
	}

	private void OnDestroy()
	{
	}

	private void OnWaterFilterEnter(Water filter)
	{
	}

	private void OnWaterFilterExit(Water filter)
	{
	}

	private void OnLavaEnter()
	{
	}

	private void OnLavaExit()
	{
	}

	private void OnStatusEffectAdded(EStatusEffect eStatusEffect, bool newEffect)
	{
	}

	private void OnStatusEffectRemoved(EStatusEffect eStatusEffect)
	{
	}

	private void RefreshTimeFreeze()
	{
	}

	private float GetDesiredCutoff()
	{
		return 0f;
	}

	private void Update()
	{
	}
}
