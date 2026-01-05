using Assets.Scripts.Actors;
using Assets.Scripts.Actors.Enemies;
using Assets.Scripts.Inventory__Items__Pickups.Pickups;
using UnityEngine;

public class PickupManager : MonoBehaviour
{
	public LayerMask whatIsPickups;

	public GameObject hastePrefab;

	public GameObject healthPrefab;

	public GameObject magnetPrefab;

	public GameObject nukePrefab;

	public GameObject ragePrefab;

	public GameObject shieldPrefab;

	public GameObject stonksPrefab;

	public GameObject timeFreezePrefab;

	private PickupStackableList xpList;

	private PickupStackableList goldList;

	private float stackRadius;

	private float stackRadiusMin;

	private float stackRadiusMax;

	private float stackRadiusMaxTime;

	public static int maxXpObjects;

	public static int maxGoldObjects;

	public static PickupManager Instance;

	private Vector3 hoverHeight;

	private EPickup[] powerups;

	private float lastPowerupAtTime;

	public static int maxPowerupsOnMap;

	private int numPowerupsOnMap;

	private static readonly Collider[] overlapResults;

	private void Awake()
	{
	}

	private void OnDestroy()
	{
	}

	private void SlowUpdate()
	{
	}

	private void OnEnemyDied(Enemy enemy, DamageContainer deathSource)
	{
	}

	private EPickup GetRandomPowerup()
	{
		return default(EPickup);
	}

	private float GetPowerupDropChance(Enemy enemy)
	{
		return 0f;
	}

	private float GetPowerupTimeMultiplier()
	{
		return 0f;
	}

	public Pickup SpawnPickup(EPickup ePickup, Vector3 pos, int value, bool useRandomOffsetPosition = true, float pickupDelay = 0f)
	{
		return null;
	}

	public void CountAdd()
	{
	}

	public void PowerupCountRemove()
	{
	}

	public bool CanSpawnPowerup()
	{
		return false;
	}

	private Pickup SpawnPooledPickup(EPickup ePickup)
	{
		return null;
	}

	public void PickupTriggered(Pickup pickup)
	{
	}

	public void PickupAllXp()
	{
	}

	private bool CheckOverlap(EPickup ePickup, Vector3 pos, out Pickup overlappingPickup)
	{
		overlappingPickup = null;
		return false;
	}

	public GameObject GetNewPickup(EPickup pickup, Vector3 pos)
	{
		return null;
	}

	public void DespawnPickup(Pickup pickup)
	{
	}
}
