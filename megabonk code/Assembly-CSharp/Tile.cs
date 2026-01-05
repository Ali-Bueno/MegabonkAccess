using System.Collections.Generic;

public class Tile
{
	private readonly int _003CX_003Ek__BackingField;

	private readonly int _003CY_003Ek__BackingField;

	private bool _003CIsAvailable_003Ek__BackingField;

	private bool _003CIsVisited_003Ek__BackingField;

	private readonly List<Tile> _003CNeighbors_003Ek__BackingField;

	public int X => _003CX_003Ek__BackingField;

	public int Y => _003CY_003Ek__BackingField;

	public bool IsAvailable
	{
		get
		{
			return _003CIsAvailable_003Ek__BackingField;
		}
		set
		{
			_003CIsAvailable_003Ek__BackingField = value;
		}
	}

	public bool IsVisited
	{
		get
		{
			return _003CIsVisited_003Ek__BackingField;
		}
		set
		{
			_003CIsVisited_003Ek__BackingField = value;
		}
	}

	public List<Tile> Neighbors => _003CNeighbors_003Ek__BackingField;

	public Tile(int x, int y)
	{
	}
}
