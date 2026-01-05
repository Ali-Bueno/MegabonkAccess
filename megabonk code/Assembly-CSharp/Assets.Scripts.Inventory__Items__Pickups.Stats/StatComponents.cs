namespace Assets.Scripts.Inventory__Items__Pickups.Stats;

public class StatComponents
{
	public bool hasModifications;

	private float _003CbaseValue_003Ek__BackingField;

	private float _003CadditiveValue_003Ek__BackingField;

	private float _003CmultiplicativeValue_003Ek__BackingField;

	public float baseValue
	{
		get
		{
			return _003CbaseValue_003Ek__BackingField;
		}
		private set
		{
			_003CbaseValue_003Ek__BackingField = value;
		}
	}

	public float additiveValue
	{
		get
		{
			return _003CadditiveValue_003Ek__BackingField;
		}
		private set
		{
			_003CadditiveValue_003Ek__BackingField = value;
		}
	}

	public float multiplicativeValue
	{
		get
		{
			return _003CmultiplicativeValue_003Ek__BackingField;
		}
		private set
		{
			_003CmultiplicativeValue_003Ek__BackingField = value;
		}
	}

	public void Recycle()
	{
	}

	public void SetValues(float baseValues, float additiveValues, float multiplicativeValues)
	{
	}

	public float GetFinalValue(StatComponents other)
	{
		return 0f;
	}

	public void AddMultiplier(float value)
	{
	}

	public void AddAdditive(float value)
	{
	}

	public void AddFlat(float value)
	{
	}
}
