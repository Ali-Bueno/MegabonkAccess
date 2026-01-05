using System;
using Discord;
using UnityEngine;

public class DiscordManager : MonoBehaviour
{
	[Serializable]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9;

		public static ActivityManager.UpdateActivityHandler _003C_003E9__8_0;

		internal void _003CUpdateActivity_003Eb__8_0(Result res)
		{
		}
	}

	public static bool ENABLED;

	private bool isRunning;

	private global::Discord.Discord discord;

	public static DiscordManager Instance;

	private float checkReconnectTimer;

	private long appid;

	private void Awake()
	{
	}

	private void OnDestroy()
	{
	}

	public void UpdateActivity(Activity activity)
	{
	}

	private void Update()
	{
	}

	private void TryReconnect()
	{
	}
}
