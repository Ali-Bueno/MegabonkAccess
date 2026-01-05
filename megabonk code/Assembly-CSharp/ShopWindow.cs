using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopWindow : MonoBehaviour
{
	public GameObject shopContainerPrefab;

	public Transform contentParent;

	public TabGridNavigation navigation;

	public Button btnBack;

	public ShopFooter shopFooter;

	public MyButtonNormal btnBuy;

	public MyButtonNormal btnRefund;

	public TextMeshProUGUI t_buy;

	public TextMeshProUGUI t_refund;

	private ShopContainer _003CcurrentContainer_003Ek__BackingField;

	private List<ShopContainer> shopContainers;

	public static Action<ShopContainer> A_LevelChanged;

	public ShopContainer currentContainer
	{
		get
		{
			return _003CcurrentContainer_003Ek__BackingField;
		}
		private set
		{
			_003CcurrentContainer_003Ek__BackingField = value;
		}
	}

	private void Awake()
	{
	}

	private void OnDestroy()
	{
	}

	private void Start()
	{
	}

	public void Buy()
	{
	}

	public void Refund()
	{
	}

	private void RefreshPrices()
	{
	}

	private void OnShopClicked(ShopContainer shopContainerClicked)
	{
	}

	public void OnShopSelect(ShopContainer shopContainerClicked)
	{
	}
}
