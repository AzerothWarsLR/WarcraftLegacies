using System;
using MacroTools;
using MacroTools.Cheats;
using MacroTools.Extensions;
using WarcraftLegacies.Source.GameLogic;

namespace WarcraftLegacies.Source.Cheats
{
  public static class CheatSkipCinematic
  {
    private static trigger? _skipTrigger;

    public static void Init()
    {
      var timer = CreateTimer();
      TimerStart(timer, 1, false, DelayedSetup);
    }

    private static void Actions()
    {
      if (!TestMode.CheatCondition()) 
        return;

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
      _skipTrigger = CreateTrigger();
      foreach (var player in WCSharp.Shared.Util.EnumeratePlayers())
        TriggerRegisterPlayerEvent(_skipTrigger, player, EVENT_PLAYER_END_CINEMATIC);
      TriggerAddAction(_skipTrigger, Actions);

      GameTime.GameStarted += (_, _) => _skipTrigger?.Destroy();
    }
  }
}