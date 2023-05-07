using System;
using DesyncSafeAnalyzer.Attributes;
using static War3Api.Common;

namespace MacroTools
{
  public static class GameTime
  {
    private const float TurnDuration = 60;

    /// <summary>
    /// How long after game start to actually show the timer.
    /// </summary>
    private const float TimerDelay = 6; 

    //This must be after the Multiboard is shown or the Multiboard will break
    private static timer? _gameTimer;
    private static timer? _turnTimer;
    private static timerdialog? _turnTimerDialog;
    private static int _turnCount;
    private static float _currentTime;


    /// <summary>
    /// Fired when a turn ends.
    /// </summary>
    public static event EventHandler? TurnEnded;

    //Returns the number of seconds that have elapsed since the start of the game
    public static float GetGameTime()
    {
      return _currentTime;
    }
    
    private static void EndTurn()
    {
      _turnCount += 1;
      TimerDialogSetTitle(_turnTimerDialog, $"Turn {I2S(_turnCount)}");
      TurnEnded?.Invoke(null, EventArgs.Empty);
    }

    private static void GameTick()
    {
      _currentTime += 1;
    }

    private static void ShowTimer()
    {
      TimerDialogDisplay(_turnTimerDialog, true);
      TimerDialogSetTitle(_turnTimerDialog, "Game starts in:");
    }

    private static void Actions()
    {
      _turnTimer = CreateTimer();
      _turnTimerDialog = CreateTimerDialog(_turnTimer);
      TimerStart(_turnTimer, TurnDuration, true, EndTurn);
      _gameTimer = CreateTimer();
      TimerStart(_gameTimer, 1, true, GameTick);
    }

    public static void Setup()
    {
      var trig = CreateTrigger();
      TriggerRegisterTimerEvent(trig, 0, false);
      TriggerAddAction(trig, Actions);

      trig = CreateTrigger();
      TriggerRegisterTimerEvent(trig, TimerDelay, false);
      TriggerAddAction(trig, ShowTimer);
    }
  }
}