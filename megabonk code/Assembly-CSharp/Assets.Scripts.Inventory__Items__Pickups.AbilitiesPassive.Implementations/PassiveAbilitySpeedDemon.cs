using Assets.Scripts.Actors;

namespace Assets.Scripts.Inventory__Items__Pickups.AbilitiesPassive.Implementations;

public class PassiveAbilitySpeedDemon : PassiveAbility
{
	private float increaseInterval;

	private float increasePerInterval;

	private float speedIncrease;

	private float nextInterval;

	private float cap;

	private float updateStatsInterval;

	private float nextUpdateDamageTime;

	private float damagePerSpeedMultiplier;

	private float damagePerLevel;

	private int hitsToFullyResetSpeedMin;

	private int hitsToFullyResetSpeedMax;

	private int hitsToFullyResetSpeed;

	private int levelPerHitIncrease;

	public override void Init()
	{
	}

	public override void Cleanup()
	{
	}

	public override void Tick()
	{
	}

	private void TickSpeedIncrease()
	{
	}

	private void TickDamageIncrease()
	{
	}

	private bool CanTick()
	{
		return false;
	}

	private void OnLevelup(int level)
	{
	}

	private void OnDamage(PlayerHealth ph, DamageContainer dc, bool brokeShield)
	{
	}

	public override EPassive GetPassiveType()
	{
		return default(EPassive);
	}
}
