using UnityEngine;

public class MeshData
{
	public Vector3[] vertices;

	public int[] triangles;

	public Vector2[] uvs;

	private int triangleIndex;

	public MeshData(int meshWidth, int meshHeight)
	{
	}

	public void AddTriangle(int a, int b, int c)
	{
	}

	public Mesh CreateMesh()
	{
		return null;
	}
}
