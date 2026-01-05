namespace Assets.Scripts.Player.Movement;

public struct InputState
{
	public float moveHorizontal;

	public float moveVertical;

	public float rotationHorizontal;

	public float rotationVertical;

	public bool jumping;

	public bool crouching;

	public bool holdingJump;

	public bool holdingWallrun;

	public InputState(float mH, float mV, float rH, float rV, bool ju, bool cr, bool holdingJump, bool holdingWallrun)
	{
		moveHorizontal = 0f;
		moveVertical = 0f;
		rotationHorizontal = 0f;
		rotationVertical = 0f;
		jumping = false;
		crouching = false;
		this.holdingJump = false;
		this.holdingWallrun = false;
	}
}
