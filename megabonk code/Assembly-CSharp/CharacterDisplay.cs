using UnityEngine;

public class CharacterDisplay : MonoBehaviour
{
	public PlayerRenderer playerRenderer;

	public LayerMask layerMask;

	private CharacterData currentCharacter;

	public Material lockedMaterial;

	private bool usingNonOwnedSkin;

	private void Start()
	{
	}

	private void OnCharacterSelected(CharacterData characterData)
	{
	}

	private void OnCharacterSelected(MyButtonCharacter btn)
	{
	}

	private void OnSkinSelected(SkinContainer skinContainer)
	{
	}

	private void OnMapSelectionEnabled()
	{
	}

	private void OnHatChanged()
	{
	}

	private void OnDestroy()
	{
	}
}
