using Assets.Scripts.UI.InGame.Rewards;
using UnityEngine;
using UnityEngine.Localization;

public class InteractableGravestone : BaseInteractable
{
	public LocalizedString localizationName;

	private bool done;

	public GameObject fx;

	public EffectStat[] statEffects;

	private static int numInteractions;

	public static string debugName;

	private void Awake()
	{
	}

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

	public override bool ShowInDebug()
	{
		return false;
	}

	public override string GetDebugName()
	{
		return null;
	}
}
