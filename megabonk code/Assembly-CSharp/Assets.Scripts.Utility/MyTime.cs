using System;

namespace Assets.Scripts.Utility;

public static class MyTime
{
	public static bool paused;

	public static float time;

	public static float deltaTime;

	public static float fixedDeltaTime;

	private static float _003CtimeScale_003Ek__BackingField;

	public static int tick;

	public static int unpauseTick;

	public static float stageTimer;

	public static float runTimer;

	public static float finalSwarmTimer;

	public static float difficultyTimer;

	public static float cryptTimer;

	public static Action<bool> A_Pause;

	public static Action A_Tick;

	public static Action A_TimeScaleChange;

	private static float timescaleTimeRemaining;

	public static float timeScale
	{
		get
		{
			return _003CtimeScale_003Ek__BackingField;
		}
		private set
		{
			_003CtimeScale_003Ek__BackingField = value;
		}
	}

	public static void Init()
	{
	}

	public static void Cleanup()
	{
	}

	private static void OnNewRunStarted()
	{
	}

	private static void OnNewStageStarted()
	{
	}

	public static void Update()
	{
	}

	public static void FixedUpdate()
	{
	}

	public static void SetTimeScale(float newTimeScale, float duration)
	{
	}

	private static void ResetTimeScale()
	{
	}

	public static void Pause()
	{
	}

	public static void Unpause()
	{
	}

	public static void StartCryptBoss()
	{
	}
}
