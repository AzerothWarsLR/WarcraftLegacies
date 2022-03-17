namespace AzerothWarsCSharp.Source.RoC.Mechanics.Frostwolf
{
  public class StructurePackingInit{

  
    private const int KODO_ID = FourCC(oosc);
    private const int[] Buildings;
  

    private static void InitKodo(unit whichUnit, int index ){
      PackableStructure.ByStructureId(Buildings[index]).SetupKodo(whichUnit);
    }

    private static void OnInit( ){
      group tempGroup = CreateGroup();
      unit u;
      int i = 0;

      Buildings[0] = FourCC(ogre);
      Buildings[1] = FourCC(ofor);
      Buildings[2] = FourCC(oalt);
      Buildings[3] = FourCC(obar);

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
