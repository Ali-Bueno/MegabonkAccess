using UnityEngine;
using UnityEngine.Pool;

public class AttackHit : MonoBehaviour
{
	public float timeout;

	public RandomSfx randomSfx;

	public ParticleSystem ps;

	public ObjectPool<GameObject> pool;

	public AudioClip enemyHitSfx;

	public AudioClip wallHitSfx;

	public void Play(bool hitEnemy, bool useSfx)
	{
	}

	private void ReleaseToPool()
	{
	}

	private void OnValidate()
	{
	}
}
