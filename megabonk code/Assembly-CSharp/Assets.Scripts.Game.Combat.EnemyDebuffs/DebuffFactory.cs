using System.Collections.Generic;
using Assets.Scripts.Actors;
using Assets.Scripts.Actors.Enemies;
using UnityEngine.Pool;

namespace Assets.Scripts.Game.Combat.EnemyDebuffs;

public static class DebuffFactory
{
	private sealed class _003C_003Ec__DisplayClass5_0
	{
		public EDebuff eDebuff;

		public ObjectPool<EnemyDebuff> newPool;

		public int maxObjects;

		internal EnemyDebuff _003CCreatePool_003Eb__0()
		{
			return null;
		}
	}

	private static Dictionary<EDebuff, ObjectPool<EnemyDebuff>> debuffPools;

	private static int created;

	private static int returned;

	private static int getted;

	public static void Init()
	{
	}

	public static void Cleanup()
	{
	}

	public static void Reset()
	{
	}

	public static EnemyDebuff GetDebuff(EDebuff eDebuff, Enemy enemy, DamageContainer dc, float duration, int stacks)
	{
		return null;
	}

	private static ObjectPool<EnemyDebuff> CreatePool(EDebuff eDebuff, int maxObjects)
	{
		return null;
	}

	private static EnemyDebuff CreatePooledItem(EDebuff eDebuff, ObjectPool<EnemyDebuff> pool, int maxSize)
	{
		return null;
	}

	public static void ReturnDebuff(EDebuff eDebuff, EnemyDebuff enemyDebuff)
	{
	}

	private static EnemyDebuff CreateDebuff(EDebuff eDebuff)
	{
		return null;
	}

	private static void OnTakeFromPool(EnemyDebuff obj)
	{
	}

	private static void OnReturnedToPool(EnemyDebuff obj)
	{
	}

	private static void OnDestroyPoolObject(EnemyDebuff obj)
	{
	}
}
