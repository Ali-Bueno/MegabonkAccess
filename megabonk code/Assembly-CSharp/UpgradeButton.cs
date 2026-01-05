using System.Collections.Generic;
using Assets.Scripts._Data;
using Assets.Scripts.Inventory__Items__Pickups;
using Assets.Scripts.Inventory__Items__Pickups.Stats;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeButton : MyButton
{
	public RawImage icon;

	public TextMeshProUGUI t_name;

	public TextMeshProUGUI t_description;

	public TextMeshProUGUI t_level;

	public TextMeshProUGUI t_rarity;

	public RawImage iconBorder;

	public RawImage iconBackground;

	public Image background;

	public Image backgroundOverlay;

	public GameObject banishOverlay;

	private IUpgradable upgradable;

	private List<StatModifier> upgradeOffer;

	public UpgradePicker upgradePicker;

	public TomeSynergiesUi tomeSynergiesUi;

	private bool isItem;

	private ItemData itemData;

	private ERarity rarity;

	private int price;

	private bool canAfford;

	public GameObject overlayCantAfford;

	public void SetUpgrade(IUpgradable upgradable)
	{
	}

	public void SetItem(ItemData itemData)
	{
	}

	public void SetItemPriced(ItemData itemData, int price)
	{
	}

	private void EnableButton()
	{
	}

	public void SelectUpgrade()
	{
	}

	public override void StartHover()
	{
	}

	public override void StopHover()
	{
	}

	protected override void OnClick()
	{
	}
}
