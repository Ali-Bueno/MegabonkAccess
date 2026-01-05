using System.Collections.Generic;
using Assets.Scripts.Game.Combat.ConstantAttacks;
using Assets.Scripts.Inventory__Items__Pickups.Weapons;
using UnityEngine;

public class AuraAttacks : MonoBehaviour
{
	private Dictionary<EWeapon, ConstantAttack> auras;

	public AegisAttack aegisAttack;

	private void Awake()
	{
	}

	private void OnDestroy()
	{
	}

	private void OnInventoryInitialized(PlayerInventory inventory)
	{
	}

	private void Start()
	{
	}

	private void Refresh()
	{
	}

	private void OnWeaponAdded(WeaponBase weaponBase)
	{
	}

	private void OnWeaponRemoved(WeaponBase weaponBase)
	{
	}

	private void OnWeaponToggle(WeaponBase weaponBase)
	{
	}

	private void Update()
	{
	}
}
