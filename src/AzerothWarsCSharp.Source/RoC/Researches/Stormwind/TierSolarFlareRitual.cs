namespace AzerothWarsCSharp.Source.RoC.Researches.Stormwind
{
  public class TierSolarFlareRitual{

    private static void Research( ){
      FACTION_STORMWIND.ModObjectLimit(FourCC(R03V), UNLIMITED)       ;//Stromgarde
      FACTION_STORMWIND.ModObjectLimit(FourCC(R03W), UNLIMITED)       ;//Honor Hold
    }

    public static void Setup( ){
      RegisterResearchFinishedAction(FourCC(R03U),  Research);
    }

  }
}
