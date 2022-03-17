using AzerothWarsCSharp.Source.Main.Libraries;

namespace AzerothWarsCSharp.Source.RoC.Tests
{
  public class TestUnitCategories{


    void Run( ){
      group tempGroup = CreateGroup();
      unit u = null;
      GroupEnumUnitsOfPlayer(tempGroup, FACTION_LORDAERON.Person.Player, null);
      while(true){
        u = FirstOfGroup(tempGroup);
        if ( u == null){ break; }
        if (UnitType.ById(GetUnitTypeId(u)) != 0){
          if (FACTION_SCOURGE.GetUnitTypeByCategory(UnitType.ById(GetUnitTypeId(u)).UnitCategory) != 0){
            ReplaceUnitBJ(u, FACTION_SCOURGE.GetUnitTypeByCategory(UnitType.ById(GetUnitTypeId(u)).UnitCategory), bj_UNIT_STATE_METHOD_RELATIVE);
          }else {
            BJDebugMsg(GetUnitName(u) + " has a category, but !for Scourge!");
          }
        }else {
          BJDebugMsg(GetUnitName(u) + " has no category!");
        }
        GroupRemoveUnit(tempGroup, u);
      }
    }

    private static void onInit( ){
      thistype.create("unitcategories");
    }


  }
}
