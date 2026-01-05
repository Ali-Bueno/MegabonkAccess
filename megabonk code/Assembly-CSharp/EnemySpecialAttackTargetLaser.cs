using Assets.Scripts.Game.Combat.EnemySpecialAttacks.Implementations;
using UnityEngine;

public class EnemySpecialAttackTargetLaser : EnemySpecialAttackPrefab
{
	public Transform laser;

	public Transform laserEnd;

	private float speed;

	private float defaultMaxSpeed;

	private float maxSpeed;

	public Transform blackhole;

	private float maxLaserLength;

	private float laserLength;

	private float overAtTime;

	private float timeToMaxSpeed;

	private float speedTimer;

	private float damageCooldown;

	private float nextDamageReadyTime;

	protected override void Init()
	{
	}

	private Vector3 GetLaserPosition()
	{
		return default(Vector3);
	}

	private void Update()
	{
	}

	private void FixedUpdate()
	{
	}

	private void OnTriggerStay(Collider other)
	{
	}
}
