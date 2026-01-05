using MilkShake;
using UnityEngine;

public class ShrineSpawnAnimation : MonoBehaviour
{
	public float offset;

	private float moveOverTime;

	public ShakePreset shakePreset;

	private Vector3 fromPos;

	private Vector3 toPos;

	private bool started;

	private float timer;

	public void Activate()
	{
	}

	private void FixedUpdate()
	{
	}
}
