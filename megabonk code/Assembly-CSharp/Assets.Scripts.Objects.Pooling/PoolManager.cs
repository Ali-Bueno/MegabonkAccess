using System.Collections.Generic;
using Assets.Scripts.Game.Combat.EnemySpecialAttacks;
using Assets.Scripts.Game.Combat.EnemySpecialAttacks.Implementations;
using Assets.Scripts.Inventory__Items__Pickups.Weapons;
using Assets.Scripts.Inventory__Items__Pickups.Weapons.Attacks;
using Assets.Scripts.Inventory__Items__Pickups.Weapons.Projectiles;
using UnityEngine;
using UnityEngine.Pool;

namespace Assets.Scripts.Objects.Pooling;

public class PoolManager : MonoBehaviour
{
	private sealed class _003C_003Ec__DisplayClass121_0
	{
		public PoolManager _003C_003E4__this;

		public GameObject hitPrefabToUse;

		public ObjectPool<GameObject> newPool;

		public int maxObjects;

		internal GameObject _003CCreateObjectPool_003Eb__0()
		{
			return null;
		}
	}

	private sealed class _003C_003Ec__DisplayClass122_0
	{
		public PoolManager _003C_003E4__this;

		public GameObject hitPrefabToUse;

		public ObjectPool<GameObject> newPool;

		public int maxObjects;

		public float timeoutTime;

		internal GameObject _003CCreateObjectPoolTimeout_003Eb__0()
		{
			return null;
		}
	}

	private sealed class _003C_003Ec__DisplayClass123_0
	{
		public PoolManager _003C_003E4__this;

		public EnemySpecialAttack specialAttack;

		public ObjectPool<GameObject> newPool;

		public int maxObjects;

		internal GameObject _003CGetEnemyAttack_003Eb__0()
		{
			return null;
		}
	}

	private sealed class _003C_003Ec__DisplayClass124_0
	{
		public PoolManager _003C_003E4__this;

		public EnemySpecialAttackPrefab enemyAttackPrefab;

		public ObjectPool<GameObject> newPool;

		public int maxObjects;

		internal GameObject _003CGetEnemyAttackFx_003Eb__0()
		{
			return null;
		}
	}

	public Transform damageNumbersParent;

	private static int maxCritPrefabs;

	private int maxBonkPrefabs;

	private int maxBulletHitPrefabs;

	private int maxHitNumbers;

	private int maxLightningStrikes;

	private int maxFirefields;

	public const int rocketPoolSize = 200;

	private int orbPoolSize;

	private int explosionPoolSize;

	private static int maxSilver;

	private static int cursedHitsPoolSize;

	private static int charmPoolSize;

	private static int eatPoolSize;

	public static PoolManager Instance;

	private int maxWarningSpheres;

	public GameObject xpPrefab;

	public GameObject goldPrefab;

	public GameObject silverPrefab;

	public GameObject enemyPrefab;

	public GameObject enemySpawnFxPrefab;

	public GameObject damageNumbersPrefab;

	public GameObject pickupEffectPrefab;

	public GameObject goldBurstPrefab;

	public GameObject critEffectPrefab;

	public GameObject lightningStrikePrefab;

	public GameObject footstepPrefab;

	public GameObject enemyStatusSymbolsPrefab;

	public ObjectPool<GameObject> xpPool;

	public ObjectPool<GameObject> goldPool;

	public ObjectPool<GameObject> silverPool;

	public ObjectPool<GameObject> enemyPool;

	public ObjectPool<GameObject> enemySpawnFxPool;

	public ObjectPool<GameObject> damageNumbersPool;

	public ObjectPool<GameObject> pickupeffectPool;

	public ObjectPool<GameObject> goldBurstPool;

	public ObjectPool<GameObject> critEffectPool;

	public ObjectPool<GameObject> lightningStrikePool;

	public ObjectPool<GameObject> footstepPool;

	public ObjectPool<GameObject> enemyStatusSymbolsPool;

	public ObjectPool<GameObject> powerupPool;

	public ObjectPool<GameObject> warningTubePool;

	public ObjectPool<GameObject> warningSpherePool;

	public ObjectPool<GameObject> bullseyePool;

	public ObjectPool<GameObject> poisonPool;

	public GameObject defaultHitPrefab;

	public GameObject powerupPrefab;

	public GameObject warningTube;

	public GameObject warningSphere;

	public GameObject bullseye;

	public GameObject poisonCloud;

	public Dictionary<EWeapon, ObjectPool<GameObject>> weaponAttackPools;

	public Dictionary<EWeapon, ObjectPool<GameObject>> projectilePools;

	public Dictionary<string, ObjectPool<GameObject>> projectileDonePools;

	public Dictionary<string, ObjectPool<GameObject>> projectileHitPools;

	public Dictionary<string, ObjectPool<GameObject>> enemyAttacksPools;

	public Dictionary<EEnemyAttack, ObjectPool<GameObject>> enemyAttacksFxPools;

	private int itemFxPoolSizes;

	public ObjectPool<GameObject> grandmaTonicPool;

	public ObjectPool<GameObject> megaCritPool;

	public ObjectPool<GameObject> executePool;

	public ObjectPool<GameObject> spicyMeatballPool;

	public ObjectPool<GameObject> chainLightningPool;

	public ObjectPool<GameObject> freezeFxPool;

	public ObjectPool<GameObject> firefieldPool;

	public ObjectPool<GameObject> rocketPool;

	public ObjectPool<GameObject> explosionPool;

	public ObjectPool<GameObject> bonkPool;

	public ObjectPool<GameObject> bulletHitPool;

	public ObjectPool<GameObject> cursedHitPool;

	public ObjectPool<GameObject> orbPool;

	public ObjectPool<GameObject> ghostPool;

	public ObjectPool<GameObject> angrySoulPool;

	public ObjectPool<GameObject> charmPool;

	public ObjectPool<GameObject> borgorPool;

	public ObjectPool<GameObject> eatPool;

	public ObjectPool<GameObject> bloodmarkPool;

	public ObjectPool<GameObject> cactusPool;

	public ObjectPool<GameObject> tumbleweedPool;

	public ObjectPool<GameObject> tumbleweedBreakPool;

	public ObjectPool<GameObject> quinMaskPool;

	public ObjectPool<GameObject> snekPool;

	public GameObject grandmaTonicFx;

	public GameObject megaCritFx;

	public GameObject spicyMeatballFx;

	public GameObject chainLightningFx;

	public GameObject freezeFx;

	public GameObject firefield;

	public GameObject rocket;

	public GameObject explosionFx;

	public GameObject bonkFx;

	public GameObject executeFx;

	public GameObject bulletHit;

	public GameObject cursedHit;

	public GameObject orb;

	public GameObject ghost;

	public GameObject angrySoul;

	public GameObject charmFx;

	public GameObject borgor;

	public GameObject eat;

	public GameObject bloodmark;

	public GameObject cactusFx;

	public GameObject tumbleweed;

	public GameObject tumbleweedBreak;

	public GameObject quinMaskFx;

	public GameObject snekFx;

	private Dictionary<GameObject, WeaponAttack> weaponAttacksDict;

	private Dictionary<GameObject, ProjectileBase> projectileDict;

	private Dictionary<GameObject, DamageNumbers> damageNumbersDict;

	private Dictionary<GameObject, AttackHit> attackHitsDict;

	private Dictionary<EWeapon, string> weaponStrings;

	private void Awake()
	{
	}

	private void Start()
	{
	}

	public DamageNumbers GetDamageNumber()
	{
		return null;
	}

	public WeaponAttack GetAttack(WeaponBase weaponBase)
	{
		return null;
	}

	public void ReturnAttack(WeaponAttack weaponAttack)
	{
	}

	public ProjectileBase GetProjectile(WeaponAttack weaponAttack)
	{
		return null;
	}

	public void ReturnProjectile(WeaponAttack weaponAttack, GameObject projectile)
	{
	}

	public AttackHit GetProjectileHit(string source, GameObject hitPrefab)
	{
		return null;
	}

	public GameObject GetProjectileDoneFx(EWeapon eWeapon, GameObject hitPrefab)
	{
		return null;
	}

	public GameObject GetProjectileDoneFx(string source, GameObject hitPrefab)
	{
		return null;
	}

	private ObjectPool<GameObject> CreateObjectPool(GameObject hitPrefabToUse, int maxObjects)
	{
		return null;
	}

	private ObjectPool<GameObject> CreateObjectPoolTimeout(GameObject hitPrefabToUse, int maxObjects, float timeoutTime)
	{
		return null;
	}

	public GameObject GetEnemyAttack(EnemySpecialAttack specialAttack)
	{
		return null;
	}

	public GameObject GetEnemyAttackFx(EnemySpecialAttackPrefab enemyAttackPrefab)
	{
		return null;
	}

	public void ReturnEnemyAttackFx(EnemyAttackEffectPrefab attackPrefab)
	{
	}

	public void ReturnEnemyAttack(EnemySpecialAttackPrefab specialAttackPrefab)
	{
	}

	private GameObject CreatePooledItem(GameObject prefab, ObjectPool<GameObject> pool, int maxSize)
	{
		return null;
	}

	private GameObject CreatePooledItemTimeout(GameObject prefab, ObjectPool<GameObject> pool, int maxSize, float time)
	{
		return null;
	}

	private void OnReturnedToPool(GameObject obj)
	{
	}

	private void OnTakeFromPool(GameObject obj)
	{
	}

	private void OnDestroyPoolObject(GameObject obj)
	{
	}

	private GameObject _003CStart_003Eb__107_0()
	{
		return null;
	}

	private GameObject _003CStart_003Eb__107_1()
	{
		return null;
	}

	private GameObject _003CStart_003Eb__107_2()
	{
		return null;
	}

	private GameObject _003CStart_003Eb__107_3()
	{
		return null;
	}

	private GameObject _003CStart_003Eb__107_4()
	{
		return null;
	}

	private GameObject _003CStart_003Eb__107_5()
	{
		return null;
	}

	private GameObject _003CStart_003Eb__107_6()
	{
		return null;
	}

	private GameObject _003CStart_003Eb__107_7()
	{
		return null;
	}

	private GameObject _003CStart_003Eb__107_8()
	{
		return null;
	}

	private GameObject _003CStart_003Eb__107_9()
	{
		return null;
	}

	private GameObject _003CStart_003Eb__107_10()
	{
		return null;
	}

	private GameObject _003CStart_003Eb__107_11()
	{
		return null;
	}

	private GameObject _003CStart_003Eb__107_12()
	{
		return null;
	}

	private GameObject _003CStart_003Eb__107_13()
	{
		return null;
	}

	private GameObject _003CStart_003Eb__107_14()
	{
		return null;
	}

	private GameObject _003CStart_003Eb__107_15()
	{
		return null;
	}

	private GameObject _003CStart_003Eb__107_16()
	{
		return null;
	}

	private GameObject _003CStart_003Eb__107_17()
	{
		return null;
	}

	private GameObject _003CStart_003Eb__107_18()
	{
		return null;
	}

	private GameObject _003CStart_003Eb__107_19()
	{
		return null;
	}

	private GameObject _003CStart_003Eb__107_20()
	{
		return null;
	}

	private GameObject _003CStart_003Eb__107_21()
	{
		return null;
	}

	private GameObject _003CStart_003Eb__107_22()
	{
		return null;
	}

	private GameObject _003CStart_003Eb__107_23()
	{
		return null;
	}

	private GameObject _003CStart_003Eb__107_24()
	{
		return null;
	}

	private GameObject _003CStart_003Eb__107_25()
	{
		return null;
	}

	private GameObject _003CStart_003Eb__107_26()
	{
		return null;
	}

	private GameObject _003CStart_003Eb__107_27()
	{
		return null;
	}

	private GameObject _003CStart_003Eb__107_28()
	{
		return null;
	}

	private GameObject _003CStart_003Eb__107_29()
	{
		return null;
	}

	private GameObject _003CStart_003Eb__107_30()
	{
		return null;
	}

	private GameObject _003CStart_003Eb__107_31()
	{
		return null;
	}

	private GameObject _003CStart_003Eb__107_32()
	{
		return null;
	}

	private GameObject _003CStart_003Eb__107_33()
	{
		return null;
	}

	private GameObject _003CStart_003Eb__107_34()
	{
		return null;
	}

	private GameObject _003CStart_003Eb__107_35()
	{
		return null;
	}

	private GameObject _003CStart_003Eb__107_36()
	{
		return null;
	}

	private GameObject _003CStart_003Eb__107_37()
	{
		return null;
	}

	private GameObject _003CStart_003Eb__107_38()
	{
		return null;
	}

	private GameObject _003CStart_003Eb__107_39()
	{
		return null;
	}

	private GameObject _003CStart_003Eb__107_40()
	{
		return null;
	}
}
