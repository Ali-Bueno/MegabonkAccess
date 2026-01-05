using Assets.Scripts.Inventory__Items__Pickups.Interactables;
using Assets.Scripts.Player.Movement;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
	public DetectInteractables detectInteractables;

	private float moveHorizontal;

	private float moveVertical;

	private bool jumping;

	private bool interacting;

	private bool sliding;

	private bool aiming;

	private bool holdingJump;

	private bool holdingWallrun;

	public Vector3 cameraRotation;

	private Vector3 desiredCameraRotation;

	private float cameraSmoothingMin;

	private float cameraSmoothingMax;

	private bool hasWallrunActionBound;

	private string stringMouseX;

	private string stringMouseY;

	private int jumpBufferTicks;

	private int currentJumpBufferTick;

	private void Awake()
	{
	}

	private void OnDestroy()
	{
	}

	private void Start()
	{
	}

	private void Update()
	{
	}

	public static bool IsConsoleOpen()
	{
		return false;
	}

	public Vector3 GetWishDir()
	{
		return default(Vector3);
	}

	private void TestInput()
	{
	}

	private void MovementInput()
	{
	}

	private void AbilityInput()
	{
	}

	public void SetSpawnDirection(Vector3 direction, float pitch = 0f)
	{
	}

	public bool IsHoldingJump()
	{
		return false;
	}

	public void RotationInput()
	{
	}

	private void AutoRotation()
	{
	}

	private void ManualRotation()
	{
	}

	private float GetCameraSmoothing()
	{
		return 0f;
	}

	private void FixedUpdate()
	{
	}

	private void OnPlayerDied()
	{
	}

	private InputState GetInputState()
	{
		return default(InputState);
	}

	private bool CanInput()
	{
		return false;
	}

	private bool IsMovementDisabled()
	{
		return false;
	}

	public bool IsAiming()
	{
		return false;
	}

	private void OnInputMappingChanged()
	{
	}
}
