using UnityEngine;

public class WorldColliderTrigger : MonoBehaviour
{
	private float maxSlopeAngle;

	private void OnCollisionStay(Collision collision)
	{
	}

	private bool IsFloor(Vector3 v)
	{
		return false;
	}

	private bool IsCeiling(Vector3 v)
	{
		return false;
	}
}
