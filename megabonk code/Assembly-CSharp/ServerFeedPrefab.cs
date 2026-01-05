using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ServerFeedPrefab : MonoBehaviour
{
	private sealed class _003CShow_003Ed__9 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public ServerFeedPrefab _003C_003E4__this;

		private float _003Ctimer_003E5__2;

		object IEnumerator<object>.Current => null;

		object IEnumerator.Current => null;

		public _003CShow_003Ed__9(int _003C_003E1__state)
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

	public CanvasGroup canvasGroup;

	public RawImage i_icon;

	public TextMeshProUGUI t_info;

	private float currentTime;

	private float fadeTime;

	private float startFadeTime;

	private float destroyTime;

	private Action<ServerFeedPrefab> timeoutAction;

	public void SetFeed(string f, float duration, Action<ServerFeedPrefab> timeoutAction, Texture icon = null)
	{
	}

	private IEnumerator Show()
	{
		return null;
	}
}
