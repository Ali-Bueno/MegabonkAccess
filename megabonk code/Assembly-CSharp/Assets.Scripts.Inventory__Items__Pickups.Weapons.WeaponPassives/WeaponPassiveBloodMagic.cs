using Assets.Scripts.Actors;
using Assets.Scripts.Actors.Enemies;

namespace Assets.Scripts.Inventory__Items__Pickups.Weapons.WeaponPassives;

public class WeaponPassiveBloodMagic : WeaponPassive
{
	private int stacks;

	private float stackChance;

	private static string bloodMagicDamageSource;

	private static float maxRollsUpgradesPerMinute;

	private float rollCooldown;

	private float nextReadyTime;

	public override void Init()
	{
	}

	public override void Cleanup()
	{
	}

	private void OnEnemyDied(Enemy enemy, DamageContainer dc)
	{
	}

	public WeaponPassiveBloodMagic(WeaponBase weaponBase)
		: base(null)
	{
	}
}
