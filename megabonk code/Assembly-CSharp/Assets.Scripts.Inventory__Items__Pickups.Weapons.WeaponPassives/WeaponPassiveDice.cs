namespace Assets.Scripts.Inventory__Items__Pickups.Weapons.WeaponPassives;

public class WeaponPassiveDice : WeaponPassive
{
	private int stacks;

	private float critPer6;

	private string movingStatName;

	private static float maxRollsUpgradesPerMinute;

	private float rollCooldown;

	private float nextRollTime;

	private float accumulatedCritChance;

	public override void Init()
	{
	}

	public override void Cleanup()
	{
	}

	private void OnStackAdded()
	{
	}

	public WeaponPassiveDice(WeaponBase weaponBase)
		: base(null)
	{
	}
}
