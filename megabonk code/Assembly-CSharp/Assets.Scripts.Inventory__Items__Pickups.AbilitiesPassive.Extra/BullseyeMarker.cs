using Assets.Scripts.Actors;
using Assets.Scripts.Actors.Enemies;
using UnityEngine;

namespace Assets.Scripts.Inventory__Items__Pickups.AbilitiesPassive.Extra;

public class BullseyeMarker : MonoBehaviour
{
	private Enemy markedEnemy;

	private float doneAtTime;

	private void Awake()
	{
	}

	private void OnDestroy()
	{
	}

	public void Set(Enemy enemy, float duration)
	{
	}

	private void Update()
	{
	}

	private void OnEnemyReleasedFromPool(Enemy enemy)
	{
	}

	private void OnEnemyDied(Enemy enemy, DamageContainer deathSource)
	{
	}

	private void Cleanup()
	{
	}
}
