library TestUnitCategories requires Test, LordaeronSetup, ScourgeSetup

  struct TestUnitCategories extends Test
    method Run takes nothing returns nothing
      local group tempGroup = CreateGroup()
      local unit u = null
      call GroupEnumUnitsOfPlayer(tempGroup, FACTION_LORDAERON.Person.Player, null)
      loop
        set u = FirstOfGroup(tempGroup)
        exitwhen u == null
        if UnitType.ById(GetUnitTypeId(u)) != 0 then
          if FACTION_SCOURGE.GetUnitTypeByCategory(UnitType.ById(GetUnitTypeId(u)).UnitCategory) != 0 then
            call ReplaceUnitBJ(u, FACTION_SCOURGE.GetUnitTypeByCategory(UnitType.ById(GetUnitTypeId(u)).UnitCategory), bj_UNIT_STATE_METHOD_RELATIVE)
          else
            call BJDebugMsg(GetUnitName(u) + " has a category, but not for Scourge!")
          endif
        else
          call BJDebugMsg(GetUnitName(u) + " has no category!")
        endif
        call GroupRemoveUnit(tempGroup, u)
      endloop
    endmethod

    private static method onInit takes nothing returns nothing 
      call thistype.create("unitcategories")
    endmethod
  endstruct

endlibrary