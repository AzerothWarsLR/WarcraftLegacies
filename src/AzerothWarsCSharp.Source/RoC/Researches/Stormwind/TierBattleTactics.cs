public class TierBattleTactics{

  private static void Research( ){
    FACTION_STORMWIND.ModObjectLimit(FourCC(h03K), -UNLIMITED)      ;//Marshal
    FACTION_STORMWIND.ModObjectLimit(FourCC(h014), 12)              ;//Marshal (Offensive)
    FACTION_STORMWIND.ModObjectLimit(FourCC(R03B), UNLIMITED)       ;//Exploit Weakness
    FACTION_STORMWIND.ModObjectLimit(FourCC(R02Z), UNLIMITED)       ;//Reflective Plating
  }

  private static void OnInit( ){
    RegisterResearchFinishedAction(FourCC(R02Y),  Research);
  }

}
