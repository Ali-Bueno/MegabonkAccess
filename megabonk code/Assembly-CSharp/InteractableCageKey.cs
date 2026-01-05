using Assets.Scripts.Inventory__Items__Pickups.Items;
using UnityEngine;

public class InteractableCageKey : BaseInteractable
{
	public GameObject fx;

	private bool done;

	public EItem eItem;

	public override bool Interact()
	{
		return false;
	}

	public override string GetInteractString()
	{
		return null;
	}
}
