using UnityEngine;

namespace Assets.Scripts.MapGeneration.ProceduralTiles;

public class FillTile : MonoBehaviour
{
	public MeshRenderer renderer;

	public EFillType fillType;

	public bool cross;

	public bool useEdge;

	public void SetFillType(EFillType type, StageData stageData, bool useEdgeTextures = false)
	{
	}

	private void OnValidate()
	{
	}
}
