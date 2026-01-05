using System.Collections.Generic;
using Assets.Scripts.Inventory__Items__Pickups.Stats;
using UnityEngine;

public class ShrineLogs : MonoBehaviour
{
	public GameObject prefab;

	private static List<StatModifier> backLog;

	private static List<StatModifier> shownLog;

	private bool isInitialized;

	private void Start()
	{
	}

	public static void Reset()
	{
	}

	public void AddLog(StatModifier statModifier, bool isNew = true)
	{
	}
}
