public class UnitType{

  

    int UNITCATEGORY_TOWNHALL = 1;
    int UNITCATEGORY_KEEP = 2;
    int UNITCATEGORY_CASTLE = 3;
    int UNITCATEGORY_UNITPRODUCTION_A = 4;
    int UNITCATEGORY_UNITPRODUCTION_B = 5;
    int UNITCATEGORY_UNITPRODUCTION_C = 6;
    int UNITCATEGORY_UNITPRODUCTION_D = 7;
    int UNITCATEGORY_SHIPYARD = 8;
    int UNITCATEGORY_FARM = 9;
    int UNITCATEGORY_ALTAR = 10;
    int UNITCATEGORY_SHOP = 11;
    int UNITCATEGORY_BASICTOWER = 12;
    int UNITCATEGORY_UPGRADEDTOWER_A = 13;
    int UNITCATEGORY_UPGRADEDTOWER_B = 14;
    int UNITCATEGORY_BLACKSMITH = 15;
    int UNITCATEGORY_SPECIAL = 16 ;//Lumber Mill, for instance
    int UNITCATEGORY_UPGRADEDTOWER2_A = 13 ;//Tower that)s been upgraded twice
    int UNITCATEGORY_UPGRADEDTOWER2_B = 14 ;//Tower that)s been upgraded twice
  

  //Stores extra data about UnitTypeIds.

    private static Table byId;
    readonly int unitId = 0;
    readonly boolean refund = false      ;//When the player leaves this unit gets deleted, cost refunded, and given to allies
    readonly boolean meta = false        ;//When the player leaves this unit is exempted from being affected
    readonly string iconPath = null;
    private int unitCategory = 0;

    //How much gold the UnitType costs to train or build.
    integer operator GoldCost( ){
      return GetUnitGoldCost(unitId);
    }

    //How much lumber the UnitType costs to train or build.
    integer operator LumberCost( ){
      return GetUnitWoodCost(unitId);
    }

    //Whether or not the unit should be deleted without refund when the player leaves.
    boolean operator Meta( ){
      return meta;
    }

    void operator Meta=(boolean b ){
      meta = b;
    }

    //Whether or not the unit should be refunded when the player leaves.
    boolean operator Refund( ){
      return refund;
    }

    void operator Refund=(boolean b ){
      refund = b;
    }

    //An arbitrary category, like "Shipyard" or "Shop".
    integer operator UnitCategory( ){
      return unitCategory;
    }

    void operator UnitCategory=(int unitCategory ){
      this.unitCategory = unitCategory;
    }

    //Returns the UnitType representation of a unit on the map.
    static thistype ByHandle(unit whichUnit ){
      ;type.byId[GetUnitTypeId(whichUnit)];
    }

    //Returns the UnitType representation of a particular UnitTypeId.
    static thistype ById(int id ){
      ;type.byId[id];
    }

     UnitType (int unitId ){

      this.unitId = unitId;
      thistype.byId[unitId] = this;
      ;;
    }

    private static void onInit( ){
      thistype.byId = Table.create();
    }


}
