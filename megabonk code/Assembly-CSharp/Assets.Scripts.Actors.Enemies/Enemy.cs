using System;
using System.Collections;
using System.Collections.Generic;
using Actors.Enemies;
using Assets.Scripts.Game.Combat.EnemyDebuffs;
using Assets.Scripts.Game.Combat.EnemySpecialAttacks;
using Assets.Scripts.Inventory__Items__Pickups.Stats;
using UnityEngine;

namespace Assets.Scripts.Actors.Enemies;

public class Enemy : MonoBehaviour
{
	private sealed class _003CDespawn_003Ed__111 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public Enemy _003C_003E4__this;

		private float _003Ctime_003E5__2;

		private float _003CdesiredHeight_003E5__3;

		private Vector3 _003ClocalPos_003E5__4;

		object IEnumerator<object>.Current => null;

		object IEnumerator.Current => null;

		public _003CDespawn_003Ed__111(int _003C_003E1__state)
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

	private sealed class _003CStartTeleporting_003Ed__110 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public Enemy _003C_003E4__this;

		public bool skipStart;

		public Vector3 toPosition;

		private float _003Ctime_003E5__2;

		private float _003CdesiredHeight_003E5__3;

		private Vector3 _003ClocalPos_003E5__4;

		object IEnumerator<object>.Current => null;

		object IEnumerator.Current => null;

		public _003CStartTeleporting_003Ed__110(int _003C_003E1__state)
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

	private EnemyData _003CenemyData_003Ek__BackingField;

	public AnimatedMesh animatedMesh;

	public Renderer renderer;

	public EnemyRenderer enemyRenderer;

	private float _003CmeshHeight_003Ek__BackingField;

	private float _003CmeshRadius_003Ek__BackingField;

	public Rigidbody rb;

	public CapsuleCollider collider;

	public EnemyMovementRb enemyMovement;

	public Material whiteMaterial;

	public EnemyDissolve dissolve;

	private float flashTime;

	private Vector3 _003CfeetOffset_003Ek__BackingField;

	private float _003Chp_003Ek__BackingField;

	public float maxHp;

	private uint _003Cid_003Ek__BackingField;

	private int _003CwaveNumber_003Ek__BackingField;

	private Rigidbody _003Ctarget_003Ek__BackingField;

	private float despawnAtTime;

	private float _003CspawnedAtTime_003Ek__BackingField;

	public EEnemyState state;

	private float eliteScaleMultiplier;

	private SpecialAttackController specialAttackController;

	public static int deaths;

	public static Action<Enemy, DamageContainer> A_EnemyDied;

	public static Action<Enemy> A_EnemyDiedPre;

	public static Action<Enemy> A_EnemySpawned;

	public static Action<Enemy> A_EnemyReleasedFromPool;

	public static Action<Enemy> A_TargetOfInterestSpawn;

	public static Action<Enemy, DamageContainer> A_Damage;

	public Action<Enemy, DamageContainer> A_DamageNonStatic;

	public static Action<Enemy> A_HealthChange;

	private float controlHp;

	private EEnemyFlag enemyFlag;

	private float _003CextraKnockbackRes_003Ek__BackingField;

	private float maxDespawnTime;

	private float speedMultiplier;

	private EnemyStatusSymbols statusSymbols;

	private float armor;

	private int _003CarmorCurrent_003Ek__BackingField;

	private int _003CarmorMax_003Ek__BackingField;

	public static Action<Enemy, int, int> A_ArmorChanged;

	private EEnemyFlag eliteChallengeFlags;

	private Vector3 defaultScale;

	private Outline outline;

	public float teleportTime;

	public static float defaultTeleportTime;

	public static Action A_HpTamper;

	private float echoDamage;

	private float stopFlashTime;

	private float readyToFlashTime;

	public float flashInterval;

	private bool flashing;

	private bool isInvulnerable;

	public static Action<Enemy, bool> A_InvulnerableChanged;

	private bool isDyingNextFrame;

	private bool deathFunctionCalled;

	private float startTeleportThresholdDistance;

	private float lastTeleportTime;

	private List<AddDebuffContainer> _toAddBuffer;

	public Dictionary<EDebuff, EnemyDebuff> debuffs;

	public HashSet<EDebuff> debuffsToRemove;

	public Dictionary<EDebuff, AddDebuffContainer> debuffsToAdd;

	public Action<EDebuff> A_DebuffAdded;

	public Action<EDebuff> A_DebuffRemoved;

	private Dictionary<EDebuff, int> debuffCounts;

	private float nextVerifyTime;

	private float nextTeleportTimeCheck;

	private float teleportCheckInterval;

	private Transform _003CfollowTarget_003Ek__BackingField;

	private float minStayAtDistance;

	private float maxStayAtDistance;

	private bool allowSpecialAttacks;

	private float basePowerupDropChance;

	public EnemyData enemyData
	{
		get
		{
			return _003CenemyData_003Ek__BackingField;
		}
		private set
		{
			_003CenemyData_003Ek__BackingField = value;
		}
	}

	public float meshHeight
	{
		get
		{
			return _003CmeshHeight_003Ek__BackingField;
		}
		private set
		{
			_003CmeshHeight_003Ek__BackingField = value;
		}
	}

	public float meshRadius
	{
		get
		{
			return _003CmeshRadius_003Ek__BackingField;
		}
		private set
		{
			_003CmeshRadius_003Ek__BackingField = value;
		}
	}

	public Vector3 feetOffset
	{
		get
		{
			return _003CfeetOffset_003Ek__BackingField;
		}
		private set
		{
			_003CfeetOffset_003Ek__BackingField = value;
		}
	}

	public float hp
	{
		get
		{
			return _003Chp_003Ek__BackingField;
		}
		set
		{
			_003Chp_003Ek__BackingField = value;
		}
	}

	public uint id
	{
		get
		{
			return _003Cid_003Ek__BackingField;
		}
		private set
		{
			_003Cid_003Ek__BackingField = value;
		}
	}

	public int waveNumber
	{
		get
		{
			return _003CwaveNumber_003Ek__BackingField;
		}
		set
		{
			_003CwaveNumber_003Ek__BackingField = value;
		}
	}

	public Rigidbody target
	{
		get
		{
			return _003Ctarget_003Ek__BackingField;
		}
		private set
		{
			_003Ctarget_003Ek__BackingField = value;
		}
	}

	public float spawnedAtTime
	{
		get
		{
			return _003CspawnedAtTime_003Ek__BackingField;
		}
		private set
		{
			_003CspawnedAtTime_003Ek__BackingField = value;
		}
	}

	public float extraKnockbackRes
	{
		get
		{
			return _003CextraKnockbackRes_003Ek__BackingField;
		}
		set
		{
			_003CextraKnockbackRes_003Ek__BackingField = value;
		}
	}

	public int armorCurrent
	{
		get
		{
			return _003CarmorCurrent_003Ek__BackingField;
		}
		private set
		{
			_003CarmorCurrent_003Ek__BackingField = value;
		}
	}

	public int armorMax
	{
		get
		{
			return _003CarmorMax_003Ek__BackingField;
		}
		private set
		{
			_003CarmorMax_003Ek__BackingField = value;
		}
	}

	public Transform followTarget
	{
		get
		{
			return _003CfollowTarget_003Ek__BackingField;
		}
		private set
		{
			_003CfollowTarget_003Ek__BackingField = value;
		}
	}

	public void InitEnemy(uint id, EnemyData enemyData, Vector3 pos, int waveNumber, EEnemyFlag flag = EEnemyFlag.None, bool canBeElite = true, float extraSizeMultiplier = 1f)
	{
	}

	public void SetSpeedMultiplier(float f)
	{
	}

	public void SetSwarmMultiplierHp(float f)
	{
	}

	public float GetSpeed()
	{
		return 0f;
	}

	public float GetExtraKnockback()
	{
		return 0f;
	}

	public int GetMoney()
	{
		return 0;
	}

	private void Freeze()
	{
	}

	private void UnFreeze()
	{
	}

	private void CheckScale()
	{
	}

	public void MakeChallenge()
	{
	}

	private void CheckStatusSymbols()
	{
	}

	public void Heal(int amount)
	{
	}

	private void SetBoss()
	{
	}

	public void SetArmor(float newArmor, int current, int max)
	{
	}

	public void SetSummonerMiniboss()
	{
	}

	public bool IsStageBoss()
	{
		return false;
	}

	public bool IsBoss()
	{
		return false;
	}

	public bool IsElite()
	{
		return false;
	}

	public bool IsChallenge()
	{
		return false;
	}

	public bool IsEliteChallenge()
	{
		return false;
	}

	public bool IsFinalBoss()
	{
		return false;
	}

	public void SetMinibossGoon(float hp)
	{
	}

	private void AddStatusSymbols()
	{
	}

	private void RemoveStatusSymbols()
	{
	}

	private void ResetUi()
	{
	}

	private void Awake()
	{
	}

	private void OnDestroy()
	{
	}

	private void OnStatusEffectAdded(EStatusEffect eStatusEffect, bool newEffect)
	{
	}

	private void OnStatusEffectRemoved(EStatusEffect eStatusEffect)
	{
	}

	private IEnumerator StartTeleporting(Vector3 toPosition, bool skipStart = false)
	{
		return null;
	}

	private IEnumerator Despawn()
	{
		return null;
	}

	public void DamageFromPlayerWeapon(DamageContainer dc)
	{
	}

	public void DamageFromPlayerOther(DamageContainer dc)
	{
	}

	public void DamageExternal(DamageContainer dc)
	{
	}

	public bool HasDebuff(EDebuff debuff)
	{
		return false;
	}

	public void ReleaseEcho()
	{
	}

	private void Damage(DamageContainer damageContainer)
	{
	}

	public void MakeWhite()
	{
	}

	public void Kill(string damageSource = "Unkown")
	{
	}

	public bool CanTakeDamage()
	{
		return false;
	}

	public void MakeInvulnerable(bool invulnerable)
	{
	}

	public void DiedNextFrame()
	{
	}

	private void EnemyDied()
	{
	}

	public void EnemyDied(DamageContainer dc)
	{
	}

	private void OnPaused(bool paused)
	{
	}

	private void OnDissolveFinished()
	{
	}

	public void ReleaseToPoolNextFrame()
	{
	}

	public void ReleaseToPool()
	{
	}

	public void MyFixedUpdate()
	{
	}

	public void AddDebuff(EDebuff eDebuff, DamageContainer dc, float duration, int stacks = 1)
	{
	}

	private void AddDebuffImplementation(AddDebuffContainer debuffContainer)
	{
	}

	public void RemoveDebuff(EDebuff debuff, bool fromDeath)
	{
	}

	public void DebuffTick()
	{
	}

	public void QueueClearAllDebuffs()
	{
	}

	public void ClearAllDebuffs()
	{
	}

	public void Charm(DamageContainer dc, float duration)
	{
	}

	public void ReleaseCharm()
	{
	}

	public void FindTarget()
	{
	}

	private void VerifyPosition()
	{
	}

	public void TeleportToPlayer()
	{
	}

	private void TryDespawn()
	{
	}

	public bool IsTeleporting()
	{
		return false;
	}

	private void TryTeleport()
	{
	}

	public void StartSpecialAttack()
	{
	}

	public void EndSpecialAttack()
	{
	}

	public void FollowTarget(Transform target)
	{
	}

	public void MyUpdate()
	{
	}

	public bool CanMove()
	{
		return false;
	}

	public bool IsRunningFromPlayer()
	{
		return false;
	}

	private bool IsStationary()
	{
		return false;
	}

	public int GetXp()
	{
		return 0;
	}

	private void ResetMaterial()
	{
	}

	public bool IsDead()
	{
		return false;
	}

	public bool IsDeadOrDyingNextFrame()
	{
		return false;
	}

	public Vector3 GetCenterPosition()
	{
		return default(Vector3);
	}

	public Vector3 GetFeetPosition()
	{
		return default(Vector3);
	}

	public Vector3 GetHeadPosition()
	{
		return default(Vector3);
	}

	public Vector3 GetGroundCheckPosition()
	{
		return default(Vector3);
	}

	public bool IsImportantEnemy()
	{
		return false;
	}

	public float GetHeight()
	{
		return 0f;
	}

	public void DisableSpecialAttacks()
	{
	}

	public Vector3 GetBottomPosition()
	{
		return default(Vector3);
	}

	public float GetPowerupDropChance()
	{
		return 0f;
	}

	public float GetHpRatio()
	{
		return 0f;
	}
}
