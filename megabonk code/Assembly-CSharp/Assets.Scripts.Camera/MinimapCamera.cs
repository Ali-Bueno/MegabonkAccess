using System;
using System.Collections.Generic;
using Assets.Scripts.Actors.Enemies;
using UnityEngine;

namespace Assets.Scripts.Camera;

public class MinimapCamera : MonoBehaviour
{
	public Transform playerIcon;

	public Transform arrowPrefab;

	public bool staticOrientation;

	private Vector3 staticRotation;

	public UnityEngine.Camera minimapCamera;

	private bool bossSpotted;

	private Transform bossSpawner;

	public static Action<float> A_RotationUpdated;

	private Quaternion lastRotation;

	private Color bossColor;

	private Color portalColor;

	private Dictionary<Transform, MinimapArrow> arrowDict;

	private void Start()
	{
	}

	private void OnDestroy()
	{
	}

	private void OnEnemySpawn(Enemy enemy)
	{
	}

	private void OnEnemyDied(Enemy enemy)
	{
	}

	private void TryFindBossSpawner()
	{
	}

	private void Update()
	{
	}

	private void StaticOrientation()
	{
	}

	private void DynamicOrientation()
	{
	}

	private void UpdateArrows()
	{
	}

	private void TrySpotBossSpawner()
	{
	}

	public void AddArrow(Transform target, Color color)
	{
	}

	public void RemoveArrow(Transform transform)
	{
	}

	private void OnBossSpawnerInteract()
	{
	}

	private void OnBossSpawnerCompleted(bool openedPortal)
	{
	}
}
