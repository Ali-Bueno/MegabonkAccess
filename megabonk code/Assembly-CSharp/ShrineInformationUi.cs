using System;
using System.Collections.Generic;
using UnityEngine;

public class ShrineInformationUi : MonoBehaviour
{
	[Serializable]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9;

		public static Comparison<KeyValuePair<string, InteractablesStatus.InteractableStatusContainer>> _003C_003E9__10_0;

		internal int _003CInit_003Eb__10_0(KeyValuePair<string, InteractablesStatus.InteractableStatusContainer> a, KeyValuePair<string, InteractablesStatus.InteractableStatusContainer> b)
		{
			return 0;
		}
	}

	public Transform parent;

	public GameObject prefab;

	private List<ShrineInformationPrefab> entries;

	private int ticksUntilInit;

	private void Awake()
	{
	}

	private void OnDestroy()
	{
	}

	private void Start()
	{
	}

	private void OnInteractableSpawned(string debugName)
	{
	}

	private void FixedUpdate()
	{
	}

	private void OnMapGenerated()
	{
	}

	private void Init()
	{
	}

	private void Rebuild()
	{
	}

	private void OnInteractableStatusUpdate(string name)
	{
	}

	private void Refresh()
	{
	}

	private void CheckVisible()
	{
	}

	private void OnSettingUpdate(string name, object oldVal, object newVal)
	{
	}
}
