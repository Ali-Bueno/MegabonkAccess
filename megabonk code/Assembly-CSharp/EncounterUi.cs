using System.Collections.Generic;
using Assets.Scripts.UI.InGame.Rewards;
using Assets.Scripts.UI.Menu.Windows;
using TMPro;
using UnityEngine;

public class EncounterUi : BaseEncounterWindow
{
	public TextMeshProUGUI t_name;

	public TextMeshProUGUI t_description;

	public GameObject b_generic;

	private List<EncounterButton> genericButtons;

	private List<EncounterButton> rarityButtons;

	public GameObject particles;

	public TabsExplicitNavigation tabsExplicitNavigation;

	private EncounterOffer[] offers;

	private float openedAtTime;

	private int rebuildAfterFrames;

	private bool needRebuild;

	public override void Open(EEncounter encounterType)
	{
	}

	private void Update()
	{
	}

	private void KeyboardInput()
	{
	}

	private void LateUpdate()
	{
	}

	private void HideButtons()
	{
	}

	public override void OnClose()
	{
	}

	public override void ChooseOffer(int index)
	{
	}
}
