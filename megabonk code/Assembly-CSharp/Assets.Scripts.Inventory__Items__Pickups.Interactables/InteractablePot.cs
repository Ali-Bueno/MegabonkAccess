using Assets.Scripts.Inventory__Items__Pickups.Pickups;
using UnityEngine;
using UnityEngine.Localization;

namespace Assets.Scripts.Inventory__Items__Pickups.Interactables;

public class InteractablePot : BaseInteractable
{
	public GameObject goldPrefab;

	public GameObject xpPrefab;

	public GameObject hpPrefab;

	public GameObject silverPrefab;

	public GameObject potBreakFx;

	private bool broken;

	public bool isBig;

	public bool isSilver;

	public LocalizedString localizedString;

	public bool isInCrypt;

	public static string debugName;

	public static string debugNameSilver;

	public static string debugNameCrypt;

	public static string debugGraveyardName;

	public override bool Interact()
	{
		return false;
	}

	private int GetXp()
	{
		return 0;
	}

	private void SpawnStuff(EPickup ePickup, int value, float pickupDelay, int amount)
	{
	}

	public override string GetInteractString()
	{
		return null;
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
}
