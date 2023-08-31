using MacroTools.Timer;
using System;
using MacroTools.Extensions;
using MacroTools.FactionSystem;
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
    private static timer? _initialTimer;
    private static timerdialog? _turnTimerDialog;
    private static timerdialog? _initialTimerDialog;
    private static int _turnCount;
    private static float _currentTime;
    private static float _introSeconds;

    /// <summary>
    /// Fired when a turn ends.
    /// </summary>
    public static event EventHandler? TurnEnded;

    /// <inheritdoc/>
    public EventHandler? OnTimerEnds { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public GameTime(int introSeconds)
    {
      _gameTimer = CreateTimer();
      _turnTimer = CreateTimer();
      _initialTimer = CreateTimer();
      _turnTimerDialog = CreateTimerDialog(_turnTimer);
      _initialTimerDialog = CreateTimerDialog(_initialTimer);
      _introSeconds = introSeconds;
   
    }
    /// <inheritdoc/>
    public void StartTimer()
    {
      var trig = CreateTrigger();
      TriggerRegisterTimerEvent(trig, 0, false);
      TriggerAddAction(trig, TimeTick);

      // Display a intro timer.
      trig = CreateTrigger();
      TriggerRegisterTimerEvent(trig, TimerDelay, false);
      TriggerAddAction(trig, ShowIntroTimer);

      // Start the turns after waiting for the initial delay.
      trig = CreateTrigger();
      TriggerRegisterTimerEvent(trig, _introSeconds + TimerDelay, false);
      TriggerAddAction(trig, TurnTick);
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
      if (_turnCount >= 20)
      {
        foreach (var player in WCSharp.Shared.Util.EnumeratePlayers(PLAYER_SLOT_STATE_PLAYING,MAP_CONTROL_USER))
        {
          var faction = player.GetFaction();
          var meetEliminationThreshold = player.GetControlPoints().Count <= 5 && player.GetFoodUsed() <= 105 && !player.GetTeam()!.DoesTeamHaveEssentialLegend();
          if (meetEliminationThreshold)
          {
            if (PlayerData.ByHandle(player).EliminationTurns >= 3)
            {
              if (faction != null)
                faction.ScoreStatus = ScoreStatus.Defeated;
            }
            else
            {
              DisplayTextToPlayer(player, 0, 0,
                PlayerData.ByHandle(player).EliminationTurns == 2
                  ? $"You have met the threshold for being eliminated from the game. Unless you increase your cp count to above 5, raise food used above 105 or your team retake/gain an essential Legend you will be defeated in {3 - PlayerData.ByHandle(player).EliminationTurns} turn."
                  : $"You have met the threshold for being eliminated from the game. Unless you increase your cp count to above 5, raise food used above 105 or your team retake/gain an essential Legend you will be defeated in {3 - PlayerData.ByHandle(player).EliminationTurns} turns.");
            }
            PlayerData.ByHandle(player).EliminationTurns++;
          }
          else
          {
            PlayerData.ByHandle(player).EliminationTurns = 0;
          }
        }
      }
      TurnEnded?.Invoke(null, EventArgs.Empty);
      OnTimerEnds?.Invoke(null, EventArgs.Empty);
    }

    private static void GameTick()
    {
      _currentTime += 1;
    }

    /// <summary>
    /// Start the game: destroys the intro timers, and starts the first turn.
    /// </summary>
    private void GameStart()
    {
      DestroyTimerDialog(_initialTimerDialog);
      DestroyTimer(_initialTimer);
      TimerDialogDisplay(_turnTimerDialog, true);
      EndTurn();
    }

    private void ShowIntroTimer()
    {
      TimerStart(_initialTimer, _introSeconds, false, GameStart); // Start the intro timer
      TimerDialogDisplay(_initialTimerDialog, true);
      TimerDialogSetTitle(_initialTimerDialog, "Game starts in:");
    }

    private void TurnTick()
    {
      TimerStart(_turnTimer, TurnDuration, true, EndTurn);
    }

    private void TimeTick()
    {
      TimerStart(_gameTimer, 1, true, GameTick); 
    }
  }
}