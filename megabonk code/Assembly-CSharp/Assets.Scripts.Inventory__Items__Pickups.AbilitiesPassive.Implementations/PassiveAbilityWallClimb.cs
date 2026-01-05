using UnityEngine.Localization;

namespace Assets.Scripts.Inventory__Items__Pickups.AbilitiesPassive.Implementations;

public class PassiveAbilityWallClimb : PassiveAbility
{
	private float hpPerLevel;

	public override void Init()
	{
	}

	private void OnLevelup(int level)
	{
	}

	public override void Cleanup()
	{
	}

	public override void Tick()
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
