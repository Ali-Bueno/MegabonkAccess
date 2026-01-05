using Assets.Scripts.Game.Combat.ConstantAttacks;
using Assets.Scripts.Menu.Shop;

public class ChunkersAttack : ConstantAttack
{
	public RandomSfx regenSfx;

	public RotatingProjectiles rotatingProjectiles;

	private int currentAmount;

	private float shieldReadyAtTime;

	private float rotationSpeed;

	private float cooldown;

	private float minCooldown;

	private float duration;

	private int amount;

	private float startTime;

	private float stopTime;

	private float nextStartTime;

	private bool isAttacking;

	protected override void Init()
	{
	}

	private void FindNewTimes()
	{
	}

	public void StartAttack()
	{
	}

	public void StopAttack()
	{
	}

	private void FixedUpdate()
	{
	}

	public override float GetAuraRotationSpeed()
	{
		return 0f;
	}

	protected override void OnWeaponStatUpdate(EStat stat, EWeapon weapon)
	{
	}

	protected override void OnStatUpdate(EStat stat)
	{
	}

	private void SetDuration()
	{
	}

	private void SetProjectiles()
	{
	}

	private void SetSize()
	{
	}

	private void SetProjectileSpeed()
	{
	}

	private void SetCooldown()
	{
	}
}
