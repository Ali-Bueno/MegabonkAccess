using System;
using System.Collections.Generic;
using Assets.Scripts.Actors;
using Assets.Scripts.Actors.Enemies;
using Assets.Scripts.Inventory__Items__Pickups;
using Assets.Scripts.Inventory__Items__Pickups.Items;
using Assets.Scripts.Inventory__Items__Pickups.Pickups;
using Assets.Scripts.Inventory__Items__Pickups.Weapons.Projectiles;
using Assets.Scripts.Saves___Serialization.Progression.Achievements;
using Inventory__Items__Pickups.Xp_and_Levels;

namespace Assets.Scripts.Saves___Serialization.Progression.Stats;

public static class TrackStats
{
	public static Action A_PotBroken;

	private static string tornadoDamageSource;

	private static HashSet<EPickup> nonPowerupPickups;

	private static Dictionary<EMyStat, string> statStrings;

	public static void Init()
	{
	}

	public static void Cleanup()
	{
	}

	private static void AddValue(EMyStat stat, int value)
	{
	}

	private static void AddValue(string statKey, int value)
	{
	}

	private static void OnGoldChange(PlayerInventory inv, int amount)
	{
	}

	private static void OnSilverChange(int change)
	{
	}

	private static void OnEnemyDied(Enemy enemy, DamageContainer deathSource)
	{
	}

	private static void OnEnemyDamage(Enemy enemy, DamageContainer dc)
	{
	}

	private static void OnChestOpened()
	{
	}

	private static void OnItemAdded(EItem eItem)
	{
	}

	private static void OnXpAdded(PlayerXp playerXp, int amount)
	{
	}

	private static void OnAchievementUnlocked(MyAchievement ach)
	{
	}

	private static void OnUnlockPurchased(UnlockableBase unlock)
	{
	}

	private static void OnProjectileSpawned(ProjectileBase projectileBase)
	{
	}

	private static void OnInteracted(BaseInteractable interactable, bool success)
	{
	}

	private static void OnShrineCharged(bool notInterrupted)
	{
	}

	private static void OnChallengeShrineCompleted()
	{
	}

	private static void OnChestBought()
	{
	}

	private static void OnPlayerTakeDamage(PlayerHealth ph, DamageContainer dc, bool brokeShield)
	{
	}

	private static void OnEvade(Enemy attacker)
	{
	}

	private static void OnLifestealHealing(int amount)
	{
	}

	private static void OnDead()
	{
	}

	private static void OnIcecubeFreezeEnemy()
	{
	}

	private static void OnPickup(Pickup pickup)
	{
	}

	public static string GetStatString(EMyStat stat)
	{
		return null;
	}

	public static string GetCharacterRunsString(ECharacter character)
	{
		return null;
	}
}
