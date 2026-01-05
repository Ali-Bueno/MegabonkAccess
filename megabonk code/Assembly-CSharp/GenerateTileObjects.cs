using System;
using System.Collections.Generic;
using UnityEngine;

public class GenerateTileObjects : MonoBehaviour
{
	[Serializable]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9;

		public static Func<int, float> _003C_003E9__6_0;

		internal float _003CMapSpecificTiles_003Eb__6_0(int _)
		{
			return 0f;
		}
	}

	public GameObject tileObjectsParent;

	public GameObject bossSpawner;

	public GameObject bossSpawnerFinal;

	public GameObject graveyardBossPortal;

	public GameObject arrowPrefabTest;

	public void Generate(List<GameObject> allFlatTiles, StageData stageData)
	{
	}

	private void MapSpecificTiles(List<GameObject> available, StageData stageData)
	{
	}
}
