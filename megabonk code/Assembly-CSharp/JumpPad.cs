using UnityEngine;

public class JumpPad : MonoBehaviour
{
	public float force;

	public Transform spring;

	public Transform direction;

	private float animationTime;

	private float animationScale;

	private float animationSpeed;

	public AudioSource audioSource;

	private Vector3 defaultScale;

	private void Awake()
	{
	}

	public Vector3 GetForce()
	{
		return default(Vector3);
	}

	private void OnTriggerEnter(Collider other)
	{
	}

	private void AnimateSpring()
	{
	}

	private void Update()
	{
	}
}
