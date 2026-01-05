using System.Collections.Generic;
using UnityEngine;

public class UpgradeInventoryUI : MonoBehaviour
{
	public GameObject itemContainerPrefab;

	public Transform weaponParent;

	public Transform tomeParent;

	public Transform itemParent;

	private List<InventoryItemPrefabUI> weaponContainers;

	private List<InventoryItemPrefabUI> tomeContainers;

	private List<InventoryItemPrefabUI> itemContainers;

	private void OnEnable()
	{
	}

	public void Refresh()
	{
	}

	private void Rebuild()
	{
	}
}
