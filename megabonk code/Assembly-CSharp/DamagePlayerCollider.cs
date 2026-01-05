using UnityEngine;

public class DamagePlayerCollider : MonoBehaviour
{
	public float knockbackForce;

	public float damage;

	public float refreshTime;

	private float readyAtTime;

	private void OnCollisionEnter(Collision collision)
	{
	}
}
