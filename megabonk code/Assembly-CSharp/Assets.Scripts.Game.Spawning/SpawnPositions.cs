using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Game.Spawning;

public static class SpawnPositions
{
	public static Vector3 INVALID_POS;

	private static RaycastHit[] spherecastBuffer;

	private static float nextFindBoundsTime;

	private static float minX;

	private static float minZ;

	private static float maxX;

	private static float maxZ;

	private static List<RaycastHit> myRaycastAllBuffer;

	private static RaycastHit[] myRaycastAllArrayBuffer;

	private static string layerNoSpawnArea;

	private static string layerCameraIgnore;

	private static string layerWater;

	private static string layerObject;

	private static string layerGround;

	private static string tagIgnore;

	public static Vector3 GetEnemySpawnPosition(EnemyData enemyData, int attempts = 50, bool useDirectionBias = true)
	{
		return default(Vector3);
	}

	public static Vector3 GetPositionAroundPlayer(float maxDistance)
	{
		return default(Vector3);
	}

	public static Vector3 GetEnemySpawnPositionTest(EnemyData enemyData, int attempts = 50)
	{
		return default(Vector3);
	}

	private static void GetSpawnDistances(out float min, out float max)
	{
		min = default(float);
		max = default(float);
	}

	private static void FindBounds()
	{
	}

	private static Vector3 GetEnemySpawnPositionBiased(EnemyData enemyData, float playerDirectionBias, int attempts = 50, float maxDistance = 3.4028235E+38f)
	{
		return default(Vector3);
	}

	private static RaycastHit[] MyRaycastAll(Vector3 origin, Vector3 dir, int layerMask, float maxDistance = 9999f, int maxHits = 10)
	{
		return null;
	}

	public static Vector3 GetEnemySpawnPositionAroundPoint(Vector3 pos, float minRadius, float maxRadius, int attempts = 50, bool onlyGround = false, float fromHeight = 999f)
	{
		return default(Vector3);
	}

	private static Vector3 SampleBiasedDirection(Vector3 biasedTowards, float bias)
	{
		return default(Vector3);
	}

	private static Vector3 GetPlayerMovementDirection()
	{
		return default(Vector3);
	}

	public static Vector3 GetPositionAroundPoint(Vector3 center, float minRadius, float maxRadius, float spherecastRadius, int attempts = 50)
	{
		return default(Vector3);
	}

	public static Vector3 GetObjectSpawnPosition(Vector3 center, Vector3 size, float checkRadius, int layerMask, out Vector3 normal, int attempts = 50, bool onlyUseGroundLayer = true, bool debug = false, bool canSpawnInWater = false, float maxSlopeAngle = 44f, float extraRayFromHeight = 0f)
	{
		normal = default(Vector3);
		return default(Vector3);
	}

	private static bool TryGetPosition(Vector3 pos, float checkRadius, int layerMask, out Vector3 hitPoint, out Vector3 normal, bool onlyUseGroundLayer = true, bool canSpawnInWater = false, float maxSlopeAngle = 90f)
	{
		hitPoint = default(Vector3);
		normal = default(Vector3);
		return false;
	}

	public static RaycastHit FindHitClosestToPlayerY(RaycastHit[] hits, out bool foundPosition, bool canChooseObject = true)
	{
		foundPosition = default(bool);
		return default(RaycastHit);
	}

	public static Vector3 PredictPlayerPosition(float time)
	{
		return default(Vector3);
	}

	public static Vector3 GetRandomSpawnPositionOnMap(float extraHeight = 0f)
	{
		return default(Vector3);
	}
}
