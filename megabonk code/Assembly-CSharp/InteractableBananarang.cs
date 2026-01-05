using UnityEngine;

public class InteractableBananarang : BaseInteractable
{
	public GameObject fx;

	private bool done;

	public override bool Interact()
	{
		return false;
	}

	public override string GetInteractString()
	{
		return null;
	}
}
