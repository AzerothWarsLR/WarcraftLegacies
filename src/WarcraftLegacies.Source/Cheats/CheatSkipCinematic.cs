using System;
using MacroTools;
using MacroTools.Cheats;
using WarcraftLegacies.Source.GameLogic;

namespace WarcraftLegacies.Source.Cheats
{
  public static class CheatSkipCinematic
  {
    public static void Init()
    {
      var timer = CreateTimer();
      TimerStart(timer, 1, false, DelayedSetup);
    }

    private static void Actions()
    {
      if (!TestMode.CheatCondition()) return;
      try
      {
        CinematicMode.EndEarly();
        GameTime.SkipTurns(1);
      }
      catch (Exception ex)
      {
        Console.WriteLine($"Failed to execute {nameof(CheatSkipCinematic)}: {ex}");
      }
      finally
      {
        DestroyTrigger(GetTriggeringTrigger());
      }
    }

    private static void DelayedSetup()
    {
      var trig = CreateTrigger();
      foreach (var player in WCSharp.Shared.Util.EnumeratePlayers())
        TriggerRegisterPlayerEvent(trig, player, EVENT_PLAYER_END_CINEMATIC);
      TriggerAddAction(trig, Actions);
    }
  }
}