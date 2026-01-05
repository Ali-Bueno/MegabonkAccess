using System.Collections.Generic;
using Assets.Scripts.Actors.Enemies;
using Assets.Scripts.Game.Combat.ConstantAttacks;
using Assets.Scripts.Inventory__Items__Pickups.Weapons;
using Assets.Scripts.Menu.Shop;
using UnityEngine;

public class LaserBeamAttack : ConstantAttack
{
	public LineRenderer linerenderer;

	public GameObject laserStart;

	public GameObject laserEnd;

	private float radius;

	private Vector3 laserDir;

	private Enemy target;

	private float laserStopTime;

	private float laserStartedAtTime;

	private float laserReadyTime;

	private bool isShooting;

	private Vector3 prevStart;

	private Vector3 prevEnd;

	private Vector3 center;

	private Quaternion rotation;

	private Vector3 halfExtents;

	public AudioSource audioLoop;

	public GameObject explosionFx;

	private Dictionary<Collider, float> enemyHitCooldowns;

	private float hitCooldown;

	public int whipSegments;

	public float whipAmplitude;

	public float whipFrequency;

	public float animateWhipTime;

	private float whipAnimationTime;

	private static readonly Collider[] sphereHits;

	private static readonly Collider[] boxHits;

	private float laserRadius;

	private new void Awake()
	{
	}

	private new void OnDestroy()
	{
	}

	private void OnWeaponToggled(WeaponBase weaponBase)
	{
	}

	protected override void Init()
	{
	}

	private void Update()
	{
	}

	private void StartLaser()
	{
	}

	private void StopLaser()
	{
	}

	private void RenderLaser()
	{
	}

	private Vector3 GetBeamStart()
	{
		return default(Vector3);
	}

	private Vector3 GetBeamEnd()
	{
		return default(Vector3);
	}

	private void FindTarget()
	{
	}

	private void FixedUpdate()
	{
	}

	private void ProcessHits(Collider[] colliders, int count)
	{
	}

	private void HitEnemy(Collider collider)
	{
	}

	private void UpdateSize()
	{
	}

	private float GetRadius()
	{
		return 0f;
	}

	public override float GetAuraRotationSpeed()
	{
		return 0f;
	}

	private float GetDuration()
	{
		return 0f;
	}

	private float GetCooldown()
	{
		return 0f;
	}

	protected override void OnWeaponStatUpdate(EStat stat, EWeapon weapon)
	{
	}

	protected override void OnStatUpdate(EStat stat)
	{
	}
}
