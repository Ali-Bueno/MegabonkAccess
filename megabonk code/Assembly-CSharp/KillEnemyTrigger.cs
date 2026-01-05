using UnityEngine;

public class KillEnemyTrigger : MonoBehaviour
{
	public float bossPercentage;

	public float knockback;

	public string customDamageSource;

	public bool canOneshotRedGhost;

	private float chanceToOneshotRedGhosts;

	public bool isBossLamp;

	private void OnTriggerEnter(Collider collider)
	{
	}

	private string GetDamageSource()
	{
		return null;
	}
}
