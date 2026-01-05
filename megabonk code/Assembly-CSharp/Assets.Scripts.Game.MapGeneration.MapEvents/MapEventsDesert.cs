using System.Collections.Generic;

namespace Assets.Scripts.Game.MapGeneration.MapEvents;

public class MapEventsDesert : MapEvents
{
	public bool ENABLE_SANDSTORM;

	private int numStorms;

	private List<float> stormTimes;

	private float minDuration;

	private float maxDuration;

	private static bool isActiveStorm;

	private float nextStormTime;

	private float stormOverAtTime;

	private int stormIndex;

	public static float currentStormStartedAtTime;

	private float tumbleweedSpawnInterval;

	private float lastSpawnedTumbleweedTime;

	private float minGapBetweenStorms => 0f;

	public override void Init()
	{
	}

	public override void Cleanup()
	{
	}

	public static bool IsActiveStorm()
	{
		return false;
	}

	public override void Tick()
	{
	}

	private void TickStorms()
	{
	}

	private void SpawnTumbleWeeds()
	{
	}

	private void StartStorm()
	{
	}

	private void StopStorm()
	{
	}
}
