using System;
using UnityEngine;

public class ObjectStageMaterial : MonoBehaviour
{
	[Serializable]
	public class StageMaterial
	{
		public int stageIndex;

		public Material material;
	}

	public StageMaterial[] stageMaterials;

	public MeshRenderer meshRenderer;

	private void Start()
	{
	}

	private void OnValidate()
	{
	}
}
