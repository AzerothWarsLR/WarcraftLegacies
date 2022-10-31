using WarcraftLegacies.MacroTools.Cheats;
using WarcraftLegacies.Source.GameLogic;
using static War3Api.Common;

namespace WarcraftLegacies.Source.Cheats
{
  public static class CheatSkipCinematic
  {
    private static void Actions()
    {
      if (!TestSafety.CheatCondition()) return;
      CinematicMode.EndEarly();
      DestroyTrigger(GetTriggeringTrigger());
    }

    private static void DelayedSetup()
    {
      var trig = CreateTrigger();
      foreach (var player in WCSharp.Shared.Util.EnumeratePlayers())
      {
        TriggerRegisterPlayerEvent(trig, player, EVENT_PLAYER_END_CINEMATIC);
      }
      TriggerAddAction(trig, Actions);
    }

    public static void Setup()
    {
      var timer = CreateTimer();
      TimerStart(timer, 1, false, DelayedSetup);
    }
  }
}