namespace Assets.Scripts.Game.Combat.EnemyDebuffs.Implementations;

public class DebuffIce : EnemyDebuff
{
	public static float slowMultiplier;

	public static int numFrozenEnemies;

	public override int GetStacks()
	{
		return 0;
	}

	public override void MyTick()
	{
	}

	public override EDebuff GetDebuffType()
	{
		return default(EDebuff);
	}

	public override void OnAdded()
	{
	}

	public override void OnRemove(bool fromDeath)
	{
	}

	protected override void OnResetState()
	{
	}

	public override void OnRefresh()
	{
	}

	public override void AddStacks(int numStacks)
	{
	}
}
