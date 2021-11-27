library FactionSetup requires DalaranSetup, DruidsSetup, FelHordeSetup, FrostwolfSetup, IronforgeSetup, LegionSetup, LordaeronSetup, QuelthalasSetup, ScourgeSetup, SentinelsSetup, StormwindSetup, WarsongSetup, NagaSetup, CthunSetup, BlackEmpireSetup

  public function OnInit takes nothing returns nothing
    call ScourgeSetup_OnInit()
    call LegionSetup_OnInit()
    call LordaeronSetup_OnInit()
    call DalaranSetup_OnInit()
    call QuelthalasSetup_OnInit()
    call SentinelsSetup_OnInit()
    call DruidsSetup_OnInit()
    call FelHordeSetup_OnInit()
    call FrostwolfSetup_OnInit()
    call WarsongSetup_OnInit()
    call StormwindSetup_OnInit()
    call IronforgeSetup_OnInit()
    call KultirasSetup_OnInit()
    call NagaSetup_OnInit()
    call GilneasSetup_OnInit()
    call TrollSetup_OnInit()
    call GoblinSetup_OnInit()
    call TwilightSetup_OnInit()
    call ScarletSetup_OnInit()
    call CthunSetup_OnInit()
    call ForsakenSetup_OnInit()
    call BlackEmpireSetup_OnInit()
  endfunction

endlibrary