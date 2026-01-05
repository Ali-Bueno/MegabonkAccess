using System;
using System.Collections.Generic;
using Assets.Scripts.Camera;
using Assets.Scripts.Inventory__Items__Pickups;
using UnityEngine;

namespace Assets.Scripts.Actors.Player;

public class MyPlayer : MonoBehaviour
{
	public PlayerRenderer playerRenderer;

	public PlayerMovement playerMovement;

	public ParticleSystem levelupParticles;

	public AudioSource levelupSfx;

	public ECharacter character;

	public PlayerInput playerInput;

	public AuraAttacks playerConstantAttacks;

	public PlayerSfxs playerSfxs;

	public PlayerEffects playerEffects;

	public GameObject fogOfWar;

	public GameObject teleportEffect;

	public UnityEngine.Camera minimapCamera;

	public MinimapCamera minimapCameraScript;

	private bool inited;

	private float _003CbaseMovementSpeed_003Ek__BackingField;

	public PlayerInventory inventory;

	public static Action<PlayerInventory> A_PlayerInventoryInitialized;

	public static MyPlayer Instance;

	public static Action A_PrePlayerSpawn;

	public float height;

	public Transform feet;

	public Transform head;

	public bool hasStarted;

	public Vector3 spawnDir;

	public float width;

	private bool started;

	private float nextChangeTime;

	private bool isInvincible;

	private float damageCooldownOverAtTime;

	private float lastCalledTime;

	private Dictionary<GameObject, float> enemyCooldowns;

	private float enemyAttackCooldown;

	private int enemyLayer;

	public static Action A_Collided;

	public static Action A_CollidedEnemy;

	private float movingDirectionBias;

	private float shootingDirectionBias;

	private float biasMoveSpeed;

	private Vector3 averageMovingDirection;

	private Vector3 averageMovingDirectionShooting;

	private float maxVectorSize;

	private float maxVectorSizeShooting;

	public Transform arrow;

	public Transform shootingArrow;

	public bool isTeleporting;

	private static float defaultBaseDamage;

	private float baseDamage;

	public float baseMovementSpeed
	{
		get
		{
			return _003CbaseMovementSpeed_003Ek__BackingField;
		}
		private set
		{
			_003CbaseMovementSpeed_003Ek__BackingField = value;
		}
	}

	public void Awake()
	{
	}

	public void TryInit()
	{
	}

	private void Start()
	{
	}

	public void Spawn(Vector3 position, Vector3 direction, bool useHeightOffset = false)
	{
	}

	public void StartPlayer(ECharacter character, Vector3 direction)
	{
	}

	public void RefreshSize(CharacterData characterData, Vector3 direction, float sizeMultiplier = 1f)
	{
	}

	private void FixedUpdate()
	{
	}

	private void Update()
	{
	}

	private void LateUpdate()
	{
	}

	private void OnDamage(PlayerHealth ph, DamageContainer dc, bool shieldDamage)
	{
	}

	private void DamageCooldownOver()
	{
	}

	public void OnLevelUp()
	{
	}

	private void StopLevelupParticles()
	{
	}

	private void OnCollisionStay(Collision other)
	{
	}

	private void OnGUI()
	{
	}

	private bool CanTakeDamage()
	{
		return false;
	}

	public void UpdateSpawnDirectionBias()
	{
	}

	public float GetSpawnDirectionBias()
	{
		return 0f;
	}

	public Vector3 GetAverageMovingDirection()
	{
		return default(Vector3);
	}

	public Vector3 GetAverageMovingDirectionTarget()
	{
		return default(Vector3);
	}

	public bool IsDead()
	{
		return false;
	}

	private void OnPlayerDied()
	{
	}

	public void TeleportPlayerNextStage()
	{
	}

	public void TeleportPlayerImmediate(Vector3 position, Vector3 dir, Vector3 cameraDir, float cameraPitch = 20f)
	{
	}

	private void TeleportEnd()
	{
	}

	public void PauseInventory(bool b)
	{
	}

	public Vector3 GetFeetPosition()
	{
		return default(Vector3);
	}

	private void CalculateBaseDamage()
	{
	}

	public float GetBaseDamage()
	{
		return 0f;
	}

	private void OnDestroy()
	{
	}
}
