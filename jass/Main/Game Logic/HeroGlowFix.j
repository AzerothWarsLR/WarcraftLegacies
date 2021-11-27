library HeroGlowFix initializer OnInit requires Legend

  private function Revived takes nothing returns nothing
    local Legend revivedLegend = Legend.ByHandle(GetTriggerUnit())
    if revivedLegend.HasCustomColor then
      call SetUnitColor(GetTriggerUnit(), revivedLegend.PlayerColor)
    else
      call SetUnitColor(GetTriggerUnit(), Person.ByHandle(GetTriggerPlayer()).Faction.playCol)
    endif
  endfunction

  private function OnInit takes nothing returns nothing
    call PlayerUnitEventAddAction(EVENT_PLAYER_HERO_REVIVE_FINISH, function Revived)
  endfunction

endlibrary