namespace AzerothWarsCSharp.Source.Researches.Stormwind
{
  public class TierSolarFlareRitual{

    private static void Research( ){
      FACTION_STORMWIND.ModObjectLimit(FourCC(R03V), Faction.UNLIMITED)       ;//Stromgarde
      FACTION_STORMWIND.ModObjectLimit(FourCC(R03W), Faction.UNLIMITED)       ;//Honor Hold
    }

    public static void Setup( ){
      RegisterResearchFinishedAction(FourCC(R03U),  Research);
    }

  }
}
