using System;
using System.Collections.Generic;
using Assets.Scripts.Actors;
using Assets.Scripts.Inventory__Items__Pickups.Stats;
using Assets.Scripts.Menu.Shop;
using UnityEngine.Localization;

namespace Assets.Scripts.Inventory__Items__Pickups.Items;

public abstract class ItemBase
{
	private string damageSource;

	public int amount;

	private ItemInventory itemInventoryRef;

	public Dictionary<EStat, StatModifiersContainer> statModifiers;

	public static Action<ItemBase> A_ItemAdded;

	public static Action<ItemBase> A_ItemRemoved;

	protected ItemBase(ItemInventory itemInventoryRef)
	{
	}

	protected void SetStat(StatModifier statModifier)
	{
	}

	public void AddAmount()
	{
	}

	public void RemoveAmount()
	{
	}

	public abstract void Init();

	public abstract void Cleanup();

	protected abstract void OnInitOrAmountChanged();

	public abstract void Tick();

	public abstract void PreAttack(DamageContainer dc, StatComponents itemAttackModifier);

	public abstract void ProcOnHitEffects(DamageContainer dc);

	public abstract bool HasOnHitEffectProc();

	public abstract bool HasPreAttackProc();

	public virtual void LateFixedUpdate()
	{
	}

	protected virtual Dictionary<string, object> GetLocalizationKeys()
	{
		return null;
	}

	public virtual string GetDescription(LocalizedString localizedString)
	{
		return null;
	}
}
