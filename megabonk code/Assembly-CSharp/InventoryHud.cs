using System.Collections.Generic;
using Assets.Scripts._Data.Tomes;
using Assets.Scripts.Inventory__Items__Pickups.Weapons;
using Assets.Scripts.Menu.Shop;
using UnityEngine;

public class InventoryHud : MonoBehaviour
{
	public GameObject itemContainerPrefab;

	public Transform weaponParent;

	public Transform tomeParent;

	private List<InventoryItemPrefabUI> weaponContainers;

	private List<InventoryItemPrefabUI> tomeContainers;

	private void Start()
	{
	}

	private void OnDestroy()
	{
	}

	private void OnInventoryInit(PlayerInventory obj)
	{
	}

	public void Refresh()
	{
	}

	private void OnTomeAdded(ETome eTome, EStat obj)
	{
	}

	private void OnWeaponAdded(WeaponBase obj)
	{
	}
}
