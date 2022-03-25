namespace AzerothWarsCSharp.Source.Researches.Stormwind
{
  public class TierCodeOfChivalry{

    private static void Research( ){
      FACTION_STORMWIND.ModObjectLimit(FourCC(h01B), -Faction.UNLIMITED)      ;//Outrider
      FACTION_STORMWIND.ModObjectLimit(FourCC(h054), Faction.UNLIMITED)       ;//Stormwind Knight
    }

    public static void Setup( ){
      RegisterResearchFinishedAction(FourCC(R030),  Research);
    }

  }
}
