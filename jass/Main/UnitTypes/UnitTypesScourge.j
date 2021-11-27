library UnitTypesScourge initializer OnInit requires UnitType

  private function OnInit takes nothing returns nothing
    local UnitType unitType = 0

    set unitType = UnitType.create('unpl')      //Necropolis
    set unitType.UnitCategory = UNITCATEGORY_TOWNHALL

    set unitType = UnitType.create('unp1')      //Halls of the Dead
    set unitType.UnitCategory = UNITCATEGORY_KEEP

    set unitType = UnitType.create('unp2')      //Black Citadel
    set unitType.UnitCategory = UNITCATEGORY_CASTLE

    set unitType = UnitType.create('uzig')      //Ziggurat
    set unitType.UnitCategory = UNITCATEGORY_FARM

    set unitType = UnitType.create('uaod')      //Altar of Darkness
    set unitType.UnitCategory = UNITCATEGORY_ALTAR

    set unitType = UnitType.create('usep')      //Crypt
    set unitType.UnitCategory = UNITCATEGORY_UNITPRODUCTION_A

    set unitType = UnitType.create('utod')      //Temple of the Damned
    set unitType.UnitCategory = UNITCATEGORY_UNITPRODUCTION_B

    set unitType = UnitType.create('uslh')      //Slaughterhouse
    set unitType.UnitCategory = UNITCATEGORY_UNITPRODUCTION_C

    set unitType = UnitType.create('ubon')      //Boneyard
    set unitType.UnitCategory = UNITCATEGORY_UNITPRODUCTION_D

    set unitType = UnitType.create('ugrv')      //Graveyard
    set unitType.UnitCategory = UNITCATEGORY_BLACKSMITH

    set unitType = UnitType.create('utom')      //Tomb of Relics
    set unitType.UnitCategory = UNITCATEGORY_SHOP

    set unitType = UnitType.create('uzg1')      //Spirit Tower
    set unitType.UnitCategory = UNITCATEGORY_UPGRADEDTOWER_A

    set unitType = UnitType.create('uzg2')      //Nerubian Tower
    set unitType.UnitCategory = UNITCATEGORY_UPGRADEDTOWER_B

    set unitType = UnitType.create('u002')      //Improved Spirit Tower
    set unitType.UnitCategory = UNITCATEGORY_UPGRADEDTOWER2_A

    set unitType = UnitType.create('u003')      //Improved Nerubian Tower
    set unitType.UnitCategory = UNITCATEGORY_UPGRADEDTOWER2_B

    set unitType = UnitType.create('ushp')      //Haunted Harbor
    set unitType.UnitCategory = UNITCATEGORY_SHIPYARD
  endfunction

endlibrary