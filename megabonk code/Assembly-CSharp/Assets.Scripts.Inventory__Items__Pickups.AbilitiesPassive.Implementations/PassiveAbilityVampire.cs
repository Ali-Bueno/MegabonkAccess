using UnityEngine.Localization;

namespace Assets.Scripts.Inventory__Items__Pickups.AbilitiesPassive.Implementations;

public class PassiveAbilityVampire : PassiveAbility
{
	private float lifestealPerLevel;

	public override void Init()
	{
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
