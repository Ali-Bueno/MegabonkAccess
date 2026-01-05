using UnityEngine;

public class RsgPiece : MonoBehaviour
{
	public bool mirror;

	public bool reverse;

	public Transform start;

	public Transform end;

	public Transform lowestPoint;

	public GameObject children;

	public MeshFilter meshFilter;

	public MeshCollider newCollider;

	public float complexity;

	public int traverseTime;

	private BoxCollider boundsCollider;

	private Bounds bounds;

	private bool mirrored;

	private void OnValidate()
	{
	}

	public Bounds GetBounds()
	{
		return default(Bounds);
	}

	public float GetLowestCordY()
	{
		return 0f;
	}

	public void Mirror()
	{
	}

	public void SetCollider()
	{
	}

	private Mesh MirrorMesh(Mesh mesh)
	{
		return null;
	}
}
