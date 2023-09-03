using System;
using MacroTools.Extensions;
using MacroTools.FactionSystem;
using static War3Api.Common;

namespace WarcraftLegacies.Source.GameLogic.GameEnd
{
  /// <summary>
  /// When a player leaves the game, their <see cref="Faction"/> is defeated.
  /// </summary>
  public static class PlayerLeaves
  {
    private static void PlayerLeavesGame()
    {
      try
      {
        var triggerPlayer = GetTriggerPlayer();

        var playerFaction = triggerPlayer.GetFaction();
        DisplayTextToPlayer(GetLocalPlayer(), 0, 0,
          playerFaction != null
            ? $"{playerFaction.ColoredName} has left the game."
            : $"{GetPlayerName(triggerPlayer)} has left the game.");

        if (playerFaction != null && playerFaction.ScoreStatus != ScoreStatus.Defeated)
          playerFaction.Defeat();
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
      var trig = CreateTrigger();
      var i = 0;
      while (true)
      {
        if (i > 24) break;
        TriggerRegisterPlayerEvent(trig, Player(i), EVENT_PLAYER_LEAVE);
        i += 1;
      }

      TriggerAddAction(trig, PlayerLeavesGame);
    }
  }
}