using UnityEngine.Localization;

namespace Assets.Scripts.Inventory__Items__Pickups.AbilitiesPassive.Implementations;

public class PassiveAbilityEnduring : PassiveAbility
{
	private float sizePerLevel;

	private float maxSize;

	private float damageMultiplierPerFrozenEnemy;

	private float maxDamageFromFrozenEnemies;

	private int lastNumFrozenEnemies;

	public override void Init()
	{
	}

	private void OnStageStarted()
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
