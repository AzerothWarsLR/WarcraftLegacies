library HelmOfDominationDropsWhenScourgeLeaves initializer OnInit requires Faction, ScourgeSetup, ArtifactSetup

  private function Actions takes nothing returns nothing
    if GetTriggerFaction() == FACTION_SCOURGE and ARTIFACT_HELMOFDOMINATION.OwningUnit == LEGEND_LICHKING.Unit then
      call SetItemPosition(ARTIFACT_HELMOFDOMINATION.item, GetRectCenterX(gg_rct_LichKing), GetRectCenterY(gg_rct_LichKing))
    endif
  endfunction

  private function OnInit takes nothing returns nothing
    local trigger trig = CreateTrigger()
    call OnFactionGameLeave.register(trig)
    call TriggerAddAction(trig, function Actions)
  endfunction    

endlibrary