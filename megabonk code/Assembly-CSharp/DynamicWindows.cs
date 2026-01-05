using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DynamicWindows : MonoBehaviour
{
	public Transform contentParent;

	public Transform overlay;

	public GameObject dynamicWindowPrefab;

	public GameObject dynamicWindowPromptPrefab;

	private void Awake()
	{
	}

	private void OnDestroy()
	{
	}

	private void Update()
	{
	}

	public bool HasWindows()
	{
		return false;
	}

	private void OnNewSceneLoaded(Scene scene, LoadSceneMode mode)
	{
	}

	public void NewWindow(string header, string content)
	{
	}

	public void NewWindowPrompt(string header, string content, Action A_Accept)
	{
	}
}
