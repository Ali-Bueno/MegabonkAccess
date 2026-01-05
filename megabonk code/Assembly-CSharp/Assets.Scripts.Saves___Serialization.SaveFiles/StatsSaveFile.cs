using System;
using System.Collections.Generic;
using Actors.Enemies;
using Assets.Scripts.Saves___Serialization.Progression;
using Assets.Scripts.Saves___Serialization.Progression.Stats;

namespace Assets.Scripts.Saves___Serialization.SaveFiles;

[Serializable]
public class StatsSaveFile
{
	public Dictionary<string, MyStat> stats;

	public Dictionary<EEnemy, EnemyLog> enemyLogs;

	public Dictionary<ESpeedrunTime, float> times;

	public void Init()
	{
	}
}
