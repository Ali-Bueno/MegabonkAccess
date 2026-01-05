using Inventory__Items__Pickups.Xp_and_Levels;
using UnityEngine;

public class XpAndGoldHUD : MonoBehaviour
{
	public XpAndGoldText xpText;

	public XpAndGoldText goldText;

	public XpAndGoldText silverText;

	private void Awake()
	{
	}

	private void OnDestroy()
	{
	}

	private void OnGoldIncrease(PlayerInventory inv, int amount)
	{
	}

	private void OnXpIncrease(PlayerXp pXp, int amount)
	{
	}

	private void OnSilverChange(int amount)
	{
	}
}
