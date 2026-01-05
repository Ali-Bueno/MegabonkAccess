using System;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Inventory__Items__Pickups.Interactables;
using Assets.Scripts.UI.InGame.Rewards;
using TMPro;

public class ChestWindowUi : BaseEncounterWindow
{
	private sealed class _003CAnimateSingleTextObject_003Ed__22 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public TextMeshProUGUI text;

		public float fadeTime;

		private float _003Ctimer_003E5__2;

		object IEnumerator<object>.Current => null;

		object IEnumerator.Current => null;

		public _003CAnimateSingleTextObject_003Ed__22(int _003C_003E1__state)
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

	private sealed class _003CAnimateText_003Ed__21 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public ChestWindowUi _003C_003E4__this;

		object IEnumerator<object>.Current => null;

		object IEnumerator.Current => null;

		public _003CAnimateText_003Ed__21(int _003C_003E1__state)
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

	public TextMeshProUGUI t_itemName;

	public TextMeshProUGUI t_itemDesc;

	public TextMeshProUGUI t_itemRarity;

	public ChestOpening chestOpening;

	public LevelupScreen levelupScreen;

	public MyButtonOffersUtility b_banish;

	public MyButton b_open;

	public MyButton b_leave;

	public MyButton b_take;

	public ItemData itemData;

	public Window window;

	public static Action A_Open;

	public static Action A_Close;

	private EChest chestType;

	private void Awake()
	{
	}

	private void OnDestroy()
	{
	}

	public override void Open(EEncounter encounterType)
	{
	}

	private void ShowOpenButton()
	{
	}

	public override void OnClose()
	{
	}

	public override void ChooseOffer(int index)
	{
	}

	private void OpeningFinished(ItemData unused)
	{
	}

	private IEnumerator AnimateText()
	{
		return null;
	}

	private IEnumerator AnimateSingleTextObject(TextMeshProUGUI text, float fadeTime)
	{
		return null;
	}

	public void OpenButton()
	{
	}

	public void TakeButton()
	{
	}

	public void DiscardButton()
	{
	}

	public void BanishButton()
	{
	}
}
