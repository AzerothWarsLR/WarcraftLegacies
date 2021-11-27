library UnitTypesLordaeron initializer OnInit requires UnitType

  private function OnInit takes nothing returns nothing
    local UnitType unitType = 0

    set unitType = UnitType.create('htow')      //Town Hall
    set unitType.UnitCategory = UNITCATEGORY_TOWNHALL

    set unitType = UnitType.create('hkee')      //Keep
    set unitType.UnitCategory = UNITCATEGORY_KEEP

    set unitType = UnitType.create('hcas')      //Castle
    set unitType.UnitCategory = UNITCATEGORY_CASTLE

    set unitType = UnitType.create('hhou')      //Farm
    set unitType.UnitCategory = UNITCATEGORY_FARM

    set unitType = UnitType.create('halt')      //Altar of Kings
    set unitType.UnitCategory = UNITCATEGORY_ALTAR

    set unitType = UnitType.create('hbar')      //Barracks
    set unitType.UnitCategory = UNITCATEGORY_UNITPRODUCTION_A

    set unitType = UnitType.create('h035')      //Chapel
    set unitType.UnitCategory = UNITCATEGORY_UNITPRODUCTION_B

    set unitType = UnitType.create('hgra')      //Aviary
    set unitType.UnitCategory = UNITCATEGORY_UNITPRODUCTION_C

    set unitType = UnitType.create('hlum')      //Lumber Mill
    set unitType.UnitCategory = UNITCATEGORY_UNITPRODUCTION_D

    set unitType = UnitType.create('hbla')      //Blacksmith
    set unitType.UnitCategory = UNITCATEGORY_BLACKSMITH

    set unitType = UnitType.create('nmrk')      //Marketplace
    set unitType.UnitCategory = UNITCATEGORY_SHOP

    set unitType = UnitType.create('hwtw')      //Scout Tower
    set unitType.UnitCategory = UNITCATEGORY_BASICTOWER

    set unitType = UnitType.create('hwtw')      //Guard Tower
    set unitType.UnitCategory = UNITCATEGORY_UPGRADEDTOWER_A

    set unitType = UnitType.create('hctw')      //Cannon Tower
    set unitType.UnitCategory = UNITCATEGORY_UPGRADEDTOWER_B

    set unitType = UnitType.create('h006')      //Improved Guard Tower
    set unitType.UnitCategory = UNITCATEGORY_UPGRADEDTOWER2_A

    set unitType = UnitType.create('h007')      //Improved Cannon Tower
    set unitType.UnitCategory = UNITCATEGORY_UPGRADEDTOWER2_B

    set unitType = UnitType.create('hshy')      //Alliance Shipyard
    set unitType.UnitCategory = UNITCATEGORY_SHIPYARD
  endfunction

endlibrary