using System.Collections.Generic;
using Assets.Scripts.Inventory__Items__Pickups.Items;
using UnityEngine;

public class ItemsHud : MonoBehaviour
{
	public GameObject prefab;

	private Dictionary<EItem, ItemsHudElementPrefab> itemToPrefab;

	private void Start()
	{
	}

	private void OnDestroy()
	{
	}

	private void OnItemAdded(EItem item)
	{
	}

	private void OnItemRemoved(EItem item, bool showEffect)
	{
	}
}
