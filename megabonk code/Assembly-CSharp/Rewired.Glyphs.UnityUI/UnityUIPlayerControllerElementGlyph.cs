using System;

namespace Rewired.Glyphs.UnityUI;

public class UnityUIPlayerControllerElementGlyph : UnityUIPlayerControllerElementGlyphBase
{
	private int _playerId;

	private string _actionName;

	[NonSerialized]
	private int _actionId;

	[NonSerialized]
	private bool _actionIdCached;

	public override int playerId
	{
		get
		{
			return 0;
		}
		set
		{
		}
	}

	public override int actionId
	{
		get
		{
			return 0;
		}
		set
		{
		}
	}

	public string actionName
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

	private void CacheActionId()
	{
	}
}
