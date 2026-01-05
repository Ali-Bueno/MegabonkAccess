using System.Collections.Generic;
using Assets.Scripts.Audio.Music;
using TMPro;
using UnityEngine;

public class MusicSelectionUi : MonoBehaviour
{
	private static int index;

	public TextMeshProUGUI t_trackName;

	private List<MusicTrack> tracks;

	public MapSelectionUi mapSelection;

	private void Awake()
	{
	}

	private void OnDestroy()
	{
	}

	private void Start()
	{
	}

	public void Flip(int dir)
	{
	}

	private void UpdateTrack(bool playTrack)
	{
	}

	private void OnMapSelected(SelectionGroupToggleSingleButton btn, MapData mapData)
	{
	}

	private int NumSongs()
	{
		return 0;
	}
}
