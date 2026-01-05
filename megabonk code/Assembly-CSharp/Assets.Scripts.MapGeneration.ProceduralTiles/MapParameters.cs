using UnityEngine;

namespace Assets.Scripts.MapGeneration.ProceduralTiles;

public class MapParameters : ScriptableObject
{
	public float volatility;

	public float centerHeightTarget;

	public float slopeStrength;

	public float yOffset;

	public float flatMapBias;

	public int size;

	public int scale;

	public int tileWidth;

	public int tileHeight;

	public EBiasStrategy biasStrategy;

	public EHeightGenerationStrategy heightGenerationStrategy;

	public int scaledTileWidth;

	public int scaledTileHeight;

	public StageData testStageData;

	private void OnValidate()
	{
	}
}
