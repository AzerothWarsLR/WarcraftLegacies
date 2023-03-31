using MacroTools.Timer;
using System;
using static War3Api.Common;

namespace MacroTools
{
  /// <summary>
  ///  Á Dialogue that counts the elapsed game time, displayed in number of turns passed.
  ///  One turn passes every 60 seconds.
  /// </summary>
  public class GameTime: ITimer
  {
    private const float TurnDuration = 60;

    /// <summary>
    /// How long after game start to actually show the timer.
    /// </summary>
    private const float TimerDelay = 2;

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

    /// <inheritdoc/>
    public EventHandler? OnTimerEnds { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public GameTime()
    {
      _gameTimer = CreateTimer();
      _turnTimer = CreateTimer();
      _turnTimerDialog = CreateTimerDialog(_turnTimer);
   
    }
    /// <inheritdoc/>
    public void StartTimer()
    {
      var trig = CreateTrigger();
      TriggerRegisterTimerEvent(trig, 0, false);
      TriggerAddAction(trig, Actions);

      trig = CreateTrigger();
      TriggerRegisterTimerEvent(trig, TimerDelay, false);
      TriggerAddAction(trig, ShowTimer); ;
    }
  
    /// <returns>The number of seconds that have elapsed since the start of the game</returns>
    public static float GetGameTime()
    {
      return _currentTime;
    }

    private void EndTurn()
    {
      _turnCount += 1;
      TimerDialogSetTitle(_turnTimerDialog, $"Turn {I2S(_turnCount)}");
      TurnEnded?.Invoke(null, EventArgs.Empty);
      OnTimerEnds?.Invoke(null, EventArgs.Empty);
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

    private void Actions()
    {
      TimerStart(_turnTimer, TurnDuration, true, EndTurn);
      TimerStart(_gameTimer, 1, true, GameTick);
    }
  }
}