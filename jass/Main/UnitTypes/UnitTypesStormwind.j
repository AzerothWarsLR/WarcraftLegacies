library UnitTypesStormwind initializer OnInit requires UnitType

  private function OnInit takes nothing returns nothing
    local UnitType unitType = 0

    set unitType = UnitType.create('h06K')      //Town Hall
    set unitType.UnitCategory = UNITCATEGORY_TOWNHALL

    set unitType = UnitType.create('h06M')      //Keep
    set unitType.UnitCategory = UNITCATEGORY_KEEP

    set unitType = UnitType.create('h06N')      //Castle
    set unitType.UnitCategory = UNITCATEGORY_CASTLE

    set unitType = UnitType.create('h072')      //Farm
    set unitType.UnitCategory = UNITCATEGORY_FARM

    set unitType = UnitType.create('h06T')      //Altar of Kings
    set unitType.UnitCategory = UNITCATEGORY_ALTAR

    set unitType = UnitType.create('h06E')      //Barracks
    set unitType.UnitCategory = UNITCATEGORY_UNITPRODUCTION_A

    set unitType = UnitType.create('hars')      //Arcane Sanctum
    set unitType.UnitCategory = UNITCATEGORY_UNITPRODUCTION_B

    set unitType = UnitType.create('h06A')      //Workshop
    set unitType.UnitCategory = UNITCATEGORY_UNITPRODUCTION_C

    set unitType = UnitType.create('h06G')      //Lumber Mill
    set unitType.UnitCategory = UNITCATEGORY_UNITPRODUCTION_D

    set unitType = UnitType.create('h06F')      //Blacksmith
    set unitType.UnitCategory = UNITCATEGORY_BLACKSMITH

    set unitType = UnitType.create('n07T')      //Marketplace
    set unitType.UnitCategory = UNITCATEGORY_SHOP

    set unitType = UnitType.create('h06V')      //Scout Tower
    set unitType.UnitCategory = UNITCATEGORY_BASICTOWER

    set unitType = UnitType.create('h06W')      //Guard Tower
    set unitType.UnitCategory = UNITCATEGORY_UPGRADEDTOWER_A

    set unitType = UnitType.create('h06X')      //Cannon Tower
    set unitType.UnitCategory = UNITCATEGORY_UPGRADEDTOWER_B

    set unitType = UnitType.create('h070')      //Improved Guard Tower
    set unitType.UnitCategory = UNITCATEGORY_UPGRADEDTOWER2_A

    set unitType = UnitType.create('h071')      //Improved Cannon Tower
    set unitType.UnitCategory = UNITCATEGORY_UPGRADEDTOWER2_B

    set unitType = UnitType.create('h06D')      //Royal Harbour
    set unitType.UnitCategory = UNITCATEGORY_SHIPYARD
  endfunction

endlibrary