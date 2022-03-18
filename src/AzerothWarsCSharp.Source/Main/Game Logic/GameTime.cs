namespace AzerothWarsCSharp.Source.Main.Game_Logic
{
  public static class GameTime
  {
    private const float TURN_DURATION = 60;

    private const float TIMER_DELAY = 6; //How long after game start to actually show the timer.

    //This must be after the Multiboard is shown or the Multiboard will break
    private static timer? _gameTimer;
    private static timer? _turnTimer;
    private static timerdialog? _turnTimerDialog;
    private static int _turnCount;

    private static float _currentTime;


    //Returns the number of seconds that have elapsed since the start of the game
    public static float GetGameTime()
    {
      return _currentTime;
    }

    private static void EndTurn()
    {
      _turnCount += 1;
      TimerDialogSetTitle(_turnTimerDialog, "Turn " + I2S(_turnCount));
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
      TimerStart(_turnTimer, TURN_DURATION, true, EndTurn);
      _gameTimer = CreateTimer();
      TimerStart(_gameTimer, 1, true, GameTick);
    }

    public static void Setup()
    {
      trigger trig = CreateTrigger();
      TriggerRegisterTimerEvent(trig, 0, false);
      TriggerAddAction(trig, Actions);

      trig = CreateTrigger();
      TriggerRegisterTimerEvent(trig, TIMER_DELAY, false);
      TriggerAddAction(trig, ShowTimer);
    }
  }
}