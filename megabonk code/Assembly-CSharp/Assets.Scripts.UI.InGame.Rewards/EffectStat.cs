using System;
using Assets.Scripts.Inventory__Items__Pickups.Stats;
using Assets.Scripts.UI.InGame.Rewards.Effects;

namespace Assets.Scripts.UI.InGame.Rewards;

[Serializable]
public class EffectStat
{
	public EEncounterEffect effectType;

	public StatModifier statModifier;

	public bool permanent;

	public float duration;

	public float value;

	public bool isPositiveEffect;

	public string GetDescription()
	{
		return null;
	}

	private float GetValue()
	{
		return 0f;
	}

	private string GetStatDescription(string color)
	{
		return null;
	}

	public string GetShortDescription()
	{
		return null;
	}

	public string GetEffectNumber()
	{
		return null;
	}

	public string GetEffectName()
	{
		return null;
	}

	public void ApplyEffect()
	{
	}

	private string GetColor()
	{
		return null;
	}

	private void HealthEffect()
	{
	}

	public bool CanApplyEffect(out string reason)
	{
		reason = null;
		return false;
	}
}
