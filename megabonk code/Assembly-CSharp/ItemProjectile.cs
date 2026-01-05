using Assets.Scripts.Actors;
using Assets.Scripts.Actors.Enemies;
using UnityEngine;
using UnityEngine.Pool;

public class ItemProjectile : MonoBehaviour
{
	public bool ignoreGroundCollision;

	public float projectileSpeed;

	public float projectileRadius;

	private float damage;

	protected float spawnedAtTime;

	private float finalProjectileSpeed;

	private float upTime;

	protected float expirationTime;

	private string damageSource;

	protected int projectileIndex;

	protected int projectilesCount;

	private float range;

	private Vector3 startDirection;

	private Vector3 lastDirection;

	private Enemy targetEnemy;

	private Vector3 currentDir;

	private float nextFindTime;

	protected static readonly RaycastHit[] raycastBuffer;

	private float procCoefficient;

	private DamageContainer reuseDc;

	public ObjectPool<GameObject> projectilePool;

	public GameObject projectileHitEffect;

	public void Set(Vector3 pos, float damage, float procCoefficient, string damageSource, ObjectPool<GameObject> projectilePool, int projectileIndex, int totalProjectiles, float duration, float range)
	{
	}

	public void AddDamage(float damage)
	{
	}

	protected virtual void Init()
	{
	}

	private void FixedUpdate()
	{
	}

	protected virtual void Step()
	{
	}

	protected virtual Vector3 GetMovementDirection()
	{
		return default(Vector3);
	}

	private void FindTarget()
	{
	}

	protected virtual void StepAttackMovement()
	{
	}

	protected virtual void CheckSpawnCollision()
	{
	}

	protected virtual bool CheckCollision(Collider collider, Vector3 normal)
	{
		return false;
	}

	private bool HitEnemy(Collider collider, Vector3 normal)
	{
		return false;
	}

	private void HitOther(Collider collider, Vector3 normal)
	{
	}

	private void CheckTimeout()
	{
	}

	protected virtual void ProjectileDone()
	{
	}
}
