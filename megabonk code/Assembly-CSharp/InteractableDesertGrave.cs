using Assets.Scripts.Actors;
using Assets.Scripts.Actors.Enemies;
using UnityEngine;
using UnityEngine.Localization;

public class InteractableDesertGrave : BaseInteractable
{
	public EnemyData enemyData;

	public LocalizedString interactString;

	public GameObject chargeFx;

	public GameObject explodeFx;

	private Enemy myEnemy;

	private bool done;

	public ShrineSpawnAnimation nextShrine;

	public float speedMultiplier;

	public float sizeMultiplier;

	private void Awake()
	{
	}

	private new void OnDestroy()
	{
	}

	private void OnEnemyDied(Enemy enemy, DamageContainer dc)
	{
	}

	public override bool Interact()
	{
		return false;
	}

	private void SpawnEnemy()
	{
	}

	public override string GetInteractString()
	{
		return null;
	}
}
