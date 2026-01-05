using System;
using Assets.Scripts.Inventory__Items__Pickups;

namespace Assets.Scripts.UI.InGame.Rewards;

[Serializable]
public class EncounterOffer
{
	public ERarity rarity;

	public EffectStat[] effects;

	public string GetEffectsDescription()
	{
		return null;
	}

	public void ApplyEffects(bool showInScoreUi = true)
	{
	}

	public bool CanAccept(out string reason)
	{
		reason = null;
		return false;
	}
}
