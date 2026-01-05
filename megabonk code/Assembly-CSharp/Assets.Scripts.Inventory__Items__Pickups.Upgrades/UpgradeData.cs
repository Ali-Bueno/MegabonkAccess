using System.Collections.Generic;
using Assets.Scripts.Inventory__Items__Pickups.Stats;
using UnityEngine;

namespace Assets.Scripts.Inventory__Items__Pickups.Upgrades;

public class UpgradeData : ScriptableObject
{
	public List<StatModifier> upgradeModifiers;

	public List<StatModifier> GetUpgradeOffer(ERarity rarity, EWeapon eWeapon)
	{
		return null;
	}

	private StatModifier GetRandomModifier(StatModifier randomModifier, float multiplier)
	{
		return null;
	}
}
