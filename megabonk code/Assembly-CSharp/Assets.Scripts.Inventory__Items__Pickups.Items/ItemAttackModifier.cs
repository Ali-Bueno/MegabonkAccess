using Assets.Scripts.Actors;

namespace Assets.Scripts.Inventory__Items__Pickups.Items;

public class ItemAttackModifier
{
	public float flatValues;

	public float additiveValues;

	public float multiplicativeValues;

	private float _003CdamageMultiplier_003Ek__BackingField;

	public float damageMultiplier
	{
		get
		{
			return _003CdamageMultiplier_003Ek__BackingField;
		}
		private set
		{
			_003CdamageMultiplier_003Ek__BackingField = value;
		}
	}

	public void Recycle()
	{
	}

	public void Apply(DamageContainer dc)
	{
	}

	public void AddMultiplier(float multiplier)
	{
	}
}
