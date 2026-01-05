using System;
using Steamworks;
using UnityEngine;

public class SteamManager : MonoBehaviour
{
	protected static bool initialized;

	protected static SteamManager Instance;

	public static AppId_t APP_ID;

	public static Action A_UpdateComponents;

	public static Action A_Initialized;

	public static ulong steamId;

	public static Action<ulong> A_PlayerInformationArrived;

	private static void InitOnPlayMode()
	{
	}

	public virtual void Load()
	{
	}

	protected virtual void OnDestroy()
	{
	}

	private void InitComponents()
	{
	}

	private void DestroyComponents()
	{
	}

	private void OnPersonaStateChange(PersonaStateChange_t param)
	{
	}

	protected virtual void Update()
	{
	}

	public static bool IsInitialized()
	{
		return false;
	}
}
