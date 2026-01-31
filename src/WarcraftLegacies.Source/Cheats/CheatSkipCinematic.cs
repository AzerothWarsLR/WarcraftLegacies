using System;
using MacroTools.Cinematics;
using MacroTools.Commands;
using MacroTools.GameTime;
using WCSharp.Shared;

namespace WarcraftLegacies.Source.Cheats;

public static class CheatSkipCinematic
{
  private static trigger? _skipTrigger;

  public static void Init()
  {
    timer timer = timer.Create();
    timer.Start(1, false, DelayedSetup);
  }

  private static void Actions()
  {
    if (!TestMode.CheatCondition(@event.Player))
    {
      return;
    }

    try
    {
      CinematicMode.EndEarly();
      GameTimeManager.SkipTurns(1);
    }
    catch (Exception ex)
    {
      Console.WriteLine($"Failed to execute {nameof(CheatSkipCinematic)}: {ex}");
    }
    finally
    {
      @event.Trigger.Dispose();
    }
  }

  private static void DelayedSetup()
  {
    _skipTrigger = trigger.Create();
    foreach (var player in Util.EnumeratePlayers())
    {
      _skipTrigger.RegisterPlayerEvent(player, playerevent.EndCinematic);
    }

    _skipTrigger.AddAction(Actions);

    GameTimeManager.GameStarted += (_, _) =>
    {
      if (_skipTrigger != null)
      {
        _skipTrigger.Dispose();
      }
    };
  }
}
