using System;
using System.Collections.Generic;
using Actors.Enemies;
using Assets.Scripts.Actors.Enemies;
using Assets.Scripts.Menu.Shop;

namespace Assets.Scripts.Game.Spawning.New;

public abstract class BaseSummoner
{
	[Serializable]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9;

		public static Comparison<EnemyCard> _003C_003E9__21_0;

		public static Comparison<EnemyCard> _003C_003E9__22_0;

		public static Func<EnemyCard, float> _003C_003E9__27_0;

		public static Func<EnemyCard, float> _003C_003E9__27_1;

		internal int _003CGenerateCards_003Eb__21_0(EnemyCard card1, EnemyCard card2)
		{
			return 0;
		}

		internal int _003CRefreshCardWeights_003Eb__22_0(EnemyCard card1, EnemyCard card2)
		{
			return 0;
		}

		internal float _003CGetRandomCard_003Eb__27_0(EnemyCard c)
		{
			return 0f;
		}

		internal float _003CGetRandomCard_003Eb__27_1(EnemyCard card)
		{
			return 0f;
		}
	}

	protected float credits;

	private List<EnemyCard> cards;

	private float giveCreditsTimer;

	private float spendCreditsTimer;

	public const int maxEnemiesPerSecond = 500;

	public const int maxEnemiesPerCycle = 200;

	protected int enemiesThisSecond;

	private int nextSecond;

	protected int id;

	public bool slowmode;

	private float slowmodeMultiplier;

	private float slowmodeOverAtTime;

	private bool isWaveMode;

	private float waveModeOverAtTime;

	private List<EnemyCard> waveModeCards;

	protected List<EEnemy> currentEnemies;

	private List<Enemy> spawnedEnemies;

	public BaseSummoner(int id, List<EEnemy> defaultEnemies)
	{
	}

	public void Cleanup()
	{
	}

	public void Tick()
	{
	}

	protected virtual void TickExtra()
	{
	}

	protected void GenerateCardsForSummoner(List<EEnemy> enemies)
	{
	}

	protected virtual List<EnemyCard> GenerateCards(List<EEnemy> enemies)
	{
		return null;
	}

	private void RefreshCardWeights()
	{
	}

	public void AddCredits()
	{
	}

	public float GetCreditsPerSecond()
	{
		return 0f;
	}

	public virtual List<Enemy> SpendCredits(bool useWeights = true)
	{
		return null;
	}

	protected EnemyCard GetRandomCard(bool useWeights)
	{
		return null;
	}

	public void SetSlowmode(float multiplier, float duration)
	{
	}

	public void SetWaveMode(List<EEnemy> waveEnemies, float duration)
	{
	}

	protected float GetMultiplier()
	{
		return 0f;
	}

	protected virtual bool UseMultiplier()
	{
		return false;
	}

	private bool CanEarnCredits()
	{
		return false;
	}

	private void OnStatUpdated(EStat stat)
	{
	}

	private void OnPlayerInventoryInitialized(PlayerInventory playerInventory)
	{
	}

	protected abstract void Init();

	protected abstract List<EEnemy> GetEnemies();

	public abstract float GetSummonInterval();

	public abstract float GetBaseCreditsPerSecond();

	public abstract float GetInitialCredits();

	public abstract int GetNumTargetEnemies();

	protected abstract bool UseDirectionBias();

	protected abstract bool ForceSpawn();
}
