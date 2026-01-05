using UnityEngine;

namespace MilkShake;

public class ShakePreset : ScriptableObject, IShakeParameters
{
	private ShakeType shakeType;

	private float strength;

	private float roughness;

	private float fadeIn;

	private float fadeOut;

	private Vector3 positionInfluence;

	private Vector3 rotationInfluence;

	public ShakeType ShakeType
	{
		get
		{
			return default(ShakeType);
		}
		set
		{
		}
	}

	public float Strength
	{
		get
		{
			return 0f;
		}
		set
		{
		}
	}

	public float Roughness
	{
		get
		{
			return 0f;
		}
		set
		{
		}
	}

	public float FadeIn
	{
		get
		{
			return 0f;
		}
		set
		{
		}
	}

	public float FadeOut
	{
		get
		{
			return 0f;
		}
		set
		{
		}
	}

	public Vector3 PositionInfluence
	{
		get
		{
			return default(Vector3);
		}
		set
		{
		}
	}

	public Vector3 RotationInfluence
	{
		get
		{
			return default(Vector3);
		}
		set
		{
		}
	}
}
