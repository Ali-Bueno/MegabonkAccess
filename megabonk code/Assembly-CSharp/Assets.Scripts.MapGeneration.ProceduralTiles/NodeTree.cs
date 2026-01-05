using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.MapGeneration.ProceduralTiles;

public class NodeTree
{
	[Serializable]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9;

		public static Func<NodeTree, string> _003C_003E9__15_0;

		internal string _003CToString_003Eb__15_0(NodeTree c)
		{
			return null;
		}
	}

	private Vector2Int _003Cposition_003Ek__BackingField;

	private NodeTree _003Cparent_003Ek__BackingField;

	private List<NodeTree> _003Cchildren_003Ek__BackingField;

	public int height;

	public int yDir;

	public Vector2Int position
	{
		get
		{
			return _003Cposition_003Ek__BackingField;
		}
		private set
		{
			_003Cposition_003Ek__BackingField = value;
		}
	}

	public NodeTree parent
	{
		get
		{
			return _003Cparent_003Ek__BackingField;
		}
		private set
		{
			_003Cparent_003Ek__BackingField = value;
		}
	}

	public List<NodeTree> children
	{
		get
		{
			return _003Cchildren_003Ek__BackingField;
		}
		private set
		{
			_003Cchildren_003Ek__BackingField = value;
		}
	}

	public NodeTree(Vector2Int position, NodeTree parent)
	{
	}

	public override string ToString()
	{
		return null;
	}
}
