using System;
using System.Collections.Generic;
using Assets.Scripts.Inventory__Items__Pickups.Items;
using UnityEngine;

public class InteractableShadyGuy : BaseInteractable
{
	public Material matRare;

	public Material matEpic;

	public Material matLegendary;

	public SkinnedMeshRenderer meshRenderer;

	public GameObject smokeFx;

	public RandomSfx purchaseSfx;

	public GameObject[] hideAfterPurchase;

	public EItemRarity rarity;

	public List<ItemData> items;

	public List<int> prices;

	public static InteractableShadyGuy currentlyInteracting;

	private float[] pricesMultipliers;

	public static Action A_ShadyGuyDone;

	private string dissapearText;

	private bool done;

	public static string debugName;

	private new void Start()
	{
	}

	private void FindItems()
	{
	}

	private void UpdatePrices()
	{
	}

	private new void OnDestroy()
	{
	}

	public override bool Interact()
	{
		return false;
	}

	public override string GetInteractString()
	{
		return null;
	}

	private void OnShadyGuyDone()
	{
	}

	private void Disappear()
	{
	}

	public override bool CanInteract()
	{
		return false;
	}

	public override bool ShowInDebug()
	{
		return false;
	}

	public override string GetDebugName()
	{
		return null;
	}
}
