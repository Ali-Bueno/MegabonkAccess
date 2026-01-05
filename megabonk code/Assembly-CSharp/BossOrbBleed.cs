using Assets.Scripts.Actors.Enemies;
using UnityEngine;

public class BossOrbBleed : MonoBehaviour
{
	public Rigidbody rb;

	public SphereCollider collider;

	public GameObject explosion;

	public GameObject trail;

	public RandomSfx randomSfx;

	private Enemy boss;

	private float acceleration;

	private bool isFired;

	private float speed;

	private float moveAtTime;

	private float destroyAtTime;

	private Vector3 offset;

	private Vector3 velocity;

	private float moveTimer;

	private float moveOverSeconds;

	public float spinSpeed;

	private float currentAngle;

	protected void Start()
	{
	}

	public void Set(Enemy boss, int currentPhase, int numOrbs, int orbIndex)
	{
	}

	private void FixedUpdate()
	{
	}

	private void Update()
	{
	}

	private void ShootOrb()
	{
	}

	private void Movement()
	{
	}

	private void FloatMovement()
	{
	}

	private void OnCollisionEnter(Collision collision)
	{
	}

	private void Explode()
	{
	}

	private float GetDamage()
	{
		return 0f;
	}
}
