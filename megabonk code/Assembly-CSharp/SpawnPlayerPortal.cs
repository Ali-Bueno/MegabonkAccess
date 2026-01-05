using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlayerPortal : MonoBehaviour
{
	private sealed class _003CDoPortal_003Ed__12 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public SpawnPlayerPortal _003C_003E4__this;

		object IEnumerator<object>.Current => null;

		object IEnumerator.Current => null;

		public _003CDoPortal_003Ed__12(int _003C_003E1__state)
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

	public AudioSource audioOpen;

	public AudioSource audioLoop;

	public AudioSource audioClose;

	public AudioSource audioPassing;

	public GameObject blockObjectSpawns;

	public Transform portalRender;

	private Vector3 portalScale;

	public ParticleSystem passingFx;

	public static Action A_PortalOpen;

	public static Action A_PortalClosed;

	private bool movePlayer;

	private float moveTime;

	private float moveTimer;

	private Vector3 playerStartPosition;

	private Vector3 desiredPosition;

	private float openTime;

	private float scaleTimer;

	private bool open;

	public void StartPortal()
	{
	}

	private bool CanSkipPortalAnimation()
	{
		return false;
	}

	private IEnumerator DoPortal()
	{
		return null;
	}

	private void PassShake()
	{
	}

	private void MovePlayer()
	{
	}

	private void Update()
	{
	}

	private void ClosePortal()
	{
	}
}
