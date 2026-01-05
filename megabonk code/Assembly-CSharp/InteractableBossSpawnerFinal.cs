using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableBossSpawnerFinal : BaseInteractable
{
	private sealed class _003CDoLoadNextStage_003Ed__4 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		object IEnumerator<object>.Current => null;

		object IEnumerator.Current => null;

		public _003CDoLoadNextStage_003Ed__4(int _003C_003E1__state)
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

	public GameObject preventObjectsSpawningHere;

	private new void Start()
	{
	}

	public override bool Interact()
	{
		return false;
	}

	private IEnumerator DoLoadNextStage()
	{
		return null;
	}

	public override string GetInteractString()
	{
		return null;
	}
}
