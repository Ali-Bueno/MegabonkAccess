using System.Collections.Generic;

namespace Assets.Scripts.Utility;

public static class FxUtility
{
	public static Dictionary<EWeapon, float> weaponCooldowns;

	public static Dictionary<EWeapon, float> muzzleCooldowns;

	public static void Init()
	{
	}

	public static void Cleanup()
	{
	}

	private static void OnRunStarted()
	{
	}
}
