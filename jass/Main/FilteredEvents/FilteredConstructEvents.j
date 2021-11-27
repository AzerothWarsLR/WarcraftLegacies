library FilteredConstructEvents initializer OnInit requires PlayerUnitEventFilterManager

  globals
    private FilteredEventType FILTEREDEVENTTYPE_CONSTRUCTFINISH
    private FilteredEventType FILTEREDEVENTTYPE_CONSTRUCTSTART
    private FilteredEventType FILTEREDEVENTTYPE_CONSTRUCTCANCEL
  endglobals

  function RegisterConstructFinishedAction takes integer CONSTRUCTId, code whichTriggerAction returns nothing
    call PlayerUnitEventAddFilteredAction(EVENT_PLAYER_UNIT_CONSTRUCT_FINISH, whichTriggerAction, FILTEREDEVENTTYPE_CONSTRUCTFINISH, CONSTRUCTId)
  endfunction

  function RegisterConstructStartedAction takes integer CONSTRUCTId, code whichTriggerAction returns nothing
    call PlayerUnitEventAddFilteredAction(EVENT_PLAYER_UNIT_CONSTRUCT_START, whichTriggerAction, FILTEREDEVENTTYPE_CONSTRUCTSTART, CONSTRUCTId)
  endfunction

  function RegisterConstructCancelledAction takes integer CONSTRUCTId, code whichTriggerAction returns nothing
    call PlayerUnitEventAddFilteredAction(EVENT_PLAYER_UNIT_CONSTRUCT_CANCEL, whichTriggerAction, FILTEREDEVENTTYPE_CONSTRUCTCANCEL, CONSTRUCTId)
  endfunction

  private function OnAnyUnitFinishedConstruct takes nothing returns nothing
    call PlayerUnitEventExecute(EVENT_PLAYER_UNIT_CONSTRUCT_FINISH, FILTEREDEVENTTYPE_CONSTRUCTFINISH, GetUnitTypeId(GetTriggerUnit()))
  endfunction

  private function OnAnyUnitStartedConstruct takes nothing returns nothing
    call PlayerUnitEventExecute(EVENT_PLAYER_UNIT_CONSTRUCT_START, FILTEREDEVENTTYPE_CONSTRUCTSTART, GetUnitTypeId(GetTriggerUnit()))
  endfunction

  private function OnAnyUnitCancelledConstruct takes nothing returns nothing
    call PlayerUnitEventExecute(EVENT_PLAYER_UNIT_CONSTRUCT_CANCEL, FILTEREDEVENTTYPE_CONSTRUCTCANCEL, GetUnitTypeId(GetTriggerUnit()))
  endfunction

  private function OnInit takes nothing returns nothing
    call PlayerUnitEventAddAction(EVENT_PLAYER_UNIT_CONSTRUCT_FINISH, function OnAnyUnitFinishedConstruct)
    call PlayerUnitEventAddAction(EVENT_PLAYER_UNIT_CONSTRUCT_START, function OnAnyUnitStartedConstruct)
    call PlayerUnitEventAddAction(EVENT_PLAYER_UNIT_CONSTRUCT_CANCEL, function OnAnyUnitCancelledConstruct)
    set FILTEREDEVENTTYPE_CONSTRUCTFINISH = FilteredEventType.create()
    set FILTEREDEVENTTYPE_CONSTRUCTSTART = FilteredEventType.create()
    set FILTEREDEVENTTYPE_CONSTRUCTCANCEL = FilteredEventType.create()
  endfunction

endlibrary