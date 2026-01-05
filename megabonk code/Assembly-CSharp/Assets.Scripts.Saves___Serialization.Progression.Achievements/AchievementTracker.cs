using Assets.Scripts._Data.Tomes;
using Assets.Scripts.Actors;
using Assets.Scripts.Actors.Enemies;
using Assets.Scripts.Inventory__Items__Pickups;
using Assets.Scripts.Inventory__Items__Pickups.Items;
using Assets.Scripts.Inventory__Items__Pickups.Weapons;
using Assets.Scripts.Menu.Shop;

namespace Assets.Scripts.Saves___Serialization.Progression.Achievements;

public static class AchievementTracker
{
	private static float baseMovementSpeed;

	private static float noDamageTimer;

	private static bool hasTakenDamageThisRun;

	private static bool hasDealtDamageThisRun;

	private static int consecutiveIceCrystalCooks;

	private static int consecutiveMoldyCheeseCooks;

	private static int runChestsBought;

	private static bool hasSpawnedLuckTomeQuest;

	private static string a_tacticalGlasses;

	private static string a_bossBuster;

	private static string a_luckTome;

	private static string a_quinsMask;

	private static string a_roberto;

	private static string aegisDamageSource;

	private static int chargedShrines;

	private static int chargedShrinesNoInterruptions;

	private static int totalChargeShrines;

	private static int numBoomboxes;

	public static void Init()
	{
	}

	public static void Cleanup()
	{
	}

	private static void OnFinalSwarmStart()
	{
	}

	private static void OnRunStarted()
	{
	}

	private static void OnStageStarted()
	{
	}

	private static void OnPLayerInventoryInited(PlayerInventory inv)
	{
	}

	private static void OnStatUpdate(EStat stat)
	{
	}

	private static void OnTick()
	{
	}

	private static void OnEnemyDied(Enemy enemy, DamageContainer deathSource)
	{
	}

	private static void OnStageBossDefeated(bool isOpeningPortal)
	{
	}

	private static void OnDamageTaken(PlayerHealth ph, DamageContainer dc, bool brokeShield)
	{
	}

	private static void OnEnemyDamaged(Enemy arg1, DamageContainer arg2)
	{
	}

	private static void OnLevelUp(int level)
	{
	}

	private static void OnChestBought()
	{
	}

	private static void OnShrineCharged(bool noChargeInterruption)
	{
	}

	private static void OnChargeShrineSpawned()
	{
	}

	private static void OnMicrowaveUsed(EItem eItem)
	{
	}

	private static void OnGhostBossDied()
	{
	}

	private static void OnWeaponAddedOrUpgraded(WeaponBase weapon)
	{
	}

	private static void OnTomeAddedOrUpgraded(ETome eTome, EStat stat)
	{
	}

	private static void OnItemAdded(EItem item)
	{
	}

	private static void OnPickupTriggered(Pickup pickup)
	{
	}

	private static void OnPotBroken()
	{
	}

	private static void OnInteracted(BaseInteractable interactable, bool success)
	{
	}

	private static void OnCryptSpeedrun(float cryptTime)
	{
	}

	private static void OnInteractableUsedDebug(string debugName)
	{
	}

	private static void CheckPotUnlock(string debugName)
	{
	}

	private static void CheckPumpkinUnlock(string debugName)
	{
	}

	private static void OnUnlock(MyAchievement achUnlocked)
	{
	}

	private static void OnPurchased(UnlockableBase unlockable)
	{
	}
}
