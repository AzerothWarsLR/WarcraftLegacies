using AzerothWarsCSharp.Source.Cheats;
using AzerothWarsCSharp.Source.Libraries;
using AzerothWarsCSharp.Source.Libraries.MacroTools;

namespace AzerothWarsCSharp.Source.Game_Logic
{
  /// <summary>
  /// Removes players from the game if their slot is unoccupied.
  /// </summary>
  public static class CleanPersons
  {
    public static void Setup()
    {
      trigger trig = CreateTrigger();
      TriggerRegisterTimerEvent(trig, 2, false);
      TriggerAddAction(trig, () =>
      {
        if (TestSafety.AreCheatsActive)
        {
          return;
        }

        foreach (var player in GeneralHelpers.GetAllPlayers())
        {
          var person = Person.ByHandle(player);
          if (person != null && GetPlayerSlotState(player) != PLAYER_SLOT_STATE_PLAYING &&
              person.Faction.ScoreStatus == ScoreStatus.Undefeated)
          {
            person.Faction.ScoreStatus = ScoreStatus.Defeated;
          }
        }
      });
    }
  }
}