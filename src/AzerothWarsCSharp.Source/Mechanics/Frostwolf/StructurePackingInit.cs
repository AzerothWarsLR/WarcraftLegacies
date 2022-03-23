namespace AzerothWarsCSharp.Source.Mechanics.Frostwolf
{
  public class StructurePackingInit{

  
    private const int KODO_ID = FourCC(oosc);
    private const int[] BUILDINGS;
  

    private static void InitKodo(unit whichUnit, int index ){
      PackableStructure.ByStructureId(BUILDINGS[index]).SetupKodo(whichUnit);
    }

    public static void Setup( ){
      group tempGroup = CreateGroup();
      unit u;
      var i = 0;

      BUILDINGS[0] = FourCC(ogre);
      BUILDINGS[1] = FourCC(ofor);
      BUILDINGS[2] = FourCC(oalt);
      BUILDINGS[3] = FourCC(obar);

      GroupEnumUnitsInRect(tempGroup, gg_rct_CairneStart, null);
      while(true){
        u = FirstOfGroup(tempGroup);
        if ( u == null){ break; }
        if (GetUnitTypeId(u) == KODO_ID){
          InitKodo(u, i);
          i = i + 1;
        }
        GroupRemoveUnit(tempGroup, u);
      }
      DestroyGroup(tempGroup);
      tempGroup = null;
    }

  }
}
