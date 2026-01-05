using System.Collections.Generic;
using UnityEngine;

public class AnimatedMesh : MonoBehaviour
{
	public delegate void AnimationEndEvent(string Name);

	private AnimatedMeshScriptableObject AnimationSO;

	private MeshFilter Filter;

	private int Tick;

	private int AnimationIndex;

	private string AnimationName;

	private List<Mesh> AnimationMeshes;

	public bool paused;

	private float LastTickTime;

	private float tickInterval;

	public bool testing;

	public event AnimationEndEvent OnAnimationEnd
	{
		add
		{
		}
		remove
		{
		}
	}

	public void SetAnimation(AnimatedMeshScriptableObject animation)
	{
	}

	private void Awake()
	{
	}

	public void Pause()
	{
	}

	public void UnPause()
	{
	}

	private void Update()
	{
	}
}
