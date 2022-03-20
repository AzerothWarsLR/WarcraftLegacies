namespace AzerothWarsCSharp.Source.Researches.Stormwind
{
  public class TierVeteranGuard{

    private static void Research( ){
      FACTION_STORMWIND.ModObjectLimit(FourCC(h03K), -UNLIMITED)      ;//Marshal
      FACTION_STORMWIND.ModObjectLimit(FourCC(h03U), 12)              ;//Marshal (Defensive)
      FACTION_STORMWIND.ModObjectLimit(FourCC(R03B), UNLIMITED)       ;//Exploit Weakness
      FACTION_STORMWIND.ModObjectLimit(FourCC(R02Z), UNLIMITED)       ;//Reflective Plating
    }

    public static void Setup( ){
      RegisterResearchFinishedAction(FourCC(R03D),  Research);
    }

  }
}
