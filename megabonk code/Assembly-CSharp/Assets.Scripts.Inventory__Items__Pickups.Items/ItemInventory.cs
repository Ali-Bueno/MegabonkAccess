using System;
using System.Collections.Generic;
using Assets.Scripts.Actors;
using Assets.Scripts.Inventory__Items__Pickups.Stats;
using Assets.Scripts.Menu.Shop;

namespace Assets.Scripts.Inventory__Items__Pickups.Items;

public class ItemInventory
{
	public Dictionary<EItem, ItemBase> items;

	public static Action<EStat> A_StatsChanged;

	public static Action<EItem> A_ItemAdded;

	public static Action<EItem, bool> A_ItemRemoved;

	private HashSet<EItem> itemsWithOnHitProcs;

	private HashSet<EItem> itemsWithPreAttackProcs;

	private DamageContainer postDamageDc;

	public void AddItem(EItem eItem)
	{
	}

	public void AddItem(EItem eItem, int count)
	{
	}

	public ItemBase GetItem(EItem eItem)
	{
		return null;
	}

	public void RemoveItem(EItem eItem, bool showEffect = true)
	{
	}

	public void Tick()
	{
	}

	public StatComponents PreAttack(DamageContainer dc, StatComponents itemModifierStatComponents)
	{
		return null;
	}

	public void PostDamage(DamageContainer dc)
	{
	}

	private void OnLateFixedUpdate()
	{
	}

	public void StatWasModified(EStat stat)
	{
	}

	public int GetAmount(EItem eItem)
	{
		return 0;
	}

	public int GetUniqueItemsInRarity(EItemRarity itemRarity)
	{
		return 0;
	}

	public void Cleanup()
	{
	}
}
