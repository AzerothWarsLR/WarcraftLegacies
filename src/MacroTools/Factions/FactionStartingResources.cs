using System;
using System.Collections.Generic;
using MacroTools.Extensions;
using MacroTools.GameTime;

namespace MacroTools.Factions;

/// <summary>
/// Responsible for providing players with a faction's starting resources.
/// </summary>
public static class FactionStartingResources
{
  private static readonly List<Faction> _pendingFactions = new();
  private static bool _pendingGrantDone;

  public static void Setup()
  {
    FactionManager.FactionRegistered += faction =>
    {
      if (_pendingGrantDone)
      {
        Grant(faction);
      }
      else
      {
        _pendingFactions.Add(faction);
      }
    };
  }

  public static void GrantPending()
  {
    foreach (var faction in _pendingFactions)
    {
      Grant(faction);
    }

    _pendingFactions.Clear();
    _pendingGrantDone = true;
  }

  private static void Grant(Faction faction)
  {
    var startingGold = faction.StartingGold;
    if (startingGold == null)
    {
      return;
    }

    var player = faction.Player;
    if (player == null)
    {
      throw new InvalidOperationException($"Faction '{faction.Name}' registered without an associated player.");
    }

    var currentTurn = GameTimeManager.Turn;
    if (currentTurn == 0)
    {
      player.HeroTokens = 1;
    }

    player.Gold += startingGold.Instant;

    var income = startingGold.Income;
    if (income <= 0)
    {
      return;
    }

    var playerData = player.GetPlayerData();
    playerData.BonusIncome += income;

    var turns = startingGold.Turns;
    if (turns <= 0)
    {
      return;
    }

    GameTimeManager.RegisterOnTurn(currentTurn + turns + 1, () =>
    {
      playerData.BonusIncome -= income;
    });
  }
}
