using System;
using Assets.Scripts.UI.InGame.Rewards;
using TMPro;
using UnityEngine;

public class LevelupScreen : BaseEncounterWindow
{
	public static bool isLevelingUp;

	public GameObject window;

	public GameObject effects;

	public AudioSource audioLevel;

	public AudioSource audioShadyGuy;

	public GameObject button;

	public UpgradePicker upgradePicker;

	public UpgradeInventoryUI upgradeInventoryUi;

	public TextMeshProUGUI t_title;

	public TextMeshProUGUI t_description;

	public MyButtonOffersUtility b_skip;

	public MyButtonOffersUtility b_refresh;

	public MyButtonOffersUtility b_banish;

	public MyButtonNormal b_leave;

	public static Action A_LevelupEnabled;

	public static Action A_LevelUpClose;

	private int level;

	private int currentLevel;

	public Window windowScript;

	private static bool hasBanishes;

	private static bool hasRefreshes;

	private static bool hasSkips;

	private bool hasInitedThisStage;

	private EEncounter encounterType;

	public float refreshTime;

	private void TryInit()
	{
	}

	public void ShowLevelupScreen()
	{
	}

	private void Update()
	{
	}

	public void CloseLevelupScreen()
	{
	}

	public override void Open(EEncounter encounterType)
	{
	}

	public override void OnClose()
	{
	}

	public override void ChooseOffer(int index)
	{
	}

	public void Leave()
	{
	}

	public void Skip()
	{
	}

	public void Refresh()
	{
	}

	public void StartBanish()
	{
	}

	public void Banish()
	{
	}

	private int GetSkips()
	{
		return 0;
	}

	private int GetRefreshes()
	{
		return 0;
	}

	public int GetBanishes()
	{
		return 0;
	}

	private int GetSkipsUsed()
	{
		return 0;
	}

	private int GetRefreshesUsed()
	{
		return 0;
	}

	public int GetBanishesUsed()
	{
		return 0;
	}

	public void DecrementBanishes()
	{
	}

	private void RefreshUtilityButtons()
	{
	}

	public int GetShopToolPrice(int numUses)
	{
		return 0;
	}

	private string GetMoaiText(int level)
	{
		return null;
	}

	private string GetShadyGuyText()
	{
		return null;
	}
}
