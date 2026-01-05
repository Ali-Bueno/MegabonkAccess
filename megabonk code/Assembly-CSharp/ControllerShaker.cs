using Assets.Scripts.Actors;
using Assets.Scripts.Inventory__Items__Pickups;
using UnityEngine;

public class ControllerShaker : MonoBehaviour
{
	private void Awake()
	{
	}

	private void OnDestroy()
	{
	}

	private void OnPlayerTakeDamage(PlayerHealth ph, DamageContainer dc, bool isShield)
	{
	}

	private void OnPlayerLanded(float speed)
	{
	}

	public static void Shake(int motor, float intensity, float duration)
	{
	}

	public static void StopShakes()
	{
	}

	private static bool CanShake()
	{
		return false;
	}

	private static float GetGlobalIntensity()
	{
		return 0f;
	}
}
