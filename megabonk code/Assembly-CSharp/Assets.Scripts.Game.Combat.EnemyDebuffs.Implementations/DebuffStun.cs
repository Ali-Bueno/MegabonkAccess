namespace Assets.Scripts.Game.Combat.EnemyDebuffs.Implementations;

public class DebuffStun : EnemyDebuff
{
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

	public override void OnRefresh()
	{
	}

	protected override void OnResetState()
	{
	}

	public override void AddStacks(int numStacks)
	{
	}
}
