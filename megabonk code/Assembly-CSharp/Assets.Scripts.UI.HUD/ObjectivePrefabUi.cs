using Assets.Scripts.Inventory__Items__Pickups.Items;
using TMPro;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.UI;

namespace Assets.Scripts.UI.HUD;

public class ObjectivePrefabUi : MonoBehaviour
{
	public GameObject checkBox;

	public GameObject checkMark;

	public TextMeshProUGUI t_objective;

	public LayoutGroup content;

	public TextSizer textSizer;

	private EObjective eObjective;

	private LocalizedString localizedObjective;

	public RawImage overlay;

	private float padding;

	private int paddingWidth;

	private float slideTime;

	private float timer;

	private bool completed;

	private Color completedColor;

	private void Awake()
	{
	}

	private void OnDestroy()
	{
	}

	private void OnItemAdded(EItem eItem)
	{
	}

	private void RefreshText()
	{
	}

	public void Set(LocalizedString localizedObjective, bool showCheckmark, EObjective eObjective = EObjective.Generic)
	{
	}

	private void Update()
	{
	}

	private void PadAndRebuild()
	{
	}

	private void Rebuild()
	{
	}

	public void Complete()
	{
	}
}
