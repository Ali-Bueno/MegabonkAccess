using System;
using Assets.Scripts.Inventory__Items__Pickups.Interactables;
using UnityEngine;

namespace Assets.Scripts.Inventory__Items__Pickups.Chests;

public class InteractableChest : BaseInteractable
{
	public EChest chestType;

	private float rotation;

	public Transform icon;

	public static Action A_ChestBought;

	public static Action A_ChestOpened;

	private bool opening;

	private bool isHoveringAndCantAfford;

	public bool isInCrypt;

	public bool isShownInDebug;

	public static string debugName;

	public static string debugNameCrypt;

	private void Awake()
	{
	}

	private new void OnDestroy()
	{
	}

	private new void Start()
	{
	}

	public override bool Interact()
	{
		return false;
	}

	private void OpenChestImplementation()
	{
	}

	private void OnChestWindowClose()
	{
	}

	public override string GetInteractString()
	{
		return null;
	}

	private void FixedUpdate()
	{
	}

	public override Color GetColor()
	{
		return default(Color);
	}

	private int GetPrice()
	{
		return 0;
	}

	private bool CanAfford()
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

	private void OnDisable()
	{
	}

	public override bool CanInteract()
	{
		return false;
	}
}
