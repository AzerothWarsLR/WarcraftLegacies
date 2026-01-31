using MacroTools.Commands;
using MacroTools.Extensions;
using MacroTools.Factions;
using WCSharp.Shared;

namespace WarcraftLegacies.Source.GameLogic;

/// <summary>
/// Responsible for ensuring that unoccupied player slots do not persist in the game.
/// </summary>
public static class CleanupUnoccupiedPlayerSlots
{
  /// <summary>
  ///   After a short delay, removes players from the game if their slot is unoccupied.
  /// </summary>
  public static void Setup()
  {
    var trig = trigger.Create();
    trig.RegisterTimerEvent(2, false);
    trig.AddAction(() =>
    {
      if (TestMode.AreCheatsActive)
      {
        return;
      }

      foreach (var player in Util.EnumeratePlayers())
      {
        var playerFaction = player.GetPlayerData().Faction;
        if (playerFaction == null)
        {
          continue;
        }

        if (player.SlotState != playerslotstate.Playing && playerFaction.ScoreStatus == ScoreStatus.Undefeated)
        {
          playerFaction.Defeat();
        }
      }
    });
  }
}
