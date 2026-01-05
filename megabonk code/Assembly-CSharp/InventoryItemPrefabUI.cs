using Assets.Scripts.Inventory__Items__Pickups.Items;
using Assets.Scripts.Inventory__Items__Pickups.Weapons;
using Assets.Scripts.Saves___Serialization.Progression.Achievements;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryItemPrefabUI : MonoBehaviour
{
	public RawImage icon;

	public TextMeshProUGUI t_level;

	public GameObject lockedOverlay;

	public ToolTipObject toolTipObject;

	private UnlockableBase item;

	private void Awake()
	{
	}

	private void OnDestroy()
	{
	}

	private void OnWeaponToggled(WeaponBase weaponBase)
	{
	}

	public void SetItem(UnlockableBase item)
	{
	}

	private void RefreshEnabled(bool isEnabled)
	{
	}

	public void SetItem(EItem eItem)
	{
	}

	private int GetLevel(UnlockableBase item)
	{
		return 0;
	}

	public void SetUnavailable()
	{
	}
}
