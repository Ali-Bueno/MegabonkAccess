using System;
using UnityEngine;

namespace Assets.Scripts.Inventory__Items__Pickups.Interactables;

public class OpenChest : MonoBehaviour
{
	public EChest chestType;

	private float delay;

	private float readyForPickupTime;

	private bool pickedup;

	public static Action A_Open;

	private void Awake()
	{
	}

	private void OnTriggerStay(Collider other)
	{
	}

	private bool CanPickup()
	{
		return false;
	}
}
