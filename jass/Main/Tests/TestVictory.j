library TestVictory requires Test, ControlPointVictory, ControlPoint, VictoryDefeat

  struct TestVictory extends Test
    method Run takes nothing returns nothing
      local group tempGroup = CreateGroup()
      local unit u
      call BlzGroupAddGroupFast(ControlPoints, tempGroup)
      loop
        set u = FirstOfGroup(tempGroup)
        exitwhen u == null or GameWon == true
        call SetUnitOwner(u, Player(0), true)
        call GroupRemoveUnit(tempGroup, u)
      endloop
      set u = null
    endmethod

    private static method onInit takes nothing returns nothing 
      call thistype.create("victory")
    endmethod
  endstruct

endlibrary