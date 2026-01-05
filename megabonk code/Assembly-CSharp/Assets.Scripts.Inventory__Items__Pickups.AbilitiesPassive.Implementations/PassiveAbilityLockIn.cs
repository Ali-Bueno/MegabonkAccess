using UnityEngine.Localization;

namespace Assets.Scripts.Inventory__Items__Pickups.AbilitiesPassive.Implementations;

public class PassiveAbilityLockIn : PassiveAbility
{
	public int thornsPerLevel;

	private float maxDamage;

	private float maxDamagePerLevel;

	private float updateCooldown;

	private float nextUpdateTime;

	private float lastValue;

	public override void Init()
	{
	}

	public override void Cleanup()
	{
	}

	private void OnAegisChange(int currentAmount)
	{
	}

	public override void Tick()
	{
	}

	private void OnLevelup(int level)
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
