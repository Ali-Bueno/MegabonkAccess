using TMPro;
using UnityEngine;

public class ShopFooter : MonoBehaviour
{
	public TextMeshProUGUI t_title;

	public TextMeshProUGUI t_description;

	public ShopContainer shopContainer;

	public RequirementsContainer requirementsContainer;

	public GameObject buy;

	public GameObject refund;

	public void Set(ShopContainer shopContainerClicked)
	{
	}

	private void SetLocked(ShopItemData shopItem)
	{
	}

	private void SetUnlocked(ShopItemData shopItem)
	{
	}
}
