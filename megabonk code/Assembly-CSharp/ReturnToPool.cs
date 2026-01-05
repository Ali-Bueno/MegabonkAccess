using UnityEngine;
using UnityEngine.Pool;

public class ReturnToPool : MonoBehaviour
{
	private float timeout;

	private float returnTime;

	public ObjectPool<GameObject> pool;

	public void SetTime(float timeout, ObjectPool<GameObject> pool)
	{
	}

	private void OnEnable()
	{
	}

	private void Update()
	{
	}
}
