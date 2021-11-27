library Plagueling initializer OnInit requires FilteredSellEvents

  globals
    private constant integer PLAGUELING_ID = 'n08G'
    private constant real DURATION = 15.
  endglobals

  private function OnSell takes nothing returns nothing
    call UnitApplyTimedLife(GetSoldUnit(), 0, DURATION)
    call SetUnitExploded(GetSoldUnit(), true)
  endfunction

  private function OnInit takes nothing returns nothing
    call RegisterUnitSoldUnitTypeAction(PLAGUELING_ID, function OnSell)
  endfunction

endlibrary