using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RetroArsenal;

public class RetroTarget : MonoBehaviour
{
	private sealed class _003CRespawn_003Ed__14 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public RetroTarget _003C_003E4__this;

		object IEnumerator<object>.Current => null;

		object IEnumerator.Current => null;

		public _003CRespawn_003Ed__14(int _003C_003E1__state)
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

	private sealed class _003CSquashAndStretch_003Ed__16 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public RetroTarget _003C_003E4__this;

		private float _003CtimeElapsed_003E5__2;

		private Vector3 _003CstartScale_003E5__3;

		private Vector3 _003CendScale_003E5__4;

		object IEnumerator<object>.Current => null;

		object IEnumerator.Current => null;

		public _003CSquashAndStretch_003Ed__16(int _003C_003E1__state)
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

	public TargetEffects effects;

	public int hitsToDestroy;

	public float respawnTime;

	public bool enableSquashAndStretch;

	public float duration;

	public Vector3 squashScale;

	public Vector3 stretchScale;

	private Renderer targetRenderer;

	private Collider targetCollider;

	private AudioSource audioSource;

	private int currentHits;

	private Vector3 originalScale;

	private void Start()
	{
	}

	private void SpawnTarget()
	{
	}

	private IEnumerator Respawn()
	{
		return null;
	}

	public void OnHit()
	{
	}

	private IEnumerator SquashAndStretch()
	{
		return null;
	}

	private void DestroyTarget()
	{
	}
}
