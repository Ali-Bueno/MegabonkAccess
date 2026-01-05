using System.Collections.Generic;
using UnityEngine;

public class GrassChunkManager : MonoBehaviour
{
	private struct GrassInstance
	{
		public Vector3 position;

		public float rotationY;
	}

	private struct GrassData
	{
		public Matrix4x4 transform;
	}

	public Mesh grassMesh;

	public Material grassMaterial;

	public int grassPerChunk;

	public int chunkSize;

	public int renderDistance;

	public float yThreshold;

	public LayerMask layerMask;

	public bool testWithoutPlayer;

	private int currentGrassPerChunk;

	private Vector2Int currentChunk;

	private Dictionary<Vector2Int, List<GrassInstance>> precomputedGrassPositions;

	private List<GrassData> allGrassDataList;

	private ComputeBuffer allGrassBuffer;

	private ComputeBuffer argsBuffer;

	private readonly uint[] args;

	public void Set(Material material, int grassPerChunk)
	{
	}

	private void Awake()
	{
	}

	private void Start()
	{
	}

	private void Update()
	{
	}

	private Vector2Int GetPlayerChunk()
	{
		return default(Vector2Int);
	}

	private void UpdateChunks()
	{
	}

	private void GenerateGrassForChunk(Vector2Int chunkCoord)
	{
	}

	private void RebuildGrassBuffer()
	{
	}

	private void RenderGrass()
	{
	}

	private bool GetTerrainHeight(float x, float z, out float height)
	{
		height = default(float);
		return false;
	}

	private void UpdateGrassQuality(int quality)
	{
	}

	private void OnSettingUpdated(string setting, object oldValue, object newValue)
	{
	}

	private void OnDestroy()
	{
	}

	private void OnDrawGizmosSelected()
	{
	}
}
