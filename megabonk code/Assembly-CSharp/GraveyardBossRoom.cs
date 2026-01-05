using System;
using Assets.Scripts.Actors;
using Assets.Scripts.Actors.Enemies;
using Assets.Scripts.Audio.Music;
using MilkShake;
using UnityEngine;

public class GraveyardBossRoom : MonoBehaviour
{
	private enum ELavaState
	{
		Idle,
		Rising,
		UpIdle,
		Lowering
	}

	public Transform playerTeleportTransform;

	public Transform bossSpawnTransform;

	public InteractableGhostBossLeave interactableGhostBossLeave;

	private bool _003CisFightingBoss_003Ek__BackingField;

	private Enemy bossEnemy;

	private float spawnBossAtTime;

	private bool _003ChasSpawnedBoss_003Ek__BackingField;

	public Light directionalLight;

	public AegisRenderer bossShields;

	public MusicTrack musicTrackBoss;

	private float timer;

	private static float darknessLightIntensityMultiplier;

	public static bool isPlayerInsideLight;

	public static Action A_BossDied;

	public BossLamp[] lamps;

	private int lampCount;

	private float lightDropFromLamps;

	private float currentLightIntensity;

	private float defaultLightIntensity;

	private Color defaultAmbientLight;

	private float bossDeadGracePeriod;

	private float bossDeadAtTime;

	public bool isBossDefeated;

	private float bdLightFadeDuration;

	private float bdLightStartFadeDelay;

	private float bdLightStartIntensity;

	private float bdLightIntensity;

	private float openGateDelay;

	private bool hasOpenedGate;

	public GraveyardBossMetalGate metalGate;

	private bool hasUsedDamageOtherThanLamps;

	public Transform lava;

	public Transform risingObjects;

	public Transform pillars;

	public AudioSource sfxRumble;

	public ShakePreset rumbleShake;

	private float lavaInterval;

	private float lavaDuration;

	private float lavaRiseTime;

	private float lavaStartTime;

	private float lavaEndTime;

	private float lavaRiseTimer;

	private Vector3 risingObjectsPositionDefault;

	private Vector3 risingObjectsPositionUp;

	private Vector3 lavaPosDefault;

	private Vector3 lavaPosUp;

	private Vector3 pillarsPosDefault;

	private Vector3 pillarsPosUp;

	private ELavaState lavaState;

	public bool isFightingBoss
	{
		get
		{
			return _003CisFightingBoss_003Ek__BackingField;
		}
		private set
		{
			_003CisFightingBoss_003Ek__BackingField = value;
		}
	}

	public bool hasSpawnedBoss
	{
		get
		{
			return _003ChasSpawnedBoss_003Ek__BackingField;
		}
		private set
		{
			_003ChasSpawnedBoss_003Ek__BackingField = value;
		}
	}

	private void Awake()
	{
	}

	private void OnDestroy()
	{
	}

	private void Start()
	{
	}

	private void LampActivate()
	{
	}

	private void LampDeactivate()
	{
	}

	private void RefreshBossArmor()
	{
	}

	private void RefreshLighting()
	{
	}

	public void Activate()
	{
	}

	private void BossFightOver()
	{
	}

	private void PostBossDeadUpdate()
	{
	}

	private void Update()
	{
	}

	private void FixedUpdate()
	{
	}

	private void CheckIfBossDead()
	{
	}

	private void UpdateShields()
	{
	}

	private void CheckSpawnBoss()
	{
	}

	private void OnEnemyReleased(Enemy enemy)
	{
	}

	private void OnEnemyDied(Enemy enemy, DamageContainer dc)
	{
	}

	private void OnLightIntensityChangeFromDarknessAttack(float i)
	{
	}

	private void DarknessAttackStarted()
	{
	}

	private void DarknessExplosion()
	{
	}

	public static bool IsDarknessAttack()
	{
		return false;
	}

	public static float GetDarknessIntensityMultiplier()
	{
		return 0f;
	}

	private void OnEnemyDamage(Enemy enemy, DamageContainer dc)
	{
	}

	private void OnDisable()
	{
	}

	private void FindNextLavaRise()
	{
	}

	private void UpdateLava()
	{
	}
}
