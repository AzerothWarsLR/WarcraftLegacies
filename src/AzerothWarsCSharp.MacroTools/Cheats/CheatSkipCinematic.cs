using AzerothWarsCSharp.MacroTools.Libraries;
using static War3Api.Common; 

namespace AzerothWarsCSharp.MacroTools.Cheats
{
  public static class CheatSkipCinematic
  {
    private static void Actions()
    {
      if (!TestSafety.CheatCondition()) return;
      //CinematicModeBJ(false, GetPlayersAll()); Todo: put this back
      DestroyTrigger(GetTriggeringTrigger());
    }

    public static void Setup()
    {
      trigger trig = CreateTrigger();
      var i = 0;
      while (true)
      {
        if (i > Environment.MAX_PLAYERS) break;
        TriggerRegisterPlayerEvent(trig, Player(i), EVENT_PLAYER_END_CINEMATIC);
        i += 1;
      }

      TriggerAddAction(trig, Actions);
    }
  }
}