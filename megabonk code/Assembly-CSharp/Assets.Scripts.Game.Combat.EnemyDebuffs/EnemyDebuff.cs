using Assets.Scripts.Actors;
using Assets.Scripts.Actors.Enemies;

namespace Assets.Scripts.Game.Combat.EnemyDebuffs;

public abstract class EnemyDebuff
{
	private int _003CticksLeft_003Ek__BackingField;

	protected Enemy enemy;

	public int ticksLeft
	{
		get
		{
			return _003CticksLeft_003Ek__BackingField;
		}
		protected set
		{
			_003CticksLeft_003Ek__BackingField = value;
		}
	}

	public EnemyDebuff()
	{
	}

	public void Set(Enemy enemy, DamageContainer dc, float duration, int stacks = 1)
	{
	}

	public virtual void Tick()
	{
	}

	public bool IsDone()
	{
		return false;
	}

	public void Refresh(float duration, int stacks)
	{
	}

	private int GetTicks(float duration)
	{
		return 0;
	}

	private void RefreshTimeout(float duration)
	{
	}

	public void ResetState()
	{
	}

	public abstract void AddStacks(int numStacks);

	public abstract int GetStacks();

	public abstract void MyTick();

	public abstract EDebuff GetDebuffType();

	public abstract void OnRemove(bool fromDeath);

	public abstract void OnAdded();

	public abstract void OnRefresh();

	protected abstract void OnResetState();
}
