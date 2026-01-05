using UnityEngine;

public class TerrainData : UpdateableData
{
	public float uniformScale;

	public bool useFalloff;

	public float heightMultiplier;

	public AnimationCurve heightCurve;

	public float minHeight => 0f;

	public float maxHeight => 0f;
}
