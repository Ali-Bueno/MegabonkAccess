namespace Assets.Scripts.Inventory__Items__Pickups.AbilitiesActives;

public abstract class ActiveAbility
{
	protected float readyAtTime;

	public void Use()
	{
	}

	public abstract void Tick();

	private bool IsReady()
	{
		return false;
	}

	public abstract void Init();

	public abstract void Cleanup();

	public abstract void UseImplementation();

	public abstract float GetCooldown();
}
