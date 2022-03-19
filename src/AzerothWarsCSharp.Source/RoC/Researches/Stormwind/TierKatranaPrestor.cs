namespace AzerothWarsCSharp.Source.RoC.Researches.Stormwind
{
  public class TierKatranaPrestor{

  
    private const int DEMI_UNITTYPE_ID = FourCC(n06F);
  

    private static void Research( ){
      CreateUnit(FACTION_STORMWIND.Player, DEMI_UNITTYPE_ID, GetUnitX(GetTriggerUnit()), GetUnitY(GetTriggerUnit()), 0);
    }

    public static void Setup( ){
      RegisterResearchFinishedAction(FourCC(R03Y),  Research);
      FACTION_STORMWIND.ModObjectLimit(DEMI_UNITTYPE_ID, 1);
    }

  }
}
