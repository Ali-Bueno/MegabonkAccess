using Assets.Scripts.Inventory__Items__Pickups.Stats;
using UnityEngine;

public abstract class ChallengeModifier : ScriptableObject
{
	public string internalName;

	public StatModifier[] statModifiers;

	public abstract void Init(ChallengeData challengeData);

	public abstract void Cleanup();

	public virtual void Tick()
	{
	}

	public virtual void OnStatsApplied()
	{
	}
}
