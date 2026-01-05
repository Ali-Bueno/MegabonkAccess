using System;
using System.Collections.Generic;
using UnityEngine;

namespace Rewired.Glyphs.UnityUI;

public abstract class UnityUIPlayerControllerElementGlyphBase : UnityUIControllerElementGlyphBase
{
	private ControllerElementGlyphSelectorOptionsSOBase _options;

	private AxisRange _actionRange;

	private Transform _group1;

	private Transform _group2;

	[NonSerialized]
	private List<ActionElementMap> _tempAems;

	[NonSerialized]
	private List<ActionElementMap> _tempCombinedElementAems;

	[NonSerialized]
	private readonly List<GlyphOrTextObject> _group1Objects;

	[NonSerialized]
	private readonly List<GlyphOrTextObject> _group2Objects;

	public virtual ControllerElementGlyphSelectorOptionsSOBase options
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

	public abstract int playerId { get; set; }

	public abstract int actionId { get; set; }

	public virtual AxisRange actionRange
	{
		get
		{
			return default(AxisRange);
		}
		set
		{
		}
	}

	public virtual Transform group1
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

	public virtual Transform group2
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

	protected virtual bool isMousePrioritizedOverKeyboard => false;

	protected virtual bool TryGetControllerTypeOrder(int index, out ControllerType controllerType)
	{
		controllerType = default(ControllerType);
		return false;
	}

	protected override void Update()
	{
	}

	protected override void ClearObjects()
	{
	}

	protected virtual bool ShowBinding(ActionElementMap actionElementMap)
	{
		return false;
	}

	protected virtual bool ShowSplitAxisBindings(ActionElementMap negativeAem, ActionElementMap positiveAem)
	{
		return false;
	}

	protected override void EvaluateObjectVisibility()
	{
	}

	protected virtual int ShowGlyphsOrText(IList<ActionElementMap> bindings, Transform parent, List<GlyphOrTextObject> objects)
	{
		return 0;
	}

	protected override void Hide()
	{
	}

	protected virtual Transform GetObjectGroupTransform(int groupIndex)
	{
		return null;
	}

	protected virtual ControllerElementGlyphSelectorOptions GetOptionsOrDefault()
	{
		return null;
	}
}
