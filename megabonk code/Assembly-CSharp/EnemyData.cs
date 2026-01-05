using Actors.Enemies;
using Assets.Scripts._Data.MapsAndStages;
using Assets.Scripts.Game.Combat.EnemySpecialAttacks;
using UnityEngine;
using UnityEngine.Localization;

public class EnemyData : ScriptableObject
{
	public EEnemy enemyName;

	public Material material;

	public AnimatedMeshScriptableObject animation;

	public Vector3 rendererOffset;

	public Vector3 rendererRotationOffset;

	public float rendererScale;

	public float colliderRadius;

	public float overrideHeight;

	public Vector3 colliderCenter;

	public int hp;

	public int damage;

	public int shield;

	public bool isPoison;

	public float knockbackResistance;

	public bool nukeProtection;

	public float mass;

	public float speed;

	public bool isFlying;

	public float teleportCooldown;

	public bool isRunningFromPlayer;

	public float minStayAtDistance;

	public float maxStayAtDistance;

	public int xp;

	public float despawnTime;

	public bool canBeElite;

	public bool canBeExecuted;

	public float maxSuckTime;

	public EnemySpecialAttack[] specialAttacks;

	public EMap maps;

	public int minStage;

	public float creditCost;

	public float canSpawnAfterTime;

	public LocalizedString forceName;

	public string GetName()
	{
		return null;
	}

	public int GetGold()
	{
		return 0;
	}

	public int GetXp()
	{
		return 0;
	}

	public int GetEliteXp()
	{
		return 0;
	}

	public float GetKnockback()
	{
		return 0f;
	}

	public float GetDamage()
	{
		return 0f;
	}
}
