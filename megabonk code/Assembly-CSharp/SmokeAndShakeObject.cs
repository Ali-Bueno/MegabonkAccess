using System;
using UnityEngine;

public class SmokeAndShakeObject : MonoBehaviour
{
	public float shakeStrength;

	private float readyAtTime;

	private float maxDistanceToPlayer;

	private float minSpeed;

	private float maxSpeed;

	public static Action<float> A_Impact;

	private void OnCollisionEnter(Collision other)
	{
	}
}
