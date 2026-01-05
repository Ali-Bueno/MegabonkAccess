using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RetroArsenal;

public class RetroLoopScript : MonoBehaviour
{
	private sealed class _003CEffectLoop_003Ed__7 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public RetroLoopScript _003C_003E4__this;

		private GameObject _003CeffectPlayer_003E5__2;

		object IEnumerator<object>.Current => null;

		object IEnumerator.Current => null;

		public _003CEffectLoop_003Ed__7(int _003C_003E1__state)
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

	public GameObject chosenEffect;

	public float loopTimeLimit;

	public bool disableLights;

	public bool disableSound;

	public float spawnScale;

	private void Start()
	{
	}

	public void PlayEffect()
	{
	}

	private IEnumerator EffectLoop()
	{
		return null;
	}
}
