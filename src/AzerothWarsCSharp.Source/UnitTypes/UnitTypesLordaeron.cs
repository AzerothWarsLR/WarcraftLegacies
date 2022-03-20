using AzerothWarsCSharp.MacroTools;
using AzerothWarsCSharp.Source.Libraries;

namespace AzerothWarsCSharp.Source.UnitTypes
{
  public class UnitTypesLordaeron{

    public static void Setup( ){
      UnitType unitType = 0;

      unitType = UnitType.create(FourCC(htow))      ;//Town Hall
      unitType.UnitCategory = UNITCATEGORY_TOWNHALL;

      unitType = UnitType.create(FourCC(hkee))      ;//Keep
      unitType.UnitCategory = UNITCATEGORY_KEEP;

      unitType = UnitType.create(FourCC(hcas))      ;//Castle
      unitType.UnitCategory = UNITCATEGORY_CASTLE;

      unitType = UnitType.create(FourCC(hhou))      ;//Farm
      unitType.UnitCategory = UNITCATEGORY_FARM;

      unitType = UnitType.create(FourCC(halt))      ;//Altar of Kings
      unitType.UnitCategory = UNITCATEGORY_ALTAR;

      unitType = UnitType.create(FourCC(hbar))      ;//Barracks
      unitType.UnitCategory = UNITCATEGORY_UNITPRODUCTION_A;

      unitType = UnitType.create(FourCC(h035))      ;//Chapel
      unitType.UnitCategory = UNITCATEGORY_UNITPRODUCTION_B;

      unitType = UnitType.create(FourCC(hgra))      ;//Aviary
      unitType.UnitCategory = UNITCATEGORY_UNITPRODUCTION_C;

      unitType = UnitType.create(FourCC(hlum))      ;//Lumber Mill
      unitType.UnitCategory = UNITCATEGORY_UNITPRODUCTION_D;

      unitType = UnitType.create(FourCC(hbla))      ;//Blacksmith
      unitType.UnitCategory = UNITCATEGORY_BLACKSMITH;

      unitType = UnitType.create(FourCC(nmrk))      ;//Marketplace
      unitType.UnitCategory = UNITCATEGORY_SHOP;

      unitType = UnitType.create(FourCC(hwtw))      ;//Scout Tower
      unitType.UnitCategory = UNITCATEGORY_BASICTOWER;

      unitType = UnitType.create(FourCC(hwtw))      ;//Guard Tower
      unitType.UnitCategory = UNITCATEGORY_UPGRADEDTOWER_A;

      unitType = UnitType.create(FourCC(hctw))      ;//Cannon Tower
      unitType.UnitCategory = UNITCATEGORY_UPGRADEDTOWER_B;

      unitType = UnitType.create(FourCC(h006))      ;//Improved Guard Tower
      unitType.UnitCategory = UNITCATEGORY_UPGRADEDTOWER2_A;

      unitType = UnitType.create(FourCC(h007))      ;//Improved Cannon Tower
      unitType.UnitCategory = UNITCATEGORY_UPGRADEDTOWER2_B;

      unitType = UnitType.create(FourCC(hshy))      ;//Alliance Shipyard
      unitType.UnitCategory = UNITCATEGORY_SHIPYARD;
    }

  }
}
