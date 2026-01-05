using System;
using UnityEngine;

public class TubeWarning : MonoBehaviour
{
	public ParticleSystem ps;

	private float timer;

	private float fixedTimer;

	private float warningTime;

	private Action completeAction;

	private bool done;

	public void Set(float radius, float length, float time, Action completeAction)
	{
	}

	private void Update()
	{
	}

	public void ReleaseToPool()
	{
	}
}
