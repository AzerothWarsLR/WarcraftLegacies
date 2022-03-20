using AzerothWarsCSharp.MacroTools;
using AzerothWarsCSharp.Source.Libraries;

namespace AzerothWarsCSharp.Source.UnitTypes
{
  public class UnitTypesStormwind{

    public static void Setup( ){
      UnitType unitType = 0;

      unitType = UnitType.create(FourCC(h06K))      ;//Town Hall
      unitType.UnitCategory = UNITCATEGORY_TOWNHALL;

      unitType = UnitType.create(FourCC(h06M))      ;//Keep
      unitType.UnitCategory = UNITCATEGORY_KEEP;

      unitType = UnitType.create(FourCC(h06N))      ;//Castle
      unitType.UnitCategory = UNITCATEGORY_CASTLE;

      unitType = UnitType.create(FourCC(h072))      ;//Farm
      unitType.UnitCategory = UNITCATEGORY_FARM;

      unitType = UnitType.create(FourCC(h06T))      ;//Altar of Kings
      unitType.UnitCategory = UNITCATEGORY_ALTAR;

      unitType = UnitType.create(FourCC(h06E))      ;//Barracks
      unitType.UnitCategory = UNITCATEGORY_UNITPRODUCTION_A;

      unitType = UnitType.create(FourCC(hars))      ;//Arcane Sanctum
      unitType.UnitCategory = UNITCATEGORY_UNITPRODUCTION_B;

      unitType = UnitType.create(FourCC(h06A))      ;//Workshop
      unitType.UnitCategory = UNITCATEGORY_UNITPRODUCTION_C;

      unitType = UnitType.create(FourCC(h06G))      ;//Lumber Mill
      unitType.UnitCategory = UNITCATEGORY_UNITPRODUCTION_D;

      unitType = UnitType.create(FourCC(h06F))      ;//Blacksmith
      unitType.UnitCategory = UNITCATEGORY_BLACKSMITH;

      unitType = UnitType.create(FourCC(n07T))      ;//Marketplace
      unitType.UnitCategory = UNITCATEGORY_SHOP;

      unitType = UnitType.create(FourCC(h06V))      ;//Scout Tower
      unitType.UnitCategory = UNITCATEGORY_BASICTOWER;

      unitType = UnitType.create(FourCC(h06W))      ;//Guard Tower
      unitType.UnitCategory = UNITCATEGORY_UPGRADEDTOWER_A;

      unitType = UnitType.create(FourCC(h06X))      ;//Cannon Tower
      unitType.UnitCategory = UNITCATEGORY_UPGRADEDTOWER_B;

      unitType = UnitType.create(FourCC(h070))      ;//Improved Guard Tower
      unitType.UnitCategory = UNITCATEGORY_UPGRADEDTOWER2_A;

      unitType = UnitType.create(FourCC(h071))      ;//Improved Cannon Tower
      unitType.UnitCategory = UNITCATEGORY_UPGRADEDTOWER2_B;

      unitType = UnitType.create(FourCC(h06D))      ;//Royal Harbour
      unitType.UnitCategory = UNITCATEGORY_SHIPYARD;
    }

  }
}
