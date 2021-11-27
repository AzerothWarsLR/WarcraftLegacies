library FilteredResearchEvents initializer OnInit requires PlayerUnitEventFilterManager

  globals
    private FilteredEventType FILTEREDEVENTTYPE_RESEARCHFINISH
    private FilteredEventType FILTEREDEVENTTYPE_RESEARCHSTART
    private FilteredEventType FILTEREDEVENTTYPE_RESEARCHCANCEL
  endglobals

  function RegisterResearchFinishedAction takes integer researchId, code whichTriggerAction returns nothing
    call PlayerUnitEventAddFilteredAction(EVENT_PLAYER_UNIT_RESEARCH_FINISH, whichTriggerAction, FILTEREDEVENTTYPE_RESEARCHFINISH, researchId)
  endfunction

  function RegisterResearchStartedAction takes integer researchId, code whichTriggerAction returns nothing
    call PlayerUnitEventAddFilteredAction(EVENT_PLAYER_UNIT_RESEARCH_START, whichTriggerAction, FILTEREDEVENTTYPE_RESEARCHSTART, researchId)
  endfunction

  function RegisterResearchCancelledAction takes integer researchId, code whichTriggerAction returns nothing
    call PlayerUnitEventAddFilteredAction(EVENT_PLAYER_UNIT_RESEARCH_CANCEL, whichTriggerAction, FILTEREDEVENTTYPE_RESEARCHCANCEL, researchId)
  endfunction

  private function OnAnyUnitFinishedResearch takes nothing returns nothing
    call PlayerUnitEventExecute(EVENT_PLAYER_UNIT_RESEARCH_FINISH, FILTEREDEVENTTYPE_RESEARCHFINISH, GetResearched())
  endfunction

  private function OnAnyUnitStartedResearch takes nothing returns nothing
    call PlayerUnitEventExecute(EVENT_PLAYER_UNIT_RESEARCH_START, FILTEREDEVENTTYPE_RESEARCHSTART, GetResearched())
  endfunction

  private function OnAnyUnitCancelledResearch takes nothing returns nothing
    call PlayerUnitEventExecute(EVENT_PLAYER_UNIT_RESEARCH_CANCEL, FILTEREDEVENTTYPE_RESEARCHCANCEL, GetResearched())
  endfunction

  private function OnInit takes nothing returns nothing
    call PlayerUnitEventAddAction(EVENT_PLAYER_UNIT_RESEARCH_FINISH, function OnAnyUnitFinishedResearch)
    call PlayerUnitEventAddAction(EVENT_PLAYER_UNIT_RESEARCH_START, function OnAnyUnitStartedResearch)
    call PlayerUnitEventAddAction(EVENT_PLAYER_UNIT_RESEARCH_CANCEL, function OnAnyUnitCancelledResearch)
    set FILTEREDEVENTTYPE_RESEARCHFINISH = FilteredEventType.create()
    set FILTEREDEVENTTYPE_RESEARCHSTART = FilteredEventType.create()
    set FILTEREDEVENTTYPE_RESEARCHCANCEL = FilteredEventType.create()
  endfunction

endlibrary