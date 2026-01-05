using Assets.Scripts.Actors;
using Assets.Scripts.Inventory__Items__Pickups;
using MilkShake;
using UnityEngine;

namespace Assets.Scripts.Camera;

public class CameraShakerController : MonoBehaviour
{
	public Shaker shaker;

	public ShakePreset damageShake;

	public ShakePreset objectImpactShake;

	public ShakePreset grindShake;

	public ShakePreset pylonSpawnShake;

	private float damageShakeCooldown;

	private float damageNextShakeReadyTime;

	private ShakeInstance grindShakeInstance;

	private void Awake()
	{
	}

	private void OnDestroy()
	{
	}

	private void Start()
	{
	}

	private void OnSettingUpdated(string setting, object oldValue, object newValue)
	{
	}

	private void OnDamage(PlayerHealth ph, DamageContainer dc, bool shieldDamage)
	{
	}

	private void OnObjectImpact(float shakeMultiplier)
	{
	}

	private void OnGrindToggle(bool isGrinding)
	{
	}

	private void OnPylonsStarted()
	{
	}
}
