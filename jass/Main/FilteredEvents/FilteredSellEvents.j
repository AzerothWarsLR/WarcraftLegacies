library FilteredSellEvents initializer OnInit requires PlayerUnitEventFilterManager

  globals
    private FilteredEventType FILTEREDEVENTTYPE_UNIT_SELLS_UNITTYPE //Any unit sells a specific unit type
    private FilteredEventType FILTEREDEVENTTYPE_UNITTYPE_SELLS_UNIT //A specific unit type sells any unit
  endglobals

  function RegisterUnitSoldUnitTypeAction takes integer unitId, code whichTriggerAction returns nothing
    call PlayerUnitEventAddFilteredAction(EVENT_PLAYER_UNIT_SELL, whichTriggerAction, FILTEREDEVENTTYPE_UNIT_SELLS_UNITTYPE, unitId)
  endfunction

  function RegisterUnitTypeSoldUnitAction takes integer unitId, code whichTriggerAction returns nothing
    call PlayerUnitEventAddFilteredAction(EVENT_PLAYER_UNIT_SELL, whichTriggerAction, FILTEREDEVENTTYPE_UNITTYPE_SELLS_UNIT, unitId)
  endfunction

  private function OnAnyUnitSold takes nothing returns nothing
    call PlayerUnitEventExecute(EVENT_PLAYER_UNIT_SELL, FILTEREDEVENTTYPE_UNIT_SELLS_UNITTYPE, GetUnitTypeId(GetSoldUnit()))
    call PlayerUnitEventExecute(EVENT_PLAYER_UNIT_SELL, FILTEREDEVENTTYPE_UNITTYPE_SELLS_UNIT, GetUnitTypeId(GetTriggerUnit()))
  endfunction

  private function OnInit takes nothing returns nothing
    call PlayerUnitEventAddAction(EVENT_PLAYER_UNIT_SELL, function OnAnyUnitSold)
    set FILTEREDEVENTTYPE_UNIT_SELLS_UNITTYPE = FilteredEventType.create()
    set FILTEREDEVENTTYPE_UNITTYPE_SELLS_UNIT = FilteredEventType.create()
  endfunction

endlibrary