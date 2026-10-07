using System;
using System.Collections.Generic;
using MacroTools.Extensions;
using MacroTools.Setup;
using WCSharp.Events;
using WCSharp.Shared;

namespace MacroTools.Factions;

/// <summary>
/// Gives teams that have shrunk below the size they started at a bonus to damage dealt and a reduction to damage
/// taken, so a team left short-handed by betrayals isn't simply overrun. Teams never get a handicap just for starting
/// small, since factions are balanced around their starting matchups. Teams in a <see cref="Bloc"/> are still judged on
/// their own, so one half of an alliance losing a player doesn't strengthen the other half.
/// </summary>
public static class TeamHandicaps
{
  private static readonly Dictionary<Team, int> StartingSizes = new();
  private static readonly Dictionary<Team, float> Handicaps = new();
  private static readonly List<Action> ChangedHandlers = new();

  /// <summary>How much each missing player is worth, as a fraction.</summary>
  public static float PerMissingPlayer { get; set; } = 0.05f;

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

  /// <summary>
  /// Gives a newly founded team the same starting size as the team its founder left, so leaving a big team alone
  /// counts as being short-handed.
  /// </summary>
  internal static void InheritStartingSize(Team newTeam, Team? formerTeam)
  {
    if (!IsEnabled || formerTeam == null || StartingSizes.ContainsKey(newTeam))
    {
      return;
    }

    StartingSizes[newTeam] = GetStartingSize(formerTeam);
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
      var missingPlayers = GetStartingSize(team) - team.UndefeatedPlayerCount;
      if (missingPlayers > 0)
      {
        Handicaps[team] = Math.Min(Maximum, missingPlayers * PerMissingPlayer);
      }
    }

    foreach (var handler in ChangedHandlers)
    {
      handler();
    }
  }

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
