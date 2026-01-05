using System;
using Assets.Scripts.Menu.Shop;

namespace Assets.Scripts.Inventory__Items__Pickups.Stats;

[Serializable]
public class StatModifier
{
	public EStat stat;

	public EStatModifyType modifyType;

	public float modification;

	public float GetModificationAtAmount(int amount)
	{
		return 0f;
	}

	public float GetModificationTotal(int amount)
	{
		return 0f;
	}

	public override string ToString()
	{
		return null;
	}
}
