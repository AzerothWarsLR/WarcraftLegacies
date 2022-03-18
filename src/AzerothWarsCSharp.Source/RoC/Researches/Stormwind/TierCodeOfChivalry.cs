namespace AzerothWarsCSharp.Source.RoC.Researches.Stormwind
{
  public class TierCodeOfChivalry{

    private static void Research( ){
      FACTION_STORMWIND.ModObjectLimit(FourCC(h01B), -UNLIMITED)      ;//Outrider
      FACTION_STORMWIND.ModObjectLimit(FourCC(h054), UNLIMITED)       ;//Stormwind Knight
    }

    public static void Setup( ){
      RegisterResearchFinishedAction(FourCC(R030),  Research);
    }

  }
}
