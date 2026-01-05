using System;
using System.Collections.Generic;
using Actors.Enemies;
using Assets.Scripts.Actors.Enemies;
using Assets.Scripts.Game.Spawning.New;
using UnityEngine;

namespace Assets.Scripts.Managers;

public class EnemyManager : MonoBehaviour
{
	public EnemyData testEnemy;

	public Dictionary<uint, Enemy> enemies;

	public Dictionary<Collider, Enemy> collidersToEnemies;

	public Dictionary<GameObject, Enemy> gameobjectsToEnemies;

	private Dictionary<int, int> waveEnemies;

	private uint id;

	public static EnemyManager Instance;

	public bool enabledWaves;

	public SummonerController summonerController;

	private List<Enemy> stageBosses;

	public static Action A_StageBossDied;

	private bool _003CstageBossIsDead_003Ek__BackingField;

	public static int maxNumEnemiesPooled;

	public int numEnemies;

	private float nextDebuffTickTime;

	private float zoomValue;

	private float currentValue;

	private bool started;

	public bool stageBossIsDead
	{
		get
		{
			return _003CstageBossIsDead_003Ek__BackingField;
		}
		private set
		{
			_003CstageBossIsDead_003Ek__BackingField = value;
		}
	}

	private void Awake()
	{
	}

	private void Start()
	{
	}

	private void OnDestroy()
	{
	}

	public Enemy SpawnEnemy(EnemyData enemyData, int summonerId, bool forceSpawn, EEnemyFlag flag = EEnemyFlag.None, bool useDirectionBias = true)
	{
		return null;
	}

	public Enemy SpawnEnemy(EnemyData enemyData, Vector3 pos, int waveNumber, bool forceSpawn = false, EEnemyFlag flag = EEnemyFlag.None, bool canBeElite = true, float extraSizeMultiplier = 1f)
	{
		return null;
	}

	public Enemy SpawnBoss(EEnemy eEnemy, int summonerId, EEnemyFlag enemyFlag, Vector3 pos, float extraSizeMultiplier = 1f)
	{
		return null;
	}

	public void RemoveEnemy(Enemy enemy)
	{
	}

	private void StageBossDied()
	{
	}

	public bool CanSpawnEnemy()
	{
		return false;
	}

	public bool HasMaxEnemies()
	{
		return false;
	}

	public int GetNumMaxEnemies()
	{
		return 0;
	}

	public int GetNumEnemies()
	{
		return 0;
	}

	public int GetEnemiesFromSummoner(int wave)
	{
		return 0;
	}

	public bool IsFinalSwarm()
	{
		return false;
	}

	private void Update()
	{
	}

	private void FixedUpdate()
	{
	}

	public bool GetEnemy(Collider collider, out Enemy enemy)
	{
		enemy = null;
		return false;
	}

	public bool GetEnemy(GameObject enemyObject, out Enemy enemy)
	{
		enemy = null;
		return false;
	}

	private void TestSpawnEnemy()
	{
	}
}
