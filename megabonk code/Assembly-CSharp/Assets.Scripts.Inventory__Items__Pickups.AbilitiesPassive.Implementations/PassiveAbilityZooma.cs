using Assets.Scripts.Actors;
using Assets.Scripts.Actors.Enemies;
using UnityEngine;
using UnityEngine.Localization;

namespace Assets.Scripts.Inventory__Items__Pickups.AbilitiesPassive.Implementations;

public class PassiveAbilityZooma : PassiveAbility
{
	private float chargePerMeter;

	private float checkInterval;

	private float nextCheckTime;

	private Vector3 lastPos;

	private float accumulatedCharge;

	private float attractionAddPerLevel;

	private DamageContainer reuseDc;

	private string damageSource;

	public override void Init()
	{
	}

	public override void Cleanup()
	{
	}

	private void OnLevelup(int level)
	{
	}

	private void OnEnemyDamage(Enemy enemy, DamageContainer dc)
	{
	}

	private float GetDamage()
	{
		return 0f;
	}

	public override void Tick()
	{
	}

	public float GetProgress()
	{
		return 0f;
	}

	public override EPassive GetPassiveType()
	{
		return default(EPassive);
	}

	public override string GetDescription(LocalizedString localizedString)
	{
		return null;
	}
}
