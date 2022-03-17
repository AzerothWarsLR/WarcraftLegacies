namespace AzerothWarsCSharp.Source.RoC.Mechanics.Scourge
{
  public class SacrificeAcolyte{

  
    private const int ACOLYTE_ID = FourCC(uaco);
  

    private static void OnSell( ){
      KillUnit(GetTriggerUnit());
      BlzSetUnitFacingEx(GetSoldUnit(), GetUnitFacing(GetTriggerUnit()));
      if (GetLocalPlayer() == GetOwningPlayer(GetSoldUnit())){
        SelectUnit(GetSoldUnit(), true);
      }
    }

    private static void OnInit( ){
      RegisterUnitTypeSoldUnitAction(ACOLYTE_ID,  OnSell);
    }

  }
}
