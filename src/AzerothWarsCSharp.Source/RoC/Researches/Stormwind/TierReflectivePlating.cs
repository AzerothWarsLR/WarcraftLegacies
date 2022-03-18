namespace AzerothWarsCSharp.Source.RoC.Researches.Stormwind
{
  public class TierReflectivePlating{

    private static void Research( ){
      FACTION_STORMWIND.ModObjectLimit(FourCC(h04C),UNLIMITED)        ;//Bladesman
      FACTION_STORMWIND.ModObjectLimit(FourCC(h02O),-UNLIMITED)       ;//Militiaman
      FACTION_STORMWIND.ModObjectLimit(FourCC(R030), UNLIMITED)       ;//Code of Chivalry
      FACTION_STORMWIND.ModObjectLimit(FourCC(R031), UNLIMITED)       ;//Elven Refugees
    }

    public static void Setup( ){
      RegisterResearchFinishedAction(FourCC(R02Z),  Research);
    }

  }
}
