using Assets.Scripts.Inventory__Items__Pickups.Weapons;
using UnityEngine;
using UnityEngine.UI;

public class CrosshairUi : MonoBehaviour
{
	public Image crosshairOuter;

	public RawImage crosshairInner;

	public RectTransform parentCrosshair;

	public CanvasGroup group;

	public Color hoveringEnemyColor;

	public Color hoveringMarkedEnemyColor;

	public float movingSize;

	public float airborneSize;

	private float globalSizeMultiplier;

	private float defaultSize;

	private float desiredSize;

	private bool hoveringEnemy;

	private bool isVisible;

	private static float yMin;

	private static float yMax;

	private void Awake()
	{
	}

	private void OnDestroy()
	{
	}

	private void Start()
	{
	}

	private void CheckVisible()
	{
	}

	private void Update()
	{
	}

	private void FixedUpdate()
	{
	}

	private void FindDesiredSize()
	{
	}

	public static Vector3 GetCrosshairRaycastPosition()
	{
		return default(Vector3);
	}

	public static Vector3 GetCrosshairUiPosition()
	{
		return default(Vector3);
	}

	private void OnSettingUpdated(string settingName, object oldValue, object newValue)
	{
	}

	private void OnWeaponAdded(WeaponBase weapon)
	{
	}

	private void OnWeaponRemoved(WeaponBase weapon)
	{
	}

	private void RefreshSize()
	{
	}

	private void RefreshAlpha()
	{
	}
}
