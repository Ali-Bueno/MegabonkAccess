using UnityEngine;

namespace RetroArsenal;

public class RetroProjectileScript : MonoBehaviour
{
	public GameObject impactParticle;

	public GameObject projectileParticle;

	public GameObject muzzleParticle;

	public GameObject[] trailParticles;

	public float colliderRadius;

	public float collideOffset;

	private Rigidbody rb;

	private Transform myTransform;

	private SphereCollider sphereCollider;

	private float destroyTimer;

	private bool destroyed;

	private void Start()
	{
	}

	private void FixedUpdate()
	{
	}

	private void DestroyMissile()
	{
	}

	private void RotateTowardsDirection()
	{
	}
}
