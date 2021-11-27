library GameTimer initializer OnInit

  globals
    private constant real TURN_DURATION = 60.
    private constant real TIMER_DELAY = 6.      //How long after game start to actually show the timer. 
                                                //This must be after the Multiboard is shown or the Multiboard will break
    private timer GameTimer = null
    private timer TurnTimer = null
    private timerdialog TurnTimerDialog = null
    private integer TurnCount = 0

    private real GameTime = 0
  endglobals

  //Returns the number of seconds that have elapsed since the start of the game  
  function GetGameTime takes nothing returns real
    return GameTime
  endfunction

  private function EndTurn takes nothing returns nothing
    set TurnCount = TurnCount + 1
    call TimerDialogSetTitle(TurnTimerDialog, "Turn " + I2S(TurnCount))
  endfunction

  private function GameTick takes nothing returns nothing
    set GameTime = GameTime + 1
  endfunction

  private function ShowTimer takes nothing returns nothing
    call TimerDialogDisplay(TurnTimerDialog, true)
    call TimerDialogSetTitle(TurnTimerDialog, "Game starts in:")    
  endfunction

  private function Actions takes nothing returns nothing
    set TurnTimer = CreateTimer()
    set TurnTimerDialog = CreateTimerDialog(TurnTimer)
    call TimerStart(TurnTimer, TURN_DURATION, true, function EndTurn)
    set GameTimer = CreateTimer()
    call TimerStart(GameTimer, 1, true, function GameTick)
  endfunction

  private function OnInit takes nothing returns nothing
    local trigger trig = CreateTrigger()
    call TriggerRegisterTimerEvent(trig, 0, false)
    call TriggerAddCondition(trig, Condition(function Actions))  
    
    set trig = CreateTrigger()
    call TriggerRegisterTimerEvent(trig, TIMER_DELAY, false)
    call TriggerAddCondition(trig, Condition(function ShowTimer))  
  endfunction

endlibrary
