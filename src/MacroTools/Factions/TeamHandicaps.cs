using System;
using System.Collections.Generic;
using MacroTools.Extensions;
using MacroTools.Setup;
using WCSharp.Events;
using WCSharp.Shared;

namespace MacroTools.Factions;

/// <summary>Gives teams whose side of a <see cref="Front"/> has fallen behind more damage dealt and less damage taken.</summary>
public static class TeamHandicaps
{
  private static readonly List<Front> _fronts = new();
  private static readonly Dictionary<Team, float> _handicaps = new();
  private static readonly HashSet<Bloc> _pooledBlocs = new();
  private static readonly List<Action> _changedHandlers = new();

  /// <summary>How much each player a side has fallen behind by is worth, as a fraction.</summary>
  public static float PerMissingPlayer { get; set; } = 0.05f;

  /// <summary>The largest handicap a team can get, as a fraction.</summary>
  public static float Maximum { get; set; } = 0.25f;

  public static bool IsEnabled { get; private set; }

  /// <summary>Adds a front whose sides are compared from now on.</summary>
  public static void AddFront(Front front)
  {
    _fronts.Add(front);
    if (IsEnabled)
    {
      RememberStartingSides(front);
      Recalculate();
    }
  }

  /// <summary>Remembers how big every side is right now and starts applying handicaps from then on.</summary>
  public static void Enable()
  {
    if (IsEnabled)
    {
      return;
    }

    IsEnabled = true;
    foreach (var front in _fronts)
    {
      RememberStartingSides(front);
    }

    foreach (var whichPlayer in Util.EnumeratePlayers())
    {
      PlayerUnitEvents.Register(CustomPlayerUnitEvents.PlayerTakingDamage, OnPlayerTakingDamage, whichPlayer.Id);
    }

    foreach (var faction in FactionManager.GetAllFactions())
    {
      faction.ScoreStatusChanged += _ => Recalculate();
    }

    FactionManager.FactionRegistered += faction =>
    {
      faction.ScoreStatusChanged += _ => Recalculate();
      Recalculate();
    };
    TeamChanges.OnAnyTeamChanged(Recalculate);
    Recalculate();
  }

  /// <summary>Works handicaps out again after a faction changed sides without changing team.</summary>
  public static void Refresh()
  {
    if (IsEnabled)
    {
      Recalculate();
    }
  }

  /// <summary>Runs <paramref name="handler"/> whenever handicaps are recalculated.</summary>
  /// <summary>Judges every team in <paramref name="bloc"/> together, so they share one handicap.</summary>
  public static void Pool(Bloc bloc)
  {
    _pooledBlocs.Add(bloc);
    Refresh();
  }

  public static void OnChanged(Action handler) => _changedHandlers.Add(handler);

  /// <summary>The handicap <paramref name="team"/> currently has, as a fraction, like 0.1 for 10%.</summary>
  public static float GetHandicap(Team? team) =>
    team != null && _handicaps.TryGetValue(team, out var handicap) ? handicap : 0;

  private static void RememberStartingSides(Front front)
  {
    front.StartingAttackers = CountSide(front.Attacks);
    front.StartingDefenders = CountSide(front.Defends);
  }

  private static void Recalculate()
  {
    _handicaps.Clear();
    var attackerGrowths = new List<int>();
    var defenderGrowths = new List<int>();
    foreach (var front in _fronts)
    {
      attackerGrowths.Add(CountSide(front.Attacks) - front.StartingAttackers);
      defenderGrowths.Add(CountSide(front.Defends) - front.StartingDefenders);
    }

    foreach (var team in FactionManager.GetAllTeams())
    {
      if (team.UndefeatedPlayerCount <= 0)
      {
        continue;
      }

      var behindBy = 0;
      for (var i = 0; i < _fronts.Count; i++)
      {
        if (IsGroupOnSide(team, _fronts[i].Attacks))
        {
          behindBy = Math.Max(behindBy, defenderGrowths[i] - attackerGrowths[i]);
        }

        if (IsGroupOnSide(team, _fronts[i].Defends))
        {
          behindBy = Math.Max(behindBy, attackerGrowths[i] - defenderGrowths[i]);
        }
      }

      if (behindBy > 0)
      {
        _handicaps[team] = Math.Min(Maximum, behindBy * PerMissingPlayer);
      }
    }

    foreach (var handler in _changedHandlers)
    {
      handler();
    }
  }

  /// <summary>How many undefeated factions are on a side. Factions on no front count with their teammates.</summary>
  private static int CountSide(Func<Faction, bool> side)
  {
    var count = 0;
    foreach (var team in FactionManager.GetAllTeams())
    {
      var teamIsOnSide = IsOnSide(team, side);
      foreach (var faction in team.GetAllFactions())
      {
        if (IsUndefeated(faction) && (side(faction) || (teamIsOnSide && !IsOnAnyFront(faction))))
        {
          count++;
        }
      }
    }

    return count;
  }

  /// <summary>Whether <paramref name="team"/>, or any team pooled with it, is on <paramref name="side"/>.</summary>
  private static bool IsGroupOnSide(Team team, Func<Faction, bool> side)
  {
    var bloc = team.Bloc;
    if (bloc == null || !_pooledBlocs.Contains(bloc))
    {
      return IsOnSide(team, side);
    }

    foreach (var blocTeam in bloc.Teams)
    {
      if (IsOnSide(blocTeam, side))
      {
        return true;
      }
    }

    return false;
  }

  private static bool IsOnSide(Team team, Func<Faction, bool> side)
  {
    foreach (var faction in team.GetAllFactions())
    {
      if (IsUndefeated(faction) && side(faction))
      {
        return true;
      }
    }

    return false;
  }

  private static bool IsOnAnyFront(Faction faction)
  {
    foreach (var front in _fronts)
    {
      if (front.Attacks(faction) || front.Defends(faction))
      {
        return true;
      }
    }

    return false;
  }

  private static bool IsUndefeated(Faction faction) => faction.ScoreStatus != ScoreStatus.Defeated;

  private static void OnPlayerTakingDamage()
  {
    var source = @event.DamageSource;
    if (source == null || _handicaps.Count == 0)
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
