using System;
using Rewired;
using UnityEngine;

public class MyInputManager : MonoBehaviour
{
	public UserDataStore_FileCustom userDataStore;

	private static Controller _003CcurrentController_003Ek__BackingField;

	private static Player player;

	private static bool isSpaceNavigationActive;

	private static bool isHorizontalNavigationDuringChestActive;

	public static Action<Controller> A_SetCurrentController;

	public static string Jump;

	public static string JumpBhop;

	public static string Slide;

	public static string Aim;

	public static string Interact;

	public static string QuickReset;

	public static string MapOverlay;

	public static string Wallrun;

	public static string MoveHorizontal;

	public static string MoveVertical;

	public static string LookHorizontal;

	public static string LookVertical;

	public static string UIHorizontal;

	public static string UIVertical;

	public static string UISubmit;

	public static string UICancel;

	public static string UIAbort;

	public static string UIShoulderLeft;

	public static string UIShoulderRight;

	private static double mouseLastActiveTime;

	public static Controller currentController
	{
		get
		{
			return _003CcurrentController_003Ek__BackingField;
		}
		private set
		{
			_003CcurrentController_003Ek__BackingField = value;
		}
	}

	private void Awake()
	{
	}

	private void OnDestroy()
	{
	}

	private void OnSavesLoaded()
	{
	}

	private void Update()
	{
	}

	public static bool IsUsingController()
	{
		return false;
	}

	private void CheckCurrentController()
	{
	}

	public static Player GetPlayer()
	{
		return null;
	}

	public static Controller GetLastActiveController()
	{
		return null;
	}

	public static bool GetButton(string action)
	{
		return false;
	}

	public static bool GetButtonDown(string action)
	{
		return false;
	}

	public static bool GetButtonUp(string action)
	{
		return false;
	}

	public static float GetAxis(string action)
	{
		return 0f;
	}

	private void SetController(Controller c)
	{
	}

	public static void RefreshSpaceNavigation()
	{
	}

	public static void RefreshHorizontalNavigationForChests(bool isChestWindowOpen)
	{
	}

	public static bool IsActionBound(string action)
	{
		return false;
	}

	private void OnSettingUpdated(string settingName, object o1, object o2)
	{
	}
}
