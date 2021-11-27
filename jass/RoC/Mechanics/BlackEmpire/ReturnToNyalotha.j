library ReturnToNyalotha requires BlackEmpireSetup, Environment, Math

  globals
    private constant string EFFECT = "Abilities\\Spells\\Items\\AIre\\AIreTarget.mdl"
  endglobals

  private function ReturnUnitToNyalotha takes unit whichUnit returns nothing
    local real angle = GetRandomReal(0, 360)
    local real distance = GetRandomReal(100, 400)
    local real x = GetPolarOffsetX(-25543, distance, angle)
    local real y = GetPolarOffsetY(-1962, distance, angle)

    call DestroyEffect(AddSpecialEffect(EFFECT, GetUnitX(whichUnit), GetUnitY(whichUnit)))
    call DestroyEffect(AddSpecialEffect(EFFECT, x, y))

    call SetUnitX(whichUnit, x)
    call SetUnitY(whichUnit, y)
    call IssueImmediateOrder(whichUnit, "stop")
  endfunction

  function ReturnToNyalotha takes nothing returns nothing
    local group tempGroup = CreateGroup()
    local unit u
    call GroupEnumUnitsOfPlayer(tempGroup, FACTION_BLACKEMPIRE.Player, null)
    loop
      set u = FirstOfGroup(tempGroup)
      exitwhen u == null
      if not IsUnitInRect(u, gg_rct_NyalothaInstance) and BlzIsUnitInvulnerable(u) == false and IsUnitType(u, UNIT_TYPE_ANCIENT) == false then
        if IsUnitType(u, UNIT_TYPE_STRUCTURE) then
          call KillUnit(u)
        else
          call ReturnUnitToNyalotha(u)
        endif
      endif
      call GroupRemoveUnit(tempGroup, u)
    endloop
    call DestroyGroup(tempGroup)
    set tempGroup = null
    set u = null
  endfunction

endlibrary