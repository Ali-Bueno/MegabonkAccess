using UnityEngine;
using UnityEngine.UI;

namespace Rewired.Glyphs.UnityUI;

public class UnityUIGlyphOrText : GlyphOrTextBase<Image, Sprite, Text>
{
	protected override string textString
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

	protected override Sprite glyphGraphic
	{
		get
		{
			return null;
		}
		set
		{
		}
	}
}
