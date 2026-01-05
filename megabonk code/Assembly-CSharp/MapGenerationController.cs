using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerationController : MonoBehaviour
{
	private sealed class _003CGenerateMap_003Ed__39 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public MapGenerationController _003C_003E4__this;

		private Mesh _003CworldMesh_003E5__2;

		private StageData _003CstageData_003E5__3;

		private MapData _003CmapData_003E5__4;

		private Vector3 _003CworldSize_003E5__5;

		private Vector3 _003CworldCenter_003E5__6;

		private Vector3 _003CspawnPosition_003E5__7;

		private Vector3 _003CspawnDirection_003E5__8;

		private Vector3 _003CworldAreaNew_003E5__9;

		private Vector3 _003CworldCenterNew_003E5__10;

		private float _003CworldAreaMagnitude_003E5__11;

		object IEnumerator<object>.Current => null;

		object IEnumerator.Current => null;

		public _003CGenerateMap_003Ed__39(int _003C_003E1__state)
		{
		}

		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			return false;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		void IEnumerator.Reset()
		{
		}
	}

	public MapData testMapData;

	public StageData testStageData;

	public ProceduralTileGeneration proceduralTileGeneration;

	public RandomObjectPlacer randomObjectPlacer;

	public GenerateTileObjects RandomTileObjects;

	public MinimapMesh minimapMesh;

	public GameObject colliderBox;

	public GameObject spawnPortal;

	public GameObject bossPortal;

	public GameObject spawnPlatform;

	public GameObject bossPortalFinal;

	public GameObject graveyardBossPortal;

	public GameManager gameManager;

	public SpawnInteractables interactablesSpawner;

	public GrassChunkManager grassRenderer;

	public MapEdges mapEdges;

	public MeshRenderer proceduralMeshRenderer;

	public Water water;

	public GameObject proceduralMapWorldEdges;

	public MapGenerator proceduralMapMeshGenerator;

	public static Action A_GenerationComplete;

	public static Action A_PreGeneration;

	public Light sunLight;

	public static bool isGenerating;

	public GameObject cryptParent;

	public GameObject cryptExitOutside;

	public RsgController rsgController;

	public int testSeed;

	private static Vector3 _003CtileSpawnPosition_003Ek__BackingField;

	private static Vector3 _003CtileSpawnDir_003Ek__BackingField;

	public static int mapSeed;

	public static Vector3 tileSpawnPosition
	{
		get
		{
			return _003CtileSpawnPosition_003Ek__BackingField;
		}
		private set
		{
			_003CtileSpawnPosition_003Ek__BackingField = value;
		}
	}

	public static Vector3 tileSpawnDir
	{
		get
		{
			return _003CtileSpawnDir_003Ek__BackingField;
		}
		private set
		{
			_003CtileSpawnDir_003Ek__BackingField = value;
		}
	}

	private void Awake()
	{
	}

	private void CryptGeneration(int seed, out Vector3 spawnPos, out Vector3 spawnDir)
	{
		spawnPos = default(Vector3);
		spawnDir = default(Vector3);
	}

	private IEnumerator GenerateMap()
	{
		return null;
	}
}
