using System;
using System.Collections.Generic;
using UnityEngine;

namespace Rewired.Localization;

public class LocalizedStringProvider : LocalizedStringProviderBase
{
	private TextAsset _localizedStringsFile;

	[NonSerialized]
	private Dictionary<string, string> _dictionary;

	[NonSerialized]
	private bool _initialized;

	protected virtual Dictionary<string, string> dictionary
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

	public virtual TextAsset localizedStringsFile
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

	protected override bool initialized => false;

	protected override bool Initialize()
	{
		return false;
	}

	protected virtual bool TryLoadLocalizedStringData()
	{
		return false;
	}

	protected override bool TryGetLocalizedString(string key, out string result)
	{
		result = null;
		return false;
	}
}
