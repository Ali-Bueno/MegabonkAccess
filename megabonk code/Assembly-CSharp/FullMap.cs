using System.Collections.Generic;
using UnityEngine;

public class FullMap : MonoBehaviour
{
	public Camera mapCamera;

	private float worldSize;

	private int textureSize;

	private float revealRadius;

	private Texture2D fogTexture;

	private Color32[] pixels;

	public Material mapMaterial;

	public Transform mapDisplayTransform;

	private int mapsOpen;

	private bool[] fullyRevealed;

	private bool[] visitedCords;

	private HashSet<int> revealedIndices;

	private Vector3 lastPos;

	private void Awake()
	{
	}

	private void OnDestroy()
	{
	}

	private void OnMapToggle(bool on)
	{
	}

	private void OnGenerationComplete()
	{
	}

	private void InitFogTexture()
	{
	}

	private void Update()
	{
	}

	private void FixedUpdate()
	{
	}

	private void QueueRevealFog(Vector3 worldPos)
	{
	}

	private bool IsMapOpen()
	{
		return false;
	}

	private void RevealFog()
	{
	}
}
