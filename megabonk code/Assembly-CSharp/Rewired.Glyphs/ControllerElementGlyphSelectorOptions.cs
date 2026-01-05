using System;

namespace Rewired.Glyphs;

[Serializable]
public class ControllerElementGlyphSelectorOptions
{
	private bool _useLastActiveController;

	private ControllerType[] _controllerTypeOrder;

	private static ControllerElementGlyphSelectorOptions s_defaultOptions;

	public bool useLastActiveController
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public ControllerType[] controllerTypeOrder
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

	public static ControllerElementGlyphSelectorOptions defaultOptions
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

	public virtual bool TryGetControllerTypeOrder(int index, out ControllerType controllerType)
	{
		controllerType = default(ControllerType);
		return false;
	}
}
