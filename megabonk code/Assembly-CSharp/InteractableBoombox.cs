using UnityEngine;
using UnityEngine.Localization;

public class InteractableBoombox : BaseInteractable
{
	public LocalizedString interactString;

	public GameObject alertIcon;

	private bool done;

	public GameObject fx;

	public AudioSource music;

	public Animator animator;

	public MusicPauseZone pauseZone;

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
}
