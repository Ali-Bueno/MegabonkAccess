using UnityEngine;

public class MapGenerator : MonoBehaviour
{
	public enum DrawMode
	{
		NoiseMap,
		Mesh,
		FalloffMap,
		ColorMap
	}

	public DrawMode drawMode;

	public TerrainData terrainData;

	public NoiseData noiseData;

	public TextureData textureData;

	public int levelOfDetail;

	private static int seed;

	public bool autoUpdate;

	private float[,] falloffMap;

	private MapDisplay _003Cdisplay_003Ek__BackingField;

	public static int mapChunkSize;

	public static int worldScale;

	public GameObject mesh;

	public static MapGenerator Instance;

	public static float[,] staticNoiseMap;

	public float[,] heightMap;

	public MapDisplay display
	{
		get
		{
			return _003Cdisplay_003Ek__BackingField;
		}
		private set
		{
			_003Cdisplay_003Ek__BackingField = value;
		}
	}

	private void Awake()
	{
	}

	private void OnValuesUpdated()
	{
	}

	public void GenerateMap(MapData mapData, StageData stageData, int seed = 105)
	{
	}

	public void GenerateMap(int seed = 105)
	{
	}

	public float[,] GeneratePerlinNoiseMap(NoiseData noiseData, int seed, bool useFalloffMap)
	{
		return null;
	}

	public float[,] GeneratePerlinNoiseMap(int seed)
	{
		return null;
	}

	public void DrawMapInEditor()
	{
	}

	private void OnValidate()
	{
	}
}
