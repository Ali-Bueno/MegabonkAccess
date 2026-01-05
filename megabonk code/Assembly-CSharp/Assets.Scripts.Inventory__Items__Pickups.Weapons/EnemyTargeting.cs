using System;
using System.Collections.Generic;
using Assets.Scripts.Actors.Enemies;
using UnityEngine;

namespace Assets.Scripts.Inventory__Items__Pickups.Weapons;

public static class EnemyTargeting
{
	private static int currentBufferCount;

	private static Collider[] enemyBuffer;

	private static RaycastHit[] losBuf;

	private static EnemyScanContainer currentBufferContainer;

	private static readonly Dictionary<Type, Collider[]> buffers;

	private static readonly object nullType;

	private static readonly RaycastHit[] raycastBuffer;

	public static void Init()
	{
	}

	public static void Cleanup()
	{
	}

	private static void Reset()
	{
	}

	public static int GetEnemiesInRadiusSafe(object owner, Vector3 pos, float range, out Collider[] buffer)
	{
		buffer = null;
		return 0;
	}

	public static Enemy GetEnemy(Vector3 position, float range, int projectileIndex, bool useVision, GameObject exceptObject)
	{
		return null;
	}

	public static Enemy GetRandomEnemyInRadius(Vector3 position, float range, bool useVision, GameObject exceptObject)
	{
		return null;
	}

	private static int GetEnemiesInRadius(Vector3 position, float range, out Collider[] enemies)
	{
		enemies = null;
		return 0;
	}

	private static Enemy GetTargetedEnemy(Collider[] colliders, int count, Vector3 pos, bool useVision, GameObject exceptObject)
	{
		return null;
	}

	private static Enemy GetSmartEnemy(Collider[] colliders, int count, Vector3 pos, bool useVision, GameObject exceptObject)
	{
		return null;
	}

	private static Enemy GetClosestEnemy(Collider[] colliders, int count, Vector3 pos, bool useVision, GameObject exceptObject)
	{
		return null;
	}

	private static Enemy GetRandomEnemy(Collider[] colliders, int count, Vector3 pos, bool useVision, GameObject exceptObject)
	{
		return null;
	}

	private static bool ShouldPickRandom(int idx, float ratio)
	{
		return false;
	}
}
