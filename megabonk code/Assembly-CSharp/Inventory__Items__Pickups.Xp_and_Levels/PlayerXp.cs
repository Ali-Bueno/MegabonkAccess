using System;

namespace Inventory__Items__Pickups.Xp_and_Levels;

public class PlayerXp
{
	public int xp;

	public int level;

	public static float maxXpMultiplier;

	public static Action<int> A_LevelUp;

	public static Action<PlayerXp, int> A_XpAdded;

	private float leftOverXp;

	public void AddXp(int amount)
	{
	}

	public int GetXpInt()
	{
		return 0;
	}
}
