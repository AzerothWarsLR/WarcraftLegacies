using System.Collections.Generic;
using MacroTools.Factions;
using MacroTools.GameTime;

namespace WarcraftLegacies.Source.GameLogic.GameEnd;

/// <summary>The last side with undefeated factions wins, with teams in the same <see cref="Bloc"/> counting as one side.</summary>
public static class LastTeamStandingVictory
{
  private static readonly HashSet<Faction> _watchedFactions = new();

  public static void Setup()
  {
    foreach (var faction in FactionManager.GetAllFactions())
    {
      Watch(faction);
    }

    FactionManager.FactionRegistered += Watch;
    TeamChanges.OnAnyTeamChanged(Check);
  }

  private static void Watch(Faction faction)
  {
    if (_watchedFactions.Contains(faction))
    {
      return;
    }

    _watchedFactions.Add(faction);
    faction.ScoreStatusChanged += _ => Check();
  }

  private static void Check()
  {
    if (GameVictory.IsWon || GameTimeManager.Turn < 1)
    {
      return;
    }

    Team? lastTeam = null;
    Bloc? lastBloc = null;
    var survivors = new List<Faction>();
    foreach (var team in FactionManager.GetAllTeams())
    {
      var teamSurvives = false;
      foreach (var faction in team.GetAllFactions())
      {
        if (faction.Player != null && faction.ScoreStatus != ScoreStatus.Defeated)
        {
          teamSurvives = true;
          survivors.Add(faction);
        }
      }

      if (!teamSurvives)
      {
        continue;
      }

      if (lastTeam != null && (team.Bloc == null || team.Bloc != lastBloc))
      {
        return;
      }

      lastTeam = team;
      lastBloc = team.Bloc;
    }

    if (lastTeam == null)
    {
      return;
    }

    GameVictory.Declare(lastBloc?.Name ?? lastTeam.Name, lastTeam.VictoryMusic, survivors);
  }
}
