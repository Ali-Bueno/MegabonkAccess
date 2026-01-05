using Assets.Scripts.UI.InGame.Rewards;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EncounterButton : MyButton
{
	public GameObject rarityContainer;

	public Image background;

	public Image selectedOverlay;

	public RawImage iconBorder;

	public RawImage iconBackground;

	public TextMeshProUGUI t_description;

	public TextMeshProUGUI t_rarity;

	public int index;

	private EncounterUi encounterUi;

	private bool canAccept;

	private string cantAcceptReason;

	public void Init(EncounterUi encounterUi, int index)
	{
	}

	public void SetOffer(EncounterOffer offer, bool showRarity)
	{
	}

	private void TimeoutButton(float time)
	{
	}

	private void EnableButton()
	{
	}

	public void SetDeclineOffer(int numOffers)
	{
	}

	public override void StartHover()
	{
	}

	public override void StopHover()
	{
	}

	protected override void OnClick()
	{
	}
}
