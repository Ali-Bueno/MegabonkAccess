using System.Collections.Generic;
using Assets.Scripts.Inventory__Items__Pickups.Stats;

namespace Assets.Scripts.Inventory__Items__Pickups.Items;

public class StatModifiersContainer
{
	private Dictionary<EStatModifyType, StatModifier> statContainers;

	public void SetModifier(StatModifier statModifier)
	{
	}

	public IEnumerable<StatModifier> GetModifiers()
	{
		return null;
	}
}
