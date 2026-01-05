using Assets.Scripts.Menu.Shop;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StatEntry : MonoBehaviour
{
	public RawImage icon;

	public TextMeshProUGUI t_stat;

	public TextMeshProUGUI t_value;

	private EStat stat;

	public ToolTipObject toolTipObject;

	private void OnEnable()
	{
	}

	private void RefreshValues()
	{
	}

	public void Set(EStat stat)
	{
	}
}
