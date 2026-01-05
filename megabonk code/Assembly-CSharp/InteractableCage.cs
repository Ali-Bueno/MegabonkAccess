using UnityEngine;
using UnityEngine.Localization;

public class InteractableCage : BaseInteractable
{
	public GameObject fx;

	private bool done;

	public AudioSource audioSource;

	public GameObject monke;

	public LocalizedString localizedString;

	public MeshRenderer meshRenderer;

	public BoxCollider collider;

	public override bool Interact()
	{
		return false;
	}

	public override bool CanInteract()
	{
		return false;
	}

	public override string GetInteractString()
	{
		return null;
	}

	private bool HasKey()
	{
		return false;
	}
}
