namespace AzerothWarsCSharp.Source.Researches.Stormwind
{
  public class TierReflectivePlating{

    private static void Research( ){
      FACTION_STORMWIND.ModObjectLimit(FourCC(h04C),UNLIMITED)        ;//Bladesman
      FACTION_STORMWIND.ModObjectLimit(FourCC(h02O),-Faction.UNLIMITED)       ;//Militiaman
      FACTION_STORMWIND.ModObjectLimit(FourCC(R030), Faction.UNLIMITED)       ;//Code of Chivalry
      FACTION_STORMWIND.ModObjectLimit(FourCC(R031), Faction.UNLIMITED)       ;//Elven Refugees
    }

    public static void Setup( ){
      RegisterResearchFinishedAction(FourCC(R02Z),  Research);
    }

  }
}
