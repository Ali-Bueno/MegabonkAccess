using Assets.Scripts.Actors;
using Assets.Scripts.Actors.Enemies;

namespace Assets.Scripts.Game.Combat.EnemyDebuffs.Implementations;

public class DebuffBloodmark : EnemyDebuff
{
	public const float defaultDuration = 4f;

	private int stacks;

	public static string damageSource;

	private DamageContainer dc;

	private float baseDamageMultiplier;

	private float damage;

	private bool isDone;

	private bool isSubscribed;

	public override int GetStacks()
	{
		return 0;
	}

	public override void MyTick()
	{
	}

	public float GetDamage()
	{
		return 0f;
	}

	public override void AddStacks(int numStacks)
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

	private void OnEnemyDamaged(Enemy e, DamageContainer dc)
	{
	}

	public override void OnRefresh()
	{
	}

	protected override void OnResetState()
	{
	}
}
