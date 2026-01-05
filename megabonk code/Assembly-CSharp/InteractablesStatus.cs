using System;
using System.Collections.Generic;

public static class InteractablesStatus
{
	public class InteractableStatusContainer
	{
		public int numTotal;

		public int numUsed;

		public string debugName;

		public InteractableStatusContainer(string debugName)
		{
		}

		public bool DisplayInDebug()
		{
			return false;
		}

		public bool IsDone()
		{
			return false;
		}
	}

	public static Dictionary<string, InteractableStatusContainer> interactablesByName;

	public static Action<string> A_InteractableUsed;

	public static Action<string> A_InteractableSpawned;

	public static void Init()
	{
	}

	public static void Cleanup()
	{
	}

	private static void PreMapGeneration()
	{
	}

	private static void OnInteractableSpawn(string debugName)
	{
	}

	private static void OnInteractableDisable(string debugName)
	{
	}

	private static void OnInteractableUse(BaseInteractable interactable, bool success)
	{
	}

	private static void OnChargeShrineCharged(bool whatever)
	{
	}

	private static void OnShadyGuyUsed()
	{
	}

	private static void OnMicrowaveExplode()
	{
	}

	private static void OnDungeonEnded()
	{
	}

	public static void PrintAll()
	{
	}
}
