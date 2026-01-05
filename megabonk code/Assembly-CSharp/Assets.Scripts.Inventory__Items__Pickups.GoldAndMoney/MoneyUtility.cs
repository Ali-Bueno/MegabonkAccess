using System;
using System.Collections.Generic;
using Assets.Scripts.Actors;
using Assets.Scripts.Actors.Enemies;
using Assets.Scripts.Inventory__Items__Pickups.Items;
using UnityEngine;

namespace Assets.Scripts.Inventory__Items__Pickups.GoldAndMoney;

public class MoneyUtility
{
	public static int[] moneyTiers;

	private const float spawnInterval = 60f;

	private static float nextSilverSpawnTime;

	private static List<int> coins;

	private static Dictionary<GameObject, MoneyFlying> flyingMoneyDict;

	private static MoneyFlying lastSpawnedMoney;

	private static int chestBasePrice;

	private static int priceIncreasePerChest;

	private static int priceIncreasePerChestOver10;

	private static int priceIncreasePerChestOver20;

	private static int priceIncreasePerChestOver30;

	private static int priceIncreasePerChestOver40;

	private static int priceIncreasePerChestOver50;

	private static float chestPriceIncrease;

	private static int chestsPurchased;

	private static float bigPotMultiplier;

	private static float potMoneyFractionOfChest;

	public static Action A_ChestPriceIncreased;

	public static void Init()
	{
	}

	public static void Cleanup()
	{
	}

	private static void OnEnemyDied(Enemy enemy, DamageContainer deathSource)
	{
	}

	private static void CheckSilver(Enemy enemy)
	{
	}

	private static void SpawnSilver(Enemy enemy)
	{
	}

	public static void SpawnSilver(Vector3 pos)
	{
	}

	public static void SpawnSilverNoTimerImpact(int amount, Vector3 pos)
	{
	}

	private static void OnNewRun()
	{
	}

	private static void OnNewStage()
	{
	}

	public static List<int> Exchange(int amount)
	{
		return null;
	}

	public static void SpawnMoney(int amount, Vector3 pos)
	{
	}

	public static int GetChestPrice()
	{
		return 0;
	}

	public static int GetShadyguyPrice()
	{
		return 0;
	}

	public static int GetItemPriceShadyGuy(EItemRarity rarity)
	{
		return 0;
	}

	public static int GetPotMoney(bool isBig)
	{
		return 0;
	}

	public static void IncreaseChestPrice()
	{
	}
}
