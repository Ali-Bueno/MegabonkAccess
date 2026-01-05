using TMPro;
using UnityEngine;

public class ShrineInformationPrefab : MonoBehaviour
{
	public TextMeshProUGUI t_name;

	public TextMeshProUGUI t_values;

	private string debugName;

	private InteractablesStatus.InteractableStatusContainer container;

	public void Set(InteractablesStatus.InteractableStatusContainer container, string name)
	{
	}

	public void Refresh()
	{
	}

	public void SetValue(int current, int max)
	{
	}

	public bool CanShow()
	{
		return false;
	}
}
