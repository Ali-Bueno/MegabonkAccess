using System.Collections.Generic;
using Assets.Scripts.Inventory__Items__Pickups.Items;
using UnityEngine;

public class ServerFeed : MonoBehaviour
{
	public GameObject serverFeedPrefab;

	public Transform content;

	private int numMaxPrefabs;

	private readonly List<ServerFeedPrefab> activePrefabs;

	private void Awake()
	{
	}

	private void OnDestroy()
	{
	}

	public void SetFeed(string text, float duration, Texture icon = null)
	{
	}

	private void TimeoutPrefab(ServerFeedPrefab prefab)
	{
	}

	private void OnItemAdded(EItem eItem)
	{
	}
}
