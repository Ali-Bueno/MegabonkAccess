using UnityEngine;

namespace Rewired.Glyphs;

public abstract class DefaultControllerElementGlyphSettingsBase : MonoBehaviour
{
	private ControllerElementGlyphSelectorOptions _options;

	private GameObject _glyphOrTextPrefab;

	public ControllerElementGlyphSelectorOptions options
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

	public GameObject glyphOrTextPrefab
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

	protected virtual void OnEnable()
	{
	}

	protected virtual void OnDisable()
	{
	}

	protected virtual void SetDefaults()
	{
	}

	protected virtual void SetDefaultOptions()
	{
	}

	protected abstract void SetDefaultGlyphOrTextPrefab();
}
