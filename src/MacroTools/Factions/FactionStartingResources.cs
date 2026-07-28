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

  /// <summary>
  /// Registers this system, but doesn't grant anything yet for factions that register before
  /// <see cref="GrantPending"/> is called - see that method for why. Any faction that registers afterwards
  /// (e.g. a faction unlocked mid-game by a quest) is granted its resources immediately instead, same as always.
  /// </summary>
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

  /// <summary>
  /// Grants starting resources to every faction that registered before the game-start vote sequence concluded.
  /// Deferred this late (rather than granting each faction the instant it registers, like before) so a
  /// difficulty setting has a chance to adjust a faction's <see cref="StartingGold"/> - e.g. Hard mode
  /// shortening Scourge's income window - before the grant actually happens, instead of having to claw back
  /// gold that was already handed out.
  /// </summary>
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

    // Apply the income bonus permanently when no turns are specified
    var turns = startingGold.Turns;
    if (turns <= 0)
    {
      return;
    }

    // Apply the income bonus temporarily for the specified number of turns
    GameTimeManager.RegisterOnTurn(currentTurn + turns + 1, () =>
    {
      playerData.BonusIncome -= income;
    });
  }
}
