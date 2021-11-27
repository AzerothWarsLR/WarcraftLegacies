library TierCodeOfChivalry initializer OnInit requires StormwindSetup

  private function Research takes nothing returns nothing
    call FACTION_STORMWIND.ModObjectLimit('h01B', -UNLIMITED)      //Outrider
    call FACTION_STORMWIND.ModObjectLimit('h054', UNLIMITED)       //Stormwind Knight  
  endfunction

  private function OnInit takes nothing returns nothing
    call RegisterResearchFinishedAction('R030', function Research)   
  endfunction

endlibrary