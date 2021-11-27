library UnitWithFuelZeppelin requires AIDS, T32, Environment

  globals
    private constant integer UNIT_TYPE = 'h091'
    private constant integer TICK_RATE = 1
  endglobals

  private struct UnitWithFuelZeppelin extends array
    //! runtextmacro AIDS()
    private real tick

    private static method AIDS_filter takes unit u returns boolean
      if GetUnitTypeId(u) == UNIT_TYPE then
        return true
      endif
      return false
    endmethod

    private method AIDS_onCreate takes nothing returns nothing
      set tick = 0
      call this.startPeriodic()
    endmethod

    private method AIDS_onDestroy takes nothing returns nothing
      set this.tick = 0
      call this.stopPeriodic()
    endmethod

    private method unfreeze takes nothing returns nothing
      call PauseUnit(this.unit, false)
      call SetUnitTimeScalePercent( this.unit, 100.00 )
    endmethod

    private method freeze takes nothing returns nothing
      call KillUnit(this.unit)
    endmethod

  private method periodic takes nothing returns nothing
      set tick = tick + 1
      if tick == TICK_RATE * T32_FPS then
        if GetUnitState(this.unit, UNIT_STATE_MANA) < 1 then   
          call this.freeze()
        elseif GetUnitState(this.unit, UNIT_STATE_MANA) > 50 or not UnitAlive(this.unit) then  
          call this.unfreeze()
        endif
        set tick = 0
      endif
    endmethod

    implement T32x
  endstruct

endlibrary