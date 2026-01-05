using UnityEngine;

namespace Assets.Scripts.Player.Movement;

public class PlayerMovementValues
{
	private const float defaultMoveSpeed = 2700f;

	private const float defaultSwimSpeed = 10f;

	public const float defaultMaxSpeed = 10f;

	private const float defaultSlideForce = 200f;

	private const float defaultAirDeceleration = 0.003f;

	private const float defaultExtraGravity = 11f;

	private float _003CmoveSpeed_003Ek__BackingField;

	private float _003CmaxRunSpeed_003Ek__BackingField;

	private float _003CairDeceleration_003Ek__BackingField;

	private float _003CslideForce_003Ek__BackingField;

	private float _003CextraGravity_003Ek__BackingField;

	private float _003CswimSpeed_003Ek__BackingField;

	private bool inited;

	private ECharacter currentCharacter;

	private float counterMovement;

	public float moveSpeed
	{
		get
		{
			return _003CmoveSpeed_003Ek__BackingField;
		}
		private set
		{
			_003CmoveSpeed_003Ek__BackingField = value;
		}
	}

	public float maxRunSpeed
	{
		get
		{
			return _003CmaxRunSpeed_003Ek__BackingField;
		}
		private set
		{
			_003CmaxRunSpeed_003Ek__BackingField = value;
		}
	}

	public float airDeceleration
	{
		get
		{
			return _003CairDeceleration_003Ek__BackingField;
		}
		private set
		{
			_003CairDeceleration_003Ek__BackingField = value;
		}
	}

	public float slideForce
	{
		get
		{
			return _003CslideForce_003Ek__BackingField;
		}
		private set
		{
			_003CslideForce_003Ek__BackingField = value;
		}
	}

	public float extraGravity
	{
		get
		{
			return _003CextraGravity_003Ek__BackingField;
		}
		private set
		{
			_003CextraGravity_003Ek__BackingField = value;
		}
	}

	public float swimSpeed
	{
		get
		{
			return _003CswimSpeed_003Ek__BackingField;
		}
		private set
		{
			_003CswimSpeed_003Ek__BackingField = value;
		}
	}

	private void Init(Rigidbody rb)
	{
	}

	public void CreateMovement(Rigidbody rb, ECharacter character)
	{
	}

	private static float GetCounterMovementMultiplier(ECharacter character)
	{
		return 0f;
	}

	private static float GetMoveSpeedMultiplier(ECharacter character)
	{
		return 0f;
	}

	public float GetCounterMovementMultiplier(FrictionModifier.EFrictionSurface surface)
	{
		return 0f;
	}

	public static float GetSlowdownMultiplier(FrictionModifier.EFrictionSurface surface, ECharacter character)
	{
		return 0f;
	}

	public float GetMoveSpeed(FrictionModifier.EFrictionSurface surface, bool grounded)
	{
		return 0f;
	}

	public float GetGravity(Rigidbody rb, ECharacter character)
	{
		return 0f;
	}

	public float GetMaxSpeed()
	{
		return 0f;
	}
}
