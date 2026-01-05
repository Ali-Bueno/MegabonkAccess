using System;
using UnityEngine;

public class TextureData : UpdatableData
{
	[Serializable]
	public class Layer
	{
		public Texture2D texture;

		public Color tint;

		public float tintStrength;

		public float startHeight;

		public float blendStrength;

		public float textureScale;

		public TerrainType type;
	}

	public enum TerrainType
	{
		Water,
		Sand,
		Grass
	}

	[Serializable]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9;

		public static Func<Layer, Color> _003C_003E9__5_0;

		public static Func<Layer, float> _003C_003E9__5_1;

		public static Func<Layer, float> _003C_003E9__5_2;

		public static Func<Layer, float> _003C_003E9__5_3;

		public static Func<Layer, float> _003C_003E9__5_4;

		public static Func<Layer, Texture2D> _003C_003E9__5_5;

		internal Color _003CApplyToMaterial_003Eb__5_0(Layer x)
		{
			return default(Color);
		}

		internal float _003CApplyToMaterial_003Eb__5_1(Layer x)
		{
			return 0f;
		}

		internal float _003CApplyToMaterial_003Eb__5_2(Layer x)
		{
			return 0f;
		}

		internal float _003CApplyToMaterial_003Eb__5_3(Layer x)
		{
			return 0f;
		}

		internal float _003CApplyToMaterial_003Eb__5_4(Layer x)
		{
			return 0f;
		}

		internal Texture2D _003CApplyToMaterial_003Eb__5_5(Layer x)
		{
			return null;
		}
	}

	private const int textureSize = 512;

	private const TextureFormat textureFormat = TextureFormat.RGB565;

	public Layer[] layers;

	private float savedMinHeight;

	private float savedMaxHeight;

	public void ApplyToMaterial(Material material)
	{
	}

	public void UpdateMeshHeights(float minHeight, float maxHeight)
	{
	}

	private Texture2DArray GenerateTextureArray(Texture2D[] textures)
	{
		return null;
	}
}
