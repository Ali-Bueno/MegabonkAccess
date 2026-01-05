using System;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Game.Other;
using TMPro;
using UnityEngine;
using UnityEngine.Localization;

public class MapTitle : MonoBehaviour
{
	private sealed class _003CTypeDescription_003Ed__22 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public MapTitle _003C_003E4__this;

		private string _003Cdescription_003E5__2;

		private int _003Ci_003E5__3;

		object IEnumerator<object>.Current => null;

		object IEnumerator.Current => null;

		public _003CTypeDescription_003Ed__22(int _003C_003E1__state)
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

	private float delay;

	private float visibleTime;

	private float fadeTime;

	public TextMeshProUGUI t_title;

	public TextMeshProUGUI t_description;

	public TextMeshProUGUI t_tier;

	public CanvasGroup titleCanvasGroup;

	private float alphaTimer;

	public StageData testStage;

	public LocalizedString cryptTitle;

	public LocalizedString cryptDesc;

	private bool started;

	private RunConfig runConfig;

	private int numTimesShowed;

	private float totalTimer;

	private bool hasPlayedSfx;

	private bool isFading;

	private bool isTyping;

	private int numDescriptionsShowed;

	public AudioSource textSfx;

	public RandomSfx letterSfx;

	private bool done;

	public void StartAnimation()
	{
	}

	private void SetGraveyardText()
	{
	}

	private void SetMapText()
	{
	}

	private void Update()
	{
	}

	private IEnumerator TypeDescription()
	{
		return null;
	}

	private string GetTitle()
	{
		return null;
	}

	private string GetDescription()
	{
		return null;
	}
}
