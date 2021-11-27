library TierSolarFlareRitual initializer OnInit requires StormwindSetup

  private function Research takes nothing returns nothing
    call FACTION_STORMWIND.ModObjectLimit('R03V', UNLIMITED)       //Stromgarde
    call FACTION_STORMWIND.ModObjectLimit('R03W', UNLIMITED)       //Honor Hold    
  endfunction

  private function OnInit takes nothing returns nothing
    call RegisterResearchFinishedAction('R03U', function Research)
  endfunction

endlibrary