using System.Collections.Generic;
using Assets.Scripts.Inventory__Items__Pickups.Items;
using Assets.Scripts.Inventory__Items__Pickups.Stats;
using Assets.Scripts.Menu.Shop;

namespace Assets.Scripts.Inventory__Items__Pickups.Weapons.WeaponPassives;

public abstract class WeaponPassive
{
	public Dictionary<EStat, StatModifiersContainer> statModifiers;

	protected WeaponBase weaponBase;

	public WeaponPassive(WeaponBase weaponBase)
	{
	}

	protected void SetStat(StatModifier statModifier)
	{
	}

	public abstract void Init();

	public abstract void Cleanup();
}
