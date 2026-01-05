using Assets.Scripts.Inventory__Items__Pickups.Pickups;
using UnityEngine;

public class PickupOrb : MonoBehaviour
{
	public GameObject hitEffect;

	public TrailRenderer trail;

	public ParticleSystem[] particleSystems;

	public Rigidbody rb;

	public EPickup ePickup;

	private float timeoutAtTime;

	private bool isDone;

	private void Awake()
	{
	}

	private void Update()
	{
	}

	public void Set(EPickup ePickup)
	{
	}

	private void OnCollisionEnter(Collision collision)
	{
	}

	private void Timeout()
	{
	}
}
