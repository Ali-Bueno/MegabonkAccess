using UnityEngine;
using UnityEngine.Splines;

public class Rail : MonoBehaviour
{
	private bool isRailingPlayer;

	private float stopRailTime;

	public SplineContainer splineContainer;

	private float restoreCollisionAtTime;

	private bool isIgnoringCollision;

	public Collider renderCollider;

	private Collider playerCollider;

	public bool IsOnCooldown()
	{
		return false;
	}

	public void Cooldown(Collider playerCollider)
	{
	}

	private void FixedUpdate()
	{
	}

	public bool IsValidPosition()
	{
		return false;
	}

	private void OnValidate()
	{
	}
}
