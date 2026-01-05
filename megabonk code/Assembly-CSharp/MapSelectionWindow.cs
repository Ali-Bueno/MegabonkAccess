using System;
using UnityEngine;

public class MapSelectionWindow : MonoBehaviour
{
	[Serializable]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9;

		public static Func<MapData, int> _003C_003E9__2_0;

		internal int _003CInitButtons_003Eb__2_0(MapData a)
		{
			return 0;
		}
	}

	public GameObject mapEntryPrefab;

	public SelectionGroupToggleSingle selectionGroup;

	public void InitButtons()
	{
	}
}
