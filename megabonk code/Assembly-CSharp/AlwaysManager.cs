using System;
using Assets.Scripts.Actors.Enemies;
using Newtonsoft.Json;
using UnityEngine;

public class AlwaysManager : MonoBehaviour
{
	[Serializable]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9;

		public static Func<JsonSerializerSettings> _003C_003E9__8_0;

		internal JsonSerializerSettings _003CAwake_003Eb__8_0()
		{
			return null;
		}
	}

	public SaveManager saveManager;

	public DataManager dataManager;

	public SteamManager steamManager;

	public GameObject rewiredManager;

	public GameObject eventSystem;

	public AlwaysUi alwaysUi;

	public static AlwaysManager Instance;

	public Material playerMaterialPreset;

	private int index;

	private Enemy testEnemy;

	private void Awake()
	{
	}

	private void Start()
	{
	}

	private void Update()
	{
	}

	private void FixedUpdate()
	{
	}

	private void OnDestroy()
	{
	}
}
