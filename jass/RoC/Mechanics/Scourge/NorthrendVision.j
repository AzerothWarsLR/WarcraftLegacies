//Scourge always has vision over Northrend.

library NorthrendVision initializer OnInit requires ScourgeSetup

  globals
    private fogmodifier array ScourgeFogModifiers
  endglobals

  private function Enable takes nothing returns nothing
    local player whichPlayer = FACTION_SCOURGE.Player
    local integer i = 0
    set ScourgeFogModifiers[0] = CreateFogModifierRect(whichPlayer, FOG_OF_WAR_VISIBLE, gg_rct_Storm_Peaks, true, true)
    set ScourgeFogModifiers[1] = CreateFogModifierRect(whichPlayer, FOG_OF_WAR_VISIBLE, gg_rct_Central_Northrend, true, true)
    set ScourgeFogModifiers[2] = CreateFogModifierRect(whichPlayer, FOG_OF_WAR_VISIBLE, gg_rct_The_Basin, true, true)
    set ScourgeFogModifiers[3] = CreateFogModifierRect(whichPlayer, FOG_OF_WAR_VISIBLE, gg_rct_Ice_Crown, true, true)
    set ScourgeFogModifiers[4] = CreateFogModifierRect(whichPlayer, FOG_OF_WAR_VISIBLE, gg_rct_Fjord, true, true)
    set ScourgeFogModifiers[5] = CreateFogModifierRect(whichPlayer, FOG_OF_WAR_VISIBLE, gg_rct_Eastern_Northrend, true, true)
    set ScourgeFogModifiers[6] = CreateFogModifierRect(whichPlayer, FOG_OF_WAR_VISIBLE, gg_rct_Far_Eastern_Northrend, true, true)
    set ScourgeFogModifiers[7] = CreateFogModifierRect(whichPlayer, FOG_OF_WAR_VISIBLE, gg_rct_Coldarra, true, true)
    set ScourgeFogModifiers[8] = CreateFogModifierRect(whichPlayer, FOG_OF_WAR_VISIBLE, gg_rct_Borean_Tundra, true, true)
    set ScourgeFogModifiers[9] = CreateFogModifierRect(whichPlayer, FOG_OF_WAR_VISIBLE, gg_rct_IcecrownShipyard, true, true)
    loop
    exitwhen ScourgeFogModifiers[i] == null
      call FogModifierStart(ScourgeFogModifiers[i])
      set i = i + 1
    endloop
  endfunction

  private function Disable takes nothing returns nothing
    local integer i = 0
    loop
      exitwhen ScourgeFogModifiers[i] == null
      call DestroyFogModifier(ScourgeFogModifiers[i])
      set ScourgeFogModifiers[i] = null
      set i = i + 1
    endloop
  endfunction

  private function PersonChangesFaction takes nothing returns nothing
    local player triggerPlayer
    local integer i = 0
    if GetTriggerPerson().Faction == FACTION_SCOURGE then
      call Enable()
    elseif GetChangingPersonPrevFaction() == FACTION_SCOURGE then
      call Disable()
    endif
  endfunction

  private function OnInit takes nothing returns nothing
    local trigger trig = CreateTrigger()
    call OnPersonFactionChange.register(trig)
    call TriggerAddCondition(trig, Condition(function PersonChangesFaction))

    if FACTION_SCOURGE.Person != 0 then
      call Enable()
    endif
  endfunction

endlibrary