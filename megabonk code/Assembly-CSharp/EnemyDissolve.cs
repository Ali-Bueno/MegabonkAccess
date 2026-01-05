using System;
using Assets.Scripts.Actors.Enemies;
using UnityEngine;

public class EnemyDissolve : MonoBehaviour
{
	public Material dissolveMaterial;

	private float dissolveDuration;

	private float dissolveAmount;

	private float displaceAmount;

	private float displaceTarget;

	private bool isDissolving;

	public Renderer enemyRenderer;

	private MaterialPropertyBlock mpb;

	public Enemy enemy;

	public Action A_DissolveFinished;

	private void Update()
	{
	}

	public void StartDissolve()
	{
	}

	public void Reset()
	{
	}
}
