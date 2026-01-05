using System.Collections.Generic;
using Assets.Scripts.Inventory__Items__Pickups.Items;
using Assets.Scripts.UI.InGame.Rewards;
using TMPro;
using UnityEngine;

public class MicrowaveUi : BaseEncounterWindow
{
	public GameObject itemPrefab;

	private List<MicrowaveItemButton> itemPrefabs;

	public TextMeshProUGUI t_price;

	public override void Open(EEncounter encounterType)
	{
	}

	private void Update()
	{
	}

	public void SelectUpgrade(EItem eItem)
	{
	}

	public void CloseScreen()
	{
	}

	public override void OnClose()
	{
	}

	public override void ChooseOffer(int index)
	{
	}
}
