using UnityEngine;
using UnityEngine.Localization;

public class InteractableGift : BaseInteractable
{
	public LocalizedString localizationOpenGift;

	public GameObject hatFloating;

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
