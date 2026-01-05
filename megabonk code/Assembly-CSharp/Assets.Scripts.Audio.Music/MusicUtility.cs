using System.Collections.Generic;
using Assets.Scripts._Data.MapsAndStages;
using Assets.Scripts.Game.Other;

namespace Assets.Scripts.Audio.Music;

public class MusicUtility
{
	private static List<MusicTrack> tracks;

	private static List<MusicTrack> tracksOther;

	private static Dictionary<EMap, int> mapTrackRotation;

	private static MusicTrack themeTrackPlayedLastRound;

	public static MusicTrack GetMusicTrackToPlay(RunConfig runConfig)
	{
		return null;
	}

	public static List<MusicTrack> GetTracks()
	{
		return null;
	}

	public static List<MusicTrack> GetTracksOther()
	{
		return null;
	}
}
