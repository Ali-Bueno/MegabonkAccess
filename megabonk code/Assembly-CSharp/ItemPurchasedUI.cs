using System;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Saves___Serialization.Progression.Achievements;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemPurchasedUI : MonoBehaviour
{
	private sealed class _003CShowNewItem_003Ed__24 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public ItemPurchasedUI _003C_003E4__this;

		public UnlockableBase unlockable;

		object IEnumerator<object>.Current => null;

		object IEnumerator.Current => null;

		public _003CShowNewItem_003Ed__24(int _003C_003E1__state)
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

	private sealed class _003CShowNewItem_003Ed__25 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public ItemPurchasedUI _003C_003E4__this;

		public MyAchievement achievement;

		object IEnumerator<object>.Current => null;

		object IEnumerator.Current => null;

		public _003CShowNewItem_003Ed__25(int _003C_003E1__state)
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

	public ParticleSystem ps;

	private bool hasClaimedAchievement;

	private float fadeInTime;

	private float fadeOutTime;

	private float cardDesiredScale;

	private float textDesiredScale;

	private float desiredAlpha;

	private float yRotation;

	private float animatorTime;

	private float animatorSpeed;

	public AudioSource sfx;

	public Texture silverIcon;

	private void Awake()
	{
	}

	private void OnDestroy()
	{
	}

	private void OnSkinPurchased(SkinData skinData)
	{
	}

	private void OnItemPurchased(UnlockableBase unlockable)
	{
	}

	private void OnAchievementClaimed(MyAchievement achievement)
	{
	}

	private void Update()
	{
	}

	private void Test()
	{
	}

	private void Animate()
	{
	}

	private IEnumerator ShowNewItem(UnlockableBase unlockable)
	{
		return null;
	}

	private IEnumerator ShowNewItem(MyAchievement achievement)
	{
		return null;
	}

	public void Close()
	{
	}
}
