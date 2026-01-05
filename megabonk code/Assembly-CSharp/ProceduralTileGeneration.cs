using System.Collections.Generic;
using Assets.Scripts.MapGeneration.ProceduralTiles;
using UnityEngine;

public class ProceduralTileGeneration : MonoBehaviour
{
	public int debugSeed;

	public GameObject stairsMesh;

	public GameObject flatTile;

	public GameObject slopeTile;

	public GameObject ceilingTile;

	public GameObject wallFlat;

	public GameObject wallLeftUp;

	public GameObject wallLeftDown;

	public GameObject wallLeftCross;

	public List<GameObject> tiles;

	public List<GameObject> flatTiles;

	public List<GameObject> fillTiles;

	public GameObject collider;

	private StageData currentStage;

	private MapParameters currentMapParameters;

	public StageData testStage;

	public MapParameters testMapParameters;

	public GameObject newRoot;

	public GameObject tilesParent;

	public ProceduralTile[][] proceduralTiles;

	public Vector3 Generate(out Vector3 firstTileDirection, StageData stageData, MapParameters mapParameters, bool useDebugSeed = false)
	{
		firstTileDirection = default(Vector3);
		return default(Vector3);
	}

	public Vector3 TilePositionToWorldPosition(Vector2Int pos)
	{
		return default(Vector3);
	}

	public void FillHoles()
	{
	}

	private void FillHole(Vector2Int pos1, Vector2Int pos2)
	{
	}

	private void FillWallSlopeToFlat(int heightDifference, Vector2Int position, int height, Vector2Int globalDir, bool isFirstPieceSloped, bool useEdgeTextures = false)
	{
	}

	private void FillWallSlopToSlop(int heightDifference, Vector2Int position, int height, Vector2Int globalDir)
	{
	}

	public GameObject InstantiateTile(Vector2Int pos, int height, GameObject tilePrefab, Vector3 direction, Vector3 parentDir)
	{
		return null;
	}

	public GameObject InstantiateTile(Vector2Int pos, int height, int yDir, Vector2Int direction)
	{
		return null;
	}

	private void InstantiateFillTile(Vector2Int pos, int height, GameObject tilePrefab, Vector2Int direction, Vector2Int globalDirection, EFillType fillType, bool flip = false, bool useEdgeTexture = false)
	{
	}

	private void FillEdges()
	{
	}

	private void FillEdgesIsland()
	{
	}

	private void FillEdgesWalls()
	{
	}

	private void FillEdgesTrees()
	{
	}

	private void FillEdge(Vector2Int pos1, int desiredHeightOffset, bool isFacingOut, Vector2Int dir, bool useEdgeTextures = false)
	{
	}

	private Vector3 GetMapToZeroPositionOffset()
	{
		return default(Vector3);
	}

	public Vector3 GetWorldSize()
	{
		return default(Vector3);
	}

	public Vector3 GetWorldCenter()
	{
		return default(Vector3);
	}

	private void ClearTiles()
	{
	}
}
