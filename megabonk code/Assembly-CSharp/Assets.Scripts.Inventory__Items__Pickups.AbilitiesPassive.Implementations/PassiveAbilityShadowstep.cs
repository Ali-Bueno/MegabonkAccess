using Assets.Scripts.Actors;
using Assets.Scripts.Actors.Enemies;
using UnityEngine.Localization;

namespace Assets.Scripts.Inventory__Items__Pickups.AbilitiesPassive.Implementations;

public class PassiveAbilityShadowstep : PassiveAbility
{
	private float evadePerLevel;

	public const string damageSource = "Shadowstep";

	private DamageContainer reuseDc;

	public override void Init()
	{
	}

	public override void Cleanup()
	{
	}

	public override void Tick()
	{
	}

	private void OnLevelup(int level)
	{
	}

	private void OnEvade(Enemy enemy)
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
