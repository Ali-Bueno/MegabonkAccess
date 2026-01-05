namespace Assets.Scripts.Movement;

public enum EMovementState
{
	Idle = 1,
	Walking = 2,
	Crouching = 4,
	Sliding = 8,
	Airborne = 16,
	Wallrunning = 32,
	CategoryCrouched = 12,
	CategoryFootstepNoise = 34
}
