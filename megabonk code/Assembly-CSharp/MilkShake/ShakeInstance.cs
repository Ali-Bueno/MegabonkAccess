using System;
using UnityEngine;

namespace MilkShake;

[Serializable]
public class ShakeInstance
{
	public ShakeParameters ShakeParameters;

	public float StrengthScale;

	public float RoughnessScale;

	public bool RemoveWhenStopped;

	private ShakeState _003CState_003Ek__BackingField;

	private bool _003CIsPaused_003Ek__BackingField;

	private int baseSeed;

	private float seed1;

	private float seed2;

	private float seed3;

	private float noiseTimer;

	private float fadeTimer;

	private float fadeInTime;

	private float fadeOutTime;

	private float pauseTimer;

	private float pauseFadeTime;

	private int lastUpdatedFrame;

	public ShakeState State
	{
		get
		{
			return _003CState_003Ek__BackingField;
		}
		private set
		{
			_003CState_003Ek__BackingField = value;
		}
	}

	public bool IsPaused
	{
		get
		{
			return _003CIsPaused_003Ek__BackingField;
		}
		private set
		{
			_003CIsPaused_003Ek__BackingField = value;
		}
	}

	public bool IsFinished => false;

	public float CurrentStrength => 0f;

	public float CurrentRoughness => 0f;

	public ShakeInstance(int? seed = null)
	{
	}

	public ShakeInstance(IShakeParameters shakeData, int? seed = null)
	{
	}

	public ShakeResult UpdateShake(float deltaTime)
	{
		return default(ShakeResult);
	}

	public void Start(float fadeTime)
	{
	}

	public void Stop(float fadeTime, bool removeWhenStopped)
	{
	}

	public void Pause(float fadeTime)
	{
	}

	public void Resume(float fadeTime)
	{
	}

	public void TogglePaused(float fadeTime)
	{
	}

	private Vector3 getPositionShake()
	{
		return default(Vector3);
	}

	private Vector3 getRotationShake()
	{
		return default(Vector3);
	}

	private float getNoise(float x, float y)
	{
		return 0f;
	}
}
