using Assets.Scripts.Inventory__Items__Pickups.Weapons;
using Assets.Scripts.Menu.Shop;
using UnityEngine;

namespace Assets.Scripts.Game.Combat.ConstantAttacks;

public abstract class ConstantAttack : MonoBehaviour
{
	public WeaponBase weaponBase;

	public void Set(WeaponBase weaponBase)
	{
	}

	protected void Awake()
	{
	}

	protected void OnDestroy()
	{
	}

	protected abstract void Init();

	protected abstract void OnWeaponStatUpdate(EStat stat, EWeapon weapon);

	protected abstract void OnStatUpdate(EStat stat);

	public abstract float GetAuraRotationSpeed();

	public virtual bool IsManualRotation()
	{
		return false;
	}
}
