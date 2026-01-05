using Assets.Scripts.Actors;
using Assets.Scripts.Inventory__Items__Pickups;
using UnityEngine;

public class DetectRails : MonoBehaviour
{
	public LayerMask whatIsRails;

	private PlayerMovement playerMovement;

	private Collider[] buffer;

	private string railTag;

	private void Awake()
	{
	}

	private void OnDestroy()
	{
	}

	private void OnDamage(PlayerHealth arg1, DamageContainer arg2, bool arg3)
	{
	}

	private void FixedUpdate()
	{
	}
}
