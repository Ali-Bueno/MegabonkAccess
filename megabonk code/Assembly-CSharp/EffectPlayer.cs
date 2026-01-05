using System;
using UnityEngine;

public class EffectPlayer : MonoBehaviour
{
	public float psMinInterval;

	public ParticleSystem ps;

	public AudioSpamFilter audioSpamFilter;

	public RandomSfx randomSfx;

	private float nextPlayTime;

	public bool playOnEnable;

	public Action A_Played;

	private void OnEnable()
	{
	}

	public void Play()
	{
	}

	private void OnValidate()
	{
	}
}
