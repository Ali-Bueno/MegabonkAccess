using System.Collections.Generic;
using Assets.Scripts.Saves___Serialization.Progression.Achievements;
using UnityEngine;

public class UnlocksUi : MonoBehaviour
{
	private sealed class _003C_003Ec__DisplayClass9_0
	{
		public string internalName;

		internal bool _003CUpdateExclamationMarks_003Eb__0(CharacterData c)
		{
			return false;
		}

		internal bool _003CUpdateExclamationMarks_003Eb__1(WeaponData w)
		{
			return false;
		}

		internal bool _003CUpdateExclamationMarks_003Eb__2(TomeData t)
		{
			return false;
		}

		internal bool _003CUpdateExclamationMarks_003Eb__3(ItemData i)
		{
			return false;
		}

		internal bool _003CUpdateExclamationMarks_003Eb__4(HatData i)
		{
			return false;
		}
	}

	private List<UnlockContainer> unlockContainers;

	public GameObject unlockContainerPrefab;

	public Transform contentParent;

	public ButtonNavigationSelectionOnly tabButtons;

	public TabGridNavigation tabGridNavigation;

	public GameObject exclChar;

	public GameObject exclWeapon;

	public GameObject exclTome;

	public GameObject exclItem;

	public GameObject exclHats;

	public GameObject[] exclamationMarks;

	private void Awake()
	{
	}

	private void OnDestroy()
	{
	}

	private void OnEnable()
	{
	}

	public void FocusCharacterPurchase(CharacterData character)
	{
	}

	private void UpdateExclamationMarks()
	{
	}

	private void OnTabSelected(int index)
	{
	}

	private void Refresh(List<UnlockableBase> unlockables)
	{
	}
}
