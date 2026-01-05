using Assets.Scripts.Actors;
using Assets.Scripts.Actors.Enemies;
using UnityEngine.Localization;

namespace Assets.Scripts.Inventory__Items__Pickups.AbilitiesPassive.Implementations;

public class PassiveAbilityPlague : PassiveAbility
{
	private int levelsPerStack;

	private float radius;

	private float maxRadius;

	private float radiusPerLevel;

	private float duration;

	private float poisonDamagePerLevel;

	public override void Init()
	{
	}

	public override void Cleanup()
	{
	}

	private void OnEnemyDied(Enemy enemy, DamageContainer deathSource)
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
