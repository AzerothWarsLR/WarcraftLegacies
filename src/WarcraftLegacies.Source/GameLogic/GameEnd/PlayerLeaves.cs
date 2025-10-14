using System;
using MacroTools.Extensions;
using MacroTools.FactionSystem;
using WCSharp.Shared;

namespace WarcraftLegacies.Source.GameLogic.GameEnd;

/// <summary>
/// When a player leaves the game, their <see cref="Faction"/> is defeated.
/// </summary>
public static class PlayerLeaves
{
  private static void PlayerLeavesGame()
  {
    try
    {
      var triggerPlayer = @event.Player;

      var playerFaction = triggerPlayer.GetPlayerData().Faction;

      foreach (var player in Util.EnumeratePlayers(playerslotstate.Playing, mapcontrol.User))
      {
        player.DisplayTextTo(playerFaction != null
            ? $"{playerFaction.ColoredName} has left the game."
            : $"{triggerPlayer.Name} has left the game.");
      }

      if (playerFaction != null && playerFaction.ScoreStatus != ScoreStatus.Defeated)
      {
        playerFaction.Defeat();
      }
    }
    catch (Exception ex)
    {
      Console.WriteLine($"Failed to execute {nameof(PlayerLeaves)}: {ex}");
    }
  }

  /// <summary>
  /// Sets up <see cref="PlayerLeaves"/>.
  /// </summary>
  public static void Setup()
  {
    trigger trigger = trigger.Create();
    foreach (var player in Util.EnumeratePlayers())
    {
      trigger.RegisterPlayerEvent(player, playerevent.Leave);
    }

    trigger.AddAction(PlayerLeavesGame);
  }
}
