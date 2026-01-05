using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class VictoryScreen : MonoBehaviour
{
	private sealed class _003CShowNewItem_003Ed__27 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public VictoryScreen _003C_003E4__this;

		object IEnumerator<object>.Current => null;

		object IEnumerator.Current => null;

		public _003CShowNewItem_003Ed__27(int _003C_003E1__state)
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

	public GameObject content;

	public RawImage background;

	public RawImage itemDisplay;

	public TextMeshProUGUI itemNameText;

	public TextMeshProUGUI extraText;

	public TextMeshProUGUI t_score;

	public ParticleSystem ps;

	public GameObject btnContinue;

	public GameObject coinFx;

	public UiAnimation buttonAnimation;

	private float fadeInTime;

	private float fadeOutTime;

	private float cardDesiredScale;

	private float textDesiredScale;

	private float desiredAlpha;

	private float yRotation;

	public AudioSource silverSfx;

	public AudioSource silverSfxFinish;

	private float animatorTime;

	private float animatorSpeed;

	public AudioSource sfx;

	private bool silverStarted;

	private int maxSilver;

	private float silverTimer;

	private float silverAnimateTime;

	private void Start()
	{
	}

	private void Update()
	{
	}

	private Color GetBackgroundColor()
	{
		return default(Color);
	}

	private void Animate()
	{
	}

	private void FinishSilverCounter()
	{
	}

	private void ShowButton()
	{
	}

	private IEnumerator ShowNewItem()
	{
		return null;
	}
}
