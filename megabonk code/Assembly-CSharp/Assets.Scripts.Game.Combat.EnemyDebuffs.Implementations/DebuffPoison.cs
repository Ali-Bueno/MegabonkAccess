namespace Assets.Scripts.Game.Combat.EnemyDebuffs.Implementations;

public class DebuffPoison : EnemyDebuff
{
	public static int numPoisonedEnemies;

	private int stacks;

	public static string poisonDamageSource;

	public float GetDamageForHpBar()
	{
		return 0f;
	}

	public override void MyTick()
	{
	}

	public static float GetPoisonDamagePerTick(int stacks)
	{
		return 0f;
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

	protected override void OnResetState()
	{
	}

	public override void OnRefresh()
	{
	}

	public override void AddStacks(int numStacks)
	{
	}

	public override int GetStacks()
	{
		return 0;
	}
}
