using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Inventory__Items__Pickups.Pickups;

public class PickupStackableList
{
	private int maxObjects;

	private EPickup ePickup;

	public LinkedList<Pickup> pickupsList;

	public PickupStackableList(int nMax, EPickup ePickup)
	{
	}

	public Pickup AddPickup(Vector3 pos)
	{
		return null;
	}

	private void CombineOldestObjects()
	{
	}

	public void RemovePickup(Pickup pickup)
	{
	}
}
