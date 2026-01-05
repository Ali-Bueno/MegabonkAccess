using System;
using System.Collections.Generic;
using Assets.Scripts._Data;
using Assets.Scripts.Inventory__Items__Pickups;
using Assets.Scripts.Inventory__Items__Pickups.Stats;
using Assets.Scripts.UI.InGame.Rewards;
using Assets.Scripts.UI.Menu.Windows;
using UnityEngine;

public class UpgradePicker : MonoBehaviour
{
	public UpgradeButton[] buttons;

	public LevelupScreen levelupScreen;

	private int numUpgrades;

	public TabsExplicitNavigation tabsExplicitNavigation;

	private EEncounter encounterType;

	public GameObject window;

	private float openedAtTime;

	public static Action A_ShadyGuyDone;

	private int moaiLuckMode;

	public GameObject banisModeOverlay;

	private bool _003CbanishMode_003Ek__BackingField;

	public float banishCooldownOverAtTime;

	public bool banishMode
	{
		get
		{
			return _003CbanishMode_003Ek__BackingField;
		}
		private set
		{
			_003CbanishMode_003Ek__BackingField = value;
		}
	}

	public void ShuffleUpgrades(EEncounter encounterType)
	{
	}

	public void SetMoaiLuck(int luckMode)
	{
	}

	private void KeyboardInput()
	{
	}

	public void SelectUpgrade(IUpgradable upgradable, List<StatModifier> upgradeOffer, UpgradeButton btn, ERarity rarity)
	{
	}

	public static void AutoSelectUpgrade()
	{
	}

	public void SelectItem(ItemData itemData)
	{
	}

	public int GetNumUpgrades()
	{
		return 0;
	}

	public void StartBanishMode()
	{
	}

	private void Banish()
	{
	}

	public void StopBanishMode()
	{
	}

	private void Update()
	{
	}
}
