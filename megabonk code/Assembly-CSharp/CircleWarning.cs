using System;
using UnityEngine;

public class CircleWarning : MonoBehaviour
{
	public float warningTime;

	public Transform filler;

	private float defaultProjectorSize;

	private float timer;

	private Action finishAction;

	private Vector3 desiredScale;

	public void Set(float radius, float warningTime, Action finishAction)
	{
	}

	private void Update()
	{
	}

	public void ReleaseToPool()
	{
	}
}
