using System;
using System.Collections.Generic;
using Assets.Scripts.Actors;
using Assets.Scripts.Actors.Enemies;
using UnityEngine;

public class FinalFightController : MonoBehaviour
{
	public Transform bossSpawnPoint;

	public Enemy boss;

	public BossPylon[] pylons;

	private List<BossPylon> activePylons;

	public GameObject orbFollowing;

	public GameObject orbShooty;

	public GameObject orbBleed;

	public GameObject stealWeaponWui;

	public AudioSource audioPylonsSpawn;

	public static Action<bool> A_BossDefeated;

	public static bool isFightingFinalBoss;

	private int numWeaponsToTake;

	private int numWeaponsTaken;

	private float takeWeaponAtTime;

	private float weaponTakeInterval;

	private float healInterval;

	private float nextHealTime;

	private float bossDeadGracePeriod;

	private int _003CcurrentPhase_003Ek__BackingField;

	private float nextOrbsFollowingTime;

	private float nextOrbsShootyTime;

	private float nextOrbsBleedTime;

	private float lastSpecialAttackTime;

	private float goonsDeadAtTime;

	private float goonSpawnInterval;

	private List<Enemy> goons;

	public static Action A_PylonsStarted;

	public bool isBossDefeated => false;

	public int currentPhase
	{
		get
		{
			return _003CcurrentPhase_003Ek__BackingField;
		}
		private set
		{
			_003CcurrentPhase_003Ek__BackingField = value;
		}
	}

	private void Awake()
	{
	}

	private void OnDestroy()
	{
	}

	public void SpawnBoss()
	{
	}

	private void FixedUpdate()
	{
	}

	private void TakeWeapons()
	{
	}

	private void OnEnemyReleasedFromPool(Enemy enemy)
	{
	}

	private void OnPlayerDied()
	{
	}

	private void StartPhase(int phase)
	{
	}

	public void TakeWeapon()
	{
	}

	private void GiveWeaponBack()
	{
	}

	private void SpecialAttacks()
	{
	}

	private void SpawnOrbsFollowing()
	{
	}

	private void SpawnOrbsShooty()
	{
	}

	private void SpawnOrbsBleed()
	{
	}

	private int GetNumOrbs()
	{
		return 0;
	}

	private void IgnoreCollisions(List<GameObject> orbs)
	{
	}

	private void SpawnGoons()
	{
	}

	private bool ArePylonsActive()
	{
		return false;
	}

	private void OnPylonCharged(BossPylon pylon)
	{
	}

	private void PylonsDone()
	{
	}

	private void StartPylons()
	{
	}

	private void PylonHealing()
	{
	}

	private void OnEnemyDamage(Enemy enemy, DamageContainer dc)
	{
	}
}
