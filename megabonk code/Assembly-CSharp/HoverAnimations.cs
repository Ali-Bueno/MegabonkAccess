using UnityEngine;

public class HoverAnimations : MonoBehaviour
{
	public Transform player;

	public AudioSource audioHoverLoop;

	public AudioSource audioSpin;

	public Animator animator;

	private Vector3 defaultPos;

	private Vector3 defaultRotation;

	private float currentPitch;

	private float nextLandingReadyTime;

	private float landingInterval;

	private float minLandingSpeed;

	private float maxLandingSpeed;

	public float sinSpeed;

	public float height;

	private float currentLandingOffset;

	private float landingOffset;

	private float minLandingOffset;

	private float maxLandingOffset;

	public float landingResetSpeed;

	public float landingSpeed;

	private float lastVelY;

	private float currentLean;

	private float targetLean;

	public float maxLeanAngle;

	public float leanSpeed;

	public float maxSpeedForLean;

	private float newLean;

	private void Start()
	{
	}

	private void Update()
	{
	}

	private void OnLanded(float speed)
	{
	}

	private void LateUpdate()
	{
	}

	private void LeanRotation()
	{
	}

	private void FixedUpdate()
	{
	}
}
