using System.Collections.Generic;
using Actors.Enemies;

namespace Assets.Scripts.Game.Spawning.New.Summoners;

public class StageSummoner : BaseSummoner
{
	private List<EEnemy> enemyPool;

	private float capReduction;

	public bool AddEnemyToPoolAndPickNewCard(List<EEnemy> eEnemy, out EEnemy selectedEnemy)
	{
		selectedEnemy = default(EEnemy);
		return false;
	}

	protected override void Init()
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

	public float GetBaseCreditsPerSecondUncapped()
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

	protected override bool ForceSpawn()
	{
		return false;
	}

	private bool IsGainingCredits()
	{
		return false;
	}

	private bool IsTargetEnemiesReached()
	{
		return false;
	}

	public StageSummoner(int id, List<EEnemy> defaultEnemies)
		: base(0, null)
	{
	}
}
