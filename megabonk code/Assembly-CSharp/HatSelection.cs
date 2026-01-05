using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.UI;

public class HatSelection : MonoBehaviour
{
	public Texture noHatTexture;

	public LocalizedString localizedNoHat;

	private static int index;

	public TextMeshProUGUI t_hatName;

	public RawImage i_hatIcon;

	private List<HatData> availableHats;

	private ECharacter character;

	private HatData selectedhatData;

	public static Action A_HatChanged;

	private void Awake()
	{
	}

	private void OnDestroy()
	{
	}

	private void OnEnable()
	{
	}

	private void CheckInit(bool force)
	{
	}

	public void Flip(int dir)
	{
	}

	private void UpdateHatText()
	{
	}

	private void OnSelectCharacter(MyButtonCharacter characterButton)
	{
	}

	private int NumSongs()
	{
		return 0;
	}
}
