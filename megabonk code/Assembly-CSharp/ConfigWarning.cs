using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ConfigWarning : MonoBehaviour
{
	private sealed class _003CShowWarningCoroutine_003Ed__12 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public ConfigWarning _003C_003E4__this;

		public string filepath;

		public string e;

		object IEnumerator<object>.Current => null;

		object IEnumerator.Current => null;

		public _003CShowWarningCoroutine_003Ed__12(int _003C_003E1__state)
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

	public GameObject overlay;

	public TextMeshProUGUI t_warning;

	public TextSizer textSizer;

	private string configFilePath;

	public static ConfigWarning Instance;

	private void Awake()
	{
	}

	public void OpenFile()
	{
	}

	public void RefreshFile()
	{
	}

	public void LoadBackup()
	{
	}

	public void ResetFile()
	{
	}

	public void IgnoreWarning()
	{
	}

	public void ShowWarning(string e, string filePath)
	{
	}

	private IEnumerator ShowWarningCoroutine(string e, string filepath)
	{
		return null;
	}

	public void HideWarning()
	{
	}

	private void _003CResetFile_003Eb__9_0()
	{
	}

	private void _003CIgnoreWarning_003Eb__10_0()
	{
	}
}
