using System;
using UnityEngine;

namespace Assets.Scripts.Audio.Music;

public class MusicTrack : ScriptableObject, IComparable<MusicTrack>
{
	public bool isEnabled;

	public bool isInJukebox;

	public bool isInRandomPool;

	public int maxStageCompatibility;

	public MusicCategory category;

	public string trackName;

	public AudioClip intro;

	public AudioClip loop;

	public void LoadToMemory()
	{
	}

	public void UnloadFromMemory()
	{
	}

	public bool IsLoadedInMemory()
	{
		return false;
	}

	public int CompareTo(MusicTrack other)
	{
		return 0;
	}
}
