using Assets.Scripts.Inventory__Items__Pickups.Pickups;
using UnityEngine;

public class InteractableTumbleWeed : BaseInteractable
{
	public const int maxTumbleWeeds = 25;

	private bool broken;

	public Rigidbody rb;

	private Vector3 desiredVelocity;

	private float speed;

	private float actualSpeed;

	private Vector3 lastPos;

	public AudioSource audio;

	private float defaultVolume;

	private float startTime;

	private float stopTime;

	private float scaleMultiplier;

	public override bool Interact()
	{
		return false;
	}

	private void Despawn()
	{
	}

	private void OnEnable()
	{
	}

	private void SpawnXp(EPickup ePickup, int value, float pickupDelay)
	{
	}

	public override string GetInteractString()
	{
		return null;
	}

	private void Spawn()
	{
	}

	private void FindNewDir()
	{
	}

	private void FixedUpdate()
	{
	}
}
