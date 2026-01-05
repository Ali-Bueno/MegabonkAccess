using Assets.Scripts.Saves___Serialization.Progression.Stats;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DamageSourceEntry : MonoBehaviour
{
	public RawImage icon;

	public TextMeshProUGUI t_sourceName;

	public TextMeshProUGUI t_lvl;

	public TextMeshProUGUI t_dmg;

	public TextMeshProUGUI t_dps;

	public void Set(DamageSource dmgSource)
	{
	}

	private string FormatNumberWithSpaces(float num)
	{
		return null;
	}
}
