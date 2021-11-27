library TierKnowledgeOfHonorHold initializer OnInit requires StormwindSetup

  globals
    private constant integer UNITTYPE_PORTAL = 'n09P'
    private constant real WAYGATE_OFFSET = 100.
  endglobals

  private function EnablePortals takes nothing returns nothing
    local unit waygateA = CreateUnit(FACTION_STORMWIND.Player, UNITTYPE_PORTAL, GetDestructableX(gg_dest_B017_11954), GetDestructableY(gg_dest_B017_11954), 0)
    local unit waygateB = CreateUnit(FACTION_STORMWIND.Player, UNITTYPE_PORTAL, GetDestructableX(gg_dest_B017_8950), GetDestructableY(gg_dest_B017_8950), 130.80)
    call SetUnitPathing(waygateA, false)
    call SetUnitPathing(waygateB, false)
    call SetUnitPosition(waygateA, GetDestructableX(gg_dest_B017_11954), GetDestructableY(gg_dest_B017_11954))
    call SetUnitPosition(waygateB, GetDestructableX(gg_dest_B017_8950), GetDestructableY(gg_dest_B017_8950))
    call WaygateActivate(waygateA, true)
    call WaygateActivate(waygateB, true)
    call WaygateSetDestination(waygateA, GetPolarOffsetY(GetUnitX(waygateB), WAYGATE_OFFSET, GetUnitFacing(waygateB)), GetPolarOffsetY(GetUnitY(waygateB), WAYGATE_OFFSET, GetUnitFacing(waygateB)))
    call WaygateSetDestination(waygateB, GetPolarOffsetX(GetUnitX(waygateA), WAYGATE_OFFSET, GetUnitFacing(waygateA)), GetPolarOffsetY(GetUnitY(waygateA), WAYGATE_OFFSET, GetUnitFacing(waygateA)))
    call QueueUnitAnimation(waygateA, "birth")
    call QueueUnitAnimation(waygateB, "birth")
    call QueueUnitAnimation(waygateA, "stand")
    call QueueUnitAnimation(waygateB, "stand")
  endfunction

  private function Research takes nothing returns nothing
    call FACTION_STORMWIND.ModObjectLimit('R03X', UNLIMITED)       //High Sorcerer Andromath
    call FACTION_STORMWIND.ModObjectLimit('R03Y', UNLIMITED)       //Katrana Prestor    
    call EnablePortals()
  endfunction

  private function OnInit takes nothing returns nothing
    call RegisterResearchFinishedAction('R03W', function Research)
  endfunction

endlibrary