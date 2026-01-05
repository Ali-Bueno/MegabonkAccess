using System;
using System.Collections.Generic;
using Assets.Scripts.Inventory__Items__Pickups.Stats;
using Assets.Scripts.Inventory__Items__Pickups.Weapons.WeaponPassives;
using Assets.Scripts.Menu.Shop;

namespace Assets.Scripts.Inventory__Items__Pickups.Weapons;

public class WeaponBase
{
	private float usedWeaponAtTime;

	public WeaponData weaponData;

	public int level;

	private Dictionary<EStat, float> weaponStats;

	private List<List<StatModifier>> upgrades;

	private WeaponPassive passive;

	public static Action<EStat, EWeapon> A_WeaponStatUpdate;

	private bool _003Cenabled_003Ek__BackingField;

	public bool enabled
	{
		get
		{
			return _003Cenabled_003Ek__BackingField;
		}
		private set
		{
			_003Cenabled_003Ek__BackingField = value;
		}
	}

	public WeaponBase(WeaponData data)
	{
	}

	public void Cleanup()
	{
	}

	public void Disable()
	{
	}

	public void Enable()
	{
	}

	public void Use()
	{
	}

	public void Upgrade(List<StatModifier> upgradeOffer)
	{
	}

	private void UpdateStat(EStat stat)
	{
	}

	public float GetTestUpdateStat(EStat stat, StatModifier testUpgrade)
	{
		return 0f;
	}

	public float GetValue(EStat stat)
	{
		return 0f;
	}

	public void WeaponPassiveChanged(EStat stat)
	{
	}

	private float GetBaseValue(EStat stat)
	{
		return 0f;
	}

	private void ApplyStatModifier(StatModifier modifier, int amount, ref float flatValues, ref float additionValues, ref float multiplicationValues)
	{
	}

	private bool IsCooldown()
	{
		return false;
	}

	private float GetCooldown()
	{
		return 0f;
	}
}
