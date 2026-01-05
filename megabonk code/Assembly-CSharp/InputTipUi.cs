using System;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Inventory__Items__Pickups.Weapons;
using Assets.Scripts.Utility.Controllers;
using TMPro;
using UnityEngine;

public class InputTipUi : MonoBehaviour
{
	private sealed class _003CShowTip_003Ed__17 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public InputTipUi _003C_003E4__this;

		public InputTip inputTip;

		private float _003Ct_003E5__2;

		object IEnumerator<object>.Current => null;

		object IEnumerator.Current => null;

		public _003CShowTip_003Ed__17(int _003C_003E1__state)
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

	public MyGlyphDisplay glyphContainer;

	public TextMeshProUGUI t_tip;

	public CanvasGroup group;

	public AudioSource audio;

	private Vector3 defaultPosition;

	private string currentAction;

	private float timeout;

	private float fadeTime;

	private float delay;

	private bool isShowingTip;

	private bool skipping;

	private Queue<InputTip> tipQueue;

	private void Awake()
	{
	}

	private void OnDestroy()
	{
	}

	public void SetTip(string tip, string action, float extraDelay = 0f)
	{
	}

	private void Update()
	{
	}

	private void SkipTip()
	{
	}

	private IEnumerator ShowTip(InputTip inputTip)
	{
		return null;
	}

	private void OnWeaponAdded(WeaponBase weaponBase)
	{
	}

	private void OnRunStarted()
	{
	}
}
