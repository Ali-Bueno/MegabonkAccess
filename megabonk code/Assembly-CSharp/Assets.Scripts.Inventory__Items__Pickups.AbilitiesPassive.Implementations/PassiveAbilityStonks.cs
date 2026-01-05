using UnityEngine.Localization;

namespace Assets.Scripts.Inventory__Items__Pickups.AbilitiesPassive.Implementations;

public class PassiveAbilityStonks : PassiveAbility
{
	private float goldIncreasePerLevel;

	private float damageIncreasePer1000Gold;

	private float damagePer1000Gold_First10k;

	private float damagePer1000Gold_First200k;

	private float damagePer1000Gold_First1m;

	private float damagePer1000Gold_After1m;

	private float nextUpdateTime;

	private float updateCooldown;

	private float lastValue;

	public override void Init()
	{
	}

	private float GetDamage()
	{
		return 0f;
	}

	public override void Tick()
	{
	}

	private void OnLevelup(int level)
	{
	}

	public override void Cleanup()
	{
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
