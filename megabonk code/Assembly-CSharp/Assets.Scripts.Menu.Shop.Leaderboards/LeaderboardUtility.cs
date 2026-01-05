using System;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Steam;
using Assets.Scripts.Steam.LeaderboardsNew;
using Steamworks;

namespace Assets.Scripts.Menu.Shop.Leaderboards;

public static class LeaderboardUtility
{
	[Serializable]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9;

		public static Func<LeaderboardEntry, CSteamID> _003C_003E9__1_0;

		public static Func<LeaderboardEntry, int> _003C_003E9__1_3;

		public static Func<IGrouping<CSteamID, LeaderboardEntry>, LeaderboardEntry> _003C_003E9__1_1;

		public static Comparison<LeaderboardEntry> _003C_003E9__1_2;

		public static Comparison<LeaderboardEntry> _003C_003E9__2_0;

		internal CSteamID _003CGetEntriesKills_003Eb__1_0(LeaderboardEntry e)
		{
			return default(CSteamID);
		}

		internal LeaderboardEntry _003CGetEntriesKills_003Eb__1_1(IGrouping<CSteamID, LeaderboardEntry> g)
		{
			return null;
		}

		internal int _003CGetEntriesKills_003Eb__1_3(LeaderboardEntry e)
		{
			return 0;
		}

		internal int _003CGetEntriesKills_003Eb__1_2(LeaderboardEntry a, LeaderboardEntry b)
		{
			return 0;
		}

		internal int _003CGetFriendsEntries_003Eb__2_0(LeaderboardEntry a, LeaderboardEntry b)
		{
			return 0;
		}
	}

	public static List<LeaderboardEntry> GetEntriesKills(bool isGlobal, bool isWeekly, int numToShow)
	{
		return null;
	}

	private static List<LeaderboardEntry> GetEntriesKills(List<LeaderboardEntry> globalEntries, List<LeaderboardEntry> friendsEntries, int numToShow)
	{
		return null;
	}

	private static List<LeaderboardEntry> GetFriendsEntries(SteamLeaderboardNew leaderboard, int numToShow)
	{
		return null;
	}
}
