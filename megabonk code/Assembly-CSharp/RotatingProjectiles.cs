using System.Collections.Generic;
using Assets.Scripts.Inventory__Items__Pickups.Weapons;
using UnityEngine;
using Utility;

public class RotatingProjectiles : MonoBehaviour
{
	public GameObject prefab;

	public float baseProjectileRadius;

	public AudioSource audioSpawn;

	public AudioSource audioLoop;

	private float baseLoopVolume;

	private List<ParticleSystem> prefabs;

	private int amount;

	private float projectileRadius;

	private float rotationSpeed;

	private const int maxQuantity = 50;

	private float maxRotationSpeed;

	private Vector3[] rockPositions;

	private List<RaycastUtility.ConeSphere> debugSpheres;

	private Dictionary<int, Dictionary<Collider, float>> projectileEnemiesCooldowns;

	private float enemyHitCooldown;

	public WeaponBase weaponBase;

	private float fadeTimer;

	private float fadeTime;

	private bool isActive;

	private float startTime;

	private float endTime;

	private float duration;

	public float baseDistance;

	private Vector3 defaultScale;

	private Vector3 projectileScale;

	private float scaleMultiplier;

	private float distance;

	public void SetWeapon(WeaponBase weaponBase)
	{
	}

	private void TryInit()
	{
	}

	private void Update()
	{
	}

	private bool CanHitbox()
	{
		return false;
	}

	private void FixedUpdate()
	{
	}

	private void StepHitboxes()
	{
	}

	private bool HitEnemy(int projectileIndex, Collider collider)
	{
		return false;
	}

	private void OnDrawGizmosSelected()
	{
	}

	public void Show()
	{
	}

	public void Hide()
	{
	}

	public void SetAmount(int newAmount)
	{
	}

	public void SetSize(float multiplier)
	{
	}

	public void SetSpeed(float speed)
	{
	}

	public void SetDuration(float duration)
	{
	}
}
