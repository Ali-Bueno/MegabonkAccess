using UnityEngine;

public class InteractableShrineCursed : BaseInteractable
{
	public GameObject minimapIcon;

	public GameObject alertIcon;

	public bool done;

	public GameObject impactFx;

	public GameObject constantFx;

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
