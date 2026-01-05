using MilkShake;
using UnityEngine;

public class Explosion : MonoBehaviour
{
	private Material material;

	public ShakePreset shakePreset;

	public GameObject explosionFx;

	public float sizeMultiplier;

	public float lifeTime;

	public bool disableOnFinish;

	private Color startColor;

	private float startAlpha;

	private Vector3 desiredSize;

	private Vector3 startSize;

	private float myTime;

	private void Awake()
	{
	}

	private void Start()
	{
	}

	private void OnEnable()
	{
	}

	private void OnDestroy()
	{
	}

	private void FixedUpdate()
	{
	}
}
