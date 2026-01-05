using Assets.Scripts.Saves___Serialization.Progression.Achievements;
using UnityEngine;
using UnityEngine.UI;

public class InteractableUnlock : BaseInteractable
{
	public UnlockableBase unlock;

	public GameObject fx;

	public RawImage icon;

	private bool done;

	public bool useUnlock;

	private new void Start()
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
}
