public class GameTimer{

  
    private const float TURN_DURATION = 60;
    private const float TIMER_DELAY = 6      ;//How long after game start to actually show the timer.
                                                //This must be after the Multiboard is shown or the Multiboard will break
    private timer GameTimer = null;
    private timer TurnTimer = null;
    private timerdialog TurnTimerDialog = null;
    private int TurnCount = 0;

    private float GameTime = 0;
  

  //Returns the number of seconds that have elapsed since the start of the game
  static float GetGameTime( ){
    return GameTime;
  }

  private static void EndTurn( ){
    TurnCount = TurnCount + 1;
    TimerDialogSetTitle(TurnTimerDialog, "Turn " + I2S(TurnCount));
  }

  private static void GameTick( ){
    GameTime = GameTime + 1;
  }

  private static void ShowTimer( ){
    TimerDialogDisplay(TurnTimerDialog, true);
    TimerDialogSetTitle(TurnTimerDialog, "Game starts in:");
  }

  private static void Actions( ){
    TurnTimer = CreateTimer();
    TurnTimerDialog = CreateTimerDialog(TurnTimer);
    TimerStart(TurnTimer, TURN_DURATION, true,  EndTurn);
    GameTimer = CreateTimer();
    TimerStart(GameTimer, 1, true,  GameTick);
  }

  private static void OnInit( ){
    trigger trig = CreateTrigger();
    TriggerRegisterTimerEvent(trig, 0, false);
    TriggerAddCondition(trig, ( Actions));

    trig = CreateTrigger();
    TriggerRegisterTimerEvent(trig, TIMER_DELAY, false);
    TriggerAddCondition(trig, ( ShowTimer));
  }

}
