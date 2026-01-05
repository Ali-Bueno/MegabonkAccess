using UnityEngine.Localization;

namespace Assets.Scripts.Inventory__Items__Pickups.AbilitiesPassive.Implementations;

public class PassiveAbilityHoarder : PassiveAbility
{
	private float hoverFallSpeed;

	private float spawnIntervalStartSeconds;

	private float spawnIntervalEndSeconds;

	private float spawnIntervalIncreasePerDrop;

	private float spawnIntervalSeconds;

	private float currentTimer;

	private int accumulatedTicks;

	private int maxAccumulatedTicks;

	private float lastAccumulatedTime;

	public override void Cleanup()
	{
	}

	public override void Init()
	{
	}

	public override void Tick()
	{
	}

	private void MovementTick()
	{
	}

	private void ChestTick()
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
