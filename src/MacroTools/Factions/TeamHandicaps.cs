using System;
using System.Collections.Generic;
using MacroTools.Extensions;
using MacroTools.Setup;
using WCSharp.Events;
using WCSharp.Shared;

namespace MacroTools.Factions;

/// <summary>Gives teams that have fallen behind their rivals more damage dealt and less damage taken.</summary>
public static class TeamHandicaps
{
  private static readonly Dictionary<Team, int> StartingSizes = new();
  private static readonly Dictionary<Team, float> Handicaps = new();
  private static readonly List<Action> ChangedHandlers = new();

  /// <summary>How much each player a team has fallen behind by is worth, as a fraction.</summary>
  public static float PerMissingPlayer { get; set; } = 0.05f;

  /// <summary>Whether two teams fight each other. Teams are only compared with their rivals.</summary>
  public static Func<Team, Team, bool>? AreRivals { get; set; }

  /// <summary>The largest handicap a team can get, as a fraction.</summary>
  public static float Maximum { get; set; } = 0.25f;

  public static bool IsEnabled { get; private set; }

  /// <summary>Remembers how big every team is right now and starts applying handicaps from then on.</summary>
  public static void Enable()
  {
    if (IsEnabled)
    {
      return;
    }

    IsEnabled = true;
    foreach (var team in FactionManager.GetAllTeams())
    {
      StartingSizes[team] = team.UndefeatedPlayerCount;
    }

    foreach (var whichPlayer in Util.EnumeratePlayers())
    {
      PlayerUnitEvents.Register(CustomPlayerUnitEvents.PlayerTakingDamage, OnPlayerTakingDamage, whichPlayer.Id);
    }

    foreach (var faction in FactionManager.GetAllFactions())
    {
      faction.ScoreStatusChanged += _ => Recalculate();
    }

    FactionManager.FactionRegistered += faction => faction.ScoreStatusChanged += _ => Recalculate();
    TeamChanges.OnAnyTeamChanged(Recalculate);
    Recalculate();
  }

  /// <summary>Gives a new team the starting size of the team its founder left.</summary>
  internal static void InheritStartingSize(Team newTeam, Team? formerTeam)
  {
    if (!IsEnabled || formerTeam == null || StartingSizes.ContainsKey(newTeam))
    {
      return;
    }

    StartingSizes[newTeam] = GetStartingSize(formerTeam);
  }

  /// <summary>Sets the size <paramref name="team"/> counts as having started at.</summary>
  public static void SetStartingSize(Team team, int size)
  {
    StartingSizes[team] = size;
    if (IsEnabled)
    {
      Recalculate();
    }
  }

  /// <summary>Runs <paramref name="handler"/> whenever handicaps are recalculated.</summary>
  public static void OnChanged(Action handler) => ChangedHandlers.Add(handler);

  /// <summary>The handicap <paramref name="team"/> currently has, as a fraction, like 0.1 for 10%.</summary>
  public static float GetHandicap(Team? team) =>
    team != null && Handicaps.TryGetValue(team, out var handicap) ? handicap : 0;

  private static void Recalculate()
  {
    Handicaps.Clear();
    foreach (var team in FactionManager.GetAllTeams())
    {
      if (team.UndefeatedPlayerCount <= 0)
      {
        continue;
      }

      var behindBy = GetPlayersBehind(team);
      if (behindBy > 0)
      {
        Handicaps[team] = Math.Min(Maximum, behindBy * PerMissingPlayer);
      }
    }

    foreach (var handler in ChangedHandlers)
    {
      handler();
    }
  }

  /// <summary>How many players <paramref name="team"/> has fallen behind its rivals.</summary>
  private static int GetPlayersBehind(Team team)
  {
    var growth = GetGrowth(team);
    var hasRival = false;
    var behindBy = 0;
    foreach (var other in FactionManager.GetAllTeams())
    {
      if (other == team || other.UndefeatedPlayerCount <= 0 || AreRivals == null || !AreRivals(team, other))
      {
        continue;
      }

      hasRival = true;
      behindBy = Math.Max(behindBy, GetGrowth(other) - growth);
    }

    return hasRival ? behindBy : -growth;
  }

  private static int GetGrowth(Team team) => team.UndefeatedPlayerCount - GetStartingSize(team);

  private static int GetStartingSize(Team team) =>
    StartingSizes.TryGetValue(team, out var size) ? size : team.UndefeatedPlayerCount;

  private static void OnPlayerTakingDamage()
  {
    var source = @event.DamageSource;
    if (source == null || Handicaps.Count == 0)
    {
      return;
    }

    var attackerHandicap = GetHandicap(source.Owner.GetPlayerData().Team);
    var targetHandicap = GetHandicap(@event.Unit.Owner.GetPlayerData().Team);
    if (attackerHandicap == 0 && targetHandicap == 0)
    {
      return;
    }

    @event.Damage *= (1 + attackerHandicap) * (1 - targetHandicap);
  }
}
