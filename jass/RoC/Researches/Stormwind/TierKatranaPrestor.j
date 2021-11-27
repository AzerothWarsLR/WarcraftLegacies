library TierKatranaPrestor requires StormwindSetup

  globals
    private constant integer DEMI_UNITTYPE_ID = 'n06F'
  endglobals

  private function Research takes nothing returns nothing
    call CreateUnit(FACTION_STORMWIND.Player, DEMI_UNITTYPE_ID, GetUnitX(GetTriggerUnit()), GetUnitY(GetTriggerUnit()), 0)
  endfunction

  public function OnInit takes nothing returns nothing
    call RegisterResearchFinishedAction('R03Y', function Research)
    call FACTION_STORMWIND.ModObjectLimit(DEMI_UNITTYPE_ID, 1)
  endfunction

endlibrary