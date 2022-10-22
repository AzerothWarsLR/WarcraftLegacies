using AzerothWarsCSharp.MacroTools.Cheats;
using AzerothWarsCSharp.MacroTools.FactionSystem;
using static War3Api.Common;
using static AzerothWarsCSharp.MacroTools.Libraries.GeneralHelpers;

namespace AzerothWarsCSharp.Source.GameLogic
{
  /// <summary>
  ///   Removes players from the game if their slot is unoccupied.
  /// </summary>
  public static class CleanPersons
  {
    public static void Setup()
    {
      trigger trig = CreateTrigger();
      TriggerRegisterTimerEvent(trig, 2, false);
      TriggerAddAction(trig, () =>
      {
        if (TestSafety.AreCheatsActive) return;

        foreach (var player in GetAllPlayers())
          if (GetPlayerSlotState(player) != PLAYER_SLOT_STATE_PLAYING &&
              player.GetFaction().ScoreStatus == ScoreStatus.Undefeated)
            player.GetFaction().ScoreStatus = ScoreStatus.Defeated;
      });
    }
  }
}