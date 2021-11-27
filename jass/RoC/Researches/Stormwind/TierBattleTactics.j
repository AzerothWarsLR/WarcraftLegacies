library TierBattleTactics initializer OnInit requires StormwindSetup

  private function Research takes nothing returns nothing
    call FACTION_STORMWIND.ModObjectLimit('h03K', -UNLIMITED)      //Marshal
    call FACTION_STORMWIND.ModObjectLimit('h014', 12)              //Marshal (Offensive)
    call FACTION_STORMWIND.ModObjectLimit('R03B', UNLIMITED)       //Exploit Weakness
    call FACTION_STORMWIND.ModObjectLimit('R02Z', UNLIMITED)       //Reflective Plating          
  endfunction

  private function OnInit takes nothing returns nothing
    call RegisterResearchFinishedAction('R02Y', function Research)
  endfunction

endlibrary