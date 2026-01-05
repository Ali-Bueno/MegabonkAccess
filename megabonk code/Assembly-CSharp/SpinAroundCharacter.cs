using UnityEngine;

public class SpinAroundCharacter : MonoBehaviour
{
	public Transform camera;

	public Transform target;

	public float distanceFromTarget;

	public float cameraHeight;

	public Vector3 targetOffset;

	public float rotationSpeed;

	private float currentAngle;

	private void Update()
	{
	}
}
