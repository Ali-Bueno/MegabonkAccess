using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace RetroArsenal;

public class RetroEffectCycler : MonoBehaviour
{
	private sealed class _003CEffectLoop_003Ed__15 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public RetroEffectCycler _003C_003E4__this;

		object IEnumerator<object>.Current => null;

		object IEnumerator.Current => null;

		public _003CEffectLoop_003Ed__15(int _003C_003E1__state)
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

	public List<GameObject> listOfEffects;

	private int effectIndex;

	public float loopLength;

	public float startDelay;

	public bool disableLights;

	public bool disableSound;

	public bool autoMode;

	public Text effectNameText;

	private GameObject currentEffect;

	private void Start()
	{
	}

	public void PlayEffect()
	{
	}

	public void NextEffect()
	{
	}

	public void PreviousEffect()
	{
	}

	public void ToggleAutoMode()
	{
	}

	private void RestartEffect()
	{
	}

	private IEnumerator EffectLoop()
	{
		return null;
	}

	private void UpdateEffectUI()
	{
	}

	private void Update()
	{
	}
}
