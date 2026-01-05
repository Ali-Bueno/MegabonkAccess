using System;
using System.Collections.Generic;
using Actors.Enemies;
using Assets.Scripts.Actors.Enemies;
using Assets.Scripts.Game.Spawning.New.Summoners;
using Assets.Scripts.Game.Spawning.New.Timelines;
using UnityEngine;

namespace Assets.Scripts.Game.Spawning.New;

public class SummonerController
{
	public StageSummoner stageSummoner;

	private SpecialSkeletonSummoner specialSkeletonSummoner;

	private BaseSummoner swarmSummoner;

	private BaseSummoner finalSwarmSummoner;

	private List<BaseSummoner> summoners;

	private int id;

	private int currentTimelineEvent;

	private StageTimeline timeline;

	public static Action A_SwarmStarted;

	public static Action A_FinalSwarmStarted;

	public static Action A_MiniBoss;

	public static Action A_FinalSwarmStopped;

	private float lastAddedNewEnemyTime;

	private bool hadEventThisTick;

	private float swarmOverAtTime;

	private int _003CminibossCount_003Ek__BackingField;

	private List<EEnemy> minibossPool;

	private bool isFinalSwarmStarted;

	private float bossDeadGracePeriod;

	private bool isFinalBossDead;

	private bool areSummonersDestroyed;

	public int minibossCount
	{
		get
		{
			return _003CminibossCount_003Ek__BackingField;
		}
		private set
		{
			_003CminibossCount_003Ek__BackingField = value;
		}
	}

	public void Tick()
	{
	}

	public float GetMaxTimeLength()
	{
		return 0f;
	}

	private void TickTimeline()
	{
	}

	public float GetStageTimeMax()
	{
		return 0f;
	}

	private bool AreEventsDisabled()
	{
		return false;
	}

	private void TryAddNewEnemyCard()
	{
	}

	public void StartEvent(int eventIndex)
	{
	}

	private void EventSwarm(TimelineEvent timelineEvent)
	{
	}

	public void EventMiniboss(TimelineEvent timelineEvent)
	{
	}

	private bool CanAddNewEnemyCard()
	{
		return false;
	}

	public bool IsFinalSwarm()
	{
		return false;
	}

	private void StartFinalSwarm()
	{
	}

	public void StopFinalSwarm()
	{
	}

	private void AddSummoner(BaseSummoner summoner)
	{
	}

	private void DestroySummoner(BaseSummoner summoner)
	{
	}

	public List<Enemy> SpawnStageBoss(Vector3 pos)
	{
		return null;
	}

	private void OnBossDied(bool isLastStage)
	{
	}

	private void TryStopSummoners()
	{
	}

	public void Cleanup()
	{
	}
}
