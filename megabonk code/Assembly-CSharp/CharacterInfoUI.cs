using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CharacterInfoUI : MonoBehaviour
{
	public TextMeshProUGUI t_name;

	public TextMeshProUGUI t_description;

	public TextMeshProUGUI t_weaponName;

	public TextMeshProUGUI t_weaponDesc;

	public TextMeshProUGUI t_passiveName;

	public TextMeshProUGUI t_passiveDesc;

	public RawImage i_weapon;

	public RawImage i_passive;

	public SkinSelection skinSelection;

	public RequirementsContainer reqContainer;

	public TextMeshProUGUI t_rank;

	public TextMeshProUGUI t_runs;

	public RawImage i_rankFrame;

	public RawImage i_rankIcon;

	public RawImage progressBar;

	public RawImage i_character;

	public RawImage i_runs;

	public GameObject star;

	private void Awake()
	{
	}

	private void OnDestroy()
	{
	}

	private void OnCharacterSelected(MyButtonCharacter btn)
	{
	}
}
