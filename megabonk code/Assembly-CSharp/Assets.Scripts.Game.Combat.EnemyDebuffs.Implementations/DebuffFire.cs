using Assets.Scripts.Actors;

namespace Assets.Scripts.Game.Combat.EnemyDebuffs.Implementations;

public class DebuffFire : EnemyDebuff
{
	private static string damageSource;

	private DamageContainer dc;

	private bool canDamage;

	public override int GetStacks()
	{
		return 0;
	}

	public override void MyTick()
	{
	}

	private float GetDamage()
	{
		return 0f;
	}

	protected override void OnResetState()
	{
	}

	public override EDebuff GetDebuffType()
	{
		return default(EDebuff);
	}

	public override void OnRemove(bool fromDeath)
	{
	}

	public override void OnAdded()
	{
	}

	public override void OnRefresh()
	{
	}

	public override void AddStacks(int numStacks)
	{
	}
}
