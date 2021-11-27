library UnitTypesNeutral initializer OnInit requires UnitType

  private function OnInit takes nothing returns nothing
    local UnitType unitType = 0

    set unitType = UnitType.create('h059')      //Gilneas City Building
    set unitType.UnitCategory = UNITCATEGORY_FARM

    set unitType = UnitType.create('h00I')      //Windmill
    set unitType.UnitCategory = UNITCATEGORY_FARM
  endfunction

endlibrary