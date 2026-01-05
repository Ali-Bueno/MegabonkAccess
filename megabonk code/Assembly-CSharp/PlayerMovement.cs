using System;
using Assets.Scripts.Movement;
using Assets.Scripts.Player.Movement;
using UnityEngine;
using UnityEngine.Splines;

public class PlayerMovement : MonoBehaviour
{
	public enum CrouchState
	{
		None,
		Crouching,
		Sliding
	}

	public Transform playerCam;

	public Transform orientation;

	public Transform feet;

	public Transform head;

	public LayerMask whatIsGround;

	public LayerMask whatIsGroundOnly;

	private Rigidbody rb;

	private float currentMoveSpeed;

	private float currentMaxSpeed;

	private float counterMovement;

	private float defaultCounterMovement;

	private float threshold;

	private int readyToCounterX;

	private int readyToCounterY;

	private float slowDownSpeed;

	private float pushMultiplier;

	private float pushResetSpeed;

	private float resetPushCounter;

	private float resetPushCounterValue;

	private float maxSlopeAngle;

	private float slideAngle;

	private float minBreakFallAngle;

	private float maxBreakFallAngle;

	private int surfaceDelay;

	private int groundCancel;

	private int surfCancel;

	private int climbCancel;

	private Vector3 ladderNormal;

	private Transform ladder;

	private float ladderSpeed;

	private bool onLadderLastFrame;

	private float ladderRefreshTime;

	private Vector3 ladderWishDir;

	private Vector3 ladderWallVec;

	public bool onRamp;

	public bool onLadder;

	private bool pushed;

	public bool grounded;

	private bool isUnderwater;

	private bool onGround;

	private bool surfing;

	private bool cancellingGrounded;

	private bool cancellingSurf;

	private Vector3 playerScale;

	private Vector3 crouchScale;

	private float slideCounterMovement;

	public const float crouchRatio = 1f;

	private float playerHeight;

	private float slideThresholdSpeed;

	private bool readyToCrouch;

	private bool readyToSlide;

	private bool justLanded;

	private bool justUncrouched;

	private bool readyToJump;

	private int aerialJumps;

	private float x;

	private float y;

	private float mouseDeltaX;

	private float mouseDeltaY;

	private bool jumping;

	private bool crouching;

	private CrouchState _003CcrouchState_003Ek__BackingField;

	private Vector3 normalVector;

	private CapsuleCollider playerCollider;

	private float _003CplayerRadius_003Ek__BackingField;

	private float fallSpeed;

	private Vector3 lastVelocity;

	private int ladderRefreshCount;

	private int ladderRefreshCountMax;

	private int resetJumpCounter;

	private int jumpCounterResetTime;

	private int crouchCooldownCounter;

	private int crouchCooldownCounterMax;

	private int slideCooldownCounter;

	private int slideCooldownCounterMax;

	private int justLandedCounter;

	private int justLandedCounterMax;

	private int justUncrouchedCounter;

	private int justUncrouchedCounterMax;

	private Vector3 headHeight;

	private Vector3 crouchHeadHeight;

	private Vector3 feetHeight;

	public static Action<PlayerMovement> A_Jumped;

	public static Action<PlayerMovement> A_Crouched;

	public static Action<PlayerMovement> A_MovementState;

	public static PlayerMovement Instance;

	public PlayerMovementValues movementValues;

	private ECharacter currentCharacter;

	private EMovementState lastMovementState;

	public InputState inputState;

	private bool frozen;

	public bool isDashing;

	private float leftGroundAtTime;

	private Rail rail;

	private float railSpeed;

	private float progress;

	private float railDirectionMultiplier;

	private float canJumpOffRailTime;

	private float canJumpOffRailAtTime;

	private Vector3 railOffsetPosition;

	private Vector3 railOffsetPositionStart;

	private float railOffsetPositionTimer;

	private float railLerpTime;

	public static Action<bool> A_ToggleGrind;

	public PlayerSfxs playerSfx;

	public static Action A_StartedWallClimb;

	private float minWallClimbSpeed;

	private float wallClimbCooldown;

	private float canWallClimbAtTime;

	private float wallrunAttachAngle;

	private Vector3 _003CwallNormal_003Ek__BackingField;

	private Vector3 _003ClastGroundedPosition_003Ek__BackingField;

	private bool isNoclipping;

	private FrictionModifier.EFrictionSurface surface;

	private GameObject groundedObject;

	private float unstuckForce;

	private float stuckTimer;

	private float stuckTimerMax;

	private float lastFallSpeed;

	private float lastTouchedWallTime;

	public static Action<Vector3> CameraBob;

	public static Action<float> A_Landed;

	public static Action<Vector3, float> A_LandedSmoke;

	public static Action<float> Shake;

	private bool wallClimbing;

	public static Action<bool> A_Grounded;

	public static Action<PlayerMovement> A_SlideStart;

	public static Action<PlayerMovement> A_Wallrun;

	private float jumpAnimationCooldownSlide;

	private int usedJumps;

	private float jumpedTime;

	private float landedAtTime;

	private float landingJumpCooldownPegeMode;

	private int climbCancelTicks;

	private float avgVelocity;

	private Vector3 standingFeetOffset;

	private Vector3 crouchingFeetOffset;

	private float lastTouchedTornadoTime;

	private bool _003CisTouchingTornado_003Ek__BackingField;

	public CrouchState crouchState
	{
		get
		{
			return _003CcrouchState_003Ek__BackingField;
		}
		private set
		{
			_003CcrouchState_003Ek__BackingField = value;
		}
	}

	public float playerRadius
	{
		get
		{
			return _003CplayerRadius_003Ek__BackingField;
		}
		private set
		{
			_003CplayerRadius_003Ek__BackingField = value;
		}
	}

	public Vector3 wallNormal
	{
		get
		{
			return _003CwallNormal_003Ek__BackingField;
		}
		private set
		{
			_003CwallNormal_003Ek__BackingField = value;
		}
	}

	public Vector3 lastGroundedPosition
	{
		get
		{
			return _003ClastGroundedPosition_003Ek__BackingField;
		}
		private set
		{
			_003ClastGroundedPosition_003Ek__BackingField = value;
		}
	}

	public bool isTouchingTornado
	{
		get
		{
			return _003CisTouchingTornado_003Ek__BackingField;
		}
		private set
		{
			_003CisTouchingTornado_003Ek__BackingField = value;
		}
	}

	private void UpdateTickRate(int tickRate)
	{
	}

	private void Awake()
	{
	}

	private void OnDestroy()
	{
	}

	private void OnLavaEnter()
	{
	}

	private void OnLavaExit()
	{
	}

	private void OnWaterEnter(Water water)
	{
	}

	private void OnWaterExit(Water water)
	{
	}

	private bool IsInitialized()
	{
		return false;
	}

	private void Initialize()
	{
	}

	public void ResetState(ECharacter character, Vector3 dir)
	{
	}

	public void SetBetterInput(InputState input)
	{
	}

	public void Freeze(bool b)
	{
	}

	public void MovementTick()
	{
	}

	private float GetAirDeceleration()
	{
		return 0f;
	}

	public void StartRail(Rail rail)
	{
	}

	public void StopRail()
	{
	}

	private void RailMovement()
	{
	}

	private Vector3 GetRailPosition()
	{
		return default(Vector3);
	}

	public bool CanStartGrind()
	{
		return false;
	}

	public bool IsGrinding()
	{
		return false;
	}

	public Vector3 GetGrindNormal()
	{
		return default(Vector3);
	}

	public Vector3 GetGrindDirection()
	{
		return default(Vector3);
	}

	private float FindClosestPointOnSpline(SplineContainer spline, Vector3 position)
	{
		return 0f;
	}

	private void WallClimbing()
	{
	}

	private bool CanWallClimb(Vector3 normal, Collision other)
	{
		return false;
	}

	private void StopWallClimbing()
	{
	}

	public bool IsWallClimbing()
	{
		return false;
	}

	private bool CheckIfPlayerWantsToWallClimb(Vector3 normal)
	{
		return false;
	}

	private float RelativeToLook(Vector3 normal)
	{
		return 0f;
	}

	private Vector3 InputVectorRelativeToLook()
	{
		return default(Vector3);
	}

	private float GetWallClimbSpeed()
	{
		return 0f;
	}

	private void VerifyPosition()
	{
	}

	public void TeleportPlayerBackToBounds(Vector3 pos)
	{
	}

	public void TeleportPlayer(Vector3 pos)
	{
	}

	private void Update()
	{
	}

	private void NoclipMovement()
	{
	}

	public Vector2 GetLocalVelocity()
	{
		return default(Vector2);
	}

	public static Vector3 AirAccelerate(Vector3 velocity, Vector3 wishdir, float wishspeed, float accel, float airCap, float deltaTime, float gainMultiplier = 1f)
	{
		return default(Vector3);
	}

	public Vector3 GetWishDir()
	{
		return default(Vector3);
	}

	public Vector2 VelRelativeToLook()
	{
		return default(Vector2);
	}

	private void OnCollisionEnter(Collision other)
	{
	}

	private void CheckLanding(Vector3 point, Vector3 normal)
	{
	}

	private void CheckStuck()
	{
	}

	private void CheckFallDamageBug()
	{
	}

	public bool CanTakeFallDamage(Vector3 normal)
	{
		return false;
	}

	private void OnCollisionStay(Collision other)
	{
	}

	private void StartGrounded()
	{
	}

	private void UpdateCooldowns()
	{
	}

	private void CheckInput()
	{
	}

	private void StartCrouch()
	{
	}

	private void StopCrouch()
	{
	}

	private bool CanStopCrouching()
	{
		return false;
	}

	public bool IsCrouching()
	{
		return false;
	}

	private bool UseLimitedMovement()
	{
		return false;
	}

	private void StartSlide()
	{
	}

	private void StopSlide()
	{
	}

	public bool IsSliding()
	{
		return false;
	}

	public bool IsSlidingAnimation()
	{
		return false;
	}

	private void UpdateCrouchState()
	{
	}

	private void WaterMovement()
	{
	}

	private bool IsUnderwater()
	{
		return false;
	}

	private void RampMovement(Vector2 mag)
	{
	}

	private bool TryLadderMovement()
	{
		return false;
	}

	public void RefreshLadder(Transform ladder)
	{
	}

	private void StopLadder()
	{
	}

	private void LadderMovementTick(float x, float y)
	{
	}

	public void JumpPad(JumpPad pad)
	{
	}

	public void RocketJump(Vector3 pushForce)
	{
	}

	public void PushPlayer(Vector3 pushForce)
	{
	}

	public void PushPlayerButKeepMovement()
	{
	}

	public void BouncePlayer(Vector3 pushForce)
	{
	}

	public bool RecentlyJumped()
	{
		return false;
	}

	public bool IsTouchingGround()
	{
		return false;
	}

	public bool HasFooting()
	{
		return false;
	}

	private bool AreFeetTouchingFloor()
	{
		return false;
	}

	private void SetKinematic(bool b)
	{
	}

	private bool IsBreakingFall(Vector3 normal)
	{
		return false;
	}

	private bool CanJump(bool ignoreAerialJumps = false)
	{
		return false;
	}

	private void ResetAerialJumps()
	{
	}

	public bool CanBhopJump()
	{
		return false;
	}

	public void Jump()
	{
	}

	private float GetJumpForce()
	{
		return 0f;
	}

	private void CounterMovement(float x, float y, Vector2 mag)
	{
	}

	private bool IsHoldingAgainstHorizontalVel(Vector2 vel)
	{
		return false;
	}

	private bool IsHoldingAgainstVerticalVel(Vector2 vel)
	{
		return false;
	}

	private bool IsFloor(Vector3 v)
	{
		return false;
	}

	private bool IsSlideable(Vector3 v)
	{
		return false;
	}

	private bool IsSurf(Vector3 v)
	{
		return false;
	}

	private bool IsWall(Vector3 v)
	{
		return false;
	}

	private bool IsRoof(Vector3 v)
	{
		return false;
	}

	private void UpdateCollisionChecks()
	{
	}

	private void StopGrounded()
	{
	}

	private void StopSurf()
	{
	}

	public Vector3 GetVelocity()
	{
		return default(Vector3);
	}

	public float GetAverageVelocity()
	{
		return 0f;
	}

	public float GetSpeedHorizontal()
	{
		return 0f;
	}

	public float GetSpeed()
	{
		return 0f;
	}

	public float GetFallSpeed()
	{
		return 0f;
	}

	public Collider GetPlayerCollider()
	{
		return null;
	}

	public Transform GetPlayerCamTransform()
	{
		return null;
	}

	public Rigidbody GetRb()
	{
		return null;
	}

	public void StopFallVelocity()
	{
	}

	public Vector3 GetRbFeetPosition()
	{
		return default(Vector3);
	}

	public Vector3 GetRbHeadPosition()
	{
		return default(Vector3);
	}

	public Vector3 FeetPositionToRb(Vector3 feetPos, bool wasCrouching = false)
	{
		return default(Vector3);
	}

	public bool CanFloat()
	{
		return false;
	}

	public float GetFeetOffset()
	{
		return 0f;
	}

	public EMovementState GetMovementState()
	{
		return default(EMovementState);
	}

	public float GetPlayerRadius()
	{
		return 0f;
	}

	public Vector3 GetNormal()
	{
		return default(Vector3);
	}

	public bool IsHoldingMovement()
	{
		return false;
	}

	public void TouchingTornado()
	{
	}
}
