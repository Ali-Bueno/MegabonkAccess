using System;
using Assets.Scripts.Inventory__Items__Pickups.Interactables;
using UnityEngine;

public abstract class BaseInteractable : MonoBehaviour
{
	public bool isItemSource;

	private Outline outline;

	protected DetectInteractables detectInteractables;

	public Vector3 textOffset;

	private Vector3 textOffsetCalculated;

	public static Action<string> A_DebugSpawn;

	public static Action<string> A_DebugDisable;

	public bool showOutline;

	protected void Start()
	{
	}

	public void StartHover(DetectInteractables detectInteractables)
	{
	}

	protected void RefreshInteractable()
	{
	}

	public void StopHover()
	{
	}

	protected void OnDestroy()
	{
	}

	public abstract bool Interact();

	public abstract string GetInteractString();

	public virtual Color GetColor()
	{
		return default(Color);
	}

	public virtual bool CanInteract()
	{
		return false;
	}

	public Vector3 GetOffset()
	{
		return default(Vector3);
	}

	public virtual bool ShowInDebug()
	{
		return false;
	}

	public virtual string GetDebugName()
	{
		return null;
	}
}
