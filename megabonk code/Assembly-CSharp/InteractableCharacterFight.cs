using Assets.Scripts.Actors;
using Assets.Scripts.Actors.Enemies;
using UnityEngine;
using UnityEngine.Localization;

public class InteractableCharacterFight : BaseInteractable
{
	public CharacterData character;

	public EnemyData enemyData;

	private bool done;

	public LocalizedString interactString;

	public GameObject chargeFx;

	public GameObject explodeFx;

	public Material enemyMat2;

	public Enemy myEnemy;

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
