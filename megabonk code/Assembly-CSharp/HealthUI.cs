using Assets.Scripts.Actors;
using Assets.Scripts.Inventory__Items__Pickups;
using TMPro;
using UnityEngine;

public class HealthUI : MonoBehaviour
{
	public Transform healthBar;

	public Transform shieldBar;

	public Transform overhealBar;

	public CanvasGroup canvasGroup;

	private Vector3 defaultPosition;

	public TextMeshProUGUI t_hp;

	public TextMeshProUGUI t_shield;

	public bool followPlayer;

	private void Awake()
	{
	}

	private void OnDestroy()
	{
	}

	private void OnPlayerInventoryInit(PlayerInventory inventory)
	{
	}

	private void Start()
	{
	}

	private void Update()
	{
	}

	private void UpdateBars(PlayerHealth ph)
	{
	}

	private void UpdateHealthBar(Transform bar, float value, float max)
	{
	}

	private void OnPortalOpen()
	{
	}

	private void OnPortalClose()
	{
	}

	private void OnHeal(PlayerHealth ph, float amount, bool isShield)
	{
	}

	private void OnDamageTaken(PlayerHealth ph, DamageContainer dc, bool shieldDamage)
	{
	}

	private void OnMaxValuesChanged(PlayerHealth ph)
	{
	}

	private void OnOverhealChanged(PlayerHealth ph)
	{
	}

	private void OnSettingUpdated(string settingName, object oldValue, object newValue)
	{
	}

	private void RefreshHud()
	{
	}

	private void SetHealthBarColor(EHpBarColor color)
	{
	}
}
