using Assets.Scripts.Actors.Enemies;
using UnityEngine;

public class BossOrb : MonoBehaviour
{
	public Rigidbody rb;

	public SphereCollider collider;

	public GameObject explosion;

	public GameObject trail;

	public RandomSfx randomSfx;

	private Vector3 offset;

	private Enemy boss;

	private int iterationsBeforeExplode;

	private float overshootDistance;

	private float moveInterval;

	private float nextMoveTime;

	private float moveTimer;

	private float moveOverSeconds;

	private float maxMoveDistance;

	private Vector3 fromPosition;

	private Vector3 toPosition;

	private bool isFired;

	public float spinSpeed;

	private float currentAngle;

	private float moveDist;

	private Vector3 moveDirection;

	private float moveSpeed;

	private int numMoves;

	protected void Start()
	{
	}

	public void Set(float startDelay, int currentPhase, Enemy ignoreCollisionEnemy, int numOrbs, int orbIndex)
	{
	}

	private void FixedUpdate()
	{
	}

	private void Update()
	{
	}

	private void FloatMovement()
	{
	}

	private void UpdateMoving()
	{
	}

	private void StartMoving()
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
