using System.Collections.Generic;
using UnityEngine;

public class SkatingAnimations : MonoBehaviour
{
	public Animator animator;

	private PlayerMovement playerMovement;

	public AudioSource skateSfx;

	private string lastAnimationName;

	private float maxVolume;

	private float skateVolumeBoost;

	private float idleThreshold;

	private Queue<float> speedChangeQueue;

	private Queue<float> rotationChangeQueue;

	private float previousSpeed;

	private Vector3 previousForward;

	private int averageFrameCount;

	private float speedChangeThreshold;

	private float rotationChangeThreshold;

	private float nextKickTime;

	private float minKickInterval;

	private float maxKickInterval;

	private void Awake()
	{
	}

	private void Update()
	{
	}

	public void Kick()
	{
	}

	private void FixedUpdate()
	{
	}
}
