using Rewired.Interfaces;
using UnityEngine;

namespace Rewired.Localization;

public abstract class LocalizedStringProviderBase : MonoBehaviour, ILocalizedStringProvider
{
	private bool _prefetch;

	public virtual bool prefetch
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	protected abstract bool initialized { get; }

	protected virtual void OnEnable()
	{
	}

	protected virtual void OnDisable()
	{
	}

	protected virtual void Update()
	{
	}

	protected virtual void TrySetLocalizedStringProvider()
	{
	}

	protected abstract bool Initialize();

	public virtual void Reload()
	{
	}

	protected abstract bool TryGetLocalizedString(string key, out string result);

	bool ILocalizedStringProvider.TryGetLocalizedString(string key, out string result)
	{
		result = null;
		return false;
	}
}
