using System;
using System.Collections.Generic;
using Assets.Scripts.Inventory__Items__Pickups.Pickups;
using Assets.Scripts.Menu.Shop;

namespace Assets.Scripts.Inventory__Items__Pickups.Stats;

public class PlayerStatusEffects
{
	public Dictionary<EStatusEffect, StatusEffect> statusEffects;

	public static Action<EStat> A_StatusModifiedStat;

	public static Action<EStatusEffect, bool> A_StatusEffectAdded;

	public static Action<EStatusEffect> A_StatusEffectRemoved;

	public const string poisonEffectName = "Poison";

	public const string bleedEffectName = "Bleed";

	private float nextBleedTime;

	private float bleedInterval;

	private float nextPoisonTime;

	private float poisonInterval;

	public void OnDestroy()
	{
	}

	public void Tick()
	{
	}

	public void AddNewEffect(StatusEffect statusEffect, float statusLengthTime)
	{
	}

	private void RemoveStatusEffect(EStatusEffect eStatusEffect)
	{
	}

	public void RemoveAllStatusEffects()
	{
	}

	public bool HasStatusEffect(EStatusEffect effect)
	{
		return false;
	}

	public void TestPickup(EPickup ePickup)
	{
	}

	private void OnPickupTriggered(Pickup pickup)
	{
	}

	public void SlowPlayer(float time)
	{
	}

	public void FreezePlayer(float time)
	{
	}

	public void BleedPlayer(float duration)
	{
	}

	public void PoisonPlayer(float duration)
	{
	}

	public void BossPoisonPlayer(float duration)
	{
	}

	private void OnPickupTriggered(EPickup ePickup)
	{
	}

	private void OnLevelupScreenDone()
	{
	}

	private void TickEffects()
	{
	}
}
