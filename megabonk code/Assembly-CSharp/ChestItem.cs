using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ChestItem : MonoBehaviour
{
	public RawImage icon;

	public TextMeshProUGUI t_amountText;

	public AudioClip clipPositive;

	public AudioClip clipNegative;

	public AudioSource audioSource;

	public void Set(ItemData itemData, int amount)
	{
	}
}
