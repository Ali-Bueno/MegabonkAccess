using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ChallengeCompletedUi : MonoBehaviour
{
	private sealed class _003CStartAnimate_003Ed__24 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public ChallengeCompletedUi _003C_003E4__this;

		object IEnumerator<object>.Current => null;

		object IEnumerator.Current => null;

		public _003CStartAnimate_003Ed__24(int _003C_003E1__state)
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

	public AudioSource sfx;

	public GameObject content;

	public GameObject text;

	public GameObject challengeBox;

	public TextMeshProUGUI t_header;

	public TextMeshProUGUI t_description;

	public TextSizer textSizer;

	public CanvasGroup canvasGroup;

	public GameObject particles;

	public RawImage shadow;

	private float fadeInTime;

	private float fadeOutTime;

	private float cardDesiredScale;

	private float textDesiredScale;

	private float desiredAlpha;

	private float animatorTime;

	private float animatorSpeed;

	public Image background;

	private void Awake()
	{
	}

	private void OnDestroy()
	{
	}

	private void Test()
	{
	}

	private void OnAchievementUnlocked(ChallengeData challenge)
	{
	}

	private void Update()
	{
	}

	private void Animate()
	{
	}

	private IEnumerator StartAnimate()
	{
		return null;
	}
}
