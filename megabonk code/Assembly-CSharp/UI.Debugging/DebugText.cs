using System;
using System.Collections.Generic;
using UnityEngine;

namespace UI.Debugging;

public class DebugText : MonoBehaviour
{
	[Serializable]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9;

		public static Func<string, int> _003C_003E9__5_0;

		internal int _003CSortKeysByPriority_003Eb__5_0(string key)
		{
			return 0;
		}
	}

	public static Dictionary<string, string> debugEntries;

	public static Dictionary<string, int> debugPriority;

	private static List<string> sortedKeys;

	private void OnGUI()
	{
	}

	public static void DebugValue(string key, string value, int priority = 0)
	{
	}

	private static void SortKeysByPriority()
	{
	}
}
