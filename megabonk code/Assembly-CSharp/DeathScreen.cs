using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeathScreen : MonoBehaviour
{
	private sealed class _003CDoTransition_003Ed__29 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public DeathScreen _003C_003E4__this;

		object IEnumerator<object>.Current => null;

		object IEnumerator.Current => null;

		public _003CDoTransition_003Ed__29(int _003C_003E1__state)
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

	public DeathScreenBlocksUI blocksUi;

	public GameObject deadUiWindow;

	public GameObject statsWindow;

	public GameObject background;

	public GameObject leaderboardsWindow;

	public GameObject victoryScreen;

	public UiAnimation t_dead;

	public UiAnimation b_continue;

	public AudioSource audio;

	public RawImage playerOnlyRender;

	public CanvasGroup canvasGroup;

	private float fadeInTime;

	private float fadeTimer;

	private bool hasNewRecord;

	private int _003CnewRecordRank_003Ek__BackingField;

	private string _003CnewRecordLbName_003Ek__BackingField;

	private bool tierVictory;

	public GameObject restartBtn;

	public int newRecordRank
	{
		get
		{
			return _003CnewRecordRank_003Ek__BackingField;
		}
		private set
		{
			_003CnewRecordRank_003Ek__BackingField = value;
		}
	}

	public string newRecordLbName
	{
		get
		{
			return _003CnewRecordLbName_003Ek__BackingField;
		}
		private set
		{
			_003CnewRecordLbName_003Ek__BackingField = value;
		}
	}

	private void Awake()
	{
	}

	private void OnDestroy()
	{
	}

	private void OnLeaderboardScoreUploaded(string lbName, int rank)
	{
	}

	private void OnBossDefeated(bool canSpawnPortal)
	{
	}

	public void PlayAudio()
	{
	}

	public void StartDeathScreen()
	{
	}

	private IEnumerator DoTransition()
	{
		return null;
	}

	private void Update()
	{
	}

	public void ShowLeaderboard()
	{
	}

	public void HideVictoryScreen()
	{
	}

	public void ShowStats()
	{
	}

	public void GoToMenu()
	{
	}

	public void Restart()
	{
	}
}
