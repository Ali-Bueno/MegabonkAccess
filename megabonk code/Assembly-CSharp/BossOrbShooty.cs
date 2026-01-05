using Assets.Scripts.Actors.Enemies;
using UnityEngine;

public class BossOrbShooty : MonoBehaviour
{
	public Rigidbody rb;

	public SphereCollider collider;

	public GameObject explosion;

	public GameObject trail;

	public RandomSfx randomSfx;

	private Enemy boss;

	private bool isFired;

	private float speed;

	private float moveAtTime;

	private float destroyAtTime;

	private Vector3 offset;

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

	private void FloatMovement()
	{
	}

	private void OnCollisionEnter(Collision collision)
	{
	}

	private float GetDamage()
	{
		return 0f;
	}
}
