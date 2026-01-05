using Assets.Scripts.UI.HUD;
using Assets.Scripts.UI.InGame.Levelup;
using UnityEngine;

public class UiManager : MonoBehaviour
{
	public DeathScreen deathScreen;

	public ScoreUi scoreUi;

	public EncounterWindows encounterWindows;

	public MapTitle mapTile;

	public PauseUi pause;

	public ShrineLogs shrineLogs;

	public ObjectiveArrow objectiveArrow;

	public AlertUi alertUi;

	public ServerFeed feed;

	public ObjectiveUi objective;

	public ColorFilterUI colorFilterUi;

	public GameObject hud;

	public CinematicBars cinematicBars;

	private bool inited;

	public static UiManager Instance;

	public CanvasGroup hudGroup;

	private void Awake()
	{
	}

	private void Start()
	{
	}

	public void TryInit()
	{
	}

	private void Update()
	{
	}

	private void RefreshHud()
	{
	}

	private void OnDestroy()
	{
	}

	private void OnSettingUpdated(string settingName, object oldValue, object newValue)
	{
	}

	private void OnPortalOpen()
	{
	}

	private void OnPortalClose()
	{
	}
}
