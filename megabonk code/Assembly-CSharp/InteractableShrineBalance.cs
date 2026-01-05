using UnityEngine;

public class InteractableShrineBalance : BaseInteractable
{
	public GameObject minimapIcon;

	public GameObject alertIcon;

	public bool done;

	public static string debugName;

	public override bool Interact()
	{
		return false;
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
}
