using System.Collections.Generic;
using Assets.Scripts.Audio.Music;
using UnityEngine;

public class MusicController : MonoBehaviour
{
	public static MusicController Instance;

	public AudioSource musicSource;

	public AudioLowPassFilter lowpassFilter;

	private float volumeMultiplier;

	private float desiredVolumeMultiplier;

	private float desiredVolume;

	private float desiredLowpass;

	public MusicTrack menuMusicTrack;

	private MusicTrack currentTrack;

	private bool isPlayingIntro;

	private float introLength;

	private float defaultPitch;

	private float nextCheckTime;

	private float checkCooldown;

	private FinalFightController finalFightController;

	private int lowpassLow;

	private float currentDangerPitch;

	private Dictionary<MusicPauseZone, float> zoneInfluences;

	private float zoneMultiplier;

	private void Awake()
	{
	}

	private void OnDestroy()
	{
	}

	private void OnStageStarted()
	{
	}

	private void OnSceneTransitionStart()
	{
	}

	public void StopMusic()
	{
	}

	public void PlayStageMusic()
	{
	}

	public void PlayMenuTrack()
	{
	}

	public void PlayMusicTrack(MusicTrack musicTrack)
	{
	}

	private void OnMainMenu()
	{
	}

	private void Update()
	{
	}

	private void UpdatePitch()
	{
	}

	private void UpdateDesiredLowpass()
	{
	}

	private void OnSettingUpdated(string name, object oldValue, object newValue)
	{
	}

	public void SetMusicVolume(float volume)
	{
	}

	public void RegisterZoneInfluence(MusicPauseZone zone, float influence)
	{
	}

	private void UpdateZoneInfluences()
	{
	}

	private void OnPlayerDied()
	{
	}

	private void OnChestOpening()
	{
	}

	private void OnChestClosed()
	{
	}

	private void OnPause(bool p)
	{
	}

	public void RefreshFilter()
	{
	}
}
