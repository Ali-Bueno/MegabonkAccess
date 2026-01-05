using UnityEngine.Localization;

namespace Assets.Scripts.Inventory__Items__Pickups.AbilitiesPassive.Implementations;

public class PassiveAbilityQuantumXp : PassiveAbility
{
	private float xpPerLevel;

	public override void Init()
	{
	}

	public override void Cleanup()
	{
	}

	private void OnLevelup(int level)
	{
	}

	public override string GetDescription(LocalizedString localizedString)
	{
		return null;
	}

	public override EPassive GetPassiveType()
	{
		return default(EPassive);
	}

	public override void Tick()
	{
	}
}
