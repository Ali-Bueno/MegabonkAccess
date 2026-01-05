using Inventory__Items__Pickups.Xp_and_Levels;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class XpBarUI : MonoBehaviour
{
	public TextMeshProUGUI t_levelText;

	public RawImage xpBar;

	private Color defaultColor;

	public Material rainbow;

	private Material defaultMaterial;

	private float desiredRatio;

	private void Awake()
	{
	}

	private void OnDestroy()
	{
	}

	private void Start()
	{
	}

	private void Refresh(PlayerXp playerXp)
	{
	}

	private void SetLevelText(int level)
	{
	}

	private void OnInventoryInitialized(PlayerInventory pInventory)
	{
	}

	private void OnXpIncrease(PlayerXp pXp, int amount)
	{
	}

	private void Update()
	{
	}

	private void OnLevelUp(int level)
	{
	}

	private void OnLevelupShow()
	{
	}

	private void OnLevelupHide()
	{
	}
}
