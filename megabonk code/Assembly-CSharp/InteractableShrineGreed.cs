using Assets.Scripts.UI.InGame.Rewards;
using UnityEngine;
using UnityEngine.Localization;

public class InteractableShrineGreed : BaseInteractable
{
	public LocalizedString localizationName;

	public GameObject minimapIcon;

	public GameObject alertIcon;

	private bool done;

	public GameObject fx;

	public GameObject fxLoop;

	public EffectStat statEffect;

	public static string debugName;

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
