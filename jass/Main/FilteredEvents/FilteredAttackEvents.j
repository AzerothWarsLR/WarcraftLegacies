library FilteredAttackEvents initializer OnInit requires PlayerUnitEventFilterManager

  globals
    private FilteredEventType FILTEREDEVENTTYPE_UNITTYPEATTACKED
    private FilteredEventType FILTEREDEVENTTYPE_UNITTYPEATTACKS
  endglobals

  function RegisterUnitTypeAttackedAction takes integer unitTypeId, code whichTriggerAction returns nothing
    call PlayerUnitEventAddFilteredAction(EVENT_PLAYER_UNIT_ATTACKED, whichTriggerAction, FILTEREDEVENTTYPE_UNITTYPEATTACKED, unitTypeId)
  endfunction

  function RegisterUnitTypeAttacksAction takes integer unitTypeId, code whichTriggerAction returns nothing
    call PlayerUnitEventAddFilteredAction(EVENT_PLAYER_UNIT_ATTACKED, whichTriggerAction, FILTEREDEVENTTYPE_UNITTYPEATTACKS, unitTypeId)
  endfunction

  private function OnAnyUnitAttacked takes nothing returns nothing
    call PlayerUnitEventExecute(EVENT_PLAYER_UNIT_ATTACKED, FILTEREDEVENTTYPE_UNITTYPEATTACKED, GetUnitTypeId(GetTriggerUnit()))
    call PlayerUnitEventExecute(EVENT_PLAYER_UNIT_ATTACKED, FILTEREDEVENTTYPE_UNITTYPEATTACKS, GetUnitTypeId(GetAttacker()))
  endfunction

  private function OnInit takes nothing returns nothing
    call PlayerUnitEventAddAction(EVENT_PLAYER_UNIT_ATTACKED, function OnAnyUnitAttacked)
    set FILTEREDEVENTTYPE_UNITTYPEATTACKED = FilteredEventType.create()
    set FILTEREDEVENTTYPE_UNITTYPEATTACKS = FilteredEventType.create()
  endfunction

endlibrary