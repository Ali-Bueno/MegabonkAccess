using Assets.Scripts.Actors;
using Assets.Scripts.Actors.Enemies;
using Assets.Scripts.Inventory__Items__Pickups.Stats;
using TMPro;
using UnityEngine;

public class StonksText : MonoBehaviour
{
	private int amount;

	public TextMeshProUGUI t_gold;

	private bool active;

	private float rotationSpeed;

	private float maxRotationAngle;

	private float timeCounter;

	private float lerp;

	private float lerp2;

	private float scaleOffset;

	private void Awake()
	{
	}

	public void Reset()
	{
	}

	private void OnStatusEffectAdded(EStatusEffect eStatusEffect, bool isNewEffect)
	{
	}

	private void OnStatusEffectRemoved(EStatusEffect eStatusEffect)
	{
	}

	private void OnEnemyDied(Enemy e, DamageContainer deathSource)
	{
	}

	private void Update()
	{
	}

	private void OnDestroy()
	{
	}
}
