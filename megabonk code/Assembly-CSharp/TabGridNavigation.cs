using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TabGridNavigation : MonoBehaviour
{
	[Serializable]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9;

		public static Func<Button, float> _003C_003E9__2_0;

		public static Func<float, float> _003C_003E9__2_1;

		internal float _003CComputeRowLengthByPosition_003Eb__2_0(Button b)
		{
			return 0f;
		}

		internal float _003CComputeRowLengthByPosition_003Eb__2_1(float y)
		{
			return 0f;
		}
	}

	private sealed class _003C_003Ec__DisplayClass2_0
	{
		public float topRowY;

		internal bool _003CComputeRowLengthByPosition_003Eb__2(Button b)
		{
			return false;
		}
	}

	public GameObject buttonsParent;

	public void Set(Button tabButton)
	{
	}

	private int ComputeRowLengthByPosition(List<Button> buttons)
	{
		return 0;
	}
}
