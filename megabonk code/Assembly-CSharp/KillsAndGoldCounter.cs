using Assets.Scripts.Menu.Shop;
using TMPro;
using UnityEngine;

public class KillsAndGoldCounter : MonoBehaviour
{
	public TextMeshProUGUI t_gold;

	public TextMeshProUGUI t_kills;

	public TextMeshProUGUI t_silver;

	public TextMeshProUGUI t_chestPrice;

	private string killsString;

	private bool queuedKillsUpdate;

	private bool queuedGoldUpdate;

	private void Start()
	{
	}

	private void Awake()
	{
	}

	private void OnDestroy()
	{
	}

	private void OnInventoryInitialized(PlayerInventory inv)
	{
	}

	private void Update()
	{
	}

	private void OnRunStatChanged(string stat, float value)
	{
	}

	private void OnGoldIncrease(PlayerInventory inv, int amount)
	{
	}

	private void UpdateKillCounter()
	{
	}

	private void UpdateGoldCounter()
	{
	}

	private void OnSilverChange(int delta)
	{
	}

	private void OnChestPriceIncreased()
	{
	}

	private void OnSpawnFinished()
	{
	}

	private void OnStatsUpdated(EStat stat)
	{
	}
}
