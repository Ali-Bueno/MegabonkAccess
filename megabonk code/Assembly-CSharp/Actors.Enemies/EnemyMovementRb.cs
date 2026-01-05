using System.Collections.Generic;
using Assets.Scripts.Actors;
using Assets.Scripts.Actors.Enemies;
using Assets.Scripts.Game.Combat.EnemyDebuffs;
using UnityEngine;

namespace Actors.Enemies;

public class EnemyMovementRb : MonoBehaviour
{
	public enum State
	{
		Normal,
		Sucked,
		Charmed
	}

	public Enemy enemy;

	public Rigidbody rb;

	private float nextStepTime;

	private Vector3 offsetBias;

	private Vector3 desiredVelocity;

	private Quaternion desiredRotation;

	private float knockbackResetSpeed;

	private Vector3 knockbackVelocity;

	private float randomOffset;

	private float randomGroundedCheckOffset;

	public State state;

	private float flyingKnockupVel;

	private bool canRotate;

	private bool isClimbing;

	private float nextClimbCheckTime;

	private float nextGroundedCheckTime;

	private float groundCheckInterval;

	private bool _003Cgrounded_003Ek__BackingField;

	private bool dashing;

	private float dashStopTime;

	private Vector3 dashDirection;

	private float dashSpeed;

	private bool isDashingWall;

	private HashSet<EDebuff> debuffs;

	private Vector3 baseVelocity;

	private const float baseRotationSpeed = 10f;

	private float rotationSpeed;

	private Vector3 flyingOffset;

	public float distanceToTarget;

	private bool isStationary;

	private float nextGetSpeedTime;

	private float getSpeedCooldown;

	private float storedSpeed;

	private static float knockbackConstant;

	private const float maxKnockback = 5f;

	private const float maxBossKnockback = 2.25f;

	private float maxKnockbackVelSqrBoss;

	private bool isBoss;

	private float knockbackResistance;

	private float lastFoundKnockbackResTime;

	private Transform suckTarget;

	private float totalSuckTime;

	private float totalSuckTimeMax;

	private float nextCheckDamageTime;

	public bool grounded
	{
		get
		{
			return _003Cgrounded_003Ek__BackingField;
		}
		private set
		{
			_003Cgrounded_003Ek__BackingField = value;
		}
	}

	private void Awake()
	{
	}

	private void OnDestroy()
	{
	}

	public void Init()
	{
	}

	public void MyFixedUpdate()
	{
	}

	private float TryClimbWall()
	{
		return 0f;
	}

	private void CheckGrounded()
	{
	}

	private Vector3 GetTargetPosition()
	{
		return default(Vector3);
	}

	public void DashStart(Vector3 dir, float dashTime, float dashSpeed)
	{
	}

	public void SetDashDirection(Vector3 dir)
	{
	}

	private void Dashing()
	{
	}

	public void StopDash()
	{
	}

	public void StopMovement()
	{
	}

	public void StartMovement()
	{
	}

	private void SetVelocity(Vector3 vel)
	{
	}

	private void TimescaleVelocity()
	{
	}

	public void FindNextPosition()
	{
	}

	public void SetDesiredRotation(Vector3 targetPos)
	{
	}

	private float GetSpeed()
	{
		return 0f;
	}

	public void MyUpdate()
	{
	}

	public void Pause(bool isPaused)
	{
	}

	public void KnockUp(float knockbackForce)
	{
	}

	public void Knockback(DamageContainer dc)
	{
	}

	public void Knockback(Vector3 dir, float knockback)
	{
	}

	public void Suck(Transform target)
	{
	}

	public void StopSuck()
	{
	}

	private bool CanFindNextPosition()
	{
		return false;
	}

	private float GetNextStepTime(float distanceToTarget)
	{
		return 0f;
	}

	private float GetNextGroundCheckOffset(float distanceToTarget)
	{
		return 0f;
	}
}
