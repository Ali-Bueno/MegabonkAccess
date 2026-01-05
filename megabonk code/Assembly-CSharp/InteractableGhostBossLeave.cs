using UnityEngine;
using UnityEngine.Localization;

public class InteractableGhostBossLeave : BaseInteractable
{
	public LocalizedString stringLeave;

	private bool hasInteracted;

	private bool isBossDead;

	private Vector3 teleportPosition;

	private Vector3 teleportDir;

	public void OpenDoor()
	{
	}

	public override bool Interact()
	{
		return false;
	}

	private void Teleport()
	{
	}

	public override string GetInteractString()
	{
		return null;
	}

	public override bool CanInteract()
	{
		return false;
	}

	public void SetTeleportTransform(Vector3 pos, Vector3 dir)
	{
	}
}
