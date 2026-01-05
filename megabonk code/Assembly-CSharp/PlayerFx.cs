using MilkShake;
using UnityEngine;

public class PlayerFx : MonoBehaviour
{
	public GameObject jumpFx;

	public GameObject landFx;

	public PlayerMovement playerMovement;

	public ShakePreset landingShake;

	private void Awake()
	{
	}

	private void OnDestroy()
	{
	}

	private void OnJumped(PlayerMovement obj)
	{
	}

	private void OnLanded(float fallSpeed)
	{
	}
}
