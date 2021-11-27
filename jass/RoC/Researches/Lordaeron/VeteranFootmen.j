library VeteranFootmen initializer OnInit requires Persons, LordaeronSetup

  globals
    private constant integer RESEARCH_ID = 'R00B'
  endglobals

  private function Research takes nothing returns nothing
    call FACTION_LORDAERON.ModObjectLimit('hfoo', -UNLIMITED)  //Footman
    call FACTION_LORDAERON.ModObjectLimit('h029', UNLIMITED)   //Veteran Footman
  endfunction

  private function OnInit takes nothing returns nothing
    call RegisterResearchFinishedAction(RESEARCH_ID, function Research)
  endfunction

endlibrary