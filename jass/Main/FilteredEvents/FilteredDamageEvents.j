library FilteredDamageEvents initializer OnInit requires PlayerUnitEventFilterManager

  globals
    private FilteredEventType FILTEREDEVENTTYPE_UNITTYPE_TAKESDAMAGE
    private FilteredEventType FILTEREDEVENTTYPE_UNITTYPE_INFLICTSDAMAGE
  endglobals

  function RegisterUnitTypeTakesDamageAction takes integer unitTypeId, code whichTriggerAction returns nothing
    call PlayerUnitEventAddFilteredAction(EVENT_PLAYER_UNIT_DAMAGED, whichTriggerAction, FILTEREDEVENTTYPE_UNITTYPE_TAKESDAMAGE, unitTypeId)
  endfunction

  function RegisterUnitTypeInflictsDamageAction takes integer unitTypeId, code whichTriggerAction returns nothing
    call PlayerUnitEventAddFilteredAction(EVENT_PLAYER_UNIT_DAMAGED, whichTriggerAction, FILTEREDEVENTTYPE_UNITTYPE_INFLICTSDAMAGE, unitTypeId)
  endfunction

  private function OnAnyUnitDamaged takes nothing returns nothing
    call PlayerUnitEventExecute(EVENT_PLAYER_UNIT_DAMAGED, FILTEREDEVENTTYPE_UNITTYPE_TAKESDAMAGE, GetUnitTypeId(GetTriggerUnit()))
    call PlayerUnitEventExecute(EVENT_PLAYER_UNIT_DAMAGED, FILTEREDEVENTTYPE_UNITTYPE_INFLICTSDAMAGE, GetUnitTypeId(GetEventDamageSource()))
  endfunction

  private function OnInit takes nothing returns nothing
    call PlayerUnitEventAddAction(EVENT_PLAYER_UNIT_DAMAGED, function OnAnyUnitDamaged)
    set FILTEREDEVENTTYPE_UNITTYPE_TAKESDAMAGE = FilteredEventType.create()
    set FILTEREDEVENTTYPE_UNITTYPE_INFLICTSDAMAGE = FilteredEventType.create()
  endfunction

endlibrary