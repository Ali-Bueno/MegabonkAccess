using System;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Saves___Serialization.Progression.Achievements;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AchievementPopup : MonoBehaviour
{
	private sealed class _003CShowAchievements_003Ed__14 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public AchievementPopup _003C_003E4__this;

		private float _003Ct_003E5__2;

		object IEnumerator<object>.Current => null;

		object IEnumerator.Current => null;

		public _003CShowAchievements_003Ed__14(int _003C_003E1__state)
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

	public RectTransform content;

	public RawImage icon;

	public TextMeshProUGUI t_title;

	public TextMeshProUGUI t_description;

	public RandomSfx sfx;

	private Queue<MyAchievement> queue;

	private bool isAnimating;

	private float contentHeight;

	private float moveTime;

	private float stayTime;

	private void Awake()
	{
	}

	private void OnDestroy()
	{
	}

	private void Start()
	{
	}

	private void OnAchievementUnlocked(MyAchievement achievement)
	{
	}

	private IEnumerator ShowAchievements()
	{
		return null;
	}
}
