using System;
using System.Collections.Generic;
using Assets.Scripts.Inventory__Items__Pickups.Stats;

namespace Assets.Scripts.Inventory__Items__Pickups.Weapons;

public class WeaponInventory
{
	private bool isMaxed;

	private bool hasAimableWeapon;

	public Dictionary<EWeapon, WeaponBase> weapons;

	public static Action<WeaponBase> A_WeaponAdded;

	public static Action<WeaponBase> A_WeaponRemoved;

	public static Action<WeaponBase> A_WeaponToggled;

	public void AddWeapon(WeaponData weaponData, List<StatModifier> upgradeOffer)
	{
	}

	public void ToggleWeapon(EWeapon eWeapon, bool enable)
	{
	}

	private void RemoveWeapon()
	{
	}

	public void Tick()
	{
	}

	public int GetNumWeapons()
	{
		return 0;
	}

	public int GetWeaponLevel(EWeapon eWeapon)
	{
		return 0;
	}

	private void CheckMaxed()
	{
	}

	private bool IsMaxLevel(EWeapon eWeapon)
	{
		return false;
	}

	public bool IsMaxed()
	{
		return false;
	}

	public bool HasAimableWeapon()
	{
		return false;
	}

	public void Cleanup()
	{
	}
}
