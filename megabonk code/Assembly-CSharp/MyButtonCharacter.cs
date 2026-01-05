using System;
using Assets.Scripts.Saves___Serialization.Progression.Achievements;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MyButtonCharacter : MyButton
{
	public GameObject hoverOverlay;

	public GameObject unavailableOverlay;

	public TextMeshProUGUI t_name;

	public RawImage i_icon;

	public GameObject requiresPurchaseOverlay;

	public TextMeshProUGUI t_price;

	public GameObject star;

	public CharacterData characterData;

	public Material lockedMaterial;

	public static Action<MyButtonCharacter> A_Confirm;

	public static Action<MyButtonCharacter> A_Select;

	public bool canUseCharacter;

	private CharacterData data;

	public string cantUseCharacterReason;

	private new void Awake()
	{
	}

	private void OnEnable()
	{
	}

	private void OnDestroy()
	{
	}

	private void OnItemPurchased(UnlockableBase unlockable)
	{
	}

	public void SetCharacter(CharacterData data)
	{
	}

	public void Refresh()
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

	private new void Update()
	{
	}
}
