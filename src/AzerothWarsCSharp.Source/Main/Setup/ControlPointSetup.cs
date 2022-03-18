using AzerothWarsCSharp.Source.Main.Libraries.MacroTools;

namespace AzerothWarsCSharp.Source.Main.Setup
{
  public class ControlPointSetup{

  
    private const int    CP_BUFF_A = FourCC(B025);
    private const int    CP_BUFF_B = FourCC(B050);
    private const int    CP_BUFF_C = FourCC(B051);
    private const int    CP_BUFF_D = FourCC(B052);
    private const int    CP_BUFF_E = FourCC(B053);
    private const int    CP_BUFF_F = FourCC(B054);

    private const float       CP_VALUE_A = 10;
    private const float       CP_VALUE_B = 15;
    private const float       CP_VALUE_C = 20;
    private const float       CP_VALUE_D = 25;
    private const float       CP_VALUE_E = 30;
    private const float       CP_VALUE_F = 50;

    private int[] cpBuffs[6];
    private float[] cpValues[6];
  

    private static void InitializeCP( ){
      unit u = GetEnumUnit();
      var i = 0;
      while(true){
        if ( i > 5){ break; }
        if (GetUnitAbilityLevel(GetEnumUnit(), cpBuffs[i]) > 0){
          ControlPoint.create(GetEnumUnit(), cpValues[i]);
        }
        i = i + 1;
      }
    }

    public static void OnInit( ){
      group g;

      cpBuffs[0] = CP_BUFF_A;
      cpBuffs[1] = CP_BUFF_B;
      cpBuffs[2] = CP_BUFF_C;
      cpBuffs[3] = CP_BUFF_D;
      cpBuffs[4] = CP_BUFF_E;
      cpBuffs[5] = CP_BUFF_F;

      cpValues[0] = CP_VALUE_A;
      cpValues[1] = CP_VALUE_B;
      cpValues[2] = CP_VALUE_C;
      cpValues[3] = CP_VALUE_D;
      cpValues[4] = CP_VALUE_E;
      cpValues[5] = CP_VALUE_F;

      g = CreateGroup();
      GroupEnumUnitsInRect(g, bj_mapInitialPlayableArea, null);
      ForGroup(g,  InitializeCP);
    }

  }
}
