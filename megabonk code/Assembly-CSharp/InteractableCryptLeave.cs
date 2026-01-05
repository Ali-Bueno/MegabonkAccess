using System;
using UnityEngine;
using UnityEngine.Localization;

public class InteractableCryptLeave : BaseInteractable
{
	public LocalizedString stringLeave;

	private bool hasInteracted;

	public static Action<float> A_FirstDungeonCompleted;

	private RsgController.EDungeonType dungeonType;

	private Vector3 teleportPosition;

	private Vector3 teleportDir;

	private Vector3 teleportDirCamera;

	public override bool Interact()
	{
		return false;
	}

	public void SetType(RsgController.EDungeonType dungeonType)
	{
	}

	private void Teleport()
	{
	}

	private void Update()
	{
	}

	private void ShowTime()
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

	public void SetTeleportTransform(Vector3 pos, Vector3 dir, Vector3 cameraDir)
	{
	}
}
