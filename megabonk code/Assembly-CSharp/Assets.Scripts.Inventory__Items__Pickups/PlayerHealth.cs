using System;
using System.Collections.Generic;
using Assets.Scripts.Actors;
using Assets.Scripts.Actors.Enemies;
using Assets.Scripts.Game.Combat;
using Assets.Scripts.Inventory__Items__Pickups.Stats;
using Assets.Scripts.Menu.Shop;
using UnityEngine;

namespace Assets.Scripts.Inventory__Items__Pickups;

public class PlayerHealth
{
	public static int maxMaxHp;

	public int hp;

	public int maxHp;

	public float overheal;

	public float maxOverheal;

	public float shield;

	public float maxShield;

	public static Action<PlayerHealth, DamageContainer, bool> A_TakeDamage;

	public static Action<PlayerHealth, float, bool> A_Heal;

	public static Action<PlayerHealth> A_MaxValuesChanged;

	public static Action<PlayerHealth> A_OverhealUpdate;

	public static Action A_CooldownOver;

	public static Action A_Died;

	public static Action<Enemy> A_Evaded;

	public static Action<DamageContainer, bool> A_CheckStopDamage;

	private float baseHp;

	private float baseShield;

	private string lvlHpMovingStatName;

	private float minFallDamageSpeed;

	private float maxFallDamageSpeed;

	public float fallDamageTakenAtTime;

	public const string fallDamageSource = "fallDamage";

	private const string externalDamageSource = "Enemy";

	public static Action A_StoppedDamage;

	public static Action A_DamagePlayerCalled;

	public static HashSet<string> selfDamageSources;

	public static string thornsDamageSource;

	private float shieldRechargeAtTime;

	private float shieldRegenCooldownTime;

	public const float damageCooldownTime = 0.15f;

	public static Action<Enemy, int> A_LifestealProc;

	private int lifestealHeal;

	public static Action<int> A_LifestealHealing;

	private float leftOverHeal;

	public const string healthRegenDamageSource = "HealthRegen";

	private float nextCheckDeadTime;

	private float checkDeadInterval;

	private float overhealRemovalFractionPerSecond;

	private float shieldHealingPerTick;

	private float shieldHealingValue;

	private float healingValue;

	private float healingTime;

	private float healInterval;

	private float healPerInterval;

	private float healingPerMinute;

	private float damageCooldown;

	public PlayerHealth(PlayerStatsNew playerStats)
	{
	}

	public void OnDestroy()
	{
	}

	private void OnPickup(Pickup pickup)
	{
	}

	private void OnStatUpdate(EStat stat)
	{
	}

	private void OnLevelUp(int lvl)
	{
	}

	private void UpdateRegenValues(float forceValue = 0f)
	{
	}

	private void OnPlayerLanded(float speed)
	{
	}

	private void UpdateMaxValues()
	{
	}

	public void DamagePlayer(Enemy enemy, Vector3 direction, DcFlags flags = DcFlags.None)
	{
	}

	public void DamagePlayerExternal(float damage, float knockback, Vector3 direction, bool ignoreShield = false, string damageSource = "Enemy", DcFlags flags = DcFlags.None, EDamageEffect damageEffect = EDamageEffect.None, Enemy enemy = null)
	{
	}

	private void Damage(DamageContainer dc, bool ignoreShield)
	{
	}

	private void CheckDamageCooldown(DamageContainer dc)
	{
	}

	private void CheckShieldRecharge(DamageContainer dc)
	{
	}

	public void KillPlayer()
	{
	}

	public bool CheckStopDamage(DamageContainer dc, bool ignoreShield)
	{
		return false;
	}

	private void UseAegis(DamageContainer dc, Color color, string text = "Block")
	{
	}

	public bool WillDamageKill(DamageContainer dc, bool ignoreShield)
	{
		return false;
	}

	public bool WillDamageKill(float damage, bool ignoreShield)
	{
		return false;
	}

	private void Evade(DamageContainer dc)
	{
	}

	public void Retaliate(DamageContainer dc)
	{
	}

	private float GetDamageCooldown()
	{
		return 0f;
	}

	private void OnEnemyDamaged(Enemy enemy, DamageContainer dc)
	{
	}

	private void TryLifestealHit(Enemy enemy, DamageContainer dc)
	{
	}

	private void ApplyLifesteal()
	{
	}

	public int Heal(float amount, bool allowOverheal = true)
	{
		return 0;
	}

	public void Tick()
	{
	}

	private void CheckDead()
	{
	}

	private void UpdateHealthRegen()
	{
	}

	public void PlayerDied()
	{
	}

	public bool IsDead()
	{
		return false;
	}

	public bool CanTakeDamage()
	{
		return false;
	}

	public int GetCombinedHp()
	{
		return 0;
	}

	public int GetCombinedMaxHp()
	{
		return 0;
	}

	public float GetHpRatio()
	{
		return 0f;
	}

	public bool DamageCooldown()
	{
		return false;
	}

	public bool CanHeal()
	{
		return false;
	}

	public bool CanLifesteal()
	{
		return false;
	}
}
