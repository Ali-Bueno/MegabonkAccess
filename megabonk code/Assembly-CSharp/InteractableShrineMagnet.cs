using UnityEngine;

public class InteractableShrineMagnet : BaseInteractable
{
	public GameObject minimapIcon;

	public GameObject shrineIcon;

	private bool done;

	public GameObject interactFx;

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
