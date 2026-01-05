using System.Collections.Generic;
using Assets.Scripts._Data;
using Assets.Scripts.Game.Combat;
using Assets.Scripts.Inventory__Items__Pickups;
using Assets.Scripts.Inventory__Items__Pickups.Stats;
using Assets.Scripts.Inventory__Items__Pickups.Upgrades;
using Assets.Scripts.Inventory__Items__Pickups.Weapons;
using Assets.Scripts.Menu.Shop;
using Assets.Scripts.Saves___Serialization.Progression.Achievements;
using UnityEngine;

public class WeaponData : UnlockableBase, IUpgradable
{
	public EWeapon eWeapon;

	public Texture icon;

	public bool onlySpawnWhenCloseEnemies;

	public Dictionary<EStat, float> baseStats;

	public float damage;

	public float knockback;

	public float critChance;

	public EElement element;

	public int projectiles;

	public int projectileBounces;

	public float attackDuration;

	public float maxDuration;

	public float maxSizeMultiplier;

	public float effectDuration;

	public float projectileSpeed;

	public float endCooldown;

	public float burstTime;

	public float minBurstInterval;

	public bool canBounce;

	public EAmplificationMode amplificationMode;

	public float procCoefficient;

	public bool useVision;

	public bool canMultiHit;

	public bool hasCrosshair;

	public float spawnProjectileRange;

	public bool isAura;

	public Vector3 spawnOffset;

	public GameObject attack;

	public UpgradeData upgradeData;

	public MyAchievement AchievementRequirement;

	private string _003CdamageSourceName_003Ek__BackingField;

	public string damageSourceName
	{
		get
		{
			return _003CdamageSourceName_003Ek__BackingField;
		}
		private set
		{
			_003CdamageSourceName_003Ek__BackingField = value;
		}
	}

	public void Init()
	{
	}

	public string GetUpgradeDescription(int level, List<StatModifier> upgradeOffer, ERarity rarity)
	{
		return null;
	}

	public override Texture GetIcon()
	{
		return null;
	}

	public override MyAchievement GetUnlockRequirement()
	{
		return null;
	}

	public override UnlockableBase GetUnlockableRequirement()
	{
		return null;
	}

	public override string GetUnlockableTypeDisplayString()
	{
		return null;
	}

	public override string GetInternalName()
	{
		return null;
	}

	public int GetLevel()
	{
		return 0;
	}

	public int GetMaxLevel()
	{
		return 0;
	}

	public List<StatModifier> GetUpgradeOffer(ERarity rarity)
	{
		return null;
	}

	public float GetBaseStat(EStat eStat)
	{
		return 0f;
	}

	public float CalculateTotalDistance(float initialSpeed, float reduction)
	{
		return 0f;
	}

	public float GetSpawnProjectileRange()
	{
		return 0f;
	}

	public override string ToString()
	{
		return null;
	}
}
