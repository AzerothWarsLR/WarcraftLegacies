using System;
using MacroTools.Cheats;
using WarcraftLegacies.Source.GameLogic;
using static War3Api.Common;

namespace WarcraftLegacies.Source.Cheats
{

  /// <summary>
  /// 
  /// </summary>
  public sealed class CheatSkipCinematic
  {
    private readonly CinematicMode _cinematicMode;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="cinematicMode"></param>
    public CheatSkipCinematic(CinematicMode cinematicMode)
    {
      _cinematicMode = cinematicMode;
    }

    private  void Actions()
    {
      if (!TestMode.CheatCondition()) return;
      try
      {
        _cinematicMode.EndEarly();
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

    private void DelayedSetup()
    {
      var trig = CreateTrigger();
      foreach (var player in WCSharp.Shared.Util.EnumeratePlayers())
        TriggerRegisterPlayerEvent(trig, player, EVENT_PLAYER_END_CINEMATIC);
      TriggerAddAction(trig, Actions);
    }

    /// <summary>
    /// 
    /// </summary>
    public void Init()
    {
      var timer = CreateTimer();
      TimerStart(timer, 1, false, DelayedSetup);
    }
  }
}