using System.Linq;
using MacroTools.Extensions;
using MacroTools.Factions;
using WCSharp.Shared;
using MacroTools.Save;

namespace WarcraftLegacies.Source.Stats;

public static class MatchResultRecorder
{
  public static void RecordForfeitResult(Team losingTeam)
  {
    var allPlayers = Util.EnumeratePlayers().ToList();
    var winningTeams = allPlayers
      .Select(p => p.GetPlayerData().Team)
      .Where(t => t != null && t != losingTeam)
      .Distinct()
      .ToList();

    foreach (var player in allPlayers)
    {
      var data = player.GetPlayerData();
      var team = data.Team;
      if (team == null)
      {
        continue;
      }

      var settings = player.GetPlayerSettings();
      var stats = settings.MatchStats;
      stats.GamesPlayed++;
      stats.LastSlotPlayed = player.Id;
      stats.LastFactionPlayed = data.Faction?.Name;
      stats.LastTeamName = team.Name;

      if (team == losingTeam)
      {
        stats.Losses++;
      }
      else if (winningTeams.Contains(team))
      {
        stats.Wins++;
      }
      SaveManager.SavePublic(settings);
    }
  }
}
