using UnityEngine;
using UnityEngine.Localization;

namespace Assets.Scripts.UI.InGame.Rewards;

public class EncounterData : ScriptableObject
{
	public EEncounter encounterType;

	public EncounterOffer[] offers;

	public LocalizedString localizedName;

	public LocalizedString localizedDescription;

	public string GetName()
	{
		return null;
	}

	public string GetDescription()
	{
		return null;
	}

	public EncounterOffer[] GetOffers()
	{
		return null;
	}

	public bool HasRarity()
	{
		return false;
	}
}
