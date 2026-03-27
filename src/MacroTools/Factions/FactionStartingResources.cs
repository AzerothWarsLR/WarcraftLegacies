using System;
using MacroTools.Extensions;
using MacroTools.GameTime;

namespace MacroTools.Factions;

/// <summary>
/// Responsible for providing players with a faction's starting resources.
/// </summary>
public static class FactionStartingResources
{
  /// <summary>
  /// After a player is assigned a faction, they are given the faction's starting resources.
  /// </summary>
  public static void MainSetup()
  {
    FactionManager.FactionRegistered += faction =>
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
    };
  }
}
