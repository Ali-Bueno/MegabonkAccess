using System;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Menu.Shop;
using UnityEngine;

public class StatsUi : MonoBehaviour
{
	private sealed class _003CDelayedRebuild_003Ed__10 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public StatsUi _003C_003E4__this;

		object IEnumerator<object>.Current => null;

		object IEnumerator.Current => null;

		public _003CDelayedRebuild_003Ed__10(int _003C_003E1__state)
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

	public Transform rootTransformToRefresh;

	public GameObject entryPrefab;

	public GameObject spacerPrefab;

	private List<StatEntry> entries;

	private int[] spacers;

	private List<EStat> statsToShow;

	private void Awake()
	{
	}

	private void OnDestroy()
	{
	}

	private void OnEnable()
	{
	}

	private void OnStatUpdate(EStat stat)
	{
	}

	private void TryInit()
	{
	}

	private void Refresh()
	{
	}

	private IEnumerator DelayedRebuild()
	{
		return null;
	}

	public static string FormatStat(EStat stat, float value)
	{
		return null;
	}
}
