using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.MapGeneration.ProceduralTiles;

public static class Maze
{
	public static class Directions
	{
		public const int TOP = 1;

		public const int RIGHT = 2;

		public const int BOTTOM = 4;

		public const int LEFT = 8;
	}

	public static readonly Dictionary<int, int> Opposite;

	public static readonly (Vector2Int, int)[] DirectionsWithVectors;

	public static NodeTree Generate(int width, int height, int seed)
	{
		return null;
	}

	private static int ToIndex(Vector2Int position, int width)
	{
		return 0;
	}

	private static Vector2Int ToPosition(int index, int width)
	{
		return default(Vector2Int);
	}

	private static bool IsValidPosition(Vector2Int position, int width, int height)
	{
		return false;
	}

	private static List<T> Shuffle<T>(List<T> list, System.Random rand)
	{
		return null;
	}
}
