using UnityEngine;

public class FlipAnimationFox : MonoBehaviour
{
	public Animator animator;

	private bool isJumping;

	public Transform flipTransform;

	private float lastAnimationTime;

	private int jumpCount;

	public GameObject[] defaultHandhelds;

	public GameObject[] flippedHandhelds;

	private void Update()
	{
	}

	private void OnJumpAnimationStart()
	{
	}

	private void OnJumpAnimationFinishOrInterrupted()
	{
	}

	private void FlipHandhelds(bool flip)
	{
	}
}
