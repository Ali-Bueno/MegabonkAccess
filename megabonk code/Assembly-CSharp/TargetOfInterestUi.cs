using System.Collections.Generic;
using Assets.Scripts.Actors.Enemies;
using UnityEngine;

public class TargetOfInterestUi : MonoBehaviour
{
	public List<TargetOfInterestPrefab> prefabs;

	private HashSet<Enemy> activeTargets;

	private List<Enemy> queuedTargets;

	private Queue<Enemy> addTargetQueue;

	private void Awake()
	{
	}

	private void OnDestroy()
	{
	}

	private void OnTargetOfInterestSpawned(Enemy enemy)
	{
	}

	private void Update()
	{
	}

	private void DequeueEnemies(Enemy enemy)
	{
	}

	private void OnEnemyReleasedFromPool(Enemy enemy)
	{
	}

	private void RefreshPrefabs()
	{
	}
}
