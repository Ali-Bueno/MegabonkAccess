using UnityEngine;

namespace Assets.Scripts.Menu.Shop.Rank;

public static class Ranks
{
	public const int maxRank = 240;

	public const int numRankTiers = 6;

	public const int numRanksPerTier = 40;

	public static void GetRankTextures(int rank, out Texture frame, out Texture rankIcon, out Color rankColor, out Color frameColor)
	{
		frame = null;
		rankIcon = null;
		rankColor = default(Color);
		frameColor = default(Color);
	}
}
