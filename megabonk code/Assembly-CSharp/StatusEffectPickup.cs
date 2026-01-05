using Assets.Scripts.Inventory__Items__Pickups.Pickups;
using Assets.Scripts.Inventory__Items__Pickups.Stats;
using UnityEngine;

public class StatusEffectPickup : MonoBehaviour
{
	public EPickup ePickup;

	public EStatusEffect statusEffect;

	public GameObject sparksEffect;

	public GameObject pickupImpactEffect;

	public bool rotateToPlayerVelocity;

	public bool useFeetPosition;

	private float timeLeft;

	public void Set()
	{
	}

	private void OnPickupTriggered(Pickup pickup)
	{
	}

	private void Update()
	{
	}

	private bool HasStatusEffect()
	{
		return false;
	}

	private void DestroySelf()
	{
	}

	private void OnDestroy()
	{
	}
}
