public class TierCodeOfChivalry{

  private static void Research( ){
    FACTION_STORMWIND.ModObjectLimit(FourCC(h01B), -UNLIMITED)      ;//Outrider
    FACTION_STORMWIND.ModObjectLimit(FourCC(h054), UNLIMITED)       ;//Stormwind Knight
  }

  private static void OnInit( ){
    RegisterResearchFinishedAction(FourCC(R030),  Research);
  }

}
