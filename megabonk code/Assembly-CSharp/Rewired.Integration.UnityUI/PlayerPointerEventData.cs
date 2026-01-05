using Rewired.UI;
using UnityEngine.EventSystems;

namespace Rewired.Integration.UnityUI;

public class PlayerPointerEventData : PointerEventData
{
	private int _003CplayerId_003Ek__BackingField;

	private int _003CinputSourceIndex_003Ek__BackingField;

	private IMouseInputSource _003CmouseSource_003Ek__BackingField;

	private ITouchInputSource _003CtouchSource_003Ek__BackingField;

	private PointerEventType _003CsourceType_003Ek__BackingField;

	private int _003CbuttonIndex_003Ek__BackingField;

	public int playerId
	{
		get
		{
			return _003CplayerId_003Ek__BackingField;
		}
		set
		{
			_003CplayerId_003Ek__BackingField = value;
		}
	}

	public int inputSourceIndex
	{
		get
		{
			return _003CinputSourceIndex_003Ek__BackingField;
		}
		set
		{
			_003CinputSourceIndex_003Ek__BackingField = value;
		}
	}

	public IMouseInputSource mouseSource
	{
		get
		{
			return _003CmouseSource_003Ek__BackingField;
		}
		set
		{
			_003CmouseSource_003Ek__BackingField = value;
		}
	}

	public ITouchInputSource touchSource
	{
		get
		{
			return _003CtouchSource_003Ek__BackingField;
		}
		set
		{
			_003CtouchSource_003Ek__BackingField = value;
		}
	}

	public PointerEventType sourceType
	{
		get
		{
			return _003CsourceType_003Ek__BackingField;
		}
		set
		{
			_003CsourceType_003Ek__BackingField = value;
		}
	}

	public int buttonIndex
	{
		get
		{
			return _003CbuttonIndex_003Ek__BackingField;
		}
		set
		{
			_003CbuttonIndex_003Ek__BackingField = value;
		}
	}

	public PlayerPointerEventData(EventSystem eventSystem)
		: base(null)
	{
	}

	public override string ToString()
	{
		return null;
	}
}
