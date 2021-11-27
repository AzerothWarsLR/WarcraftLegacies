//Allows exactly two Waygates to be built on the map. These Waygates can teleport units between themselves.
library BuildableWaygate initializer OnInit requires AIDS, FilteredConstructEvents, FilteredDeathEvents

  globals
    private constant integer WAYGATE_UNITTYPE = 'n0AO'
  endglobals

  private struct BuildableWaygate extends array
    //! runtextmacro AIDS()
    private static thistype waygateA = 0
    private static thistype waygateB = 0
    private boolean constructed

    method operator Constructed= takes boolean value returns nothing
      set this.constructed = value
      if waygateA.constructed == true and waygateB.constructed == true then
        call thistype.LinkWaygates()
      endif
    endmethod

    private static method UnlinkWaygates takes nothing returns nothing
      call WaygateActivate(waygateA.unit, false)
      call WaygateActivate(waygateB.unit, false)
    endmethod

    private static method LinkWaygates takes nothing returns nothing
      call WaygateSetDestination(waygateA.unit, GetUnitX(waygateB.unit), GetUnitY(waygateB.unit))
      call WaygateSetDestination(waygateB.unit, GetUnitX(waygateA.unit), GetUnitY(waygateA.unit))
      call WaygateActivate(waygateA.unit, true)
      call WaygateActivate(waygateB.unit, true)
    endmethod

    private static method AIDS_filter takes unit u returns boolean
      if GetUnitTypeId(u) == WAYGATE_UNITTYPE then
        return true
      endif
      return false
    endmethod

    private method AIDS_onCreate takes nothing returns nothing
      set this.constructed = false
      if waygateA == 0 then
        set waygateA = this
      elseif waygateB == 0 then
        set waygateB = this
      else
        call BJDebugMsg("ERROR: cannot have more than 2 BuildableWaygates on the map")
      endif
    endmethod

    private method AIDS_onDestroy takes nothing returns nothing
      if this == waygateA then
        set waygateA = 0
      elseif this == waygateB then
        set waygateB = 0
      endif
      call UnlinkWaygates()
    endmethod
  endstruct

  private function OnWaygateConstruct takes nothing returns nothing
    set BuildableWaygate(GetUnitId(GetTriggerUnit())).Constructed = true
  endfunction

  private function OnWaygateDeath takes nothing returns nothing
    call RemoveUnit(GetTriggerUnit())
  endfunction

  private function OnInit takes nothing returns nothing
    call RegisterConstructFinishedAction(WAYGATE_UNITTYPE, function OnWaygateConstruct)
    call RegisterUnitTypeDiesAction(WAYGATE_UNITTYPE, function OnWaygateDeath)
  endfunction

endlibrary