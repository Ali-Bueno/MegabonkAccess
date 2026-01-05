using System.Collections.Generic;
using UnityEngine;

public class CharacterMenu : Window
{
	public BackEscape windowBackEscape;

	public static ECharacter selectedCharacter;

	public Transform characterGridParent;

	public GameObject characterPrefabUi;

	public MyButton b_confirm;

	public MyButton b_purchase;

	public MyButton b_back;

	public MyButton b_hatPrev;

	private List<MyButtonCharacter> characterButtons;

	public SkinSelection skinSelection;

	public GameObject hatSelection;

	private MyButtonCharacter selectedButton;

	public MainMenu mainMenu;

	public UnlocksUi shopUi;

	public new void FocusWindow()
	{
	}

	private new void Awake()
	{
	}

	private new void OnEnable()
	{
	}

	private void TryInit()
	{
	}

	private void SetupButtonNavigation()
	{
	}

	private void OnSelectCharacter(MyButtonCharacter characterButton)
	{
	}

	private void DisableNavigationStatWindow()
	{
	}

	private void EnableNavigationStatWindow()
	{
	}

	private void OnConfirmCharacter(MyButtonCharacter characterButton)
	{
	}

	public void BuyCharacter()
	{
	}

	private void Update()
	{
	}

	private new void OnDisable()
	{
	}

	private new void OnDestroy()
	{
	}
}
