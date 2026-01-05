using Assets.Scripts.Game.Combat.EnemySpecialAttacks.Implementations;
using UnityEngine;

public class EnemySpecialAttackSpinningLasers : EnemySpecialAttackPrefab
{
	public Rigidbody rb;

	public Transform disk;

	public Transform laserParent;

	private Transform[] lasers;

	private float overAtTime;

	private float startedAtTime;

	private float laserLength;

	private float maxLaserLength;

	private Vector3 defaultScale;

	private float defaultVolume;

	public AudioSource audio;

	private float audioFadeTime;

	private float damageCooldown;

	private float nextDamageReadyTime;

	public float defaultSpinSpeed;

	public float diskRotationSpeed;

	private float spinSpeed;

	private float spinAngle;

	private float spinPhaseOffset;

	protected override void Init()
	{
	}

	private void OnceInit()
	{
	}

	private void FixedUpdate()
	{
	}

	private void OnTriggerStay(Collider other)
	{
	}

	private void RotationStuff()
	{
	}
}
