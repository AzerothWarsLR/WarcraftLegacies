library BombingRun initializer OnInit requires DummyCast

  globals
    private constant integer ABIL_ID = 'A0S5'
    private constant integer LOCUSTSWARM_ID = 'A0S1'
  endglobals

  private function Cast takes nothing returns nothing
    call DummyChannelInstantFromPoint(GetOwningPlayer(GetTriggerUnit()), LOCUSTSWARM_ID, "locustswarm", 1, GetSpellTargetX(), GetSpellTargetY(), 15)
  endfunction

  private function OnInit takes nothing returns nothing
    call RegisterSpellEffectAction(ABIL_ID, function Cast)
  endfunction 

endlibrary