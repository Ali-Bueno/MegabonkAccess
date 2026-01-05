using UnityEngine;
using UnityEngine.UI;

public class ShopContainer : MonoBehaviour
{
	public RawImage icon;

	private ShopItemData _003Cdata_003Ek__BackingField;

	public Transform levelsParent;

	public GameObject backgroundLocked;

	public GameObject backgroundUnlocked;

	public GameObject alert;

	public ShopItemData data
	{
		get
		{
			return _003Cdata_003Ek__BackingField;
		}
		private set
		{
			_003Cdata_003Ek__BackingField = value;
		}
	}

	private void Awake()
	{
	}

	private void OnButtonSelect(ShopContainer shopBtn)
	{
	}

	private void OnDestroy()
	{
	}

	public void Set(ShopItemData shopItemData)
	{
	}

	private void Update()
	{
	}

	private void RefreshLevel(bool isUnlocked)
	{
	}

	private void OnShopItemLevelChanged(ShopContainer shopContainer)
	{
	}
}
