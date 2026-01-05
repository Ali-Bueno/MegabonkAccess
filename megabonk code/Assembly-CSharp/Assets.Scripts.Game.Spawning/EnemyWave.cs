using System;
using System.Collections.Generic;
using Actors.Enemies;

namespace Assets.Scripts.Game.Spawning;

[Serializable]
public class EnemyWave
{
	public EWaveType eWaveType;

	public List<EEnemy> enemies;

	public List<EnemyData> enemyDatas;

	public int waveTime;

	public int minNumEnemies;

	public float spawnInterval;

	public override string ToString()
	{
		return null;
	}

	public float EnemiesPerSecond()
	{
		return 0f;
	}
}
