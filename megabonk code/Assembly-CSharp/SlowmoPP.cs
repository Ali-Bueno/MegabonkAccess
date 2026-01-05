using Assets.Scripts.Inventory__Items__Pickups.Stats;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class SlowmoPP : MonoBehaviour
{
	public PostProcessVolume volume;

	private ColorGrading cg;

	private LensDistortion lens;

	private bool isCgEnabled;

	private bool isTimeFreeze;

	private bool isSlowmo;

	private bool isDone;

	private float timer;

	private float transitionTime;

	private float dLens;

	private float dExposure;

	private float dSaturation;

	private float fromLens;

	private float fromExposure;

	private float fromSaturation;

	private Color desiredColor;

	private Color fromColor;

	private void Awake()
	{
	}

	private void OnDestroy()
	{
	}

	private void RefreshTimeFreeze()
	{
	}

	private void OnStatusEffectAdded(EStatusEffect eStatusEffect, bool newEffect)
	{
	}

	private void OnStatusEffectRemoved(EStatusEffect eStatusEffect)
	{
	}

	private void StartTimeFreeze()
	{
	}

	private void EndTimeFreeze()
	{
	}

	private void Update()
	{
	}
}
