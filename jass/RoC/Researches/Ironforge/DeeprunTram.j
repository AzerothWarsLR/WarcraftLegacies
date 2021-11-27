library DeeprunTram initializer OnInit requires Persons, Faction, IronforgeSetup, StormwindSetup, FilteredResearchEvents

  globals
    private constant integer RESEARCH_ID = 'R014'
  endglobals

  private function Transfer takes nothing returns nothing
    local unit ironforgeTram = gg_unit_n03B_0010
    local unit stormwindTram = gg_unit_n03B_0037
    local Person recipient

    set recipient = FACTION_IRONFORGE.Person
    if recipient == 0 then
      set recipient = FACTION_STORMWIND.Person
    endif
    if recipient == 0 then
      call KillUnit(gg_unit_n03B_0010)
      call KillUnit(gg_unit_n03B_0037)
      return
    endif

    call SetUnitOwner(ironforgeTram, recipient.Player, true)
    call WaygateActivateBJ(true, ironforgeTram)
    call WaygateSetDestination(ironforgeTram, GetRectCenterX(gg_rct_Stormwind), GetRectCenterY(gg_rct_Stormwind))
    call SetUnitInvulnerable(ironforgeTram, false)

    call SetUnitOwner(stormwindTram, recipient.Player, true)
    call WaygateActivateBJ(true, stormwindTram)
    call WaygateSetDestination(stormwindTram, GetRectCenterX(gg_rct_Ironforge), GetRectCenterY(gg_rct_Ironforge))
    call SetUnitInvulnerable(stormwindTram, false)
  endfunction

  private function ResearchStart takes nothing returns nothing
    local integer i = 0
    loop
    exitwhen i > MAX_PLAYERS
      call Person.ById(i).SetObjectLimit(RESEARCH_ID, 0)
      set i = i + 1
    endloop
  endfunction

  private function ResearchCancel takes nothing returns nothing
    local integer i = 0
    loop
    exitwhen i > MAX_PLAYERS
      call Person.ById(i).SetObjectLimit(RESEARCH_ID, 1)
      set i = i + 1
    endloop
  endfunction

  private function OnInit takes nothing returns nothing
    call RegisterResearchFinishedAction(RESEARCH_ID, function Transfer)
    call RegisterResearchStartedAction(RESEARCH_ID, function ResearchStart)
    call RegisterResearchCancelledAction(RESEARCH_ID, function ResearchCancel)
  endfunction
  
endlibrary