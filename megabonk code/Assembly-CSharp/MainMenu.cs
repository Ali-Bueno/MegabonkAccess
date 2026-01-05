using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
	[Serializable]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9;

		public static Action _003C_003E9__39_0;

		internal void _003CExitGame_003Eb__39_0()
		{
		}
	}

	private sealed class _003CAnimateNewButtons_003Ed__15 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public MainMenu _003C_003E4__this;

		public List<GameObject> objects;

		private List<GameObject>.Enumerator _003C_003E7__wrap1;

		private GameObject _003Co_003E5__3;

		private float _003CscaleTime_003E5__4;

		private float _003Ctimer_003E5__5;

		object IEnumerator<object>.Current => null;

		object IEnumerator.Current => null;

		public _003CAnimateNewButtons_003Ed__15(int _003C_003E1__state)
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

		private void _003C_003Em__Finally1()
		{
		}

		void IEnumerator.Reset()
		{
		}
	}

	public static Action A_MenuOpened;

	public MenuCamera menuCamera;

	public GameObject btnUnlocks;

	public GameObject btnQuests;

	public GameObject btnShop;

	public GameObject leaderboards;

	public GameObject quickQuests;

	public MyButton btnPlay;

	private bool isAnimating;

	public GameObject blockRaycastOverlay;

	public GameObject newButtonParticles;

	public MapSelectionUi mapSelectionUi;

	public GameObject tabMenu;

	public GameObject tabCharacters;

	public GameObject tabMaps;

	public GameObject tabShop;

	public GameObject tabUnlocks;

	public GameObject tabLogs;

	public GameObject settings;

	public GameObject credits;

	public GameObject quests;

	public GameObject leaderboardsFull;

	private GameObject currentTab;

	private void Awake()
	{
	}

	private void OnDestroy()
	{
	}

	private void Start()
	{
	}

	private void RefreshButtons()
	{
	}

	private IEnumerator AnimateNewButtons(List<GameObject> objects)
	{
		return null;
	}

	public void GoToMenu()
	{
	}

	public void GoToCharacterSelection()
	{
	}

	public void GoToMapSelection()
	{
	}

	public void GoToShop()
	{
	}

	public void GoToCredits()
	{
	}

	public void GoToUnlocks()
	{
	}

	public void GoToQuests()
	{
	}

	public void GoToLogs()
	{
	}

	public void GoToSettings()
	{
	}

	public void GoToLeaderboards()
	{
	}

	public void SetWindow(GameObject tabWindow)
	{
	}

	public void ExitGame()
	{
	}
}
