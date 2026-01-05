using System;
using System.Collections.Generic;
using Actors.Enemies;

namespace Assets.Scripts.Game.Spawning.New.Timelines;

[Serializable]
public class StageTimeline
{
	[Serializable]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9;

		public static Comparison<TimelineEvent> _003C_003E9__7_0;

		internal int _003CSort_003Eb__7_0(TimelineEvent x, TimelineEvent y)
		{
			return 0;
		}
	}

	public float stageTime;

	public float checkNewEnemyInterval;

	public List<EEnemy> startEnemies;

	public List<TimelineEvent> events;

	public EnemyData boss;

	public List<EEnemy> minibosses;

	public float GetStageTime()
	{
		return 0f;
	}

	public void Sort()
	{
	}
}
