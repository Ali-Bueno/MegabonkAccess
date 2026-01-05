using System.Collections.Generic;
using Actors.Enemies;
using Assets.Scripts.UI.Menu.Windows;
using TMPro;
using UnityEngine;

public class LogsUi : MonoBehaviour
{
	public RectTransform content;

	public RectTransform entryPrefab;

	private List<MyButtonLog> logEntries;

	private int page;

	private int maxPages;

	private int entriesPerPage;

	private List<EEnemy> enemies;

	public TextMeshProUGUI t_pages;

	public TextMeshProUGUI t_title;

	public TabsExplicitNavigation entryNavigation;

	private bool hasRefreshed;

	public LogsDisplayEnemy logDisplay;

	private void LateUpdate()
	{
	}

	private void OnDisable()
	{
	}

	private void TryInit()
	{
	}

	private void Refresh()
	{
	}

	private void OpenPage(int page, bool force = false)
	{
	}

	public void FlipPage(int direction)
	{
	}

	private void UpdatePageText()
	{
	}
}
