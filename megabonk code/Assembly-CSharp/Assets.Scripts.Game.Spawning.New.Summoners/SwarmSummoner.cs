using System.Collections.Generic;
using Actors.Enemies;
using Assets.Scripts.Actors.Enemies;

namespace Assets.Scripts.Game.Spawning.New.Summoners;

public class SwarmSummoner : BaseSummoner
{
	private List<EEnemy> finalSwarmEnemies;

	public const float swarmSummonInterval = 0.5f;

	private int ghostTier;

	private bool hasSwappedEnemy;

	private List<Enemy> spawnedEnemies;

	private float swarmHpMultiplier;

	private float swarmSpeedMultiplier;

	protected override void Init()
	{
	}

	protected override void TickExtra()
	{
	}

	protected override List<EEnemy> GetEnemies()
	{
		return null;
	}

	public override float GetSummonInterval()
	{
		return 0f;
	}

	public override float GetBaseCreditsPerSecond()
	{
		return 0f;
	}

	public override float GetInitialCredits()
	{
		return 0f;
	}

	public override int GetNumTargetEnemies()
	{
		return 0;
	}

	protected override bool UseDirectionBias()
	{
		return false;
	}

	public override List<Enemy> SpendCredits(bool useWeights = true)
	{
		return null;
	}

	protected override bool ForceSpawn()
	{
		return false;
	}

	public SwarmSummoner(int id, List<EEnemy> defaultEnemies)
		: base(0, null)
	{
	}
}
