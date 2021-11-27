library StructurePackingInit initializer OnInit requires StructurePackingConfig

  globals
    private constant integer KODO_ID = 'oosc'
    private constant integer array Buildings
  endglobals

  private function InitKodo takes unit whichUnit, integer index returns nothing
    call PackableStructure.ByStructureId(Buildings[index]).SetupKodo(whichUnit)
  endfunction

  private function OnInit takes nothing returns nothing
    local group tempGroup = CreateGroup()
    local unit u
    local integer i = 0

    set Buildings[0] = 'ogre'
    set Buildings[1] = 'ofor'
    set Buildings[2] = 'oalt'
    set Buildings[3] = 'obar'

    call GroupEnumUnitsInRect(tempGroup, gg_rct_CairneStart, null)
    loop
      set u = FirstOfGroup(tempGroup)
      exitwhen u == null
      if GetUnitTypeId(u) == KODO_ID then
        call InitKodo(u, i)
        set i = i + 1
      endif
      call GroupRemoveUnit(tempGroup, u)
    endloop
    call DestroyGroup(tempGroup)
    set tempGroup = null
  endfunction

endlibrary