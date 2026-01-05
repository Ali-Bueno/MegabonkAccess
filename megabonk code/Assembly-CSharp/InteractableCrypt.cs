using Assets.Scripts.Actors.Enemies;
using UnityEngine.Localization;

public class InteractableCrypt : BaseInteractable
{
	public LocalizedString stringOpen;

	public LocalizedString stringFailed;

	private Enemy bossEnemy;

	private bool isDone;

	public override bool Interact()
	{
		return false;
	}

	private void Teleport()
	{
	}

	private void Update()
	{
	}

	public override string GetInteractString()
	{
		return null;
	}

	private bool IsOpen()
	{
		return false;
	}

	public override bool CanInteract()
	{
		return false;
	}
}
