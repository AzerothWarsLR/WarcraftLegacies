namespace AzerothWarsCSharp.Source.RoC.Mechanics.Scourge
{
  public class Plagueling{

  
    private const int PLAGUELING_ID = FourCC(n08G);
    private const float DURATION = 15;
  

    private static void OnSell( ){
      UnitApplyTimedLife(GetSoldUnit(), 0, DURATION);
      SetUnitExploded(GetSoldUnit(), true);
    }

    private static void OnInit( ){
      RegisterUnitSoldUnitTypeAction(PLAGUELING_ID,  OnSell);
    }

  }
}
