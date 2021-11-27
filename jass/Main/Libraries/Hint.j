library Hint initializer OnInit requires Set, Display

  globals
    private constant real HINT_INTERVAL = 180
  endglobals

  struct Hint
    private static Set all
    private static Set unread
    private string msg

    method display takes nothing returns nothing
      call DisplayHint(GetLocalPlayer(), msg)
      call unread.remove(this)
    endmethod

    static method displayRandom takes nothing returns nothing
      if unread.size > 0 then
        call thistype(unread[GetRandomInt(0, unread.size-1)]).display()
      endif
    endmethod

    static method create takes string msg returns thistype
      local thistype this = thistype.allocate()
      set this.msg = msg
      call all.add(this)
      call unread.add(this)
      return this
    endmethod

    static method onInit takes nothing returns nothing
      set all = Set.create("Hint all")
      set unread = Set.create("Hint unread")
    endmethod

  endstruct

  private function DisplayRandomHints takes nothing returns nothing
    local integer i = 0
    loop
      exitwhen i == MAX_PLAYERS
      if GetLocalPlayer() == Player(i) then
        call Hint.displayRandom()
      endif
      set i = i + 1
    endloop
  endfunction

  private function OnInit takes nothing returns nothing
    local trigger trig = CreateTrigger()
    call TriggerRegisterTimerEventPeriodic(trig, HINT_INTERVAL)
    call TriggerAddAction(trig, function DisplayRandomHints)
  endfunction

endlibrary