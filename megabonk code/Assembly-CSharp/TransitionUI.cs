using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TransitionUI : MonoBehaviour
{
	private sealed class _003C_003Ec__DisplayClass11_0
	{
		public string mapName;

		internal void _003CStartLoadingMap_003Eb__0()
		{
		}
	}

	private sealed class _003CDoTransition_003Ed__13 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public TransitionUI _003C_003E4__this;

		public float newTransitionTime;

		public float delay;

		public Action action;

		object IEnumerator<object>.Current => null;

		object IEnumerator.Current => null;

		public _003CDoTransition_003Ed__13(int _003C_003E1__state)
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

	private sealed class _003CEndTransition_003Ed__15 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public TransitionUI _003C_003E4__this;

		object IEnumerator<object>.Current => null;

		object IEnumerator.Current => null;

		public _003CEndTransition_003Ed__15(int _003C_003E1__state)
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

	public RawImage overlay;

	private float transitionTime;

	public static TransitionUI Instance;

	public bool isTransitioning;

	public static Action A_transitionEnd;

	public static Action A_transitionStart;

	public static Action A_MapTransitionStart;

	private string sceneMainMenuName;

	private float fadeInTime;

	private void Awake()
	{
	}

	private void Start()
	{
	}

	public void LoadMenu()
	{
	}

	public void StartLoadingMap(string mapName)
	{
	}

	public void StartTransition(Action action, float transitionTime = 0.5f, float delay = 0.5f)
	{
	}

	private IEnumerator DoTransition(Action action, float newTransitionTime, float delay = 0.5f)
	{
		return null;
	}

	private IEnumerator EndTransition()
	{
		return null;
	}

	public void StopTransition()
	{
	}

	public bool IsTransitioning()
	{
		return false;
	}

	private void OnNewSceneLoaded(Scene arg0, LoadSceneMode arg1)
	{
	}

	public float GetTransitionTime()
	{
		return 0f;
	}
}
