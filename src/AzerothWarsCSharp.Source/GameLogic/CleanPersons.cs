using AzerothWarsCSharp.MacroTools.Cheats;
using AzerothWarsCSharp.MacroTools.FactionSystem;
using static War3Api.Common;
using static AzerothWarsCSharp.MacroTools.Libraries.GeneralHelpers;

namespace AzerothWarsCSharp.Source.GameLogic
{
  /// <summary>
  /// Responsible for ensuring that unoccupied player slots do not persist in the game.
  /// </summary>
  public static class CleanPersons
  {
    /// <summary>
    ///   After a short delay, removes players from the game if their slot is unoccupied.
    /// </summary>
    public static void Setup()
    {
      var trig = CreateTrigger();
      TriggerRegisterTimerEvent(trig, 2, false);
      TriggerAddAction(trig, () =>
      {
        if (TestSafety.AreCheatsActive) return;

        foreach (var player in GetAllPlayers())
        {
          var playerFaction = player.GetFaction();
          if (playerFaction == null) continue;
          if (GetPlayerSlotState(player) != PLAYER_SLOT_STATE_PLAYING &&
              playerFaction.ScoreStatus == ScoreStatus.Undefeated)
            playerFaction.ScoreStatus = ScoreStatus.Defeated;
        }
      });
    }
  }
}