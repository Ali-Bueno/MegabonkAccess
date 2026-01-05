using System.Collections.Generic;
using Assets.Scripts.Actors;
using UnityEngine;

public class XpDamager : MonoBehaviour
{
	public Pickup pickup;

	private bool isEnabled;

	private float damage;

	private float radius;

	private Vector3 dir;

	private static readonly RaycastHit[] _hits;

	private Vector3 lastPos;

	private Dictionary<Collider, float> enemyHitCooldowns;

	private float hitCooldown;

	private static string damageSource;

	private static DamageContainer reuseDc;

	private void OnEnable()
	{
	}

	private void Awake()
	{
	}

	private void OnDestroy()
	{
	}

	private void OnValueUpdated(int value)
	{
	}

	private void FixedUpdate()
	{
	}

	protected virtual void StepMovement()
	{
	}

	private void HitEnemy(Collider collider)
	{
	}
}
