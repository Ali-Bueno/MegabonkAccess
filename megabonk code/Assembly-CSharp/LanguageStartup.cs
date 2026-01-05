using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization;

public class LanguageStartup : MonoBehaviour
{
	private sealed class _003C_003Ec__DisplayClass6_0
	{
		public string loc;

		internal bool _003CSetLocale_003Eb__0(Locale l)
		{
			return false;
		}
	}

	private sealed class _003CSetLanguageCoroutine_003Ed__3 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		object IEnumerator<object>.Current => null;

		object IEnumerator.Current => null;

		public _003CSetLanguageCoroutine_003Ed__3(int _003C_003E1__state)
		{
		}

		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			return false;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		void IEnumerator.Reset()
		{
		}
	}

	private void Awake()
	{
	}

	private void OnDestroy()
	{
	}

	private void OnSavesLoaded()
	{
	}

	private IEnumerator SetLanguageCoroutine()
	{
		return null;
	}

	private static void CheckSteamLanguage()
	{
	}

	public static void SetSystemLanguage()
	{
	}

	private static void SetLocale(string loc)
	{
	}

	private static string MapSteamLangToLocale(string steamLang)
	{
		return null;
	}

	private static string MapSystemLangToLocale(SystemLanguage lang)
	{
		return null;
	}
}
