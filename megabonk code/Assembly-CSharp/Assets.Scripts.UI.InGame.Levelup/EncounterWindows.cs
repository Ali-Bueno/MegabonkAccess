using System;
using System.Collections.Generic;
using Assets.Scripts.UI.InGame.Rewards;
using UnityEngine;

namespace Assets.Scripts.UI.InGame.Levelup;

public class EncounterWindows : MonoBehaviour
{
	public BaseEncounterWindow levelupScreen;

	public BaseEncounterWindow genericEncounterWindow;

	public BaseEncounterWindow chestWindow;

	public BaseEncounterWindow itemPickWindow;

	public BaseEncounterWindow microwaveWindow;

	private BaseEncounterWindow activeEncounterWindow;

	private Queue<EEncounter> rewardQueue;

	private bool _003CencounterInProgress_003Ek__BackingField;

	private bool closedEncounterThisFrame;

	private static List<EEncounter> nextMapQueue;

	public static Action A_WindowOpened;

	public static Action A_WindowClosed;

	public int currentLevel;

	public bool encounterInProgress
	{
		get
		{
			return _003CencounterInProgress_003Ek__BackingField;
		}
		private set
		{
			_003CencounterInProgress_003Ek__BackingField = value;
		}
	}

	private void Awake()
	{
	}

	private void OnDestroy()
	{
	}

	private void OnGameOver()
	{
	}

	private void OnPortalClosed()
	{
	}

	private bool QueueEncountersForNextMap()
	{
		return false;
	}

	public bool HasEncounter()
	{
		return false;
	}

	public void AddEncounter(EEncounter rewardWindowType)
	{
	}

	public void RewardFinished()
	{
	}

	private void PopReward()
	{
	}

	private void OnInventoryInitialized(PlayerInventory inventory)
	{
	}

	private void LateUpdate()
	{
	}

	private void Start()
	{
	}

	private void OnLevelUp(int level)
	{
	}

	private bool IsPlayerMaxed()
	{
		return false;
	}
}
