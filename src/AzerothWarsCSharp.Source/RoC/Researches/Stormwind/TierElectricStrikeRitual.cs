namespace AzerothWarsCSharp.Source.RoC.Researches.Stormwind
{
  public class TierElectricStrikeRitual{

    private static void Research( ){
      FACTION_STORMWIND.ModObjectLimit(FourCC(R03V), UNLIMITED)       ;//Stromgarde
      FACTION_STORMWIND.ModObjectLimit(FourCC(R03W), UNLIMITED)       ;//Honor Hold
    }

    private static void OnInit( ){
      RegisterResearchFinishedAction(FourCC(R03T),  Research);
    }

  }
}
