using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhotosensWarning : MonoBehaviour
{
	private sealed class _003CShowWarning_003Ed__6 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public PhotosensWarning _003C_003E4__this;

		private float _003Ct_003E5__2;

		private float _003CfadeOverTime_003E5__3;

		object IEnumerator<object>.Current => null;

		object IEnumerator.Current => null;

		public _003CShowWarning_003Ed__6(int _003C_003E1__state)
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

	public GameObject window;

	public CanvasGroup cg;

	public MyButton btn;

	private void Start()
	{
	}

	private void OnDestroy()
	{
	}

	private void OnSavesLoaded()
	{
	}

	private IEnumerator ShowWarning()
	{
		return null;
	}

	public void Confirm()
	{
	}
}
