using System;
using System.Collections.Generic;
using Assets.Scripts.Actors.Enemies;
using UnityEngine;

public class InteractableShrineChallenge : BaseInteractable
{
	public GameObject minimapIcon;

	public GameObject alertIcon;

	private bool done;

	public GameObject fx;

	private HashSet<Enemy> enemies;

	public static Action A_Completed;

	private bool hasGivenReward;

	public static string debugName;

	private void Awake()
	{
	}

	private new void OnDestroy()
	{
	}

	public override bool Interact()
	{
		return false;
	}

	public override bool CanInteract()
	{
		return false;
	}

	private void EnemyDied(Enemy enemy)
	{
	}

	public override string GetInteractString()
	{
		return null;
	}

	public override bool ShowInDebug()
	{
		return false;
	}

	public override string GetDebugName()
	{
		return null;
	}
}
