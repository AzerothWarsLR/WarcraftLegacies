using AzerothWarsCSharp.Source.Main.Libraries;

namespace AzerothWarsCSharp.Source.Main.UnitTypes
{
  public class UnitTypesScourge{

    private static void OnInit( ){
      UnitType unitType = 0;

      unitType = UnitType.create(FourCC(unpl))      ;//Necropolis
      unitType.UnitCategory = UNITCATEGORY_TOWNHALL;

      unitType = UnitType.create(FourCC(unp1))      ;//Halls of the Dead
      unitType.UnitCategory = UNITCATEGORY_KEEP;

      unitType = UnitType.create(FourCC(unp2))      ;//Black Citadel
      unitType.UnitCategory = UNITCATEGORY_CASTLE;

      unitType = UnitType.create(FourCC(uzig))      ;//Ziggurat
      unitType.UnitCategory = UNITCATEGORY_FARM;

      unitType = UnitType.create(FourCC(uaod))      ;//Altar of Darkness
      unitType.UnitCategory = UNITCATEGORY_ALTAR;

      unitType = UnitType.create(FourCC(usep))      ;//Crypt
      unitType.UnitCategory = UNITCATEGORY_UNITPRODUCTION_A;

      unitType = UnitType.create(FourCC(utod))      ;//Temple of the Damned
      unitType.UnitCategory = UNITCATEGORY_UNITPRODUCTION_B;

      unitType = UnitType.create(FourCC(uslh))      ;//Slaughterhouse
      unitType.UnitCategory = UNITCATEGORY_UNITPRODUCTION_C;

      unitType = UnitType.create(FourCC(ubon))      ;//Boneyard
      unitType.UnitCategory = UNITCATEGORY_UNITPRODUCTION_D;

      unitType = UnitType.create(FourCC(ugrv))      ;//Graveyard
      unitType.UnitCategory = UNITCATEGORY_BLACKSMITH;

      unitType = UnitType.create(FourCC(utom))      ;//Tomb of Relics
      unitType.UnitCategory = UNITCATEGORY_SHOP;

      unitType = UnitType.create(FourCC(uzg1))      ;//Spirit Tower
      unitType.UnitCategory = UNITCATEGORY_UPGRADEDTOWER_A;

      unitType = UnitType.create(FourCC(uzg2))      ;//Nerubian Tower
      unitType.UnitCategory = UNITCATEGORY_UPGRADEDTOWER_B;

      unitType = UnitType.create(FourCC(u002))      ;//Improved Spirit Tower
      unitType.UnitCategory = UNITCATEGORY_UPGRADEDTOWER2_A;

      unitType = UnitType.create(FourCC(u003))      ;//Improved Nerubian Tower
      unitType.UnitCategory = UNITCATEGORY_UPGRADEDTOWER2_B;

      unitType = UnitType.create(FourCC(ushp))      ;//Haunted Harbor
      unitType.UnitCategory = UNITCATEGORY_SHIPYARD;
    }

  }
}
