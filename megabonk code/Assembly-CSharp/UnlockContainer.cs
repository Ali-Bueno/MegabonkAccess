using System;
using Assets.Scripts.Saves___Serialization.Progression.Achievements;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UnlockContainer : MonoBehaviour, ISelectHandler, IEventSystemHandler
{
	public UnlockableBase unlockable;

	public RawImage icon;

	public RawImage fullReleaseOnly;

	public RawImage backgroundLocked;

	public RawImage backgroundUnlocked;

	public Texture t_unknown;

	public string requirementsString;

	public bool isUnlocked;

	public bool fullGameOnly;

	public bool isPurchased;

	public GameObject notPurchasedOverlay;

	public TextMeshProUGUI t_price;

	public GameObject alert;

	public GameObject activationToggle;

	public GameObject activationToggleCheckmark;

	public GameObject unactivatedOverlay;

	private Button button;

	public static Action<UnlockContainer> A_Selected;

	public static Action<UnlockContainer> A_Clicked;

	public Color defaultBackgroundColor;

	public bool visualsOnlyNoButton;

	public static Action A_RemovedAlert;

	private void Awake()
	{
	}

	private void OnDestroy()
	{
	}

	private void OnEnable()
	{
	}

	public void Set(UnlockableBase unlockable)
	{
	}

	public void SetEmpty()
	{
	}

	public void SetUnlocked(bool isUnlocked)
	{
	}

	public void SetAchievement(MyAchievement ach)
	{
	}

	private Color GetBackgroundColor(UnlockableBase unlockable)
	{
		return default(Color);
	}

	public void OnSelect(BaseEventData eventData)
	{
	}

	public void ToggleActivation()
	{
	}

	private void OnPurchased(UnlockableBase unlockable)
	{
	}
}
