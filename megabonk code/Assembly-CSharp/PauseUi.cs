using System;
using UnityEngine;

public class PauseUi : MonoBehaviour
{
	[Serializable]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9;

		public static Action _003C_003E9__12_0;

		public static Action _003C_003E9__17_0;

		internal void _003CExit_003Eb__12_0()
		{
		}

		internal void _003CRestart_003Eb__17_0()
		{
		}
	}

	public GameObject main;

	public GameObject options;

	public GameObject map;

	private GameObject current;

	public Window mainWindow;

	public Window mapWindow;

	public UpgradeInventoryUI inventory;

	private bool wasGamePaused;

	private void Awake()
	{
	}

	private void Update()
	{
	}

	public void Pause()
	{
	}

	public void Resume()
	{
	}

	public bool CanPause()
	{
		return false;
	}

	public void Exit()
	{
	}

	public void GoToMain()
	{
	}

	public void GoToOptions()
	{
	}

	public void GoToMap()
	{
	}

	private void GoToWindow(GameObject window)
	{
	}

	public void Restart()
	{
	}

	public void Toggle()
	{
	}

	private void OnDisable()
	{
	}

	private void OnEnable()
	{
	}

	public bool IsPaused()
	{
		return false;
	}
}
