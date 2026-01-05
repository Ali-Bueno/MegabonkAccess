using System;
using System.Collections.Generic;
using Assets.Scripts.Inventory__Items__Pickups.Pickups;
using UnityEngine;

public class Pickup : MonoBehaviour
{
	public LinkedListNode<Pickup> linkedListNode;

	public EPickup ePickup;

	private int value;

	private bool pickedUp;

	private Transform target;

	private float speed;

	public Collider collider;

	public Action<int> A_ValueUpdated;

	public static Action<Pickup> A_PickupTriggered;

	private Vector3 startPosition;

	private float readyForPickupTime;

	private bool ignoreMagnetMultiplier;

	public float floatOffset;

	public float floatSpeed;

	private float floatRandomOffset;

	public float floatRotationSpeed;

	public bool animateRotation;

	public bool animatePosition;

	private void OnEnable()
	{
	}

	public void Set(Vector3 pos, int value, float pickupDelay)
	{
	}

	private void Awake()
	{
	}

	public void AddValue(int addValue)
	{
	}

	public void AddValue(Pickup other)
	{
	}

	private void SetValue(int v)
	{
	}

	private void OnTriggerStay(Collider other)
	{
	}

	public void StartFollowingPlayer(Transform target)
	{
	}

	private void ApplyPickup()
	{
	}

	private void ShowUi(EPickup ePickup)
	{
	}

	private void Update()
	{
	}

	private void FixedUpdate()
	{
	}

	public virtual bool CanPickup()
	{
		return false;
	}

	public int GetValue()
	{
		return 0;
	}
}
