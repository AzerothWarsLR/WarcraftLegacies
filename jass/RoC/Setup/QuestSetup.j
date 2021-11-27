library QuestSetup requires DalaranQuestSetup, DruidsQuestSetup, FelHordeQuestSetup, FrostwolfQuestSetup, IronforgeQuestSetup, LegionQuestSetup, LordaeronQuestSetup, QuelthalasQuestSetup, ScourgeQuestSetup, SentinelsQuestSetup, StormwindQuestSetup, WarsongQuestSetup, NagaQuestSetup, BlackEmpireQuestSetup

  public function OnInit takes nothing returns nothing
    call DalaranQuestSetup_OnInit()
    call DruidsQuestSetup_OnInit()
    call FelHordeQuestSetup_OnInit()
    call FrostwolfQuestSetup_OnInit()
    call IronforgeQuestSetup_OnInit()
    call LegionQuestSetup_OnInit()
    call LordaeronQuestSetup_OnInit()
    call QuelthalasQuestSetup_OnInit()
    call ScourgeQuestSetup_OnInit()
    call SentinelsQuestSetup_OnInit()
    call StormwindQuestSetup_OnInit()
    call WarsongQuestSetup_OnInit()
    call NagaQuestSetup_OnInit()
    call GilneasQuestSetup_OnInit()
    call KultirasQuestSetup_OnInit()
    call ScarletQuestSetup_OnInit()
    call TrollQuestSetup_OnInit()
    call ForsakenQuestSetup_OnInit()
    call TwilightQuestSetup_OnInit()
    call CthunQuestSetup_OnInit()
    call GoblinQuestSetup_OnInit()
    call BlackEmpireQuestSetup_OnInit()
  endfunction

endlibrary