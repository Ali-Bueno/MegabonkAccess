using Assets.Scripts.Actors;
using Assets.Scripts.Inventory__Items__Pickups;
using UnityEngine;

public class PlayerShieldEffects : MonoBehaviour
{
	public ParticleSystem shieldBreakFx;

	public ParticleSystem shieldChargeFx;

	public AudioSource shieldBreakSfx;

	public AudioSource shieldChargeSfx;

	private bool shieldBroken;

	private void Awake()
	{
	}

	private void OnDestroy()
	{
	}

	private void OnDamage(PlayerHealth ph, DamageContainer dc, bool shieldDamage)
	{
	}

	private void OnHeal(PlayerHealth ph, float amount, bool isShield)
	{
	}
}
