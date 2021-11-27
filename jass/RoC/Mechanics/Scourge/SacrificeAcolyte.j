library SacrificeAcolyte initializer OnInit requires FilteredSellEvents

  globals
    private constant integer ACOLYTE_ID = 'uaco'
  endglobals

  private function OnSell takes nothing returns nothing
    call KillUnit(GetTriggerUnit())
    call BlzSetUnitFacingEx(GetSoldUnit(), GetUnitFacing(GetTriggerUnit()))
    if GetLocalPlayer() == GetOwningPlayer(GetSoldUnit()) then
      call SelectUnit(GetSoldUnit(), true)
    endif
  endfunction

  private function OnInit takes nothing returns nothing
    call RegisterUnitTypeSoldUnitAction(ACOLYTE_ID, function OnSell)
  endfunction

endlibrary