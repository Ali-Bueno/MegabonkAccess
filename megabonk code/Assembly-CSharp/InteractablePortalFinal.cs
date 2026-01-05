using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractablePortalFinal : BaseInteractable
{
	private sealed class _003CDoFinishGame_003Ed__3 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public InteractablePortalFinal _003C_003E4__this;

		object IEnumerator<object>.Current => null;

		object IEnumerator.Current => null;

		public _003CDoFinishGame_003Ed__3(int _003C_003E1__state)
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

	private bool done;

	public GameObject cameraCircling;

	public override bool Interact()
	{
		return false;
	}

	private IEnumerator DoFinishGame()
	{
		return null;
	}

	public override string GetInteractString()
	{
		return null;
	}

	private void _003CDoFinishGame_003Eb__3_0()
	{
	}
}
