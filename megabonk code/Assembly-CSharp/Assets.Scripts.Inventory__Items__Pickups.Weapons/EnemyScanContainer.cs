using UnityEngine;

namespace Assets.Scripts.Inventory__Items__Pickups.Weapons;

public class EnemyScanContainer
{
	public float range;

	public float time;

	public Vector3 position;

	private const float distThreshold = 2f;

	private const float distThresholdSqr = 4f;

	private const float timeThreshold = 0.04f;

	private const float rangeThreshold = 1f;

	public EnemyScanContainer(Vector3 position, float time, float range)
	{
	}

	public void Set(Vector3 position, float time, float range)
	{
	}

	public bool IsEqual(Vector3 pos, float t, float range)
	{
		return false;
	}

	public bool IsEqual(EnemyScanContainer other)
	{
		return false;
	}
}
