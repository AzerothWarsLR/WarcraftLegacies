library FilteredDeathEvents initializer OnInit requires PlayerUnitEventFilterManager

  globals
    private FilteredEventType FILTEREDEVENTTYPE_DIES
    private FilteredEventType FILTEREDEVENTTYPE_KILLS
  endglobals

  function RegisterUnitTypeDiesAction takes integer unitTypeId, code whichTriggerAction returns nothing
    call PlayerUnitEventAddFilteredAction(EVENT_PLAYER_UNIT_DEATH, whichTriggerAction, FILTEREDEVENTTYPE_DIES, unitTypeId)
  endfunction

  function RegisterUnitTypeKillsAction takes integer unitTypeId, code whichTriggerAction returns nothing
    call PlayerUnitEventAddFilteredAction(EVENT_PLAYER_UNIT_DEATH, whichTriggerAction, FILTEREDEVENTTYPE_KILLS, unitTypeId)
  endfunction

  private function OnAnyUnitDeath takes nothing returns nothing
    call PlayerUnitEventExecute(EVENT_PLAYER_UNIT_DEATH, FILTEREDEVENTTYPE_DIES, GetUnitTypeId(GetTriggerUnit()))
    call PlayerUnitEventExecute(EVENT_PLAYER_UNIT_DEATH, FILTEREDEVENTTYPE_KILLS, GetUnitTypeId(GetKillingUnit()))
  endfunction

  private function OnInit takes nothing returns nothing
    call PlayerUnitEventAddAction(EVENT_PLAYER_UNIT_DEATH, function OnAnyUnitDeath)
    set FILTEREDEVENTTYPE_DIES = FilteredEventType.create()
    set FILTEREDEVENTTYPE_KILLS = FilteredEventType.create()
  endfunction

endlibrary