using System;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Actors;
using Assets.Scripts.Actors.Enemies;
using Assets.Scripts.Inventory__Items__Pickups;
using Assets.Scripts.Inventory__Items__Pickups.Items;
using Assets.Scripts.Inventory__Items__Pickups.Pickups;
using Assets.Scripts.Saves___Serialization.Progression.Achievements;
using Assets.Scripts.UI.InGame.Rewards;
using UnityEngine;

public class EffectManager : MonoBehaviour
{
	[Serializable]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9;

		internal EWeapon _003C_002Ecctor_003Eb__117_0(EWeapon w)
		{
			return default(EWeapon);
		}

		internal string _003C_002Ecctor_003Eb__117_1(EWeapon w)
		{
			return null;
		}
	}

	private sealed class _003CDoSpawnRockets_003Ed__90 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public float damage;

		public float procCoefficient;

		public string damageSource;

		public int num;

		private int _003Ci_003E5__2;

		object IEnumerator<object>.Current => null;

		object IEnumerator.Current => null;

		public _003CDoSpawnRockets_003Ed__90(int _003C_003E1__state)
		{
		}

		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			return false;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		void IEnumerator.Reset()
		{
		}
	}

	private sealed class _003CExploderDeath_003Ed__69 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public EffectManager _003C_003E4__this;

		public Enemy enemy;

		private float _003CexplosionRadius_003E5__2;

		private float _003CinflationTime_003E5__3;

		private float _003Ctimer_003E5__4;

		private float _003CrotationSpeed_003E5__5;

		private Vector3 _003CdefaultScale_003E5__6;

		private Vector3 _003CdesiredScale_003E5__7;

		private float _003CrotationTimer_003E5__8;

		object IEnumerator<object>.Current => null;

		object IEnumerator.Current => null;

		public _003CExploderDeath_003Ed__69(int _003C_003E1__state)
		{
		}

		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			return false;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		void IEnumerator.Reset()
		{
		}
	}

	public GameObject nukePickup;

	public GameObject magnetPickup;

	public GameObject hastePickup;

	public GameObject ragePickup;

	public GameObject shieldPickup;

	public GameObject stonksPickup;

	public GameObject healthPickup;

	public GameObject playerDamage;

	public GameObject playerLandHard;

	public GameObject smokeHit;

	public GameObject goldSkeletonBreakEffect;

	public GameObject xpSkeletonBreakEffect;

	public GameObject pickupOrbFx;

	public GameObject chestPickup;

	public GameObject chestDiscard;

	public GameObject openChestNormal;

	public GameObject openChestGhost;

	public GameObject wuiFreeChest;

	public GameObject magnetFx;

	public GameObject electricPlugFx;

	public GameObject bananaQuest;

	public GameObject luckTomeQuest;

	public GameObject shotgunQuest;

	public GameObject katanaQuest;

	public GameObject campfire;

	public GameObject banishFx;

	public GameObject stealItemWui;

	public GameObject giveItemWui;

	public GameObject mirrorFx;

	public GameObject zapEffect;

	public GameObject desertStormFx;

	public GameObject tornado;

	public GameObject tumbleweed;

	public GameObject monkeCage;

	public GameObject monkeCageKey;

	public GameObject bushQuest;

	public GameObject banditQuest;

	public GameObject boomboxQuest;

	public GameObject presentQuest;

	public GameObject blindSphere;

	public GameObject floorIsLava;

	public GameObject gloveLightning;

	public GameObject glovePoison;

	public GameObject gloveBlood;

	public GameObject gloveCurse;

	public GameObject glovePower;

	public GameObject cryptKey;

	public GameObject testArrow;

	public GameObject[] desertGraves;

	public GameObject lanternExplosion;

	private List<EffectStat> effectStatsQueue;

	public static EffectManager Instance;

	private EffectPlayer playerDamageFx;

	private float nextBloodTimeReady;

	private float bloodCooldown;

	private string critText;

	private string megaCritText;

	public HashSet<Enemy> currentlyExplodingEnemy;

	private AttackHit attackHit;

	private static readonly Dictionary<EWeapon, string> weaponNamesCache;

	public GameObject americanExplosionEffect;

	public GameObject americanExplosionEffectStart;

	private float baseChestDropChance;

	private float lastChestAtTime;

	private EffectPlayer electricPlugEffect;

	private EffectPlayer activeMirrorFx;

	private EffectPlayer activeZapFx;

	private DesertStorm desertStorm;

	public GameObject spawnedLuckTomeObject;

	public GameObject spawnedShotgunObject;

	public GameObject spawnedKatanaObject;

	private Dictionary<GameObject, ItemProjectile> activeGhostProjectiles;

	private bool hasSpawnedFirstEliteChest;

	private void Awake()
	{
	}

	public void PlayerLandHard()
	{
	}

	private void OnDamage(PlayerHealth ph, DamageContainer dc, bool shieldDamage)
	{
	}

	public void NewDamageNumbers(DamageContainer dc, Enemy enemy)
	{
	}

	public void PopupText(string text, Color color, Vector3 position, int textSize = 24)
	{
	}

	public void PopupText(float damage, Color color, Vector3 position, int textSize = 24)
	{
	}

	public void PickupEffect()
	{
	}

	public void GoldBurstEffect(Vector3 position)
	{
	}

	private void OnEnemyDied(Enemy enemy, DamageContainer deathSource)
	{
	}

	private void OnEnemyDamage(Enemy enemy, DamageContainer dc)
	{
	}

	public void ExploderEnemy(Enemy enemy)
	{
	}

	private IEnumerator ExploderDeath(Enemy enemy)
	{
		return null;
	}

	public void OnHeal(PlayerHealth ph, float value, bool isShield)
	{
	}

	public void EnemyHitEffect(Vector3 hitPos, Vector3 moveDir, bool hitEnemy, string source, GameObject weaponHitEffect, bool useSfx)
	{
	}

	public void EnemyHitEffect(Vector3 hitPos, Vector3 moveDir, bool hitEnemy, EWeapon eWeapon, GameObject weaponHitEffect, bool useSfx)
	{
	}

	public void SpawnPickupOrb(EPickup ePickup, Vector3 position)
	{
	}

	public CircleWarning WarningSphere(Vector3 position, float radius, float time, Action completeAction)
	{
		return null;
	}

	public bool WarningTube(Vector3 position, Vector3 dir, float radius, float distance, float time, Action completeAction)
	{
		return false;
	}

	private void CheckChestSpawn(Enemy enemy)
	{
	}

	public void SpawnChest(GameObject chestPrefab, Vector3 pos)
	{
	}

	private float GetChestDropChance(Enemy enemy)
	{
		return 0f;
	}

	private float GetChestDropTimeMultiplier()
	{
		return 0f;
	}

	private void OnItemRemoved(EItem item, bool showEffect)
	{
	}

	private void OnItemAdded(EItem item)
	{
	}

	public void BanishItem(UnlockableBase unlockable)
	{
	}

	public void SpawnRockets(int num, float damage, float procCoefficient, string damageSource)
	{
	}

	private IEnumerator DoSpawnRockets(int num, float damage, float procCoefficient, string damageSource)
	{
		return null;
	}

	public void MagnetEffect()
	{
	}

	public void ElectricalPlugEffect()
	{
	}

	public void SpawnMirrorFx(Vector3 pos, Vector3 dir, float size)
	{
	}

	public void ZapEffect(Vector3 pos)
	{
	}

	public DesertStorm GetDesertStorm()
	{
		return null;
	}

	public void SpawnTornadoes(int amount)
	{
	}

	public void SpawnTumbleWeeds(int amount)
	{
	}

	public void TrySpawnLuckQuest(Vector3 pos)
	{
	}

	public void TrySpawnShotgunQuest(Vector3 pos)
	{
	}

	public void TrySpawnKatanaQuest(Vector3 pos)
	{
	}

	public void TakeItem(UnlockableBase data, Transform target, Vector3 targetOffset, float hoverTime = 1f, float moveTime = 1f, float scale = 1f)
	{
	}

	public void GiveItem(UnlockableBase data)
	{
	}

	private void OnMapGenerationComplete()
	{
	}

	public void SpawnGhostProjectile(float damage, float duration, string damageSource)
	{
	}

	private void OnDestroy()
	{
	}

	private void OnPickup(Pickup pickup)
	{
	}
}
