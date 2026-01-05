using System;
using System.Collections.Generic;
using Assets.Scripts.MapGeneration.ProceduralTiles;
using UnityEngine;

[Serializable]
public class ProceduralTile : MonoBehaviour
{
	public List<TileEdge> edges;

	public Renderer renderer;

	private Vector2Int[] globalDirections;

	public int posY;

	public bool isFlat;

	private Vector3 _003Cdir_003Ek__BackingField;

	private Vector3 _003CparentDir_003Ek__BackingField;

	public Vector3 dir
	{
		get
		{
			return _003Cdir_003Ek__BackingField;
		}
		private set
		{
			_003Cdir_003Ek__BackingField = value;
		}
	}

	public Vector3 parentDir
	{
		get
		{
			return _003CparentDir_003Ek__BackingField;
		}
		private set
		{
			_003CparentDir_003Ek__BackingField = value;
		}
	}

	public TileEdge GetEdge(Vector2Int globalDirection)
	{
		return null;
	}

	public void SetGlobalRotation(Vector2Int direction)
	{
	}

	public Vector2Int GlobalToLocalDirection(Vector2Int dir)
	{
		return default(Vector2Int);
	}

	public void SetPosY(int y, StageData stageData, bool isFlat, Vector3 dir, Vector3 parentDir)
	{
	}

	public int GetY()
	{
		return 0;
	}
}
