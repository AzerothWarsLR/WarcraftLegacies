using System;
using System.Collections.Generic;
using MacroTools.Extensions;
using MacroTools.Factions;

namespace WarcraftLegacies.Source.Shared;

/// <summary>Calls back once any of a team's watched starting members leaves it or is defeated.</summary>
public sealed class TeamBreakWatch
{
  private readonly Team _team;
  private readonly Action _onBroken;
  private readonly HashSet<player> _members = new();
  private bool _broken;

  /// <summary>Watches the players of every faction on <paramref name="team"/> that <paramref name="isWatched"/> picks.</summary>
  public TeamBreakWatch(Team team, Func<Faction, bool> isWatched, Action onBroken)
  {
    _team = team;
    _onBroken = onBroken;
    foreach (var faction in FactionManager.GetAllFactions())
    {
      var factionPlayer = faction.Player;
      if (isWatched(faction) && factionPlayer != null && factionPlayer.GetPlayerData().Team == team)
      {
        _members.Add(factionPlayer);
        faction.ScoreStatusChanged += _ => Check();
      }
    }

    PlayerData.FactionChange += OnFactionChange;
    TeamChanges.OnAnyTeamChanged(Check);
  }

  private void OnFactionChange(PlayerFactionChangeEventArgs args)
  {
    if (!_members.Contains(args.Player))
    {
      return;
    }

    var newFaction = args.Player.GetPlayerData().Faction;
    if (newFaction != null)
    {
      newFaction.ScoreStatusChanged += _ => Check();
    }

    Check();
  }

  private void Check()
  {
    if (_broken)
    {
      return;
    }

    foreach (var member in _members)
    {
      var playerData = member.GetPlayerData();
      if (playerData.Faction == null || playerData.Faction.ScoreStatus == ScoreStatus.Defeated || playerData.Team != _team)
      {
        _broken = true;
        _onBroken();
        return;
      }
    }
  }
}
